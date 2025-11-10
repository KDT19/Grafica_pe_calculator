using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Forfecare pătrat cu 15°";
            this.Size = new Size(600, 600);
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            PointF[] square = new PointF[]
            {
                new PointF(200, 200),
                new PointF(300, 200),
                new PointF(300, 300),
                new PointF(200, 300)
            };
            g.DrawPolygon(new Pen(Color.Blue, 3), square);
            double angle = 15 * Math.PI / 180.0;
            double shearFactor = Math.Tan(angle);
            PointF[] sheared = new PointF[square.Length];
            for (int i = 0; i < square.Length; i++)
            {
                float x = square[i].X;
                float y = square[i].Y;

                float x_new = (float)(x + shearFactor * y);
                float y_new = y;

                sheared[i] = new PointF(x_new, y_new);
            }
            g.DrawPolygon(new Pen(Color.Red, 3), sheared);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
