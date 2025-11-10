using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2._1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        TextBox tbN, tbR;
        Button btnDeseneaza;
        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 600;
            this.Text = "Poligon regulat";
            tbN = new TextBox { Location = new Point(10, 10), Width = 50, Text = "5" }; // nr laturi
            tbR = new TextBox { Location = new Point(70, 10), Width = 50, Text = "100" }; // raza
            btnDeseneaza = new Button { Location = new Point(130, 8), Text = "Desenează" };
            btnDeseneaza.Click += BtnDeseneaza_Click;
            this.Controls.Add(tbN);
            this.Controls.Add(tbR);
            this.Controls.Add(btnDeseneaza);
            this.Paint += Form1_Paint;
        }
        private void BtnDeseneaza_Click(object sender, EventArgs e)
        {
            int n = int.Parse(tbN.Text);
            int r = int.Parse(tbR.Text);
            if (n < 3)
            {
                MessageBox.Show("Numărul de laturi trebuie să fie cel puțin 3!");
                return;
            }
            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            int cx = this.ClientSize.Width / 2;
            int cy = this.ClientSize.Height / 2;
            Point[] puncte = new Point[n];
            for (int i = 0; i < n; i++)
            {
                double angle = 2 * Math.PI * i / n - Math.PI / 2;
                int x = cx + (int)(r * Math.Cos(angle));
                int y = cy + (int)(r * Math.Sin(angle));
                puncte[i] = new Point(x, y);
            }
            for (int i = 0; i < n; i++)
            {
                DrawLine(puncte[i], puncte[(i + 1) % n], Color.Blue, 2);
            }
            this.Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bmp != null)
            {
                e.Graphics.DrawImage(bmp, 0, 0);
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
