/**************************************************************************************
  Filename:       UserApp.c
  Revised:      $Date:  2024-9-6     
  Written By WPC
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "UserApp.h"

/****************************************MACROS***************************************/

/***************************************CONSTANS**************************************/
const char* info0 = "Zb Receive";
const char* info1 = "Zb Send";
const char* info4 = "update OK";
const char* info5 = "report OK";
/***************************************TYPEDEFS**************************************/

/************************************GLOBAL VARIABLES*********************************/
//����û����������õ�cluster���б�
const cId_t UserApp_ClusterList[USERAPP_MAX_CLUSTERS] =
{
  USERAPP_TRANSCLU,
  USERAPP_UPDATECLU,
  USERAPP_REPORTCLU
};
//����û�Ӧ�õļ�������
const SimpleDescriptionFormat_t UserApp_SimpleDesc =
{
  USERAPP_ENDPOINT,              //  int Endpoint;
  USERAPP_PROFID,                //  uint16 AppProfId[2];
  USERAPP_DEVICEID,              //  uint16 AppDeviceId[2];
  USERAPP_DEVICE_VERSION,        //  int   AppDevVer:4;
  USERAPP_FLAGS,                 //  int   AppFlags:4;
  USERAPP_MAX_CLUSTERS,          //  uint8  AppNumInClusters;
  (cId_t *)UserApp_ClusterList,  //  uint8 *pAppInClusterList;
  USERAPP_MAX_CLUSTERS,          //  uint8  AppNumInClusters;
  (cId_t *)UserApp_ClusterList   //  uint8 *pAppInClusterList;
};
//����û�Ӧ�õĶ˵�������
endPointDesc_t UserApp_epDesc =
{
  USERAPP_ENDPOINT,
  &UserApp_TaskID,
  (SimpleDescriptionFormat_t *)&UserApp_SimpleDesc,
  noLatencyReqs
};
/**********************************EXTERNAL VARIABLES*********************************/

/**********************************EXTERNAL FUNCTIONS*********************************/

/************************************LOCAL VARIABLES**********************************/
uint8 UserApp_TaskID;   
devStates_t UserApp_NwkState;
uint8 UserApp_TransID;  

afAddrType_t UserBroadC_DstAddr;
afAddrType_t UserGroup_DstAddr;
afAddrType_t UserP2P_DstAddr;
afAddrType_t UserED_DstAddr;

aps_Group_t UserApp_Group;
/************************************LOCAL FUNCTIONS**********************************/
void UserApp_HandleKeys( uint8 shift, uint8 keys );
void UserApp_MessageMSGCB( afIncomingMSGPacket_t *pckt );
void UserApp_SendBroadCMessage( uint16 len, uint8 *buf );
void UserApp_SendGroupMessage( uint16 len, uint8 *buf );
void UpdateNetwork( uint16 pan, uint8 chan );
void UserApp_SendEDMessage( uint16 len, uint8 *buf );
void ReportNetworkInfo(uint8 *pkt);
/***********************************PUBLIC FUNCTIONS**********************************/
/*
*Ӧ�ò��û������ʼ������
*@param   task_id �û�Ӧ����ϵͳ�е������
*@return  none
*/
void UserApp_Init( uint8 task_id )
{
  UserApp_TaskID = task_id;//ע���û�����
  UserApp_NwkState = DEV_INIT;//�豸״̬Ĭ��Ϊ�豸��ʼ��
  UserApp_TransID = 0;//�������г�ʼΪ0
  //��ʼ���豸�������
  DevNwkInit();
  //��ʼ�����䷽ʽ
  TransModeAddrInit();  
  //��ʼ���û�����
  UserUSB_Init();
  if(ZG_DEVICE_COORDINATOR_TYPE)//Э����  
    User4G_Init();//4Gģ���ʼ��
  else if(ZG_DEVICE_ENDDEVICE_TYPE)//�ն�   
    UserRS485_Init();//RS485��ʼ��
  //�����鲥ͨ�ŵ���
  UserApp_Group.ID = 0x0001;
  osal_memcpy( UserApp_Group.name, "Group 1", 7  );
  aps_AddGroup( USERAPP_ENDPOINT, &UserApp_Group ); 
  //���㲥��Ϣ��Ŀ�����
  UserBroadC_DstAddr.addrMode = (afAddrMode_t)AddrBroadcast;
  UserBroadC_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserBroadC_DstAddr.addr.shortAddr = 0xFFFF;
  //����鲥��Ϣ��Ŀ�����
  UserGroup_DstAddr.addrMode = (afAddrMode_t)AddrGroup;
  UserGroup_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserGroup_DstAddr.addr.shortAddr = 0x0001;
  //��䵥����Ϣ��Ŀ�����(ed/ro -> coord) 
  UserED_DstAddr.addrMode = (afAddrMode_t)Addr16Bit;
  UserED_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserED_DstAddr.addr.shortAddr = 0x0000;
  //ע��˵���������ʹ����AF����Ч��ʵ�����ߴ���
  afRegister( &UserApp_epDesc );
  //ע�ᰴ�������¼����Ա���Ӧ�ò�ֱ��ʹ�ð�������
  RegisterForKeys( UserApp_TaskID );
  //��ʱ�����ڵ���Ϣ�ϱ��¼�
  osal_start_timerEx(UserApp_TaskID, INFO_REPORT_EVT, INFO_REPORT_PERIOD);
  //ֻ���ն˲��������������ݲ�ѯ�¼�
  if(ZG_DEVICE_ENDDEVICE_TYPE)
    StartSensorQuery();
}

