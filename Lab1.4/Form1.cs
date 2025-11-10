using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._4
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        TextBox tbX1, tbY1, tbX2, tbY2;
        Button btnDeseneaza;
        Label lblRezultat;
        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 500;
            this.Text = "Desenare Dreaptă";

            tbX1 = new TextBox { Location = new Point(10, 10), Width = 50, Text = "50" };
            tbY1 = new TextBox { Location = new Point(70, 10), Width = 50, Text = "50" };
            tbX2 = new TextBox { Location = new Point(130, 10), Width = 50, Text = "400" };
            tbY2 = new TextBox { Location = new Point(190, 10), Width = 50, Text = "300" };

            btnDeseneaza = new Button { Location = new Point(250, 8), Text = "Desenează" };
            btnDeseneaza.Click += BtnDeseneaza_Click;

            lblRezultat = new Label { Location = new Point(10, 40), Width = 550, Height = 30, Text = "" };

            this.Controls.Add(tbX1);
            this.Controls.Add(tbY1);
            this.Controls.Add(tbX2);
            this.Controls.Add(tbY2);
            this.Controls.Add(btnDeseneaza);
            this.Controls.Add(lblRezultat);

            this.Paint += Form1_Paint;
        }
        private void BtnDeseneaza_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(tbX1.Text);
            int y1 = int.Parse(tbY1.Text);
            int x2 = int.Parse(tbX2.Text);
            int y2 = int.Parse(tbY2.Text);

            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            DrawLine(new Point(x1, y1), new Point(x2, y2), Color.Blue, 2);

            string panta;
            if (x2 - x1 == 0)
                panta = "infinita (linie verticala)";
            else
                panta = ((float)(y2 - y1) / (x2 - x1)).ToString("0.##");

            double lungime = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            lblRezultat.Text = $"Panta: {panta}, Lungime segment: {lungime:0.##}";

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
