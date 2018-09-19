using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using NPOI.HSSF.UserModel;
using System.IO;
//using OpenCvSharp;
//using OpenCvSharp.Extensions;
//using System.Collections.Generic;
//using Newtonsoft.Json;
namespace 上位机
{

    public partial class Form1 : Form
    {
       // private delegate void FlushClient();//代理
    
        public Form1()
        {
            InitializeComponent();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox_1.Text = "";
        }

       
        HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿 
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            //pB5.Image
            btn5.Visible = false;
            btn_excel.Visible = false;
            label_excel_record_val.Visible = false;
            pictureBox4.Visible = false;
            //*****************串口默认参数配置***********************/
            serialPort1.BaudRate = 9600;//波特率
            serialPort1.DataBits = 8;//
            serialPort1.StopBits = StopBits.One;
            //***********************双重缓冲***********************/
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            //*********************************************************/

            workbook2003.CreateSheet("散点图");
            workbook2003.CreateSheet("数据可视化"); //新建1个Sheet工作表 
             //**********************多线程***************************/
            CheckForIllegalCrossThreadCalls = false;//注意勿动
            /*Thread thread = new Thread(new ThreadStart(Method1));
            thread.IsBackground = true;
            thread.Start();
            /*******************************************************/
            
        }


     
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//关闭

        }
        private void CustomItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in SelectCom.DropDownItems)
            {
                item.Checked = false;
            }
            if (((ToolStripMenuItem)sender).Name != serialPort1.PortName)
            {
                if (serialPort1.IsOpen)//如果在串口打开的时候切换
                {
                    open_serial_btn.Text = "打开串口";
                    UM_print("串口已关闭,在串口打开时无法切换");
                    checkBox_pwm.Checked = false;
                    serialPort1.Close();
                    UM_print("串口状态：" + serialPort1.IsOpen.ToString());
                }
                ((ToolStripMenuItem)sender).CheckState = CheckState.Checked;
                serialPort1.PortName = ((ToolStripMenuItem)sender).Text;
            }
        }



      
        ///******************************波特率单选*******************************/
        private void select_0(object sender)
        {
            br115200.Checked = false;
            br56000.Checked = false;
            br38400.Checked = false;
            br19200.Checked = false;
            br9600.Checked = false;
            br4800.Checked = false;
            br2400.Checked = false;
            if (((ToolStripMenuItem)sender).Checked)
            {
                ((ToolStripMenuItem)sender).Checked = false;
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
            }
        }
        private void br2400_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 2400;
            select_0(br2400);
        }

        private void br4800_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 4800;
            select_0(br4800);
        }

        private void br9600_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            select_0(br9600);
        }

        private void br19200_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 19200;
            select_0(br19200);
        }

        private void br38400_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 38400;
            select_0(br38400);
        }

        private void br56000_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 56000;
            select_0(br56000);
        }

        private void br115200_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 115200;
            select_0(br115200);
        }
        //************************数据位选择*****************************/
        private void select_1(object sender)
        {
            DB5.Checked = false;
            DB6.Checked = false;
            DB7.Checked = false;
            DB8.Checked = false;
            if (((ToolStripMenuItem)sender).Checked)
            {
                ((ToolStripMenuItem)sender).Checked = false;
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
            }
        }

        private void DB4_Click(object sender, EventArgs e)
        {
            serialPort1.DataBits = 5;
            select_1(DB5);
        }

        private void DB8_Click(object sender, EventArgs e)
        {
            serialPort1.DataBits = 6;
            select_1(DB6);
        }

        private void DB16_Click(object sender, EventArgs e)
        {
            serialPort1.DataBits = 7;
            select_1(DB7);
        }

        private void DB32_Click(object sender, EventArgs e)
        {
            serialPort1.DataBits = 8;
            select_1(DB8);
        }
        //*********************停止位单选*************************/
        private void select_2(object sender)
        {
            SB1.Checked = false;
            SB15.Checked = false;
            SB2.Checked = false;
            if (((ToolStripMenuItem)sender).Checked)
            {
                ((ToolStripMenuItem)sender).Checked = false;
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
            }
        }

        private void SB1_Click(object sender, EventArgs e)
        {
            serialPort1.StopBits = StopBits.One;
            select_2(SB1);
        }

        private void SB15_Click(object sender, EventArgs e)
        {
            serialPort1.StopBits = StopBits.OnePointFive;
            select_2(SB15);
        }
        private void SB2_Click(object sender, EventArgs e)
        {
            serialPort1.StopBits = StopBits.Two;
            select_2(SB2);
        }

        private void richTextBox_1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox_keepscroll.Checked)
            {

                try
                {
                    richTextBox_1.Select(richTextBox_1.Text.Length, 0);
                    richTextBox_1.ScrollToCaret();
                }
                catch
                {
                }


            }
        }
        private void serial_println(String a)
        {
            if (serialPort1.PortName != "未指定")
            {
                if (serialPort1.IsOpen)
                {
                    string temp_0 = a;
                    serialPort1.Write(temp_0);
                    UM_print(temp_0);
                }
                else
                {
                    UM_print("串口未打开");

                }
            }

        }
        private void serial_println(String a, Boolean b)//b为false时关闭上位机打印
        {
            if (serialPort1.PortName != "未指定")

            {
                if (serialPort1.IsOpen)
                {
                    string temp_0 = a;
                    serialPort1.Write(temp_0);

                }
                else
                {
                    UM_print("串口未打开");

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            serial_println(richTextBox2.Text);
            if (checkBox_autoempty.Checked)
            {
                richTextBox2.Text = "";
            }

        }
        //***********************************格式化输出***************************************************/
        private void UM_print(string a)//upper monitor 上位机
        {
           
            richTextBox_1.AppendText("[" + DateTime.Now.ToString("t") + "]" + "上位机: " + a + '\n');
        }
        private void LM_print(string a)//upper monitor 上位机
        {
            if (show_line_num.Checked==true)
            {
                a = line_num.ToString() + "   " + a;
            }
            richTextBox_1.AppendText(a);//追加会滚动
                                        // richTextBox_1.Text += a;
                                        /*richTextBox_1.Text +="[" + DateTime.Now.ToString("t") + "]" + "下位机:" + a +'\n';*/
        }
        //****************************************************************************************************/


        private void button_open_serial_Click(object sender, EventArgs e)
        {
           
            if (open_serial_btn.Text == "打开串口")
            {
                if (serialPort1.PortName != "未指定")
                {
                    if (serialPort1.IsOpen == false)
                    {
                        open_serial_btn.Text = "关闭串口";
                        try
                        {
                            serialPort1.Open();
                        }
                        catch (Exception err)//被占用
                        {
                            open_serial_btn.Text = "打开串口";
                            MessageBox.Show(err.ToString());
                        }
                       
                        UM_print("打开串口"+ serialPort1.PortName.ToString());
                        UM_print("串口状态：" + serialPort1.IsOpen.ToString());
                    }
                    else
                    {
                        UM_print("串口已经打开了");
                        UM_print("串口状态：" + serialPort1.IsOpen.ToString());
                    }
                }

                else
                {
                    UM_print("先在串口设置那选择串口");
                }

            }
            else
            {
                UM_print("关闭串口");
                checkBox_pwm.Checked = false;
                serialPort1.Close();
                UM_print("串口状态：" + serialPort1.IsOpen.ToString());
                open_serial_btn.Text = "打开串口";
            }

        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_pwm.Text = (int)((trackBar1.Value - 920) / 12) + "%";
        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serial_println(richTextBox2.Text);
                if (checkBox_autoempty.Checked)
                {
                    richTextBox2.Text = "";
                }
                else
                {

                    richTextBox2.Text = richTextBox2.Text.Replace("\n", "");//将回车变成空白

                }

            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public bool draw_open = false;//是否开启绘图
        public bool auto_limit = true;//自动计算极限
        public bool auto_limit_temp;
        public bool cursor_ruler = true;//光标尺
        public bool vernier = true;//游动标尺
        public int line_width = 1;//线条宽度
        public const int coor_var_sd = 200;//散点图坐标缓存数量
        public int sd_var = 0;
        public double[,,] coor_sd = new double[10, coor_var_sd, 2];//坐标缓存
        public double[,,] coor_tsf_sd = new double[10, coor_var_sd, 2];//坐标缓存
        public double I_0;
        public int line_var = 0;                         //线的数量
        public int x_speed = 20;                          //x_speed毫秒一个像素
        public int timer_interval;
        public const int coor_var = 200;                 //坐标缓存数量
        public double[,,] coor = new double[10, coor_var, 2];//坐标缓存
        public double var_max;//最小值
        public double var_min;//最大值
        public double var_max_sdx;
        public double var_min_sdx;
        public double var_max_sdy;
        public double var_min_sdy;
        public int counter_100ms;//100ms计数器，每一百ms++
        //除画图外都使用这个100ms计时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter_100ms++;
            //************************读取另外一个窗口的设置**********************************/
            auto_limit = form2.auto_limit_0;
            if (!auto_limit || !auto_limit_temp)
            {
                var_max = form2.var_max;
                var_min = form2.var_min;
                auto_limit_temp = auto_limit;
            }
            cursor_ruler = form2.cursor_ruler_0;
            vernier = form2.vernier_0;
            line_width = form2.line_width_0;
            x_speed = form2.x_speed_0;
            serial_read_dealy = form2.serial_read_dealy_0;
            time_shaft_point = form2.time_shaft_point_0;
            data_shaft_point = form2.data_shaft_point_0;
            point_size = form2.point_size_0;
            //*****************************右边的串口信息更新**************************************/
            label_BR.Text = "波特率：" +'\n'+ serialPort1.BaudRate.ToString();
            label_COM.Text = "COM口：" + '\n' + serialPort1.PortName;
            label5.Text = "串口延时：" + '\n' + serial_read_dealy.ToString() + "ms";
            //*****************************COM口选择*****************************************/
            if (SerialPort.GetPortNames().Count() == 0)//但没有连接东西的时候清空所有item成员
            {
                SelectCom.DropDownItems.Clear();
                if (serialPort1.PortName != "未指定")//被拔出去的话
                {
                    serialPort1.Close();
                    serialPort1.PortName = "未指定";
                    UM_print("设备拔出，串口已关闭");
                    open_serial_btn.Text = "打开串口";
                }
            }
            else
            {
                if (SerialPort.GetPortNames().Count() != SelectCom.DropDownItems.Count)//串口情况发生改动
                {
                    SelectCom.DropDownItems.Clear();
                    foreach (string s in SerialPort.GetPortNames())   //添加串口
                    {//遍历一遍，相当于用for
                        ToolStripMenuItem mi = new ToolStripMenuItem(s);
                        mi.Name = s;
                        if (serialPort1.PortName == s)
                        {
                            mi.Checked = true;
                        }
                        // mi.CheckState = CheckState.Unchecked;/**************************************/
                        mi.Click += new EventHandler(CustomItem_Click);//创建一个新的鼠标点击事件
                        SelectCom.DropDownItems.Add(mi);

                    }
                }
            }
            //**************************自动生成pwm代码并发射*******************************//
            if (checkBox_pwm.Checked)
            {
                if (serialPort1.PortName != "未指定")
                {
                    string pwm_temp;
                    pwm_temp = "pwm_" + textBox_pwm_pin.Text + "_" + trackBar1.Value;
                    serial_println(pwm_temp, false);//只输出的下位机，不再打印出来
                    label2.Text = pwm_temp;
                }

            }
            //**************************循环发送********************************/
            if (loop_print.Checked&&counter_100ms%loop_print_interval.Value==0)//点击了循环发送且100ms计数器取余为0
            {
                checkBox_autoempty.Checked = false;//循环发送的时候不能空
                serial_println(richTextBox2.Text);
            }
            //************************************************************************/
        }

        //**************************将串口收到的数据进行分割******************************/
        private struct DATA_SPLIT
        {
            public string[] data_split;//将串口收到的信息分割
            public string[] data_split_Y;//将串口收到的信息分割
            public int DATA;
        }
        private DATA_SPLIT GetData_Keyword(string a)
        {
            int data = -1;//字符串中包含几个数据
            string[] data_split = new string[50];//将串口收到的信息分割
            for (int i = 0; i < a.Length - 3; i++)
            {
                if (a[i] == 'L' && IsNumber(a[i + 1]) && a[i + 2] == ':')//散点图关键字捕获
                {

                    data = a[i + 1] - 48;
                    string var = "";
                    for (int i_0 = i + 3; i_0 < a.Length - 1; i_0++)
                    {
                        var += a[i_0];
                        if (!IsNumber(a[i_0 + 1]))
                        {
                            break;
                        }

                    }
                    if (IsNumber(var))
                    {
                        data_split[data] = var;
                    }
                    else
                    {
                        data_split[data] = "0";
                    }

                }
            }
            if (data > 4)//限制上限5条
            {
                data = 4;
            }
            DATA_SPLIT sPLIT = new DATA_SPLIT();
            sPLIT.DATA = data;
            sPLIT.data_split = data_split;
            sPLIT.data_split_Y = data_split;
            return sPLIT;
        }

        private DATA_SPLIT GetData_Keyword_SD(string a)
        {
            int data = -1;//字符串中包含几个数据
            string[] data_split = new string[50];//将串口收到的信息分割
            string[] data_split_Y = new string[50];//将串口收到的信息分割
            for (int i = 0; i < a.Length - 4; i++)
            {
                if (a[i] == 'P' && IsNumber(a[i + 1]) && (a[i + 2] == 'X' || a[i + 2] == 'Y') && a[i + 3] == ':')//散点图关键字捕获
                {

                    data = a[i + 1] - 48;
                    string var = "";
                    for (int i_0 = i + 4; i_0 < a.Length - 1; i_0++)
                    {
                        var += a[i_0];
                        if (!IsNumber(a[i_0 + 1]))
                        {
                            break;
                        }

                    }
                    if (a[i + 2] == 'X')
                    {
                        if (IsNumber(var))
                        {
                            data_split[data] = var;
                        }
                        else
                        {
                            data_split[data] = "0";
                        }

                    }
                    else
                    {
                        if (IsNumber(var))
                        {
                            data_split_Y[data] = var;
                        }
                        else
                        {
                            data_split_Y[data] = "0";
                        }
                    }

                }
            }
            if (data > 4)//限制上限5条
            {
                data = 4;
            }
            DATA_SPLIT sPLIT = new DATA_SPLIT();
            sPLIT.DATA = data;
            sPLIT.data_split = data_split;
            sPLIT.data_split_Y = data_split_Y;
            return sPLIT;
        }
        private DATA_SPLIT GetData_Free(string a)
        {
            int data = -1;//字符串中包含几个数据
            string[] data_split = new string[50];//将串口收到的信息分割
            bool isnum_last = false;
            foreach (char item in a)
            {
                if (IsNumber(item))
                {
                    if (!isnum_last)
                    {
                        data++;
                        data_split[data] = data_split[data] + item;
                        isnum_last = true;
                    }
                    else
                    {
                        data_split[data] = data_split[data] + item;
                    }

                }
                if (isnum_last == true && !IsNumber(item))
                {
                    isnum_last = false;
                }
                if (item == '\n')
                {
                    break;
                }
            }
            if (data > 4)//限制上限5条
            {
                data = 4;
            }
            DATA_SPLIT sPLIT = new DATA_SPLIT();
            sPLIT.DATA = data;
            sPLIT.data_split = data_split;
            return sPLIT;
        }


        private bool IsNumber(string a)
        {
            foreach (char item in a)
            {
                if (!(item > 47 && item < 58 || item == 46 || item == 45))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsNumber(char item)
        {

            if (!(item > 47 && item < 58 || item == 46 || item == 45))
            {
                return false;
            }

            return true;
        }
        /*********************************画图用10ms计时器**********************************************/


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (draw_open)
            {
                I_0 += 0.01;
                data_vz.Refresh();
                scatter_diagram.Refresh();
            }
        }

        /*****************************************数据可视化**************************************************/

        public double[,,] coor_tsf = new double[10, coor_var, 2];//变换后的坐标
        public int cross_border;//记录最前面的值越界了多少
        public string[] decimal_point = new string[] { "0", "0.#", "0.##" };
        public int time_shaft_point = 2;//时间轴保留到小数点后2位、
        public int data_shaft_point = 2;//数据轴保留到小数点后0位
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (draw_open)
            {
                Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.
                g.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿

                Pen p = new Pen(Color.FromArgb(0XFF, 0X66, 0XCC, 0XFF), line_width);//自定义了一个天依蓝,宽度为的画笔
                Pen p_1 = new Pen(Color.Black, 2);
                Pen p_2 = new Pen(Color.Brown, 1);
                Pen p_3 = new Pen(Color.Aqua, 3);
                Pen p_4 = new Pen(Color.Black, 1);
                SolidBrush solid = new SolidBrush(Color.DarkBlue);
                SolidBrush solid_1 = new SolidBrush(Color.Black);
                Pen[] pens = new Pen[] { new Pen(Color.Green, line_width), new Pen(Color.Black, line_width), new Pen(Color.Red, line_width), new Pen(Color.Blue, line_width), new Pen(Color.Cyan, line_width) };

                int drawingxox_w = pictureBox1.Width - 82;
                int drawingxox_h = pictureBox1.Height - 52;
                /*********************************坐标系网格线与刻度***********************************/
                for (int i = 0; i < 9; i++)//边框
                {
                    g.DrawLine(p_2, (drawingxox_w / 10) * (i + 1), 0, (drawingxox_w / 10) * (i + 1), drawingxox_h);
                    g.DrawLine(p_2, 0, (drawingxox_h / 10) * (i + 1), drawingxox_w, (drawingxox_h / 10) * (i + 1));
                    g.DrawString(((double)(drawingxox_w * (1 + i) * 0.1 + cross_border) * x_speed / 1000).ToString(decimal_point[time_shaft_point]), DefaultFont, solid, (drawingxox_w / 10) * (i + 1), drawingxox_h + 5); //时间轴
                    g.DrawString((var_min + (var_max - var_min) * (double)(10 - (i + 1)) * 0.1).ToString(decimal_point[data_shaft_point]), DefaultFont, solid, drawingxox_w + 3, (drawingxox_h / 10) * (i + 1));//数据轴

                }

                g.DrawRectangle(p_1, 0, 0, drawingxox_w, drawingxox_h);
                g.DrawString((var_max * 1.00).ToString(decimal_point[data_shaft_point]), DefaultFont, solid, drawingxox_w + 3, 0);//数据轴第一位
                g.DrawString((var_min * 1.00).ToString(decimal_point[data_shaft_point]), DefaultFont, solid, drawingxox_w + 3, drawingxox_h - 10);//数据轴最后一位
                g.DrawString(((double)(drawingxox_w + cross_border) * x_speed * 0.001).ToString(decimal_point[time_shaft_point]), DefaultFont, solid, drawingxox_w - 5, drawingxox_h + 5);//时间轴最后位
                g.DrawString(((double)((0 + cross_border) * x_speed * 0.001)).ToString(decimal_point[time_shaft_point]), DefaultFont, solid, 0, drawingxox_h + 5);//时间轴第一位，tostring("0.##")保留2位小数点


                /*****************************坐标转换与数据显示*******************************/
                for (int i = 0; i < line_var; i++)
                {
                    int h_middle = drawingxox_h / 2;
                    if ((coor[0, coor_var - 1, 0] / x_speed) >= drawingxox_w)//判断x轴是否越界，若是进行转换
                    {
                        cross_border = (int)(coor[0, coor_var - 1, 0] / x_speed) - drawingxox_w;
                        for (int i_0 = 0; i_0 < coor_var; i_0++)
                        {

                            coor_tsf[i, i_0, 0] = ((coor[0, i_0, 0] / x_speed) - cross_border);
                            coor_tsf[i, i_0, 1] = (int)((coor[i, i_0, 1] - var_min) / (double)(var_max - var_min) * drawingxox_h);
                            coor_tsf[i, i_0, 1] = h_middle - (coor_tsf[i, i_0, 1] - h_middle);

                        }
                    }
                    else
                    {
                        for (int i_0 = 0; i_0 < coor_var; i_0++)
                        {
                            coor_tsf[i, i_0, 0] = (coor[0, i_0, 0] / x_speed);
                            coor_tsf[i, i_0, 1] = (int)((coor[i, i_0, 1] - var_min) / (double)(var_max - var_min) * drawingxox_h);
                            coor_tsf[i, i_0, 1] = h_middle - (coor_tsf[i, i_0, 1] - h_middle);

                        }

                    }

                    for (int i_0 = 0; i_0 < coor_var - 1; i_0++)//画折线
                    {

                        g.DrawLine(pens[i], (int)coor_tsf[i, i_0, 0], (int)coor_tsf[i, i_0, 1], (int)coor_tsf[i, i_0 + 1, 0], (int)coor_tsf[i, i_0 + 1, 1]);

                    }
                    if (vernier && coor[i, coor_var - 1, 1] != 0)//if (vernier&&x_speed_i>coor_var)
                    {
                        g.DrawLine(pens[i], (int)coor_tsf[i, coor_var - 1, 0], (int)coor_tsf[i, coor_var - 1, 1], drawingxox_w + 60, (int)coor_tsf[i, coor_var - 1, 1]);//游动标尺
                        g.DrawString("L" + i + ":" + (coor[i, coor_var - 1, 1].ToString(decimal_point[data_shaft_point])), DefaultFont, solid_1, drawingxox_w + 30, (int)coor_tsf[i, coor_var - 1, 1] - 15);//标尺上的数字
                    }


                }

                /************************************光标标尺*****************************************/
                if (cursor_ruler)
                {
                    System.Drawing.Point point = pictureBox1.PointToClient(Control.MousePosition);//获取相对控件的坐标
                    g.DrawLine(p_4, point.X, 0, point.X, drawingxox_h + 40);
                    g.DrawString(((double)(point.X + cross_border) * x_speed / 1000).ToString(decimal_point[time_shaft_point]), DefaultFont, solid_1, point.X + 3, drawingxox_h + 30);
                    g.DrawLine(p_4, 0, point.Y, drawingxox_w + 60, point.Y);
                    g.DrawString((((1 - ((double)point.Y / drawingxox_h)) * (var_max - var_min)) + var_min).ToString(decimal_point[data_shaft_point]), DefaultFont, solid_1, drawingxox_w + 40, point.Y + 3);

                }
            }
          
        }
        /*********************************************************************************************************/

        public int row_var = 0;
        public int row_var_sd = 0;
        public bool excel_first_sd = true;//首次写入单元格数据
        
        //********************************散点图**************************************/
        public int point_size = 5;
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (draw_open)
            {
                Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.
                g.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿
                                                          //  Mat sion = new Mat(@"sion.png", ImreadModes.AnyColor);
                                                          // Cv2.ImShow("sion", sion);


                Pen p = new Pen(Color.FromArgb(0XFF, 0X66, 0XCC, 0XFF), line_width);//自定义了一个天依蓝,宽度为的画笔
                Pen p_1 = new Pen(Color.Black, 2);
                Pen p_2 = new Pen(Color.Brown, 1);
                Pen p_3 = new Pen(Color.Aqua, 3);
                Pen p_4 = new Pen(Color.Black, 1);
                SolidBrush solid = new SolidBrush(Color.DarkBlue);
                SolidBrush solid_1 = new SolidBrush(Color.Black);
                Pen[] pens = new Pen[] { new Pen(Color.Green, line_width), p, new Pen(Color.Blue, line_width), new Pen(Color.Red, line_width), new Pen(Color.Brown, line_width) };
                SolidBrush[] solids = new SolidBrush[] { new SolidBrush(Color.Green), new SolidBrush(Color.Black), new SolidBrush(Color.Red), new SolidBrush(Color.Blue), new SolidBrush(Color.Cyan) };
                int drawingxox_w = pictureBox1.Width - 82;
                int drawingxox_h = pictureBox1.Height - 52;
                /*********************************坐标系网格线与刻度***********************************/
                for (int i = 0; i < 9; i++)//边框
                {
                    g.DrawLine(p_2, (drawingxox_w / 10) * (i + 1), 0, (drawingxox_w / 10) * (i + 1), drawingxox_h);
                    g.DrawLine(p_2, 0, (drawingxox_h / 10) * (i + 1), drawingxox_w, (drawingxox_h / 10) * (i + 1));
                    g.DrawString((var_min_sdx + (var_max_sdx - var_min_sdx) * (1 + i) * 0.1).ToString(decimal_point[time_shaft_point]), DefaultFont, solid, (drawingxox_w / 10) * (i + 1), drawingxox_h + 5); //时间轴
                    g.DrawString((var_min_sdy + (var_max_sdy - var_min_sdy) * (double)(10 - (i + 1)) * 0.1).ToString(decimal_point[data_shaft_point]), DefaultFont, solid, drawingxox_w + 3, (drawingxox_h / 10) * (i + 1));//数据轴
                }

                g.DrawRectangle(p_1, 0, 0, drawingxox_w, drawingxox_h);
                g.DrawString((var_max_sdy * 1.00).ToString(decimal_point[data_shaft_point]), DefaultFont, solid, drawingxox_w + 3, 0);//数据轴第一位
                g.DrawString((var_min_sdy * 1.00).ToString(decimal_point[data_shaft_point]), DefaultFont, solid, drawingxox_w + 3, drawingxox_h - 10);//数据轴最后一位
                g.DrawString((var_max_sdx * 1.00).ToString(decimal_point[time_shaft_point]), DefaultFont, solid, drawingxox_w - 5, drawingxox_h + 5);//时间轴最后位
                g.DrawString((var_min_sdx * 1.00).ToString(decimal_point[time_shaft_point]), DefaultFont, solid, 0, drawingxox_h + 5);//时间轴第一位，tostring("0.##")保留2位小数点
                                                                                                                                      /***********************************坐标转换及打印*************************************/
                for (int i = 0; i < sd_var; i++)
                {
                    for (int i_0 = 0; i_0 < coor_var_sd; i_0++)
                    {
                        coor_tsf_sd[i, i_0, 0] = (coor_sd[i, i_0, 0] - var_min_sdx) / (var_max_sdx - var_min_sdx) * drawingxox_w;
                        coor_tsf_sd[i, i_0, 1] = (coor_sd[i, i_0, 1] - var_min_sdy) / (var_max_sdy - var_min_sdy) * drawingxox_h;
                    }
                    for (int i_0 = 0; i_0 < coor_var_sd; i_0++)
                    {
                        Rectangle rect = new Rectangle((int)coor_tsf_sd[i, i_0, 0] - point_size / 2, (int)coor_tsf_sd[i, i_0, 1] - point_size / 2, point_size, point_size);//定义矩形,参数为起点横纵坐标以及其长和宽
                        g.FillPie(solids[i], rect, 0, 360);

                    }
                    g.DrawString(("P" + i + ":").ToString(), DefaultFont, solids[i], drawingxox_w + 40, drawingxox_h / 10 * i);//标尺上的数字
                    Rectangle rect0 = new Rectangle(drawingxox_w + 60, drawingxox_h / 10 * i + 2, point_size, point_size);//定义矩形,参数为起点横纵坐标以及其长和宽
                    g.FillPie(solids[i], rect0, 0, 360);
                }

                /************************************光标标尺*****************************************/

                {
                    System.Drawing.Point point = pictureBox2.PointToClient(Control.MousePosition);//获取相对控件的坐标
                    g.DrawLine(p_4, point.X, 0, point.X, drawingxox_h + 40);
                    g.DrawString(((((double)point.X / drawingxox_w) * (var_max_sdx - var_min_sdx)) + var_min_sdx).ToString(decimal_point[time_shaft_point]), DefaultFont, solid_1, point.X + 3, drawingxox_h + 30);
                    g.DrawLine(p_4, 0, point.Y, drawingxox_w + 60, point.Y);
                    g.DrawString((((1 - ((double)point.Y / drawingxox_h)) * (var_max_sdy - var_min_sdy)) + var_min_sdy).ToString(decimal_point[data_shaft_point]), DefaultFont, solid_1, drawingxox_w + 40, point.Y + 3);

                }
            }
           
        }



        public string serial = "";
        public string serial_temp = "";
        public int serial_read_dealy = 100;
        public Double time_temp = 0;
        public bool line_var_first = true;
        public int line_num = 0;//接收到多少行
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)//对于串口要接收大量数据不能用定时获取的方式
        {

            Thread.Sleep(serial_read_dealy);//等待串口数据全部到达，如果出现乱码就加长些

            if (serialPort1.IsOpen)//serialPort1.IsOpen&&serial_temp!=""
            {
                line_num++;
                serial = serialPort1.ReadExisting();
                serialPort1.DiscardInBuffer();//记得清空串口，不然容易留到下次接收导致乱码
                LM_print(serial);
                if (draw_open)
                {
                    DATA_SPLIT A = new DATA_SPLIT();

                    if (form2.serial_read_way_0 == "自由捕获")
                    {
                        A = GetData_Free(serial);
                    }
                    else
                    {
                        A = GetData_Keyword(serial);
                    }
                    line_var = A.DATA + 1;
                    for (int i = 0; i < line_var; i++)
                    {
                        if (line_var_first)
                        {
                            coor[i, coor_var - 1, 0] = 0;//ms
                            time_temp = Environment.TickCount;//系统启功后到当前的时间
                        }
                        else
                        {
                            coor[i, coor_var - 1, 0] = Environment.TickCount - time_temp;//开始画图后到现在的时间

                        }
                        coor[i, coor_var - 1, 1] = Convert.ToDouble(A.data_split[i]);
                        for (int i_0 = 0; i_0 < coor_var - 1; i_0++)
                        {
                            coor[i, i_0, 0] = coor[i, i_0 + 1, 0];
                            coor[i, i_0, 1] = coor[i, i_0 + 1, 1];
                            if (auto_limit)
                            {
                                if (coor[i, i_0 + 1, 1] < var_min && coor[i, i_0 + 1, 1] != 0)
                                {
                                    var_min = coor[i, i_0 + 1, 1];
                                }
                                if (coor[i, i_0 + 1, 1] > var_max)
                                {
                                    var_max = coor[i, i_0 + 1, 1] + 1;
                                    var_min = var_max - 1;//防止等于0
                                }
                            }

                        }
                        line_var_first = false;
                    }
                    /*************************散点图**********************************/
                    DATA_SPLIT B = GetData_Keyword_SD(serial);
                    sd_var = B.DATA + 1;
                    for (int i = 0; i < sd_var; i++)
                    {

                        coor_sd[i, coor_var_sd - 1, 0] = Convert.ToDouble(B.data_split[i]);
                        coor_sd[i, coor_var_sd - 1, 1] = Convert.ToDouble(B.data_split_Y[i]);

                        for (int i_0 = 0; i_0 < coor_var_sd - 1; i_0++)
                        {

                            coor_sd[i, i_0, 0] = coor_sd[i, i_0 + 1, 0];
                            coor_sd[i, i_0, 1] = coor_sd[i, i_0 + 1, 1];

                            if (coor_sd[i, i_0 + 1, 1] < var_min_sdy && coor_sd[i, i_0 + 1, 1] != 0)
                            {
                                var_min_sdy = coor_sd[i, i_0 + 1, 1];

                            }
                            if (coor_sd[i, i_0 + 1, 1] > var_max_sdy)
                            {
                                var_max_sdy = coor_sd[i, i_0 + 1, 1] + 1;
                                var_min_sdy = var_max_sdy - 1;//防止等于0

                            }

                            if (coor_sd[i, i_0 + 1, 0] < var_min_sdx && coor_sd[i, i_0 + 1, 0] != 0)
                            {
                                var_min_sdx = coor_sd[i, i_0 + 1, 0];

                            }
                            if (coor_sd[i, i_0 + 1, 0] > var_max_sdx)
                            {
                                var_max_sdx = coor_sd[i, i_0 + 1, 0] + 1;
                                var_min_sdx = var_max_sdx - 1;//防止等于0

                            }

                        }
                    }

                }

                //***********************************数据记录与保存****************************************************/

                if (excel_record)
                {
                    label_excel_record_val.Text = "已记录\n折线" + row_var + "条\n点阵" + row_var_sd + "条";
                    HSSFSheet Sheet1 = (HSSFSheet)workbook2003.GetSheet("散点图"); //获取名称为Sheet1的工作表  
                    HSSFSheet Sheet2 = (HSSFSheet)workbook2003.GetSheet("数据可视化"); //获取名称为Sheet1的工作表  
                    row_var_sd++;
                    if (excel_first_sd)
                    {

                        for (int i = 0; i < sd_var; i++)//散点图
                        {

                            if (i > 0)
                            {
                                Sheet1.GetRow(0).CreateCell(0 + i * 3).SetCellValue("点" + i + " X坐标");
                                Sheet1.GetRow(0).CreateCell(1 + i * 3).SetCellValue("点" + i + "Y坐标");
                            }
                            else
                            {
                                Sheet1.CreateRow(0).CreateCell(0 + i * 3).SetCellValue("点" + i + " X坐标");
                                Sheet1.GetRow(0).CreateCell(1 + i * 3).SetCellValue("点" + i + "Y坐标");
                            }
                        }


                        excel_first_sd = !excel_first_sd;
                    }
                    for (int i = 0; i < sd_var; i++)
                    {

                        if (i > 0)
                        {
                            Sheet1.GetRow(row_var_sd).CreateCell(0 + i * 3).SetCellValue(coor_sd[i, coor_var_sd - 1, 0]);
                            Sheet1.GetRow(row_var_sd).CreateCell(1 + i * 3).SetCellValue(coor_sd[i, coor_var_sd - 1, 1]);
                        }
                        else
                        {
                            Sheet1.CreateRow(row_var_sd).CreateCell(0).SetCellValue(coor_sd[0, coor_var_sd - 1, 0]);
                            Sheet1.GetRow(row_var_sd).CreateCell(1).SetCellValue(coor_sd[0, coor_var_sd - 1, 1]);//已经创造过的不能再用create,会被覆盖
                        }
                    }

                    if (line_var > 0)
                    {
                        row_var++;
                        Sheet2.CreateRow(0).CreateCell(0).SetCellValue("时间（秒）");
                        for (int i = 0; i < line_var; i++)//数据可视化
                        {
                            Sheet2.GetRow(0).CreateCell(i + 1).SetCellValue("数据 " + i);
                        }
                        Sheet2.CreateRow(row_var).CreateCell(0).SetCellValue((coor[0, coor_var - 1, 0] * 0.001));
                        for (int i = 0; i < line_var; i++)
                        {
                            Sheet2.GetRow(row_var).CreateCell(i + 1).SetCellValue(coor[i, coor_var - 1, 1]);
                        }
                    }
                    
                }
                if (ecxel_save)//导出文件
                {
                    
                    FileStream file2003 = new FileStream(@file_name, FileMode.Create);
                    workbook2003.Write(file2003);
                    file2003.Close();
                    workbook2003.Close();
                    ecxel_save = false;
                }
            }
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();//关闭
        }

        private void button9_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;//最小化
        }
        /***********************移动窗口*********************************/
        private System.Drawing.Point offset;
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {

                System.Drawing.Point cur = this.PointToScreen(e.Location);
                offset = new System.Drawing.Point(cur.X - this.Left, cur.Y - this.Top);
            }
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {

                System.Drawing.Point cur = MousePosition;
                this.Location = new  System.Drawing.Point(cur.X - offset.X, cur.Y - offset.Y);
            }
        }
        Form2 form2 = new Form2();
        private void button10_Click(object sender, EventArgs e)
        {
            
            form2.Show();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            serial_println(richTextBox2.Text);
            if (checkBox_autoempty.Checked)
            {
                richTextBox2.Text = "";
            }

        }
        public bool excel_record = false;//记录excel保存状态
        public string file_name;
        public bool ecxel_save = false;
       
        private void btn_excel_Click(object sender, EventArgs e)
        {
            if (btn_excel.Text == "开始记录")
            {
                btn_excel.Text = "暂停记录";
                excel_record = true;
            }
            else
            {
                btn_excel.Text = "开始记录";
                excel_record = false;
                label_excel_record_val.Text = "已暂停\n" +
                    "记录";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            saveFileDialog.Title = "请选择文件";
            saveFileDialog.Filter = "word2003(*.xls)|*.xls|所有文件(*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)//打开保存的对话框
            {
                file_name = saveFileDialog.FileName.ToString();
                ecxel_save = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (btn5.Visible==true)
            {
                btn5.Visible = false;
                btn_excel.Visible = false;
                label_excel_record_val.Visible = false;
                pictureBox4.Visible = false;
            }
            else
            {
                btn5.Visible = true;
                btn_excel.Visible = true;
                label_excel_record_val.Visible = true;
                pictureBox4.Visible = true;
            }
           
        }



        private void open_draw_btn_Click(object sender, EventArgs e)
        {
            draw_open = !draw_open;
            if (draw_open)
            {
                open_draw_btn.Text = "关闭绘图";
            }
            else
            {
                open_draw_btn.Text = "开启绘图";
            }
            data_vz.Refresh();
            scatter_diagram.Refresh();
        }

        private void loop_print_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                checkBox_autoempty.Checked = false;
            }
        }

        private void checkBox_autoempty_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                loop_print.Checked = false;
            }
        }
    }
}