/*
*�û���������
*@param   task_id �û�Ӧ����ϵͳ�е������
*@param   events  Ӧ����ص��¼�
*@return  ��ɴ������¼��б�
*/
uint16 UserApp_ProcessEvent( uint8 task_id, uint16 events )
{  
  afIncomingMSGPacket_t *MSGpkt;  
  (void)task_id;  //δʹ�ò���
  if ( events & SYS_EVENT_MSG )//ϵͳ�¼�
  {
    MSGpkt = (afIncomingMSGPacket_t *)osal_msg_receive( UserApp_TaskID );
    while ( MSGpkt )
    {
      switch ( MSGpkt->hdr.event )
      {       
        case AF_INCOMING_MSG_CMD://���յ�AF���������Ϣ
          UserApp_MessageMSGCB( MSGpkt );
          break;
        case KEY_CHANGE://��⵽�����ı仯
          UserApp_HandleKeys( ((keyChange_t *)MSGpkt)->state, ((keyChange_t *)MSGpkt)->keys );
          break;
        case ZDO_STATE_CHANGE://�豸״̬���͸ı�
        {
          UserApp_NwkState = (devStates_t)(MSGpkt->hdr.status);
          if ( UserApp_NwkState == DEV_ZB_COORD )          
          {
            
          }
          else{}
        } break;
        default: break;
      }
      osal_msg_deallocate( (uint8 *)MSGpkt );//�ͷ��ڴ�
      MSGpkt = (afIncomingMSGPacket_t *)osal_msg_receive( UserApp_TaskID );
    }
    return ( events ^ SYS_EVENT_MSG );//����δ�����¼�
  }
  
  if( events & SOIL_SENSOR_QUERY )//����������������ѯ�¼�������5s/��
  {
    uint8 soilSensor[] = {0x01, 0x03, 0x00, 0x00 ,0x00, 0x04, 0x44, 0x09};      
    UserRS485_Send(soilSensor, 8);  
    osal_start_timerEx(UserApp_TaskID, SOIL_SENSOR_QUERY, SENSOR_QUERY_PERIOD);
    return ( events ^ SOIL_SENSOR_QUERY );
  }
  
  if( events & LIGTH_SENSOR_QUERY )//�����¶ȴ�������ѯ�¼�������5s/��
  {
    uint8 ligTHSensor[] = {0x02, 0x03, 0x00, 0x00 ,0x00, 0x07, 0x04, 0x3B}; 
    UserRS485_Send(ligTHSensor, 8); 
    osal_start_timerEx(UserApp_TaskID, LIGTH_SENSOR_QUERY, SENSOR_QUERY_PERIOD);
    return ( events ^ LIGTH_SENSOR_QUERY );
  }
  
  if( events & CO2_SENSOR_QUERY )//������̼Ũ�ȴ�������ѯ�¼�������5s/��
  {
    uint8 co2Sensor[] = {0x03, 0x03, 0x00, 0x02 ,0x00, 0x01, 0x24, 0x28};
    UserRS485_Send(co2Sensor, 8);
    osal_start_timerEx(UserApp_TaskID, CO2_SENSOR_QUERY, SENSOR_QUERY_PERIOD);
    return ( events ^ CO2_SENSOR_QUERY );
  }
  
  if( events & REJOIN_NETWORK_EVT )//���������¼�
  {
    SystemResetSoft();
    return ( events ^ REJOIN_NETWORK_EVT );
  }
  
  if ( events & INFO_REPORT_EVT )//��Ϣ�ϱ��¼�������5s/��
  {
    uint8 *pktT = PrepareDeviceInfo();
    if(ZG_DEVICE_COORDINATOR_TYPE)//Э����
    {
      UserUSB_Send(pktT, 20);
    }
    else//�����ڵ��豸
    {
      ReportNetworkInfo(pktT);
    }  
    osal_start_timerEx(UserApp_TaskID, INFO_REPORT_EVT, INFO_REPORT_PERIOD);
    return ( events ^ INFO_REPORT_EVT );
  }      
  
  return 0;//����δ������¼����¼���UserApp.h�ж���
}

