using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace accounting_system
{
    public partial class Form3 : Form
    {
        Dictionary<string, decimal> monthlyExpenses;

        public Form3(Dictionary<string, decimal> expenses)
        {
            InitializeComponent();
            this.monthlyExpenses = expenses;

            this.Text = "當月支出類別圓餅圖 - " + DateTime.Now.Month.ToString() + "月";

            DrawPieChart();
        }

        private void DrawPieChart()
        {
            Chart chart = this.chart1;

            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // 設定 Chart 區域
            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            // 創建數據系列
            Series series = new Series("Expenses");
            series.ChartArea = "MainArea";
            series.ChartType = SeriesChartType.Pie; // 設定為圓餅圖 

            // 讓圓餅圖顯示數值和百分比
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0.0} $";
            series.LegendText = "#VALX: #PERCENT";

            // ** 調整圖例說明文字 (Legend) 字體大小 **
            if (chart.Legends.Count > 0)
            {
                // 設定圖例文字大小為 10 磅
                chart.Legends[0].Font = new Font("Arial", 20, FontStyle.Regular);
            }

            // ** 調整圓餅圖切塊上的標籤 (Label) 字體大小 **
            // 這裡設定為 12 磅，加粗。請根據需要調整 12 這個數字。
            series.Font = new Font("Arial", 12, FontStyle.Bold);

            // 填充數據
            foreach (var item in monthlyExpenses)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart.Series.Add(series);

            // 設定標題
            Title title = new Title("當月支出分佈", Docking.Top, new Font("Arial", 16, FontStyle.Bold), Color.Black);
            chart.Titles.Clear();
            chart.Titles.Add(title);
        }
    }
}