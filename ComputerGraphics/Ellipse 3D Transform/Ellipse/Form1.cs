using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ellipse
{
    public partial class Form1 : Form
    {
        PointF xyPoint = new PointF();
        PointF centerPoint = new PointF();
        PointF movePoint = new PointF();
        PointF xiePointF=new PointF();
        PointF xiedPointF = new PointF();
        private double perAngle = 0;
        private double nowAngle;
        private double moveAngle;
        PointF[] pointFs=new PointF[201];
        PointF[] pointFs1=new PointF[201];
        PointF[] xiePointFs=new PointF[201];
        PointF[] xiePointFs1 = new PointF[201];
        private float a =200;
        private float b =100;
        private float stepLength = 2;
        private float xLength = 0;
        private float yLength = 0;
        private float dbYlength = 0;
        private float xiedLength = 0;
        private int angle = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (this.textBox1.Text == "")
            {
                this.errorProvider1.SetError(this.textBox1, "请输入倾斜的角度");
                return;
            }
            else
            {
                this.errorProvider1.SetError(this.textBox1, "");
            }
            xyPoint.X = this.panel1.Width/2-200;
            xyPoint.Y = this.panel1.Height/2-100;
            centerPoint.X = xyPoint.X + a;
            centerPoint.Y = xyPoint.Y + b;
            Graphics graphics = this.panel1.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(this.panel1.BackColor);
            Pen pen = new Pen(Color.Red);
            for (int index = 0; index < pointFs.Length; index++)
            {
                movePoint.X = index * stepLength + xyPoint.X;
                xLength = centerPoint.X - movePoint.X;
                yLength = (float)(Math.Sqrt((1 - (xLength * xLength) / 40000) * 10000));
                movePoint.Y = b - yLength + xyPoint.Y;
                pointFs[index] = movePoint;
            }
            graphics.DrawCurve(pen, pointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                dbYlength = centerPoint.Y - pointFs[index].Y;
                pointFs1[index].Y = centerPoint.Y + dbYlength;
                pointFs1[index].X = pointFs[index].X;
            }
            graphics.DrawCurve(pen, pointFs1, 1.5f);
            for (int index = 0; index < pointFs.Length; index++)
            {
                xiePointF = pointFs[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                perAngle = int.Parse(jiaodu) * Math.PI / 180;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                xiePointF = pointFs1[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                perAngle = int.Parse(jiaodu) * Math.PI / 180;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs1[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs1, 1.5f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            angle += 10;
            this.textBox1.Text = angle.ToString();
            if (this.textBox1.Text == "")
            {
                this.errorProvider1.SetError(this.textBox1, "请输入倾斜的角度");
                return;
            }
            else
            {
                this.errorProvider1.SetError(this.textBox1, "");
            }
            xyPoint.X = this.panel1.Width / 2-200;
            xyPoint.Y = this.panel1.Height / 2-100;
            centerPoint.X = xyPoint.X + a;
            centerPoint.Y = xyPoint.Y + b;
            Graphics graphics = this.panel1.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(this.panel1.BackColor);
            Pen pen = new Pen(Color.Red);
            for (int index = 0; index < pointFs.Length; index++)
            {
                movePoint.X = index * stepLength + xyPoint.X;
                xLength = centerPoint.X - movePoint.X;
                yLength = (float)(Math.Sqrt((1 - (xLength * xLength) / 40000) * 10000));
                movePoint.Y = b - yLength + xyPoint.Y;
                pointFs[index] = movePoint;
            }
            graphics.DrawCurve(pen, pointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                dbYlength = centerPoint.Y - pointFs[index].Y;
                pointFs1[index].Y = centerPoint.Y + dbYlength;
                pointFs1[index].X = pointFs[index].X;
            }
            graphics.DrawCurve(pen, pointFs1, 1.5f);
            for (int index = 0; index < pointFs.Length; index++)
            {
                xiePointF = pointFs[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                perAngle = int.Parse(jiaodu) * Math.PI / 180;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                xiePointF = pointFs1[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                perAngle = int.Parse(jiaodu) * Math.PI / 180;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs1[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs1, 1.5f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            angle -= 10;
            this.textBox1.Text = angle.ToString();
            if (this.textBox1.Text == "")
            {
                this.errorProvider1.SetError(this.textBox1, "请输入倾斜的角度");
                return;
            }
            else
            {
                this.errorProvider1.SetError(this.textBox1, "");
            }
            xyPoint.X = this.panel1.Width / 2-200;
            xyPoint.Y = this.panel1.Height / 2-100;
            centerPoint.X = xyPoint.X + a;
            centerPoint.Y = xyPoint.Y + b;
            Graphics graphics = this.panel1.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(this.panel1.BackColor);
            Pen pen = new Pen(Color.Red);
            for (int index = 0; index < pointFs.Length; index++)
            {
                movePoint.X = index * stepLength + xyPoint.X;
                xLength = centerPoint.X - movePoint.X;
                yLength = (float)(Math.Sqrt((1 - (xLength * xLength) / 40000) * 10000));
                movePoint.Y = b - yLength + xyPoint.Y;
                pointFs[index] = movePoint;
            }
            graphics.DrawCurve(pen, pointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                dbYlength = centerPoint.Y - pointFs[index].Y;
                pointFs1[index].Y = centerPoint.Y + dbYlength;
                pointFs1[index].X = pointFs[index].X;
            }
            graphics.DrawCurve(pen, pointFs1, 1.5f);
            for (int index = 0; index < pointFs.Length; index++)
            {
                xiePointF = pointFs[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                perAngle = int.Parse(jiaodu) * Math.PI / 180;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                xiePointF = pointFs1[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                perAngle = int.Parse(jiaodu) * Math.PI / 180;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs1[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs1, 1.5f);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            angle = int.Parse(this.textBox1.Text);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           Point ePoint=new Point();
            ePoint.X = e.X;
            ePoint.Y = e.Y;
            moveAngle = Math.PI/2-Math.Atan2(ePoint.Y - centerPoint.Y, ePoint.X - centerPoint.X) ;
            xyPoint.X = this.panel1.Width / 2 - 200;
            xyPoint.Y = this.panel1.Height / 2 - 100;
            centerPoint.X = xyPoint.X + a;
            centerPoint.Y = xyPoint.Y + b;
            Graphics graphics = this.panel1.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(this.panel1.BackColor);
            Pen pen = new Pen(Color.Red);
            for (int index = 0; index < pointFs.Length; index++)
            {
                movePoint.X = index * stepLength + xyPoint.X;
                xLength = centerPoint.X - movePoint.X;
                yLength = (float)(Math.Sqrt((1 - (xLength * xLength) / 40000) * 10000));
                movePoint.Y = b - yLength + xyPoint.Y;
                pointFs[index] = movePoint;
            }
            graphics.DrawCurve(pen, pointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                dbYlength = centerPoint.Y - pointFs[index].Y;
                pointFs1[index].Y = centerPoint.Y + dbYlength;
                pointFs1[index].X = pointFs[index].X;
            }
            graphics.DrawCurve(pen, pointFs1, 1.5f);
            for (int index = 0; index < pointFs.Length; index++)
            {
                xiePointF = pointFs[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                //perAngle = int.Parse(jiaodu) * Math.PI / 180;
                perAngle = moveAngle;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs, 1.5f);
            for (int index = 0; index < pointFs1.Length; index++)
            {
                xiePointF = pointFs1[index];
                double startAngle = Math.Atan2(xiePointF.Y - centerPoint.Y, xiePointF.X - centerPoint.X);
                string jiaodu = this.textBox1.Text;
                //perAngle = int.Parse(jiaodu) * Math.PI / 180;
                perAngle = moveAngle;
                nowAngle = startAngle + perAngle;
                xiedLength = (float)Math.Sqrt(Math.Pow(xiePointF.X - centerPoint.X, 2) + Math.Pow(xiePointF.Y - centerPoint.Y, 2));
                xiedPointF.X = centerPoint.X - (float)(xiedLength * Math.Cos(nowAngle));
                xiedPointF.Y = centerPoint.Y + (float)(xiedLength * Math.Sin(nowAngle));
                xiePointFs1[index] = xiedPointF;
            }
            graphics.DrawCurve(pen, xiePointFs1, 1.5f);
        }

        
    }
}