/*
*�û�������������
*@param   shift �ò���������δʹ��
*@param   keys  ���ð����ı��
*@return  none
*/
void UserApp_HandleKeys( uint8 shift, uint8 keys )
{
  (void)shift;  //δʹ�ò��� 
  if(keys & HAL_KEY_SW_6)//sw6������
  {
    // none
  }
}

/*
*�������ݽ��մ�����
*@param   *pkt AF�㴫����������ݰ�
*@return  none
*/
void UserApp_MessageMSGCB( afIncomingMSGPacket_t *pkt )
{
  uint8 userData[32];  
  switch ( pkt->clusterId )
  {
    case USERAPP_TRANSCLU://�û�Ӧ�ô�
    {     
      if( transFlag )//�����͸��+��ַ�Ĵ��䷽ʽ
      {
        uint8 userDataLen = pkt->cmd.DataLength - 1;//���ݰ���ȥ1λ��ַ�õ��û�ʵ�����ݳ���
        osal_memcpy(userData, pkt->cmd.Data, userDataLen);//��ȡ�û�ʵ������
        uint8 addr[1];//���������ݰ�ĩβ�ĵ�ַ����
        //ָ��ƫ��ʵ�����ݳ��Ⱥ�õ���ַ���ݵ��׵�ַ
        osal_memcpy(addr, pkt->cmd.Data + userDataLen, 1);
        UserUSB_Send(userData, userDataLen);//���ڷ����û�ʵ������
        UserUSB_Send(addr, 1);//���ڷ��͵�ַ����       
      }
      else
      {      
        osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//��ȡ�û�����        
        UserUSB_Send(userData,pkt->cmd.DataLength);//���ڷ��͸���λ��/��������
      }
    } break;
    case USERAPP_UPDATECLU://��Ϣ���´�
    {
      osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//��ȡ��Ϣ����
      uint16 newPanId = (uint16)userData[0]<<8|userData[1];//�ϲ������
      uint8 newChannel = userData[2];
      osal_nv_write(ZCD_NV_PANID, 0, 2, &newPanId);//д��NV������λ���ʼ��ʱ��ȡ
      osal_nv_write(ZCD_NV_CHANLIST, 0, 1, &newChannel);
      //��ʱʱ�䵽�������һ�������¼�����λ�豸�����豸���³�ʼ������������
      osal_start_timerEx(UserApp_TaskID, REJOIN_NETWORK_EVT, REJOIN_NETWORK_PERIOD);
    } break; 
    case USERAPP_CONFIGCLU://����Զ�����ô�
    {
      osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//��ȡ��������
      SwitchDevType(userData[1]);
      ChangeUartBaudRate(userData[2]);
      //��ʱ����
      Delay_ms(3);//3ms
      SystemResetSoft();//ϵͳ������
    } break;
    case USERAPP_REPORTCLU: //������Ϣ�ϴ���
    {
      osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//��ȡ�û�����      
      UserUSB_Send(userData,pkt->cmd.DataLength);//���ڷ����û�����
    } break;  
  }
}

