using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._1
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
            bitmap.SetPixel(50, 50, Color.Red);
            bitmap.SetPixel(100, 100, Color.Blue);
            bitmap.SetPixel(150, 200, Color.Green);
            bitmap.SetPixel(200, 150, Color.Orange);
            bitmap.SetPixel(300, 300, Color.Purple);
            this.Paint += Form1_Paint;
            bitmap.Save("puncte.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
        }
    }
}