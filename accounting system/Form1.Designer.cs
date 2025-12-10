namespace accounting_system
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            balance = new Label();
            amount_box = new TextBox();
            remark_box = new TextBox();
            type_box = new ComboBox();
            input_but = new Button();
            inorout_box = new ComboBox();
            list_but = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 30F);
            label1.Location = new Point(506, 40);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(142, 50);
            label1.TabIndex = 0;
            label1.Text = "月結餘";
            // 
            // balance
            // 
            balance.Font = new Font("Microsoft JhengHei UI", 30F);
            balance.Location = new Point(506, 90);
            balance.Margin = new Padding(2, 0, 2, 0);
            balance.Name = "balance";
            balance.Size = new Size(142, 51);
            balance.TabIndex = 1;
            balance.Text = "$0";
            balance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amount_box
            // 
            amount_box.Font = new Font("Microsoft JhengHei UI", 20F);
            amount_box.Location = new Point(411, 154);
            amount_box.Margin = new Padding(2, 2, 2, 2);
            amount_box.Name = "amount_box";
            amount_box.Size = new Size(224, 41);
            amount_box.TabIndex = 3;
            amount_box.Text = "請輸入金額";
            amount_box.TextAlign = HorizontalAlignment.Center;
            amount_box.Click += amount_Click;
            amount_box.KeyPress += amount_box_KeyPress;
            // 
            // remark_box
            // 
            remark_box.Font = new Font("Microsoft JhengHei UI", 20F);
            remark_box.Location = new Point(651, 154);
            remark_box.Margin = new Padding(2, 2, 2, 2);
            remark_box.Name = "remark_box";
            remark_box.Size = new Size(248, 41);
            remark_box.TabIndex = 4;
            remark_box.Text = "備註";
            remark_box.TextAlign = HorizontalAlignment.Center;
            remark_box.Click += remark_box_click;
            // 
            // type_box
            // 
            type_box.DropDownStyle = ComboBoxStyle.DropDownList;
            type_box.Font = new Font("Microsoft JhengHei UI", 20F);
            type_box.FormattingEnabled = true;
            type_box.Location = new Point(233, 154);
            type_box.Margin = new Padding(2, 2, 2, 2);
            type_box.Name = "type_box";
            type_box.RightToLeft = RightToLeft.No;
            type_box.Size = new Size(162, 43);
            type_box.TabIndex = 5;
            // 
            // input_but
            // 
            input_but.Font = new Font("Microsoft JhengHei UI", 20F);
            input_but.Location = new Point(915, 154);
            input_but.Margin = new Padding(2, 2, 2, 2);
            input_but.Name = "input_but";
            input_but.Size = new Size(130, 38);
            input_but.TabIndex = 6;
            input_but.Text = "輸入";
            input_but.UseVisualStyleBackColor = true;
            input_but.Click += input_but_Click;
            // 
            // inorout_box
            // 
            inorout_box.DropDownStyle = ComboBoxStyle.DropDownList;
            inorout_box.Font = new Font("Microsoft JhengHei UI", 20F);
            inorout_box.FormattingEnabled = true;
            inorout_box.Location = new Point(108, 154);
            inorout_box.Margin = new Padding(2, 2, 2, 2);
            inorout_box.Name = "inorout_box";
            inorout_box.Size = new Size(110, 43);
            inorout_box.TabIndex = 7;
            // 
            // list_but
            // 
            list_but.Font = new Font("Microsoft JhengHei UI", 20F);
            list_but.Location = new Point(512, 428);
            list_but.Margin = new Padding(2, 2, 2, 2);
            list_but.Name = "list_but";
            list_but.Size = new Size(136, 38);
            list_but.TabIndex = 8;
            list_but.Text = "記帳紀錄";
            list_but.UseVisualStyleBackColor = true;
            list_but.Click += list_but_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Microsoft JhengHei UI", 20F);
            dateTimePicker1.Location = new Point(458, 242);
            dateTimePicker1.Margin = new Padding(2, 2, 2, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(240, 41);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 626);
            Controls.Add(dateTimePicker1);
            Controls.Add(list_but);
            Controls.Add(inorout_box);
            Controls.Add(input_but);
            Controls.Add(type_box);
            Controls.Add(remark_box);
            Controls.Add(amount_box);
            Controls.Add(balance);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "記帳系統";
            Click += remark_box_click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label balance;
        private TextBox amount_box;
        private TextBox remark_box;
        private ComboBox type_box;
        private Button input_but;
        private ComboBox inorout_box;
        private Button list_but;
        private DateTimePicker dateTimePicker1;
    }
}
