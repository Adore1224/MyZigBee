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
//填充用户任务中所用的cluster簇列表
const cId_t UserApp_ClusterList[USERAPP_MAX_CLUSTERS] =
{
  USERAPP_TRANSCLU,
  USERAPP_UPDATECLU,
  USERAPP_REPORTCLU
};
//填充用户应用的简单描述符
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
//填充用户应用的端点描述符
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
*应用层用户任务初始化函数
*@param   task_id 用户应用在系统中的任务号
*@return  none
*/
void UserApp_Init( uint8 task_id )
{
  UserApp_TaskID = task_id;//注册用户任务
  UserApp_NwkState = DEV_INIT;//设备状态默认为设备初始化
  UserApp_TransID = 0;//传输序列初始为0
  //初始化设备网络参数
  DevNwkInit();
  //初始化传输方式
  TransModeAddrInit();  
  //初始化用户串口
  UserUSB_Init();
  if(ZG_DEVICE_COORDINATOR_TYPE)//协调器  
    User4G_Init();//4G模块初始化
  else if(ZG_DEVICE_ENDDEVICE_TYPE)//终端   
    UserRS485_Init();//RS485初始化
  //定义组播通信的组
  UserApp_Group.ID = 0x0001;
  osal_memcpy( UserApp_Group.name, "Group 1", 7  );
  aps_AddGroup( USERAPP_ENDPOINT, &UserApp_Group ); 
  //填充广播消息的目标参数
  UserBroadC_DstAddr.addrMode = (afAddrMode_t)AddrBroadcast;
  UserBroadC_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserBroadC_DstAddr.addr.shortAddr = 0xFFFF;
  //填充组播消息的目标参数
  UserGroup_DstAddr.addrMode = (afAddrMode_t)AddrGroup;
  UserGroup_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserGroup_DstAddr.addr.shortAddr = 0x0001;
  //填充单播消息的目标参数(ed/ro -> coord) 
  UserED_DstAddr.addrMode = (afAddrMode_t)Addr16Bit;
  UserED_DstAddr.endPoint = USERAPP_ENDPOINT;
  UserED_DstAddr.addr.shortAddr = 0x0000;
  //注册端点描述符，使其在AF层有效以实现无线传输
  afRegister( &UserApp_epDesc );
  //注册按键功能事件，以便在应用层直接使用按键操作
  RegisterForKeys( UserApp_TaskID );
  //定时启动节点信息上报事件
  osal_start_timerEx(UserApp_TaskID, INFO_REPORT_EVT, INFO_REPORT_PERIOD);
  //只有终端才启动传感器数据查询事件
  if(ZG_DEVICE_ENDDEVICE_TYPE)
    StartSensorQuery();
}

/*
*用户任务处理函数
*@param   task_id 用户应用在系统中的任务号
*@param   events  应用相关的事件
*@return  完成处理后的事件列表
*/
uint16 UserApp_ProcessEvent( uint8 task_id, uint16 events )
{  
  afIncomingMSGPacket_t *MSGpkt;  
  (void)task_id;  //未使用参数
  if ( events & SYS_EVENT_MSG )//系统事件
  {
    MSGpkt = (afIncomingMSGPacket_t *)osal_msg_receive( UserApp_TaskID );
    while ( MSGpkt )
    {
      switch ( MSGpkt->hdr.event )
      {       
        case AF_INCOMING_MSG_CMD://接收到AF层的无线消息
          UserApp_MessageMSGCB( MSGpkt );
          break;
        case KEY_CHANGE://检测到按键的变化
          UserApp_HandleKeys( ((keyChange_t *)MSGpkt)->state, ((keyChange_t *)MSGpkt)->keys );
          break;
        case ZDO_STATE_CHANGE://设备状态发送改变
        {
          UserApp_NwkState = (devStates_t)(MSGpkt->hdr.status);
          if ( UserApp_NwkState == DEV_ZB_COORD )          
          {
            
          }
          else{}
        } break;
        default: break;
      }
      osal_msg_deallocate( (uint8 *)MSGpkt );//释放内存
      MSGpkt = (afIncomingMSGPacket_t *)osal_msg_receive( UserApp_TaskID );
    }
    return ( events ^ SYS_EVENT_MSG );//返回未处理事件
  }
  
  if( events & SOIL_SENSOR_QUERY )//土壤参数传感器查询事件，周期5s/次
  {
    uint8 soilSensor[] = {0x01, 0x03, 0x00, 0x00 ,0x00, 0x04, 0x44, 0x09};      
    UserRS485_Send(soilSensor, 8);  
    osal_start_timerEx(UserApp_TaskID, SOIL_SENSOR_QUERY, SENSOR_QUERY_PERIOD);
    return ( events ^ SOIL_SENSOR_QUERY );
  }
  
  if( events & LIGTH_SENSOR_QUERY )//光照温度传感器查询事件，周期5s/次
  {
    uint8 ligTHSensor[] = {0x02, 0x03, 0x00, 0x00 ,0x00, 0x07, 0x04, 0x3B}; 
    UserRS485_Send(ligTHSensor, 8); 
    osal_start_timerEx(UserApp_TaskID, LIGTH_SENSOR_QUERY, SENSOR_QUERY_PERIOD);
    return ( events ^ LIGTH_SENSOR_QUERY );
  }
  
  if( events & CO2_SENSOR_QUERY )//二氧化碳浓度传感器查询事件，周期5s/次
  {
    uint8 co2Sensor[] = {0x03, 0x03, 0x00, 0x02 ,0x00, 0x01, 0x24, 0x28};
    UserRS485_Send(co2Sensor, 8);
    osal_start_timerEx(UserApp_TaskID, CO2_SENSOR_QUERY, SENSOR_QUERY_PERIOD);
    return ( events ^ CO2_SENSOR_QUERY );
  }
  
  if( events & REJOIN_NETWORK_EVT )//重新入网事件
  {
    SystemResetSoft();
    return ( events ^ REJOIN_NETWORK_EVT );
  }
  
  if ( events & INFO_REPORT_EVT )//信息上报事件，周期5s/次
  {
    uint8 *pktT = PrepareDeviceInfo();
    if(ZG_DEVICE_COORDINATOR_TYPE)//协调器
    {
      UserUSB_Send(pktT, 20);
    }
    else//其他节点设备
    {
      ReportNetworkInfo(pktT);
    }  
    osal_start_timerEx(UserApp_TaskID, INFO_REPORT_EVT, INFO_REPORT_PERIOD);
    return ( events ^ INFO_REPORT_EVT );
  }      
  
  return 0;//丢弃未定义的事件，事件在UserApp.h中定义
}

