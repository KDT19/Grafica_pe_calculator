using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._2
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.ClientSize = new Size(500, 500);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            int x1 = 50, y1 = 50;
            int x2 = 400, y2 = 300;
            Color lineColor = Color.Red;
            DeseneazaDreapta(bitmap, x1, y1, x2, y2, lineColor);
            this.Paint += Form1_Paint;
            bitmap.Save("dreapta.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        private void DeseneazaDreapta(Bitmap bmp, int x1, int y1, int x2, int y2, Color color)
        {
            if (x2 == x1)
            {
                int startY = Math.Min(y1, y2);
                int endY = Math.Max(y1, y2);
                for (int y = startY; y <= endY; y++)
                {
                    if (x1 >= 0 && x1 < bmp.Width && y >= 0 && y < bmp.Height)
                        bmp.SetPixel(x1, y, color);
                }
                return;
            }
            float m = (float)(y2 - y1) / (x2 - x1);
            int startX = Math.Min(x1, x2);
            int endX = Math.Max(x1, x2);
            for (int x = startX; x <= endX; x++)
            {
                float y = m * (x - x1) + y1;
                int yPixel = (int)Math.Round(y);

                if (x >= 0 && x < bmp.Width && yPixel >= 0 && yPixel < bmp.Height)
                    bmp.SetPixel(x, yPixel, color);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
                e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
