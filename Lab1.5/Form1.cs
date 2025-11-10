using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._5
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int margin = 50;
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;
            this.Text = "Grafic Funcții";
            this.Paint += Form1_Paint;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            DrawLine(new Point(margin, this.ClientSize.Height / 2),
                     new Point(this.ClientSize.Width - margin, this.ClientSize.Height / 2),
                     Color.Black, 1); 
            DrawLine(new Point(this.ClientSize.Width / 2, margin),
                     new Point(this.ClientSize.Width / 2, this.ClientSize.Height - margin),
                     Color.Black, 1); 
            DrawFunction(x => x * x, -10, 10, Color.Red, 1, 20);
            DrawFunction(x => Math.Sin(x), -10, 10, Color.Blue, 1, 50);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        void DrawFunction(Func<double, double> f, double xStart, double xEnd, Color color, int thickness, double scale)
        {
            double step = 0.1;
            Point? prev = null;
            for (double x = xStart; x <= xEnd; x += step)
            {
                double y = f(x);
                int px = (int)(this.ClientSize.Width / 2 + x * scale);
                int py = (int)(this.ClientSize.Height / 2 - y * scale);
                Point current = new Point(px, py);
                if (prev != null)
                    DrawLine(prev.Value, current, color, thickness);
                prev = current;
            }
        }
        void DrawLine(Point p1, Point p2, Color color, int thickness)
        {
            int x1 = p1.X, y1 = p1.Y;
            int x2 = p2.X, y2 = p2.Y;
            float dx = x2 - x1;
            float dy = y2 - y1;
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                if (x1 > x2) { (x1, x2) = (x2, x1); (y1, y2) = (y2, y1); }
                float m = (float)(y2 - y1) / (x2 - x1);
                for (int x = x1; x <= x2; x++)
                {
                    float y = m * (x - x1) + y1;
                    DrawPoint(new Point(x, (int)Math.Round(y)), color, thickness);
                }
            }
            else
            {
                if (y1 > y2) { (x1, x2) = (x2, x1); (y1, y2) = (y2, y1); }
                float m = (float)(x2 - x1) / (y2 - y1);
                for (int y = y1; y <= y2; y++)
                {
                    float x = m * (y - y1) + x1;
                    DrawPoint(new Point((int)Math.Round(x), y), color, thickness);
                }
            }
        }
        void DrawPoint(Point p, Color color, int size)
        {
            int r = size / 2;
            for (int dx = -r; dx <= r; dx++)
            {
                for (int dy = -r; dy <= r; dy++)
                {
                    int x = p.X + dx;
                    int y = p.Y + dy;
                    if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
                        bmp.SetPixel(x, y, color);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
