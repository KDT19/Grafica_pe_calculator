using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3._6
{
    public partial class Form1 : Form
    {
        Point3D P = new Point3D(2, 2, 2);
        Point3D P1 = new Point3D(1, 1, 1);
        Point3D P2 = new Point3D(3, 2, 2);
        public Form1()
        {
            InitializeComponent();
            this.Text = "Sistem de coordonate 3D";
            this.Size = new Size(600, 600);
            this.BackColor = Color.White;
            this.Load += Form1_Load;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Desenare axe
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, 50, 550, 550, 550); // axa X
            g.DrawLine(axisPen, 50, 550, 50, 50);   // axa Y

            // Proiecție 3D -> 2D
            PointF Proiectie(Point3D p)
            {
                return new PointF(50 + (float)p.X * 100, 550 - (float)p.Y * 100);
            }

            // Translație
            Point3D T = new Point3D(1, 1, 1);
            Point3D P_translatat = new Point3D(P.X + T.X, P.Y + T.Y, P.Z + T.Z);

            // Rotație în jurul Ox
            double theta = Math.PI / 4;
            Point3D P_rotit = RotateOx(P, theta);

            // Scalarea dreptei P1-P2
            double scaleFactor = 2.0;
            Point3D P1_sca = ScalePoint(P1, scaleFactor);
            Point3D P2_sca = ScalePoint(P2, scaleFactor);

            // Desenare puncte și drepte
            DrawPoint(g, Proiectie(P), "P", Color.Black);
            DrawPoint(g, Proiectie(P_translatat), "P translatat", Color.Blue);
            DrawPoint(g, Proiectie(P_rotit), "P rotit", Color.Red);

            g.DrawLine(new Pen(Color.Gray, 2), Proiectie(P1), Proiectie(P2));
            DrawPoint(g, Proiectie(P1), "P1", Color.Gray);
            DrawPoint(g, Proiectie(P2), "P2", Color.Gray);

            g.DrawLine(new Pen(Color.Green, 2), Proiectie(P1_sca), Proiectie(P2_sca));
            DrawPoint(g, Proiectie(P1_sca), "P1 sc", Color.Green);
            DrawPoint(g, Proiectie(P2_sca), "P2 sc", Color.Green);
        }

        void DrawPoint(Graphics g, PointF p, string label, Color color)
        {
            int r = 5;
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, p.X - r, p.Y - r, 2 * r, 2 * r);
            g.DrawString(label, new Font("Arial", 10), brush, p.X + 5, p.Y - 15);
        }

        Point3D RotateOx(Point3D p, double theta)
        {
            double x = p.X;
            double y = p.Y * Math.Cos(theta) - p.Z * Math.Sin(theta);
            double z = p.Y * Math.Sin(theta) + p.Z * Math.Cos(theta);
            return new Point3D(x, y, z);
        }

        Point3D ScalePoint(Point3D p, double factor)
        {
            return new Point3D(p.X * factor, p.Y * factor, p.Z * factor);
        }
    

        public struct Point3D
        {
            public double X, Y, Z;
            public Point3D(double x, double y, double z)
            {
                X = x; Y = y; Z = z;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}