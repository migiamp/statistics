using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Draw a line
            Graphics g1 = e.Graphics;
            Pen p = new Pen(Color.Black, 5);
            Point x1 = new Point(10, 10);
            Point x2 = new Point(100, 75);
            e.Graphics.DrawLine(p, x1, x2);

        }

        private void panel3_Paint(object sender, PaintEventArgs e2)
        {
            //Draw a rectangle
            Graphics g2 = e2.Graphics;
            Pen rectangle = new Pen(Color.Green, 5);
            e2.Graphics.DrawRectangle(rectangle, 10, 10, 100, 75);

        }

        private void panel2_Paint(object sender, PaintEventArgs e3)
        {
            Graphics g2 = e3.Graphics;
            Pen circle = new Pen(Color.BlueViolet, 5);
            e3.Graphics.DrawEllipse(circle, 10, 20, 90, 90);
        }

        private void panel4_Paint(object sender, PaintEventArgs e4)
        {
            Graphics g2 = e4.Graphics;
            Pen circle = new Pen(Color.Red, 15);
            e4.Graphics.DrawEllipse(circle, 10, 20, 15, 15);
        }
    }
}
