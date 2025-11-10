using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4._1
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        private bool polygonCompleted = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Scanline Poligon Interactiv";
            this.Size = new Size(600, 600);
            this.BackColor = Color.White;
            this.MouseClick += Form1_MouseClick;
            this.KeyDown += Form1_KeyDown;
            this.DoubleBuffered = true;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (polygonCompleted)
                return;
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
                this.Invalidate();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && points.Count >= 3 && !polygonCompleted)
            {
                polygonCompleted = true;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.Red, p.X - 4, p.Y - 4, 8, 8);
            }
            if (points.Count > 1)
            {
                Pen pen = new Pen(Color.Black, 2);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    g.DrawLine(pen, points[i], points[i + 1]);
                }

                if (polygonCompleted)
                {
                    g.DrawLine(pen, points[points.Count - 1], points[0]);
                    Brush brush = new SolidBrush(Color.LightBlue);
                    g.FillPolygon(brush, points.ToArray());
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}