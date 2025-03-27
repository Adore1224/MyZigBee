/**************************************************************************************
  Filename:       UserUart.c
  Revised:      $Date:  2024-9-6    
  Written By WPC
  此文件存放用户使用串口0实现RS485通信相关的参数或函数本体
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "UserRS485.h"

/************************************GLOBAL VARIABLES*********************************/
halUARTCfg_t UserRS485Config;

/****************************************MACROS***************************************/
#define   HAL_UART_MAX_BUFFSIZE         128
#define   RS485_DE_PIN                  P1_0  //定义485通信的控制引脚

/**************************************FUNCTIONS**************************************/
/*
*uart初始化
*@param   none
*@return  none
*/
void UserRS485_Init(void)
{
  //串口0配置
  UserRS485Config.configured           = TRUE;
  UserRS485Config.flowControl          = FALSE;
  UserRS485Config.rx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserRS485Config.tx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserRS485Config.idleTimeout          = 6;
  UserRS485Config.intEnable            = TRUE;
  UserRS485Config.callBackFunc         = UserRS485_Receive_CB;
  //动态获取串口波特率并打开串口0
  GetBaud_OpenUart();   
  //配置GPIO引脚用于控制DE引脚
  P1DIR |= BV(0); //配置P1.0输出
  RS485_DE_PIN = 0; //初始方向设置为接收
}

/*
*向串口发送消息
*@param   payload 数据内容
*@param   size 数据大小
*@return  none
*/
void UserRS485_Send(const uint8 *payload, uint16 size)
{
  RS485_DE_PIN = 1;//发送模式
  HalUARTWrite(HAL_UART_PORT_0, (uint8 *)payload, size);
}

/*
*串口接收消息的回调函数
*@param   port 串口号
*@param   event 事件
*@return  none
*/
void UserRS485_Receive_CB(uint8 port, uint8 event)
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
        uint8 start = rxBuf[0]; //获取帧头
        //根据不同的帧头来判断数据来源于哪个传感器
        switch(start){
        case 0x01: //土壤参数传感器数据处理
          ProcSoilSensor(rxBuf); break;
        case 0x02: //光照温湿度传感器数据处理
          ProcLigTHSensor(rxBuf); break;
        case 0x03: //二氧化碳浓度传感器数据处理
          ProcCo2Sensor(rxBuf); break;        
        default: break;  
        }
      }
    }
    break;     
    default: break;
  }
}
/****************************************End******************************************/