using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

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

            // 初始化類別，不再在這裡寫死，而是調用方法
            UpdateTypeBox(inorout_box.SelectedItem.ToString());

            // 將事件連接到下拉選單切換
            inorout_box.SelectedIndexChanged += inorout_box_SelectedIndexChanged;

            FileInfo list = new FileInfo("list.txt");
            if (!list.Exists)
            {
                list.CreateText().Close();
            }

            // 讀取檔案數據
            using (StreamReader sr = new StreamReader("list.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
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

        // ====== 新增：動態更新類別下拉選單的方法 ======
        private void UpdateTypeBox(string selectedIncomeOrExpense)
        {
            type_box.Items.Clear();
            string[] categories;

            if (selectedIncomeOrExpense == "支出")
            {
                categories = new string[] { "餐飲", "生活用品", "交通", "通訊費", "娛樂", "教育", "醫療", "服飾", "投資", "房租", "其他" };
            }
            else // "收入"
            {
                categories = new string[] { "薪資", "兼職", "投資收益", "獎金/禮金", "租金收入", "其他收入" };
            }

            type_box.Items.AddRange(categories);
            type_box.SelectedIndex = 0;
            type_box.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ====== 新增：inorout_box 選項改變事件 ======
        private void inorout_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inorout_box.SelectedItem != null)
            {
                UpdateTypeBox(inorout_box.SelectedItem.ToString());
            }
        }

        // 餘額更新方法
        private void UpdateBalance(string targetMonth)
        {
            decimal bal = 0;

            foreach (var data in datas)
            {
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
                amount_box.Text = "";
        }

        private void input_but_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            string income = inorout_box.SelectedItem.ToString();
            string type = type_box.SelectedItem.ToString();
            string date = selectedDate.Year.ToString() + "/" + selectedDate.Month.ToString() + "/" + selectedDate.Day.ToString();

            decimal inputAmount;
            if (amount_box.Text != "" && amount_box.Text != "請輸入金額" && decimal.TryParse(amount_box.Text, out inputAmount))
            {
                // 金額有效
            }
            else
            {
                MessageBox.Show("請輸入有效金額!");
                return;
            }

            string remarkText = (remark_box.Text != "備註" && remark_box.Text != "") ? remark_box.Text : "";

            string line = date + "\t" + income + "\t" + type + "\t" + inputAmount.ToString() + "\t" + remarkText;

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
            // 呼叫 Form2 顯示列表和刪除功能
            Form2 f2 = new Form2(this.datas);
            DialogResult res = f2.ShowDialog();

            // 從 Form2 返回後，重新計算餘額
            UpdateBalance(dateTimePicker1.Value.Month.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateBalance(dateTimePicker1.Value.Month.ToString());
        }

        // ** 圖表按鈕事件處理 (請將您 Form1 上的圖表按鈕連接到此方法) **
        private void chart_but_Click(object sender, EventArgs e)
        {
            string currentMonth = dateTimePicker1.Value.Month.ToString();

            // 計算當月各類別的支出總額
            Dictionary<string, decimal> monthlyExpenses = new Dictionary<string, decimal>();

            foreach (var data in datas)
            {
                if (DateTime.TryParse(data.date, out DateTime transactionDate) &&
                    transactionDate.Month.ToString() == currentMonth &&
                    data.income == "支出") // 圓餅圖只顯示支出
                {
                    if (monthlyExpenses.ContainsKey(data.type))
                    {
                        monthlyExpenses[data.type] += data.amount;
                    }
                    else
                    {
                        monthlyExpenses.Add(data.type, data.amount);
                    }
                }
            }

            if (monthlyExpenses.Count > 0)
            {
                Form3 f3 = new Form3(monthlyExpenses);
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("當月沒有支出資料可供繪製圓餅圖！");
            }
        }
    }
}