/*
*��������Э�����㲥���ͺ���
*@param   len ���ݳ���
*@param   *buf �������ڵ�ַ
*@return  none
*/
void UserApp_SendBroadCMessage( uint16 len, uint8 *buf )
{
  if ( AF_DataRequest( &UserBroadC_DstAddr, &UserApp_epDesc,
                       USERAPP_TRANSCLU,
                       len,
                       buf,
                       &UserApp_TransID,
                       AF_DISCV_ROUTE, AF_DEFAULT_RADIUS ) == afStatus_SUCCESS )
  {
    //HalLcdWriteString((char*)info1,3);//��ʾ�ѷ���
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*��������Э�����鲥���ͺ���
*@param   len ���ݳ���
*@param   *buf �������ڵ�ַ
*@return  none
*/
void UserApp_SendGroupMessage( uint16 len, uint8 *buf )
{
  if ( AF_DataRequest( &UserGroup_DstAddr, &UserApp_epDesc,
                       USERAPP_TRANSCLU,
                       len,
                       buf,
                       &UserApp_TransID,
                       AF_DISCV_ROUTE, AF_DEFAULT_RADIUS ) == afStatus_SUCCESS )
  {
    //HalLcdWriteString((char*)info1,3);//��ʾ�ѷ���
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*��������Э�����������ͺ���
*@param   reShortAddr Ŀ��ڵ�̵�ַ
*@param   len ���ݳ���
*@param   *buf �������ڵ�ַ
*@return  none
*/
void UserApp_SendP2PMessage( uint16 reShortAddr, uint16 len, uint8 *buf )
{
  UserP2P_DstAddr.addrMode = (afAddrMode_t)Addr16Bit;
  UserP2P_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserP2P_DstAddr.addr.shortAddr = reShortAddr;
  if ( AF_DataRequest( &UserP2P_DstAddr, &UserApp_epDesc,
                       USERAPP_CONFIGCLU,
                       len,
                       buf,
                       &UserApp_TransID,
                       AF_DISCV_ROUTE, AF_DEFAULT_RADIUS ) == afStatus_SUCCESS )
  {
    //HalLcdWriteString((char*)info1,3);//��ʾ�ѷ���
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*Э����֪ͨ���ڽڵ���²���������Ϣ����
*@param   pan �ı�������
*@param   chan �ı���ŵ�
*@return  none
*/
void UpdateNetwork( uint16 pan, uint8 chan )
{
  uint8 msg[3];
  msg[0]=(uint8)(pan >> 8);
  msg[1]=(uint8)(pan & 0xFF);
  msg[2]=chan;
  if ( AF_DataRequest( &UserGroup_DstAddr, &UserApp_epDesc,
                       USERAPP_UPDATECLU,
                       3,
                       msg,
                       &UserApp_TransID,
                       0, AF_DEFAULT_RADIUS ) == afStatus_SUCCESS )
  {
    //HalLcdWriteString((char*)info4,3);//��ʾ�ѷ���;
  }
}

/*
*���������ն˷��ͺ���
*@param   len ���ݳ���
*@param   *buf �������ڵ�ַ
*@return  none
*/
void UserApp_SendEDMessage( uint16 len, uint8 *buf )
{
  if ( AF_DataRequest( &UserED_DstAddr, &UserApp_epDesc,
                       USERAPP_TRANSCLU,
                       len,
                       buf,
                       &UserApp_TransID,
                       AF_DISCV_ROUTE, AF_DEFAULT_RADIUS ) == afStatus_SUCCESS )
  {
    //HalLcdWriteString((char*)info1,3);//��ʾ�ѷ���
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*�����ڽڵ���Э�����ϱ�������Ϣ����
*@param   *pkt �洢������ݰ��ĵ�ַ
*@return  none
*/
void ReportNetworkInfo(uint8 *pkt)
{
  if ( AF_DataRequest( &UserED_DstAddr, &UserApp_epDesc,
                       USERAPP_REPORTCLU,
                       20,
                       pkt,
                       &UserApp_TransID,
                       AF_DISCV_ROUTE, AF_DEFAULT_RADIUS ) == afStatus_SUCCESS )
  {
    //HalLcdWriteString((char*)info5,3);//��ʾ�ѷ���
  }
}
/****************************************End******************************************/
