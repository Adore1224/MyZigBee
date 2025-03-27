/**************************************************************************************
  Filename:       UserUSB.c
  Revised:      $Date:  2024-9-6     
  Written By WPC
  此文件存放用户使用串口1实现USB通信相关的参数或函数本体
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "UserUSB.h"

/************************************GLOBAL VARIABLES*********************************/
halUARTCfg_t UserUSBConfig;

/****************************************MACROS***************************************/
#define   HAL_UART_MAX_BUFFSIZE         256

/**************************************FUNCTIONS**************************************/
/*
*uart初始化
*@param   none
*@return  none
*/
void UserUSB_Init(void)
{
  //串口1配置
  UserUSBConfig.configured           = TRUE;
  UserUSBConfig.flowControl          = FALSE;
  UserUSBConfig.baudRate             = HAL_UART_BR_115200;
  UserUSBConfig.rx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserUSBConfig.tx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserUSBConfig.idleTimeout          = 6;
  UserUSBConfig.intEnable            = TRUE;
  UserUSBConfig.callBackFunc         = UserUSB_Receive_CB;
  //打开串口1
  HalUARTOpen(HAL_UART_PORT_1, &UserUSBConfig);//打开串口
}

/*
*向串口发送消息
*@param   payload 数据内容
*@param   size 数据大小
*@return  none
*/
void UserUSB_Send(const uint8 *payload, uint16 size)
{
  HalUARTWrite(HAL_UART_PORT_1, (uint8 *)payload, size);
}

/*
*串口接收消息的回调函数
*@param   port 串口号
*@param   event 事件
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
        uint8 start = rxBuf[0]; //获取帧头
        //配合上位机使用的功能命令，格式：AA 03 FF FE 0B 8B 00 D5 02 E2
        if(start!=0xAA) //帧头帧尾不符合，执行功能代码
        {
           switch(start){
           case 0xAB: //查询设备信息
             QueryDeviceInfo(); break;
           case 0xAC: //软重启设备
             SoftResetDevice(); break;
           case 0xEA: //发送点对点远程配置参数            
             UserApp_SendP2PMessage((uint16)rxBuf[3]<<8|rxBuf[4],rxBufLen,rxBuf);break;
           default: //默认数据透传
             DataTrans(rxBufLen, rxBuf); break;
           }
        }
        else //执行zigbee参数设定相关代码
        {
          //设备类型切换
          SwitchDevType(rxBuf[1]);
          //网络ID和信道设置
          SetPanId_Channel((uint16)rxBuf[2]<<8|rxBuf[3], rxBuf[4]);
          //传输方式切换
          SwitchTransMode(rxBuf[5], rxBuf[6]);
          //发射功率修改
          SetTxPower(rxBuf[7]);
          //串口波特率修改
          ChangeUartBaudRate(rxBuf[8]);
          //传感器与模块绑定
          BindSensorDev(rxBuf[9]);//总计10个字节
        } 
      }
    }
    break;     
    default: break;
  }
}
/****************************************End******************************************/