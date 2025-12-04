namespace accounting_system
{
    public partial class Form1 : Form
    {
        public enum Types
        {
            飲食,
            日常用品,
            交通,
            水電瓦斯,
            房租,
            數位,
            購物,
            服飾,
            娛樂,
            醫療,
            其他
        }
        public class Date
        {
            int year;
            int month;
            int day;
            public Date(int year, int month, int day)
            {
                this.year = year;
                this.month = month;
                this.day = day;
            }
        }
        public class Data
        {
            bool income;
            Types type;
            UInt64 amount;
            string remark;
            Date date;
            public Data(bool income, Types type, ulong amount, string remark, Date date)
            {
                this.income = income;
                this.type = type;
                this.amount = amount;
                this.remark = remark;
                this.date = date;
            }
        }
        public Form1()
        {
            InitializeComponent();
            inorout_box.Items.AddRange(new string[] { "支出", "收入" });
            inorout_box.SelectedIndex = 0;
            inorout_box.DropDownStyle = ComboBoxStyle.DropDownList;
            type_box.Items.AddRange(new string[] { "飲食", "日常用品", "交通", "水電瓦斯", "房租", "數位", "購物", "服飾", "娛樂", "醫療", "其他" });
            type_box.SelectedIndex = 0;
            type_box.DropDownStyle = ComboBoxStyle.DropDownList;
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
            bool income;
            Types t = Types.其他;
            UInt64 amount;
            string remark;
            Date date = new Date (0,0,0);
            if(inorout_box.SelectedIndex == 0)
            {
                income = false;
            }
            else
            {
                income = true;
            }

            switch (type_box.SelectedIndex)
            {
                case 0:
                    t = Types.飲食;
                    break;
                case 1:
                    t = Types.日常用品;
                    break;
                case 2:
                    t = Types.交通;
                    break;
                case 3:
                    t = Types.水電瓦斯;
                    break;
                case 4:
                    t = Types.房租;
                    break;
                case 5:
                    t = Types.數位;
                    break;
                case 6:
                    t = Types.購物;
                    break;
                case 7:
                    t = Types.服飾;
                    break;
                case 8:
                    t = Types.娛樂;
                    break;
                case 9:
                    t = Types.醫療;
                    break;
                case 10:
                    t = Types.其他;
                    break;
            }
            amount = Convert.ToUInt64(amount_box.Text);
            remark = remark_box.Text;

           
            Data data = new Data(income, t, amount, remark, date);
        }
    }
}
