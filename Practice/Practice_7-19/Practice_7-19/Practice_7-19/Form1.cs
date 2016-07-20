using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practice_7_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TransformPointsPointF(PaintEventArgs e)
        {
            //Create array of two points
            PointF[] points = { new PointF(0.0F, 0.0F), new PointF(100.0F, 50.0F) };

            //Draw line connecting two untransformed points
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), points[0], points[1]);

            //Set World transformation of Graphics object to translate
            e.Graphics.TranslateTransform(40.0F, 30, 0F);

            //Transform points in array from world to page coordinates
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);

            //Reset World transformation
            e.Graphics.ResetTransform();
            
            //Draw line that connects transformed points
            e.Graphics.DrawLine(new Pen(Color.Red, 3), points[0], points[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            PaintEventArgs pe = new PaintEventArgs(g, this.ClientRectangle);
            TransformPointsPointF(pe);
            g.Dispose();
        }
    }
}
