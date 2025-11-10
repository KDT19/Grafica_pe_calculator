using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._1
{
    public partial class Form1 : Form
    {
        Point[] triunghiOriginal;
        Point[] triunghiTranslatat;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Translație Triunghi";
            this.Size = new Size(400, 400);
            this.Paint += Form_Paint;
            triunghiOriginal = new Point[]
            {
                new Point(50, 50),
                new Point(150, 50),
                new Point(100, 150)
            };
            int dx = 2;
            int dy = 3;
            triunghiTranslatat = new Point[triunghiOriginal.Length];
            for (int i = 0; i < triunghiOriginal.Length; i++)
            {
                triunghiTranslatat[i] = new Point(triunghiOriginal[i].X + dx, triunghiOriginal[i].Y + dy);
            }
        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillPolygon(Brushes.Red, triunghiOriginal);
            g.DrawPolygon(Pens.Black, triunghiOriginal);
            g.FillPolygon(Brushes.Blue, triunghiTranslatat);
            g.DrawPolygon(Pens.Black, triunghiTranslatat);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form());
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
