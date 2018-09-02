using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 上位机
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            serial_read_way.SelectedItem = serial_read_way.Items[0];
        }
        //*****************************拖动*********************************/
        private Point offset;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {

            if (MouseButtons.Left == e.Button)
            {

                Point cur = this.PointToScreen(e.Location);
                offset = new Point(cur.X - this.Left, cur.Y - this.Top);
            }
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {

            if (MouseButtons.Left == e.Button)
            {

                Point cur = MousePosition;
                this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
            }

        }
        //*******************************************************************/



        public double var_max;//最小值
        public double var_min;//最大值
        public bool auto_limit_0=true;//自动计算极限
        public int serial_read_dealy_0=100;
        public bool cursor_ruler_0 = true;//跟踪标尺
        public bool vernier_0 = true;//游动标尺
        public int line_width_0=2;
        public int x_speed_0 = 20;                          //x轴 移动速度每x_speed_0 ms 1像素
        public string serial_read_way_0 = "自由捕获";
        public int time_shaft_point_0 ;//时间轴保留到小数点后2位、
        public int data_shaft_point_0 ;//数据轴保留到小数点后0位
        public int point_size_0=5;
       
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();//隐藏
            
        }

     
        private Boolean IsNumber(string a)
        {
            foreach (char item in a)
            {
                if (!(item > 47 && item < 60|| item == 46))
                {
                    return false;
                }
            }
            return true;
        }

      
        private void auto_limit_CheckedChanged(object sender, EventArgs e)
        {

            if (auto_limit.Checked)
            {
                upper_limit.Enabled = false;
                lower_limit.Enabled = false; 
                label2.Enabled = false;
                
            }
            else
            {
                upper_limit.Enabled = true;
                lower_limit.Enabled = true;
                label2.Enabled = true;
               
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            
            /*********************************************************************/
            if (auto_limit.Checked)
            {
                auto_limit_0 = true;
                var_max = 1;
                var_min = 0;
            }
            else
            {
                 auto_limit_0 = false;
                if (!IsNumber(upper_limit.Text))
                {
                    upper_limit.Text = var_max.ToString();
                    MessageBox.Show("输入数字");

                }
                if (!IsNumber(lower_limit.Text))
                {
                    lower_limit.Text = var_min.ToString();
                    MessageBox.Show("输入数字");
                }
            }
            
            if ((lower_limit.Text != "" && upper_limit.Text != "") && lower_limit.Enabled)
            {
                if (Convert.ToDouble(upper_limit.Text) != 0)
                {
                    var_max = Convert.ToDouble(upper_limit.Text);
                }

                var_min = Convert.ToDouble(lower_limit.Text);
            }
            /*********************************************************/
            cursor_ruler_0 = cursor_ruler.Checked;
            vernier_0 = vernier.Checked;
            line_width_0 = (int)line_width.Value;
            x_speed_0 = (int)x_speed.Value;
            serial_read_dealy_0 = (int)serial_read_dealy.Value;
            time_shaft_point_0 = (int)time_shaft_point.Value;
            data_shaft_point_0 = (int)data_shaft_point.Value;
            point_size_0 = (int)point_size.Value;
            serial_read_way_0= serial_read_way.SelectedItem.ToString();
      

        }

      
    }
}
