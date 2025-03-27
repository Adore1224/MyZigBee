/**************************************************************************************
  Filename:       UserApp.h
  Revised:      $Date:  2024-9-6     
  Written By WPC
**************************************************************************************/

#ifndef USERAPP_H
#define USERAPP_H

#ifdef __cplusplus
extern "C"
{
#endif

/**************************************INCLUDES***************************************/
#include "ZComDef.h"
#include "OSAL.h"
#include "ZGlobals.h"
#include "AF.h"
#include "aps_groups.h"
#include "ZDApp.h"
#include "osal_nv.h"
#include "OnBoard.h"

/* USER */
#include "UserRS485.h"
#include "User4G.h"
#include "UserUSB.h"  
#include "UserFunc.h"
 
/* HAL */
#include "hal_lcd.h"
#include "hal_led.h"
#include "hal_key.h"
#include "hal_uart.h"
  
/* STD */  
#include <stdio.h>
#include "string.h"
 
/***************************************CONSTANS**************************************/
#define USERAPP_ENDPOINT           10

#define USERAPP_PROFID             0x0F08
#define USERAPP_DEVICEID           0x0001
#define USERAPP_DEVICE_VERSION     0
#define USERAPP_FLAGS              0

#define USERAPP_MAX_CLUSTERS       4 
#define USERAPP_TRANSCLU           1
#define USERAPP_UPDATECLU          2
#define USERAPP_CONFIGCLU          3  
#define USERAPP_REPORTCLU          4
  
/* Events for the app */
#define INFO_REPORT_EVT       0x0001
#define INFO_REPORT_PERIOD    5000
  
#define REJOIN_NETWORK_EVT    0x0002
#define REJOIN_NETWORK_PERIOD 6000
  
#define SOIL_SENSOR_QUERY     0x0004
#define LIGTH_SENSOR_QUERY    0x0008
#define CO2_SENSOR_QUERY      0x0010
#define SENSOR_QUERY_PERIOD   5000  
  
#define ESP_CONFIG_EVT        0x0020
#define ESP_CONFIG_PERIOD     5000
/**********************************EXTERNAL VARIABLES*********************************/
extern uint8 UserApp_TaskID;
/*************************************º¯ÊýÉùÃ÷****************************************/
extern void UserApp_Init( uint8 task_id );
extern UINT16 UserApp_ProcessEvent( uint8 task_id, uint16 events );
extern void UserApp_SendBroadCMessage( uint16 len, uint8 *buf );
extern void UserApp_SendGroupMessage( uint16 len, uint8 *buf );
extern void UserApp_SendP2PMessage( uint16 reShortAddr, uint16 len, uint8 *buf );
extern void UpdateNetwork( uint16 pan, uint8 chan );
extern void UserApp_SendEDMessage( uint16 len, uint8 *buf );
extern void ReportNetworkInfo(uint8 *pkt);
/****************************************End******************************************/
#ifdef __cplusplus
}
#endif

#endif /* USERAPP_H */
