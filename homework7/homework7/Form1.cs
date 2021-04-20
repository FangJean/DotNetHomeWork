using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = splitContainer1.Panel1.CreateGraphics();
            drawCayleyTree(deep,th1,th2,leng,-Math.PI/2);
        }
        private Graphics graphics;
        double th1;
        double th2;
        double per1;//左?
        double per2;//右?
        int deep;//n
        double leng;//leng
        


        void drawCayleyTree(int n,double x0, double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drowLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drowLine(double x0, double y0, double x1,double y1)
        {
            Pen color=Pens.White;
            if (radioButton1.Checked)
            {
                color = Pens.Black;
            }
            if (radioButton2.Checked)
            {
                color = Pens.Red;
            }
            if (radioButton3.Checked)
            {
                color = Pens.Green;
            }
            if (radioButton4.Checked)
            {
                color = Pens.Yellow;
            }
            if (radioButton5.Checked)
            {
                color = Pens.Blue;
            }
            graphics.DrawLine(color, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            deep = Convert.ToInt32(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            leng = Convert.ToDouble(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            per2 = Convert.ToDouble(numericUpDown3.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            per1 = Convert.ToDouble(numericUpDown4.Value);
        }

        public void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            th2 = Convert.ToDouble(numericUpDown5.Value) * Math.PI / 180;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(numericUpDown6.Value) * Math.PI / 180;
        }
    }
}
