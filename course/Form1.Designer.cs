namespace course
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
            components = new System.ComponentModel.Container();
            MenuStrip menuStrip1;
            authorToolStripMenuItem = new ToolStripMenuItem();
            panel2 = new Panel();
            groupBox3 = new GroupBox();
            WarninglistBox = new ListBox();
            groupBox2 = new GroupBox();
            btnCalculate = new Button();
            label1 = new Label();
            numA = new NumericUpDown();
            label2 = new Label();
            numdX = new NumericUpDown();
            label3 = new Label();
            numXmax = new NumericUpDown();
            label4 = new Label();
            numXmin = new NumericUpDown();
            groupBox1 = new GroupBox();
            label7 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label6 = new Label();
            label5 = new Label();
            F2listBox = new ListBox();
            F1listBox = new ListBox();
            panel4 = new Panel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            menuStrip2 = new MenuStrip();
            graphF1ToolStripMenuItem = new ToolStripMenuItem();
            graphF2ToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numdX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numXmax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numXmin).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Items.AddRange(new ToolStripItem[] { authorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1072, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // authorToolStripMenuItem
            // 
            authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            authorToolStripMenuItem.Size = new Size(52, 31);
            authorToolStripMenuItem.Text = "Автор";
            authorToolStripMenuItem.ToolTipText = "Відкриває вікно \"Про автора\"";
            authorToolStripMenuItem.Click += authorToolStripMenuItem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox3);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 508);
            panel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(WarninglistBox);
            groupBox3.Font = new Font("Segoe UI", 14F);
            groupBox3.Location = new Point(18, 240);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(225, 150);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Попередження";
            // 
            // WarninglistBox
            // 
            WarninglistBox.Font = new Font("Segoe UI", 12F);
            WarninglistBox.FormattingEnabled = true;
            WarninglistBox.Location = new Point(6, 31);
            WarninglistBox.Name = "WarninglistBox";
            WarninglistBox.Size = new Size(210, 109);
            WarninglistBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCalculate);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(numA);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(numdX);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(numXmax);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numXmin);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(12, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(228, 213);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметри";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(6, 164);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(216, 30);
            btnCalculate.TabIndex = 12;
            btnCalculate.Text = "Обрахувати";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(46, 21);
            label1.TabIndex = 1;
            label1.Text = "Xmin";
            // 
            // numA
            // 
            numA.Location = new Point(58, 129);
            numA.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numA.Name = "numA";
            numA.Size = new Size(164, 29);
            numA.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(4, 61);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 3;
            label2.Text = "Xmax";
            // 
            // numdX
            // 
            numdX.DecimalPlaces = 1;
            numdX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numdX.Location = new Point(58, 94);
            numdX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numdX.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numdX.Name = "numdX";
            numdX.Size = new Size(164, 29);
            numdX.TabIndex = 10;
            numdX.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(6, 96);
            label3.Name = "label3";
            label3.Size = new Size(28, 21);
            label3.TabIndex = 5;
            label3.Text = "dX";
            // 
            // numXmax
            // 
            numXmax.Location = new Point(58, 59);
            numXmax.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numXmax.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numXmax.Name = "numXmax";
            numXmax.Size = new Size(164, 29);
            numXmax.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(6, 131);
            label4.Name = "label4";
            label4.Size = new Size(20, 21);
            label4.TabIndex = 7;
            label4.Text = "A";
            // 
            // numXmin
            // 
            numXmin.Location = new Point(58, 24);
            numXmin.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numXmin.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numXmin.Name = "numXmin";
            numXmin.Size = new Size(164, 29);
            numXmin.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(18, 396);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = " Примітка";
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(3, 28);
            label7.Name = "label7";
            label7.Size = new Size(219, 19);
            label7.TabIndex = 15;
            label7.Text = "0<q<0.35 -> f(x)=(cos(q*x))^(1/2)";
            // 
            // label8
            // 
            label8.AccessibleRole = AccessibleRole.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(3, 49);
            label8.Name = "label8";
            label8.Size = new Size(191, 19);
            label8.TabIndex = 16;
            label8.Text = "0.35<q<1 -> f(x)=q/(log(a-x))";
            // 
            // panel1
            // 
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1072, 35);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(F2listBox);
            panel3.Controls.Add(F1listBox);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(847, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(225, 508);
            panel3.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(15, 259);
            label6.Name = "label6";
            label6.Size = new Size(105, 25);
            label6.TabIndex = 3;
            label6.Text = "Функція F2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(15, 18);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 2;
            label5.Text = "Функція F1 ";
            // 
            // F2listBox
            // 
            F2listBox.FormattingEnabled = true;
            F2listBox.Location = new Point(15, 287);
            F2listBox.Name = "F2listBox";
            F2listBox.Size = new Size(198, 169);
            F2listBox.TabIndex = 1;
            // 
            // F1listBox
            // 
            F1listBox.FormattingEnabled = true;
            F1listBox.Location = new Point(15, 46);
            F1listBox.Name = "F1listBox";
            F1listBox.Size = new Size(198, 169);
            F1listBox.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(formsPlot1);
            panel4.Controls.Add(menuStrip2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(252, 35);
            panel4.Name = "panel4";
            panel4.Size = new Size(595, 508);
            panel4.TabIndex = 3;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(595, 484);
            formsPlot1.TabIndex = 1;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.Bottom;
            menuStrip2.Items.AddRange(new ToolStripItem[] { graphF1ToolStripMenuItem, graphF2ToolStripMenuItem });
            menuStrip2.Location = new Point(0, 484);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(595, 24);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // graphF1ToolStripMenuItem
            // 
            graphF1ToolStripMenuItem.Name = "graphF1ToolStripMenuItem";
            graphF1ToolStripMenuItem.Size = new Size(78, 20);
            graphF1ToolStripMenuItem.Text = "Функція F1";
            graphF1ToolStripMenuItem.Click += graphF1ToolStripMenuItem_Click;
            // 
            // graphF2ToolStripMenuItem
            // 
            graphF2ToolStripMenuItem.Name = "graphF2ToolStripMenuItem";
            graphF2ToolStripMenuItem.Size = new Size(78, 20);
            graphF2ToolStripMenuItem.Text = "Функція F2";
            graphF2ToolStripMenuItem.Click += graphF2ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 543);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Курсова Робота, варіант 8";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numdX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numXmax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numXmin).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private ToolStripMenuItem authorToolStripMenuItem;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown numdX;
        private NumericUpDown numXmax;
        private NumericUpDown numXmin;
        private NumericUpDown numA;
        private Label label7;
        private Button btnCalculate;
        private Label label8;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel3;
        private ListBox F2listBox;
        private ListBox F1listBox;
        private Label label5;
        private Label label6;
        private Panel panel4;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem graphF1ToolStripMenuItem;
        private ToolStripMenuItem graphF2ToolStripMenuItem;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private GroupBox groupBox3;
        private ListBox WarninglistBox;
        private ToolTip toolTip1;
    }
}
