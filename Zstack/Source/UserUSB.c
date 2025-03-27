/**************************************************************************************
  Filename:       UserUSB.c
  Revised:      $Date:  2024-9-6     
  Written By WPC
  ���ļ�����û�ʹ�ô���1ʵ��USBͨ����صĲ�����������
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "UserUSB.h"

/************************************GLOBAL VARIABLES*********************************/
halUARTCfg_t UserUSBConfig;

/****************************************MACROS***************************************/
#define   HAL_UART_MAX_BUFFSIZE         256

/**************************************FUNCTIONS**************************************/
/*
*uart��ʼ��
*@param   none
*@return  none
*/
void UserUSB_Init(void)
{
  //����1����
  UserUSBConfig.configured           = TRUE;
  UserUSBConfig.flowControl          = FALSE;
  UserUSBConfig.baudRate             = HAL_UART_BR_115200;
  UserUSBConfig.rx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserUSBConfig.tx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserUSBConfig.idleTimeout          = 6;
  UserUSBConfig.intEnable            = TRUE;
  UserUSBConfig.callBackFunc         = UserUSB_Receive_CB;
  //�򿪴���1
  HalUARTOpen(HAL_UART_PORT_1, &UserUSBConfig);//�򿪴���
}

/*
*�򴮿ڷ�����Ϣ
*@param   payload ��������
*@param   size ���ݴ�С
*@return  none
*/
void UserUSB_Send(const uint8 *payload, uint16 size)
{
  HalUARTWrite(HAL_UART_PORT_1, (uint8 *)payload, size);
}

/*
*���ڽ�����Ϣ�Ļص�����
*@param   port ���ں�
*@param   event �¼�
*@return  none
*/
void UserUSB_Receive_CB(uint8 port, uint8 event)
{
  switch(event)
  {
    case HAL_UART_RX_FULL:
    case HAL_UART_RX_ABOUT_FULL:
    case HAL_UART_RX_TIMEOUT:
    {
      uint8 rxBuf[HAL_UART_MAX_BUFFSIZE] = {0};      
      int16 rxBufLen = Hal_UART_RxBufLen(HAL_UART_PORT_1);          
      if(rxBuf!=NULL)
      {
        HalUARTRead(HAL_UART_PORT_1, rxBuf, rxBufLen);
        uint8 start = rxBuf[0]; //��ȡ֡ͷ
        //�����λ��ʹ�õĹ��������ʽ��AA 03 FF FE 0B 8B 00 D5 02 E2
        if(start!=0xAA) //֡ͷ֡β�����ϣ�ִ�й��ܴ���
        {
           switch(start){
           case 0xAB: //��ѯ�豸��Ϣ
             QueryDeviceInfo(); break;
           case 0xAC: //�������豸
             SoftResetDevice(); break;
           case 0xEA: //���͵�Ե�Զ�����ò���            
             UserApp_SendP2PMessage((uint16)rxBuf[3]<<8|rxBuf[4],rxBufLen,rxBuf);break;
           default: //Ĭ������͸��
             DataTrans(rxBufLen, rxBuf); break;
           }
        }
        else //ִ��zigbee�����趨��ش���
        {
          //�豸�����л�
          SwitchDevType(rxBuf[1]);
          //����ID���ŵ�����
          SetPanId_Channel((uint16)rxBuf[2]<<8|rxBuf[3], rxBuf[4]);
          //���䷽ʽ�л�
          SwitchTransMode(rxBuf[5], rxBuf[6]);
          //���书���޸�
          SetTxPower(rxBuf[7]);
          //���ڲ������޸�
          ChangeUartBaudRate(rxBuf[8]);
          //��������ģ���
          BindSensorDev(rxBuf[9]);//�ܼ�10���ֽ�
        } 
      }
    }
    break;     
    default: break;
  }
}
/****************************************End******************************************/