/*
*用户按键任务处理函数
*@param   shift 该参数函数中未使用
*@param   keys  所用按键的标号
*@return  none
*/
void UserApp_HandleKeys( uint8 shift, uint8 keys )
{
  (void)shift;  //未使用参数 
  if(keys & HAL_KEY_SW_6)//sw6被按下
  {
    // none
  }
}

/*
*无线数据接收处理函数
*@param   *pkt AF层传输的无线数据包
*@return  none
*/
void UserApp_MessageMSGCB( afIncomingMSGPacket_t *pkt )
{
  uint8 userData[32];  
  switch ( pkt->clusterId )
  {
    case USERAPP_TRANSCLU://用户应用簇
    {     
      if( transFlag )//如果是透传+地址的传输方式
      {
        uint8 userDataLen = pkt->cmd.DataLength - 1;//数据包减去1位地址得到用户实际数据长度
        osal_memcpy(userData, pkt->cmd.Data, userDataLen);//提取用户实际数据
        uint8 addr[1];//解析出数据包末尾的地址数据
        //指针偏移实际数据长度后得到地址数据的首地址
        osal_memcpy(addr, pkt->cmd.Data + userDataLen, 1);
        UserUSB_Send(userData, userDataLen);//串口发送用户实际数据
        UserUSB_Send(addr, 1);//串口发送地址数据       
      }
      else
      {      
        osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//提取用户数据        
        UserUSB_Send(userData,pkt->cmd.DataLength);//串口发送给上位机/串口助手
      }
    } break;
    case USERAPP_UPDATECLU://信息更新簇
    {
      osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//提取信息数据
      uint16 newPanId = (uint16)userData[0]<<8|userData[1];//合并网络号
      uint8 newChannel = userData[2];
      osal_nv_write(ZCD_NV_PANID, 0, 2, &newPanId);//写入NV，待复位后初始化时读取
      osal_nv_write(ZCD_NV_CHANLIST, 0, 1, &newChannel);
      //定时时间到后就启动一个入网事件，复位设备，让设备重新初始化加入新网络
      osal_start_timerEx(UserApp_TaskID, REJOIN_NETWORK_EVT, REJOIN_NETWORK_PERIOD);
    } break; 
    case USERAPP_CONFIGCLU://参数远程配置簇
    {
      osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//提取参数数据
      SwitchDevType(userData[1]);
      ChangeUartBaudRate(userData[2]);
      //延时重启
      Delay_ms(3);//3ms
      SystemResetSoft();//系统软重启
    } break;
    case USERAPP_REPORTCLU: //拓扑信息上传簇
    {
      osal_memcpy(userData, pkt->cmd.Data, pkt->cmd.DataLength);//提取用户数据      
      UserUSB_Send(userData,pkt->cmd.DataLength);//串口发送用户数据
    } break;  
  }
}

/*
*无线数据协调器广播发送函数
*@param   len 数据长度
*@param   *buf 数据所在地址
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
    //HalLcdWriteString((char*)info1,3);//提示已发送
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*无线数据协调器组播发送函数
*@param   len 数据长度
*@param   *buf 数据所在地址
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
    //HalLcdWriteString((char*)info1,3);//提示已发送
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*无线数据协调器单播发送函数
*@param   reShortAddr 目标节点短地址
*@param   len 数据长度
*@param   *buf 数据所在地址
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
    //HalLcdWriteString((char*)info1,3);//提示已发送
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*协调器通知网内节点更新部分网络信息函数
*@param   pan 改变的网络号
*@param   chan 改变的信道
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
    //HalLcdWriteString((char*)info4,3);//提示已发送;
  }
}

/*
*无线数据终端发送函数
*@param   len 数据长度
*@param   *buf 数据所在地址
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
    //HalLcdWriteString((char*)info1,3);//提示已发送
  }
  else
  {
    // Error occurred in request to send.
  }
}

/*
*网络内节点向协调器上报网络信息函数
*@param   *pkt 存储相关数据包的地址
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
    //HalLcdWriteString((char*)info5,3);//提示已发送
  }
}
/****************************************End******************************************/
