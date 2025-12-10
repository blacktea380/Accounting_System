using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace accounting_system
{
    public partial class Form2 : Form
    {
        // 引用 Form1 傳入的 List<Data>
        List<Data> datas;

        public Form2()
        {
            InitializeComponent();
        }

        // 帶參數構造函數：用於接收 Form1 傳來的 List
        public Form2(List<Data> datas)
        {
            InitializeComponent();
            this.datas = datas;
            button1.DialogResult = DialogResult.OK;

            // ListBox 標題
            string Header = "日期\t\t收支\t類型\t金額\t備註";
            listBox1.Items.Add(Header);

            // 從 List<Data> 產生列表內容
            foreach (var data in datas)
            {
                // 格式化輸出到 ListBox
                string line = $"{data.date}\t{data.income}\t{data.type}\t{data.amount}\t{data.remark}";
                listBox1.Items.Add(line);
            }
        }

        // 刪除按鈕的事件處理
        private void delete_but_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            // 檢查是否選中項目，且不是標題行 (第 0 行)
            if (selectedIndex > 0 && selectedIndex < listBox1.Items.Count)
            {
                // 1. 從 ListBox 移除顯示行
                listBox1.Items.RemoveAt(selectedIndex);

                // 2. 從 List<Data> 移除對應資料
                // 由於標題行被移除，所以 List<Data> 的索引是 ListBox 索引 - 1
                datas.RemoveAt(selectedIndex - 1);

                // 3. 重寫 list.txt 檔案
                try
                {
                    // 使用 StreamWriter 覆寫檔案 (append: false)
                    using (StreamWriter sw = new StreamWriter("list.txt", false))
                    {
                        // 將所有剩餘的資料重新寫入檔案
                        foreach (var data in datas)
                        {
                            // 輸出所有五個欄位
                            string line = $"{data.date}\t{data.income}\t{data.type}\t{data.amount}\t{data.remark}";
                            sw.WriteLine(line);
                        }
                    }
                    MessageBox.Show("資料已刪除！請點擊確定返回主介面刷新餘額。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"重寫 list.txt 錯誤: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的資料行（請勿選擇標題）。");
            }
        }
    }
}