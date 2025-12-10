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
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft JhengHei UI", 20F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 35;
            listBox1.Location = new Point(10, 6);
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(941, 459);
            listBox1.TabIndex = 0;
            listBox1.KeyDown += listBox1_KeyDown;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 20F);
            button1.Location = new Point(440, 606);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(228, 68);
            button1.TabIndex = 1;
            button1.Text = "回主畫面";
            button1.UseVisualStyleBackColor = true;
            // 
            // delete_but
            // 
            delete_but.Location = new Point(172, 606);
            delete_but.Margin = new Padding(2);
            delete_but.Name = "delete_but";
            delete_but.Size = new Size(186, 68);
            delete_but.TabIndex = 2;
            delete_but.Text = "button2";
            delete_but.UseVisualStyleBackColor = true;
            delete_but.Click += delete_but_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft JhengHei UI", 20F);
            button2.Location = new Point(388, 470);
            button2.Name = "button2";
            button2.Size = new Size(186, 59);
            button2.TabIndex = 3;
            button2.Text = "刪除紀錄";
            button2.UseVisualStyleBackColor = true;
            button2.Click += delete_but_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 530);
            Controls.Add(button2);
            Controls.Add(delete_but);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Margin = new Padding(2);
            Name = "Form2";
            Text = "記帳紀錄";
            KeyDown += Form2_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button delete_but;
        private Button button2;
    }
}