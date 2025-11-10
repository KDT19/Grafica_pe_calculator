using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Reflexie triunghi față de y=250";
            this.Size = new Size(600, 600);
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            PointF[] triangle = new PointF[]
            {
                new PointF(100, 100),
                new PointF(200, 100),
                new PointF(150, 200)
            };

            g.DrawPolygon(new Pen(Color.Blue, 3), triangle);
            float k = 250f;
            PointF[] reflected = new PointF[triangle.Length];
            for (int i = 0; i < triangle.Length; i++)
            {
                float x = triangle[i].X;
                float y = triangle[i].Y;
                float y_reflected = 2 * k - y;
                reflected[i] = new PointF(x, y_reflected);
            }
            g.DrawPolygon(new Pen(Color.Red, 3), reflected);
            g.DrawLine(new Pen(Color.Green, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash },
                0, k, this.ClientSize.Width, k);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
