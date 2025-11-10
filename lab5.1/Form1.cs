using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5._1
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap clippedImage;
        private Rectangle clipRect;
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;
            this.Text = "Clipping imagine - exemplu C#";
            LoadImageWithDialog();
            clipRect = new Rectangle(100, 100, 200, 150);
            if (originalImage != null)
                clippedImage = ClipImage(originalImage, clipRect);
            this.Paint += Form1_Paint;
        }
        private void LoadImageWithDialog()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Alege o imagine";
                ofd.Filter = "Fișiere imagine|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Nu ai ales nicio imagine. Se va închide aplicația.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea imaginii: " + ex.Message);
                this.Close();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (originalImage == null)
                return;
            g.DrawImage(originalImage, 10, 10, 300, 200);
            g.DrawRectangle(Pens.Red, 10 + clipRect.X, 10 + clipRect.Y, clipRect.Width, clipRect.Height);
            if (clippedImage != null)
                g.DrawImage(clippedImage, 350, 50);
        }
        private Bitmap ClipImage(Bitmap src, Rectangle area)
        {
            Bitmap bmp = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(src, new Rectangle(0, 0, area.Width, area.Height),
                    area,
                    GraphicsUnit.Pixel);
            }
            return bmp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
