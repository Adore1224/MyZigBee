using System;
using System.Windows.Forms;
using static MyApp.SQLiteDB;

namespace MyApp.UI_Form
{
    public partial class HistortDataForm : Form
    {
        public HistortDataForm()
        {
            InitializeComponent();        
        }
        private void HistortDataForm_Load(object sender, EventArgs e)
        {
            airTempGridView.Columns["Id"].HeaderText = "序号";
            airTempGridView.Columns["Timestamp"].HeaderText = "时间戳";
            airTempGridView.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            airTempGridView.Columns["AirTempValue"].HeaderText = "空气温度";

            airHumiGridView.Columns["Id"].HeaderText = "序号";
            airHumiGridView.Columns["Timestamp"].HeaderText = "时间戳";
            airHumiGridView.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            airHumiGridView.Columns["AirHumiValue"].HeaderText = "空气湿度";

            humiGridView.Columns["Id"].HeaderText = "序号";
            humiGridView.Columns["Timestamp"].HeaderText = "时间戳";
            humiGridView.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            humiGridView.Columns["HumiValue"].HeaderText = "土壤水分";
          
            phGridView.Columns["Id"].HeaderText = "序号";
            phGridView.Columns["Timestamp"].HeaderText = "时间戳";
            phGridView.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            phGridView.Columns["PhValue"].HeaderText = "土壤PH";

            co2GridView.Columns["Id"].HeaderText = "序号";
            co2GridView.Columns["Timestamp"].HeaderText = "时间戳";
            airTempGridView.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            co2GridView.Columns["Co2Value"].HeaderText = "C02浓度";

            lightGridView.Columns["Id"].HeaderText = "序号";
            lightGridView.Columns["Timestamp"].HeaderText = "时间戳";
            lightGridView.Columns["Timestamp"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            lightGridView.Columns["LightValue"].HeaderText = "光照度";
        }
    }
}
