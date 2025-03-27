/**************************************************************************************
  Filename:       UserUart.c
  Revised:      $Date:  2024-9-6    
  Written By WPC
  ���ļ�����û�ʹ�ô���0ʵ��RS485ͨ����صĲ�����������
**************************************************************************************/

/***************************************INCLUDES**************************************/
#include "UserRS485.h"

/************************************GLOBAL VARIABLES*********************************/
halUARTCfg_t UserRS485Config;

/****************************************MACROS***************************************/
#define   HAL_UART_MAX_BUFFSIZE         128
#define   RS485_DE_PIN                  P1_0  //����485ͨ�ŵĿ�������

/**************************************FUNCTIONS**************************************/
/*
*uart��ʼ��
*@param   none
*@return  none
*/
void UserRS485_Init(void)
{
  //����0����
  UserRS485Config.configured           = TRUE;
  UserRS485Config.flowControl          = FALSE;
  UserRS485Config.rx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserRS485Config.tx.maxBufSize        = HAL_UART_MAX_BUFFSIZE;
  UserRS485Config.idleTimeout          = 6;
  UserRS485Config.intEnable            = TRUE;
  UserRS485Config.callBackFunc         = UserRS485_Receive_CB;
  //��̬��ȡ���ڲ����ʲ��򿪴���0
  GetBaud_OpenUart();   
  //����GPIO�������ڿ���DE����
  P1DIR |= BV(0); //����P1.0���
  RS485_DE_PIN = 0; //��ʼ��������Ϊ����
}

/*
*�򴮿ڷ�����Ϣ
*@param   payload ��������
*@param   size ���ݴ�С
*@return  none
*/
void UserRS485_Send(const uint8 *payload, uint16 size)
{
  RS485_DE_PIN = 1;//����ģʽ
  HalUARTWrite(HAL_UART_PORT_0, (uint8 *)payload, size);
}

/*
*���ڽ�����Ϣ�Ļص�����
*@param   port ���ں�
*@param   event �¼�
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
        uint8 start = rxBuf[0]; //��ȡ֡ͷ
        //���ݲ�ͬ��֡ͷ���ж�������Դ���ĸ�������
        switch(start){
        case 0x01: //�����������������ݴ���
          ProcSoilSensor(rxBuf); break;
        case 0x02: //������ʪ�ȴ��������ݴ���
          ProcLigTHSensor(rxBuf); break;
        case 0x03: //������̼Ũ�ȴ��������ݴ���
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