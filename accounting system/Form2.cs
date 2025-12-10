using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace accounting_system
{
    public partial class Form2 : Form
    {
        List<Data> datas;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<Data> datas)
        {
            InitializeComponent();
            this.datas = datas;
            button1.DialogResult = DialogResult.OK;

            string Header = "日期\t\t收支\t類型\t金額\t備註";
            listBox1.Items.Add(Header);

            // 從 List<Data> 產生列表內容
            foreach (var data in datas)
            {
                string line = $"{data.date}\t{data.income}\t{data.type}\t{data.amount}\t{data.remark}";
                listBox1.Items.Add(line);
            }
        }

        // ** 這是處理 Del 鍵刪除的核心方法 **
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            // 檢查按下的鍵是否為 Delete 鍵 (Keys.Delete)
            if (e.KeyCode == Keys.Delete)
            {
                // 呼叫現有的按鈕點擊事件處理邏輯來執行刪除
                delete_but_Click(sender, e);

                // 阻止事件繼續傳播
                e.SuppressKeyPress = true;
            }
        }

        // ** 這是處理刪除按鈕點擊和 Del 鍵呼叫的通用方法 **
        private void delete_but_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            // 檢查是否選中項目，且不是標題行 (第 0 行)
            if (selectedIndex > 0 && selectedIndex < listBox1.Items.Count)
            {
                // 1. 從 ListBox 移除顯示行
                listBox1.Items.RemoveAt(selectedIndex);

                // 2. 從 List<Data> 移除對應資料
                datas.RemoveAt(selectedIndex - 1);

                // 3. 重寫 list.txt 檔案
                try
                {
                    using (StreamWriter sw = new StreamWriter("list.txt", false))
                    {
                        foreach (var data in datas)
                        {
                            string line = $"{data.date}\t{data.income}\t{data.type}\t{data.amount}\t{data.remark}";
                            sw.WriteLine(line);
                        }
                    }
                    MessageBox.Show("資料已刪除！餘額將在返回主介面後自動刷新。");
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

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // 呼叫刪除按鈕的通用邏輯
                delete_but_Click(sender, e);

                // 阻止事件繼續傳播
                e.SuppressKeyPress = true;
            }
        }
    }
}