/**************************************************************************************
  Filename:       User4G.c
  Revised:      $Date:  2024-9-6     
  Written By WPC
  ���ļ�����û�ʹ�ô���0ʵ�ֺ�4Gģ����д���ͨ����صĲ�����������
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "User4G.h"

/************************************GLOBAL VARIABLES*********************************/
halUARTCfg_t User4GConfig; 

/****************************************MACROS***************************************/
#define   HAL_UART_MAX_BUFFSIZE         256

/**************************************FUNCTIONS**************************************/
/*
*uart��ʼ��
*@param   none
*@return  none
*/
void User4G_Init(void)
{
  //����0����
  User4GConfig.configured           = TRUE;
  User4GConfig.flowControl          = FALSE;
  User4GConfig.baudRate             = HAL_UART_BR_115200;
  User4GConfig.rx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  User4GConfig.tx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  User4GConfig.idleTimeout          = 6;
  User4GConfig.intEnable            = TRUE;
  User4GConfig.callBackFunc         = User4G_Receive_CB;
  //�򿪴���0
  HalUARTOpen(HAL_UART_PORT_0, &User4GConfig);//�򿪴���
}

/*
*�򴮿ڷ�����Ϣ
*@param   payload ��������
*@param   size ���ݴ�С
*@return  none
*/
void User4G_Send(const uint8 *payload, uint16 size)
{
  HalUARTWrite(HAL_UART_PORT_0, (uint8 *)payload, size);
}

/*
*���ڽ�����Ϣ�Ļص�����
*@param   port ���ں�
*@param   event �¼�
*@return  none
*/
void User4G_Receive_CB(uint8 port, uint8 event)
{
  switch(event)
  {
    case HAL_UART_RX_FULL:
    case HAL_UART_RX_ABOUT_FULL:
    case HAL_UART_RX_TIMEOUT:
    {
      uint8 rxBuf[HAL_UART_MAX_BUFFSIZE] = {0};      
      int16 rxBufLen = Hal_UART_RxBufLen(HAL_UART_PORT_0);          
      if(rxBuf!=NULL)
      {
        HalUARTRead(HAL_UART_PORT_0, rxBuf, rxBufLen);
        return;
      }
    }
    break;     
    default: break;
  }
}
/****************************************End******************************************/