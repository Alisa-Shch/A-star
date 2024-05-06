using System.Windows.Forms;

namespace A
{
    partial class FormP
    {
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button1);
            this.panel.Controls.Add(this.button2);
            this.panel.Controls.Add(this.comboBox2);
            this.panel.Controls.Add(this.comboBox1);
            this.panel.Location = new System.Drawing.Point(5, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(142, 60);
            this.panel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(66, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Построить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBox2.Location = new System.Drawing.Point(2, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(58, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.Text = "5";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBox1.Location = new System.Drawing.Point(2, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(58, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Найти путь";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormP
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(154, 201);
            this.Controls.Add(this.panel);
            this.MinimumSize = new System.Drawing.Size(170, 240);
            this.Name = "FormP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A*";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel panel;
        private Button button2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button1;
    }
}