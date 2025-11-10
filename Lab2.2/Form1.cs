using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2._2
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int stare;
        public Form1()
        {
            InitializeComponent();
            this.Width = 200;
            this.Height = 400;
            this.Text = "Simulare Semafor";
            stare = 0;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.Paint += Form1_Paint;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            stare = (stare + 1) % 3; 
            this.Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Gray, 50, 50, 80, 220);
            DrawLight(g, 90, 80, Color.Red, stare == 0);
            DrawLight(g, 90, 150, Color.Yellow, stare == 1);
            DrawLight(g, 90, 220, Color.Green, stare == 2);
        }
        private void DrawLight(Graphics g, int x, int y, Color color, bool aprins)
        {
            Brush b = aprins ? new SolidBrush(color) : Brushes.DarkGray;
            g.FillEllipse(b, x - 20, y - 20, 40, 40);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
