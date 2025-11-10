using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._2
{
    public partial class Form1 : Form
    {
        PointF[] dreptunghiInitial;
        PointF[] dreptunghiScalat;
        float factorScalare = 2.0f;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Scalare Dreptunghi";
            this.Size = new Size(500, 500);
            this.Paint += Form_Paint;

            // Definim dreptunghiul inițial
            dreptunghiInitial = new PointF[]
            {
                new PointF(100, 100),
                new PointF(200, 100),
                new PointF(200, 200),
                new PointF(100, 200)
            };

            // Scalare față de originea (0,0)
            dreptunghiScalat = new PointF[dreptunghiInitial.Length];
            for (int i = 0; i < dreptunghiInitial.Length; i++)
            {
                dreptunghiScalat[i] = new PointF(dreptunghiInitial[i].X * factorScalare,
                                                 dreptunghiInitial[i].Y * factorScalare);
            }
        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // Dreptunghiul original - verde
            g.FillPolygon(Brushes.Green, dreptunghiInitial);
            g.DrawPolygon(Pens.Black, dreptunghiInitial);

            // Dreptunghiul scalat - roșu
            g.FillPolygon(Brushes.Red, dreptunghiScalat);
            g.DrawPolygon(Pens.Black, dreptunghiScalat);
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
