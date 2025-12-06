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

namespace accounting_system
{
    public partial class Form2 : Form
    {
        List<Data> datas;
        public Form2()
        {
            InitializeComponent();
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
        public Form2(List<Data> datas)
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            string Header = "日期\t\t收支\t類型\t金額\t備註";
            listBox1.Items.Add(Header);
            StreamReader sr;
            using (sr = new StreamReader("list.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }
            this.datas = datas;
        }

        private void delete_but_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems != null)
            {
                
                string selectdItem = listBox1.SelectedItems.ToString();
                string[] parts = selectdItem.Split("\t");
                if (parts.Length >= 4)
                {
                    string date = parts[0];
                    string income = parts[1];
                    decimal amount = decimal.Parse(parts[3], CultureInfo.InvariantCulture);
                    datas.Remove(new Data(date, income, amount));
                }
            }
        }
    }
}
