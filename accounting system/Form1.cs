using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace accounting_system
{

    public partial class Form1 : Form
    {
        List<Data> datas = new List<Data> { };

        public Form1()
        {
            InitializeComponent();

            inorout_box.Items.AddRange(new string[] { "支出", "收入" });
            inorout_box.SelectedIndex = 0;
            inorout_box.DropDownStyle = ComboBoxStyle.DropDownList;

            type_box.Items.AddRange(new string[] { "餐飲", "生活用品", "交通", "通訊費", "娛樂", "教育", "醫療", "服飾", "投資", "房租", "其他" });
            type_box.SelectedIndex = 0;
            type_box.DropDownStyle = ComboBoxStyle.DropDownList;

            // 確保 list.txt 存在
            FileInfo list = new FileInfo("list.txt");
            if (!list.Exists)
            {
                list.CreateText().Close();
            }

            // 讀取資料：現在必須讀取五個欄位 (日期、收支、類型、金額、備註)
            using (StreamReader sr = new StreamReader("list.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    // parts[0]=日期, parts[1]=收支, parts[2]=類型, parts[3]=金額, parts[4]=備註
                    if (parts.Length >= 4 && decimal.TryParse(parts[3], CultureInfo.InvariantCulture, out decimal amount))
                    {
                        string date = parts[0];
                        string income = parts[1];
                        string type = parts[2];
                        string remark = parts.Length > 4 ? parts[4] : "";

                        datas.Add(new Data(date, income, type, amount, remark));
                    }
                }
            }

            UpdateBalance(DateTime.Now.Month.ToString());
        }

        // 獨立出餘額更新方法，方便 Form2 返回後重新呼叫
        private void UpdateBalance(string targetMonth)
        {
            decimal bal = 0;

            foreach (var data in datas)
            {
                // 嘗試解析日期以獲取月份，使其更健壯
                if (DateTime.TryParse(data.date, out DateTime transactionDate))
                {
                    if (transactionDate.Month.ToString() == targetMonth)
                    {
                        if (data.income == "收入")
                        {
                            bal += data.amount;
                        }
                        else
                        {
                            bal -= data.amount;
                        }
                    }
                }
            }
            balance.Text = "$" + bal.ToString();
        }

        private void amount_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)48 || e.KeyChar == (Char)49 ||
                e.KeyChar == (Char)50 || e.KeyChar == (Char)51 ||
                e.KeyChar == (Char)52 || e.KeyChar == (Char)53 ||
                e.KeyChar == (Char)54 || e.KeyChar == (Char)55 ||
                e.KeyChar == (Char)56 || e.KeyChar == (Char)57 ||
                e.KeyChar == (Char)13 || e.KeyChar == (Char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void amount_Click(object sender, EventArgs e)
        {
            if (amount_box.Text == "請輸入金額")
            {
                amount_box.Text = "";
            }
        }

        private void input_but_Click(object sender, EventArgs e)
        {
            string line;
            DateTime selectedDate = dateTimePicker1.Value;

            // 處理日期、收支、類型
            string income = (inorout_box.SelectedIndex == 0 ? "支出" : "收入");
            string type = type_box.Items[type_box.SelectedIndex].ToString();
            string date = selectedDate.Year.ToString() + "/" + selectedDate.Month.ToString() + "/" + selectedDate.Day.ToString();

            line = date + "\t" + income + "\t" + type + "\t";

            decimal inputAmount;
            // 處理金額
            if (amount_box.Text != "" && amount_box.Text != "請輸入金額" && decimal.TryParse(amount_box.Text, out inputAmount))
            {
                line += inputAmount.ToString() + "\t";
            }
            else
            {
                MessageBox.Show("請輸入有效金額!");
                return;
            }

            // 處理備註
            string remarkText = (remark_box.Text != "備註" && remark_box.Text != "") ? remark_box.Text : "";
            line += remarkText;

            // 寫入檔案
            using (StreamWriter sw = new StreamWriter("list.txt", append: true))
            {
                sw.WriteLine(line);
            }

            // 更新 datas List
            datas.Add(new Data(date, income, type, inputAmount, remarkText));

            UpdateBalance(DateTime.Now.Month.ToString());
        }

        private void remark_box_click(object sender, EventArgs e)
        {
            if (remark_box.Text == "備註")
                remark_box.Text = "";
        }

        private void list_but_Click(object sender, EventArgs e)
        {
            // 修正：傳遞當前的 datas 列表給 Form2
            Form2 f2 = new Form2(this.datas);
            DialogResult res = f2.ShowDialog();

            // 從 Form2 返回後，重新計算餘額 (因為 Form2 可能刪除了資料)
            UpdateBalance(DateTime.Now.Month.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateBalance(dateTimePicker1.Value.Month.ToString());
        }
    }
}