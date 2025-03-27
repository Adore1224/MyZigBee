/**************************************************************************************
  Filename:       User4G.c
  Revised:      $Date:  2024-9-6     
  Written By WPC
  此文件存放用户使用串口0实现和4G模块进行串口通信相关的参数或函数本体
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "User4G.h"

/************************************GLOBAL VARIABLES*********************************/
halUARTCfg_t User4GConfig; 

/****************************************MACROS***************************************/
#define   HAL_UART_MAX_BUFFSIZE         256

/**************************************FUNCTIONS**************************************/
/*
*uart初始化
*@param   none
*@return  none
*/
void User4G_Init(void)
{
  //串口0配置
  User4GConfig.configured           = TRUE;
  User4GConfig.flowControl          = FALSE;
  User4GConfig.baudRate             = HAL_UART_BR_115200;
  User4GConfig.rx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  User4GConfig.tx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  User4GConfig.idleTimeout          = 6;
  User4GConfig.intEnable            = TRUE;
  User4GConfig.callBackFunc         = User4G_Receive_CB;
  //打开串口0
  HalUARTOpen(HAL_UART_PORT_0, &User4GConfig);//打开串口
}

/*
*向串口发送消息
*@param   payload 数据内容
*@param   size 数据大小
*@return  none
*/
void User4G_Send(const uint8 *payload, uint16 size)
{
  HalUARTWrite(HAL_UART_PORT_0, (uint8 *)payload, size);
}

/*
*串口接收消息的回调函数
*@param   port 串口号
*@param   event 事件
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