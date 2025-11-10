using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 500;
            this.Text = "Triunghi desenat cu SetPixel";
            this.Paint += Form1_Paint;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            Point p1 = new Point(100, 350);
            Point p2 = new Point(300, 150);
            Point p3 = new Point(500, 350);

            DrawPoint(p1, Color.Red, 5);
            DrawPoint(p2, Color.Green, 5);
            DrawPoint(p3, Color.Blue, 5);

            DrawLine(p1, p2, Color.DarkRed, 2);
            DrawLine(p2, p3, Color.DarkGreen, 4);
            DrawLine(p3, p1, Color.DarkBlue, 6);

            e.Graphics.DrawImage(bmp, 0, 0);

            bmp.Save("triunghi.png", System.Drawing.Imaging.ImageFormat.Png);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
