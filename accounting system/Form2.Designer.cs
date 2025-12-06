namespace accounting_system
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            button1 = new Button();
            delete_but = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft JhengHei UI", 20F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 67;
            listBox1.Location = new Point(19, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(2235, 1143);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 20F);
            button1.Location = new Point(880, 1211);
            button1.Name = "button1";
            button1.Size = new Size(457, 137);
            button1.TabIndex = 1;
            button1.Text = "回主畫面";
            button1.UseVisualStyleBackColor = true;
            // 
            // delete_but
            // 
            delete_but.Location = new Point(345, 1211);
            delete_but.Name = "delete_but";
            delete_but.Size = new Size(372, 137);
            delete_but.TabIndex = 2;
            delete_but.Text = "button2";
            delete_but.UseVisualStyleBackColor = true;
            delete_but.Click += delete_but_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2272, 1416);
            Controls.Add(delete_but);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form2";
            Text = "記帳紀錄";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button delete_but;
    }
}