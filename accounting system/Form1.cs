using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

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
            type_box.Items.AddRange(new string[] { "飲食", "日常用品", "交通", "水電瓦斯", "房租", "數位", "購物", "服飾", "娛樂", "醫療", "其他" });
            type_box.SelectedIndex = 0;
            type_box.DropDownStyle = ComboBoxStyle.DropDownList;

            StreamReader sr;
            StreamWriter sw;
            FileInfo list = new FileInfo("list.txt");
            if (!list.Exists)
            {
                sw = list.CreateText();
                sw.Close();
            }

            using (sr = new StreamReader("list.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split("\t");
                    if (parts.Length >= 4)
                    {
                        string date = parts[0];
                        string income = parts[1];
                        decimal amount = decimal.Parse(parts[3], CultureInfo.InvariantCulture);
                        datas.Add(new Data(date, income, amount));
                    }

                }
            }

            decimal bal = 0;
            foreach (var data in datas)
            {
                string[] date = data.date.Split("/");
                string month = date[1];
                string curMonth = DateTime.Now.Month.ToString();

                if (month == curMonth)
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

            balance.Text = "$" + bal.ToString();

            sr.Close();

        }

        public class Data
        {

            public string date { get; set; }
            public string income { get; set; }
            //string type;
            public decimal amount { get; set; }

            public Data(string date, string income, decimal amount)
            {
                this.date = date;
                this.income = income;
                this.amount = amount;
            }
        }
        private void amount_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            //逐一檢查按鍵是否為0-9、enter、backspace
            if (e.KeyChar == (Char)48 || e.KeyChar == (Char)49 ||
                e.KeyChar == (Char)50 || e.KeyChar == (Char)51 ||
                e.KeyChar == (Char)52 || e.KeyChar == (Char)53 ||
                e.KeyChar == (Char)54 || e.KeyChar == (Char)55 ||
                e.KeyChar == (Char)56 || e.KeyChar == (Char)57 ||
                e.KeyChar == (Char)13 || e.KeyChar == (Char)8)
            {
                e.Handled = false;
            }
            else //不是的話，把其餘的按鍵設定為已經處理過了
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
            StreamWriter sw;
            line = selectedDate.Year.ToString() + "/" + selectedDate.Month.ToString() + "/" + selectedDate.Day.ToString() + "\t";
            if (inorout_box.SelectedIndex == 0)
            {
                line += "支出\t";
            }
            else
            {
                line += "收入\t";
            }

            switch (type_box.SelectedIndex)
            {
                case 0:
                    line += "飲食\t";
                    break;
                case 1:
                    line += "日常用品\t";
                    break;
                case 2:
                    line += "交通\t";
                    break;
                case 3:
                    line += "水電瓦斯\t";
                    break;
                case 4:
                    line += "房租\t";
                    break;
                case 5:
                    line += "數位\t";
                    break;
                case 6:
                    line += "購物\t";
                    break;
                case 7:
                    line += "服飾\t";
                    break;
                case 8:
                    line += "娛樂\t";
                    break;
                case 9:
                    line += "醫療\t";
                    break;
                case 10:
                    line += "其他\t";
                    break;
            }
            if (amount_box.Text != "" && amount_box.Text != "請輸入金額")
            {
                line += amount_box.Text + "\t";
            }
            else
            {
                MessageBox.Show("請輸入金額!");
                return;
            }
            if (remark_box.Text != "備註" && remark_box.Text != "")
            {
                line += remark_box.Text;
            }

            using (sw = new StreamWriter("list.txt", append: true))
            {
                sw.WriteLine(line);
            }


            string[] parts = line.Split("\t");
            if (parts.Length >= 4)
            {
                string date = parts[0];
                string income = parts[1];
                decimal amount = decimal.Parse(parts[3], CultureInfo.InvariantCulture);
                datas.Add(new Data(date, income, amount));
            }

            decimal bal = 0;
            foreach (var data in datas)
            {
                string[] date = data.date.Split("/");
                string month = date[1];
                string curMonth = DateTime.Now.Month.ToString();

                if (month == curMonth)
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

            balance.Text = "$" + bal.ToString();

        }

        private void remark_box_click(object sender, EventArgs e)
        {
            if (remark_box.Text == "備註")
                remark_box.Text = "";
        }

        private void list_but_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            DialogResult res;
            res = f2.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            decimal bal = 0;
            foreach (var data in datas)
            {
                string[] date = data.date.Split("/");
                string month = date[1];
                string curMonth = dateTimePicker1.Value.Month.ToString();

                if (month == curMonth)
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

            balance.Text = "$" + bal.ToString();
        }
    }
}
