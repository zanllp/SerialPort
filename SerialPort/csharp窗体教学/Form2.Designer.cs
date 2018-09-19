namespace 上位机
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.auto_limit = new System.Windows.Forms.CheckBox();
            this.upper_limit = new System.Windows.Forms.TextBox();
            this.lower_limit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.cursor_ruler = new System.Windows.Forms.CheckBox();
            this.vernier = new System.Windows.Forms.CheckBox();
            this.line_width = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.x_speed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.data_shaft_point = new System.Windows.Forms.NumericUpDown();
            this.time_shaft_point = new System.Windows.Forms.NumericUpDown();
            this.point_size = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.serial_read_dealy = new System.Windows.Forms.NumericUpDown();
            this.serial_read_way = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_shaft_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_shaft_point)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.point_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serial_read_dealy)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "在空白处按住鼠标左键可拖动";
            // 
            // auto_limit
            // 
            this.auto_limit.AutoSize = true;
            this.auto_limit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.auto_limit.Checked = true;
            this.auto_limit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.auto_limit.Location = new System.Drawing.Point(6, 20);
            this.auto_limit.Name = "auto_limit";
            this.auto_limit.Size = new System.Drawing.Size(96, 16);
            this.auto_limit.TabIndex = 4;
            this.auto_limit.Text = "自动计算范围";
            this.auto_limit.UseVisualStyleBackColor = true;
            this.auto_limit.CheckedChanged += new System.EventHandler(this.auto_limit_CheckedChanged);
            // 
            // upper_limit
            // 
            this.upper_limit.Enabled = false;
            this.upper_limit.Location = new System.Drawing.Point(89, 49);
            this.upper_limit.Name = "upper_limit";
            this.upper_limit.Size = new System.Drawing.Size(46, 21);
            this.upper_limit.TabIndex = 5;
            this.upper_limit.Text = "上限";
            // 
            // lower_limit
            // 
            this.lower_limit.Enabled = false;
            this.lower_limit.Location = new System.Drawing.Point(150, 49);
            this.lower_limit.Name = "lower_limit";
            this.lower_limit.Size = new System.Drawing.Size(44, 21);
            this.lower_limit.TabIndex = 6;
            this.lower_limit.Text = "下限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "手动输入范围";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.serial_read_way);
            this.groupBox1.Controls.Add(this.lower_limit);
            this.groupBox1.Controls.Add(this.auto_limit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.upper_limit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 138);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "折线图";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(307, 235);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 11;
            this.btn_apply.Text = "应用";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // cursor_ruler
            // 
            this.cursor_ruler.AutoSize = true;
            this.cursor_ruler.Checked = true;
            this.cursor_ruler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cursor_ruler.Location = new System.Drawing.Point(227, 12);
            this.cursor_ruler.Name = "cursor_ruler";
            this.cursor_ruler.Size = new System.Drawing.Size(72, 16);
            this.cursor_ruler.TabIndex = 12;
            this.cursor_ruler.Text = "鼠标跟踪";
            this.cursor_ruler.UseVisualStyleBackColor = true;
            // 
            // vernier
            // 
            this.vernier.AutoSize = true;
            this.vernier.Checked = true;
            this.vernier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vernier.Location = new System.Drawing.Point(227, 32);
            this.vernier.Name = "vernier";
            this.vernier.Size = new System.Drawing.Size(72, 16);
            this.vernier.TabIndex = 13;
            this.vernier.Text = "数据游标";
            this.vernier.UseVisualStyleBackColor = true;
            // 
            // line_width
            // 
            this.line_width.Location = new System.Drawing.Point(388, 7);
            this.line_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.line_width.Name = "line_width";
            this.line_width.Size = new System.Drawing.Size(53, 21);
            this.line_width.TabIndex = 14;
            this.line_width.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "线条宽度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "时间轴间隔：";
            // 
            // x_speed
            // 
            this.x_speed.Location = new System.Drawing.Point(388, 30);
            this.x_speed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.x_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.x_speed.Name = "x_speed";
            this.x_speed.Size = new System.Drawing.Size(53, 21);
            this.x_speed.TabIndex = 17;
            this.x_speed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "ms/px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "px";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "点大小：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(448, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "ms";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(447, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "位";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(447, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "位";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "横轴保留到小数点后：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(225, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "竖轴保留到小数点后：";
            // 
            // data_shaft_point
            // 
            this.data_shaft_point.Location = new System.Drawing.Point(386, 80);
            this.data_shaft_point.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.data_shaft_point.Name = "data_shaft_point";
            this.data_shaft_point.Size = new System.Drawing.Size(55, 21);
            this.data_shaft_point.TabIndex = 29;
            // 
            // time_shaft_point
            // 
            this.time_shaft_point.Location = new System.Drawing.Point(386, 102);
            this.time_shaft_point.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.time_shaft_point.Name = "time_shaft_point";
            this.time_shaft_point.Size = new System.Drawing.Size(55, 21);
            this.time_shaft_point.TabIndex = 30;
            this.time_shaft_point.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // point_size
            // 
            this.point_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.point_size.Location = new System.Drawing.Point(386, 129);
            this.point_size.Name = "point_size";
            this.point_size.Size = new System.Drawing.Size(54, 21);
            this.point_size.TabIndex = 31;
            this.point_size.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "串口读取延时:";
            // 
            // serial_read_dealy
            // 
            this.serial_read_dealy.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.serial_read_dealy.Location = new System.Drawing.Point(386, 175);
            this.serial_read_dealy.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.serial_read_dealy.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.serial_read_dealy.Name = "serial_read_dealy";
            this.serial_read_dealy.Size = new System.Drawing.Size(54, 21);
            this.serial_read_dealy.TabIndex = 34;
            this.serial_read_dealy.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // serial_read_way
            // 
            this.serial_read_way.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serial_read_way.FormattingEnabled = true;
            this.serial_read_way.Items.AddRange(new object[] {
            "自由捕获",
            "关键字捕获"});
            this.serial_read_way.Location = new System.Drawing.Point(6, 110);
            this.serial_read_way.Name = "serial_read_way";
            this.serial_read_way.Size = new System.Drawing.Size(104, 20);
            this.serial_read_way.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "折线图捕获方式：";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(479, 270);
            this.Controls.Add(this.serial_read_dealy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.point_size);
            this.Controls.Add(this.time_shaft_point);
            this.Controls.Add(this.data_shaft_point);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.x_speed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.line_width);
            this.Controls.Add(this.vernier);
            this.Controls.Add(this.cursor_ruler);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制面板";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.line_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_shaft_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_shaft_point)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.point_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serial_read_dealy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox auto_limit;
        public System.Windows.Forms.TextBox upper_limit;
        public System.Windows.Forms.TextBox lower_limit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.CheckBox cursor_ruler;
        private System.Windows.Forms.CheckBox vernier;
        private System.Windows.Forms.NumericUpDown line_width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown x_speed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown data_shaft_point;
        private System.Windows.Forms.NumericUpDown time_shaft_point;
        private System.Windows.Forms.NumericUpDown point_size;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown serial_read_dealy;
        private System.Windows.Forms.ComboBox serial_read_way;
        private System.Windows.Forms.Label label8;
    }
}