using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._3
{
    public partial class Form1 : Form
    {
        private NumericUpDown angleSelector;
        private float angle = 90f;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Rotație Dreptunghi";
            this.Size = new Size(600, 600);
            this.BackColor = Color.White;
            angleSelector = new NumericUpDown();
            angleSelector.Minimum = 0;
            angleSelector.Maximum = 360;
            angleSelector.Value = 90;
            angleSelector.Increment = 10;
            angleSelector.Dock = DockStyle.Top;
            angleSelector.ValueChanged += (s, e) =>
            {
                angle = (float)angleSelector.Value;
                this.Invalidate();
            };

            this.Controls.Add(angleSelector);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(250, 250);
            PointF[] rect = new PointF[]
            {
                new PointF(0, 0),
                new PointF(100, 0),
                new PointF(100, 50),
                new PointF(0, 50)
            };
            g.DrawPolygon(new Pen(Color.Blue, 2), rect);
            float radians = angle * (float)Math.PI / 180f;
            PointF[] rotated = new PointF[rect.Length];
            for (int i = 0; i < rect.Length; i++)
            {
                float x = rect[i].X;
                float y = rect[i].Y;

                rotated[i] = new PointF(
                    (float)(x * Math.Cos(radians) - y * Math.Sin(radians)),
                    (float)(x * Math.Sin(radians) + y * Math.Cos(radians))
                );
            }
            g.DrawPolygon(new Pen(Color.Red, 2), rotated);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
