using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GDIDemo
{
    public partial class Form1 : Form
    {
        Bitmap originImg;
        Image finishImg;
        Graphics g;
        DrawType dType;
        Point StartPoint, EndPoint, FontPoint;
        Pen p = new Pen(Color.Black, 1);
        bool IsDraw;
        Font font;
        Rectangle FontRect;
        /// <summary>  
        /// 画笔颜色  
        /// </summary>  
        Color DrawColor
        {
            get { return p.Color; }
            set { p.Color = value; }
        }
        /// <summary>  
        /// 画笔宽度  
        /// </summary>  
        float PenWidth
        {
            set { p.Width = value; }
        }

        public Form1()
        {
            InitializeComponent();
            cmbThickness.SelectedIndex = 0;
            //将文本输入框的父容器设为picDraw，否则显示时会出现错位  
            txtWrite.Parent = picDraw;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            //将线帽样式设为圆线帽，否则笔宽变宽时会出现明显的缺口  
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;

            originImg = new Bitmap(picDraw.Width, picDraw.Height);
            g = Graphics.FromImage(originImg);
            //画布背景初始化为白底  
            g.Clear(Color.White);

            picDraw.Image = originImg;
            finishImg = (Image)originImg.Clone();
        }

        private void btnArrow_Click(object sender, EventArgs e)
        {
            dType = DrawType.None;
            txtWrite.Visible = false;
            txtWrite.Text = "";
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            dType = DrawType.Pen;
            txtWrite.Visible = false;
            txtWrite.Text = "";
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            dType = DrawType.Line;
            txtWrite.Visible = false;
            txtWrite.Text = "";
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            dType = DrawType.Rect;
            txtWrite.Visible = false;
            txtWrite.Text = "";
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            dType = DrawType.Ellipse;
            txtWrite.Visible = false;
            txtWrite.Text = "";
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            dType = DrawType.Eraser;
            txtWrite.Visible = false;
            txtWrite.Text = "";
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            dType = DrawType.Write;
            FontDialog fd = new FontDialog(); //写字前先选择字体  
            if (fd.ShowDialog() == DialogResult.OK)
            {
                font = fd.Font;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWrite.Visible = false;
            txtWrite.Text = "";
            g.Clear(Color.White);
            reDraw();
        }

        private void picDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDraw = true;
                StartPoint = e.Location;
                switch (dType)
                {
                    case DrawType.Pen:
                    case DrawType.Eraser:
                        finishImg = (Image)originImg.Clone();
                        break;
                    case DrawType.Write: //隐藏写字框    
                        if (!txtWrite.Bounds.Contains(StartPoint))
                        {
                            txtWrite.Visible = false;
                            DrawString(txtWrite.Text);
                            txtWrite.Text = "";
                            return;
                        }
                        break;
                }
            }
        }

        //每次鼠标移动的时候获取指针坐标
        public void ShowCoordinate(int x,int y)
        {
            Text_Coordinate.Text = "x坐标:" + x + ",Y坐标:" + y;
        }

        //将所画的图形的中心点计算出来
        public Point GetCenterPoint()
        {
            int CenterX = (StartPoint.X + EndPoint.X) / 2;
            int CenterY = (StartPoint.Y + EndPoint.Y) / 2;
            Text_CenterPoint.Text = " x坐标:" + CenterX + " y坐标:" + CenterY;

            Point CenterPoint = new Point(CenterX, CenterY);
            return CenterPoint;
        }

        //对坐标点进行矩阵变换,测试阶段默认旋转90度
        public void MatrixTransformation()
        {
            //获取所画图形的中心点
            Point CenterPoint = GetCenterPoint();
    
            //算出相对坐标,即相对于中心点的坐标
            Point RelativeStart = new Point();                          //起始坐标相对运算
            Point RelativeEnd = new Point();                            //终点坐标相对运算

            //算出变换后的坐标
            //左上角
            Point ResultStart = new Point();
            RelativeStart.X = StartPoint.X - CenterPoint.X;
            RelativeStart.Y = StartPoint.Y - CenterPoint.Y;
            int RelativeStartZ = 1;
            int ResultStartZ = 0;

            //右下角
            Point ResultEnd = new Point();
            RelativeEnd.X = EndPoint.X - CenterPoint.X;
            RelativeEnd.Y = EndPoint.Y - CenterPoint.Y;
            int RelativeEndZ = 1;
            int ResultEndZ = 0;


            //模拟矩阵乘法,旋转角度为90度
            int m11 = 0, m12 = 1, m13 = 0;
            int m21 = -1, m22 = 0, m23 = 0;
            int m31 = 0, m32 = 0, m33 = 0;

            //double m11 =(int)Math.Cos(0.7853982), m12 = (int)Math.Sin(0.7853982), m13 = 0;
            //double m21 = -(int)Math.Sin(0.7853982), m22 = (int)Math.Cos(0.7853982), m23 = 0;
            //double  m31 = 0, m32 = 0, m33 = 0;


            //矩阵乘法
            //左上角坐标点运算
            ResultStart.X = RelativeStart.X * m11 + RelativeStart.Y * m12 + RelativeStartZ * m13;
            ResultStart.Y = RelativeStart.X * m21 + RelativeStart.Y * m22 + RelativeStartZ * m23;
            ResultStartZ = RelativeStart.X * m31 + RelativeStart.Y * m32 + RelativeStartZ * m33;

            //右下角坐标点运算
            ResultEnd.X = (int)(RelativeEnd.X * m11 + RelativeEnd.Y * m12 + RelativeEndZ * m13);
            ResultEnd.Y = (int)(RelativeEnd.X * m21 + RelativeEnd.Y * m22 + RelativeEndZ * m23);
            ResultEndZ = (int)(RelativeEnd.X * m31 + RelativeEnd.Y * m32 + RelativeEndZ * m33);

            //坐标还原

            ResultStart.X = CenterPoint.X - ResultStart.X;
            ResultStart.Y = CenterPoint.Y - ResultStart.Y;
            ResultEnd.X = CenterPoint.X - ResultEnd.X;
            ResultEnd.Y = CenterPoint.Y - ResultEnd.Y;

            start_transform.Text = "x坐标：" + ResultStart.X + ",Y坐标：" + ResultStart.Y;
            end_transform.Text = "x坐标：" + ResultEnd.X + ",Y坐标：" + ResultEnd.Y;

            Point leftTop = new Point(ResultStart.X, ResultStart.Y);
            int Ewidth = Math.Abs(ResultStart.X - ResultEnd.X), Eheight = Math.Abs(ResultStart.Y - ResultEnd.Y);
            if (ResultEnd.X < ResultStart.X)
                leftTop.X = ResultEnd.X;
            if (ResultEnd.Y < ResultStart.Y)
                leftTop.Y = ResultEnd.Y;
            Rectangle rect = new Rectangle(leftTop, new Size(Ewidth, Eheight));
            g.DrawEllipse(p, rect);


        }



        private void picDraw_MouseMove(object sender, MouseEventArgs e)
        {

            //每次鼠标移动的时候获取指针坐标
            ShowCoordinate(e.X,e.Y);

            if (IsDraw)
            {
                EndPoint = e.Location;
                if (dType != DrawType.Pen && dType != DrawType.Eraser)
                {
                    finishImg = (Image)originImg.Clone();
                }
                g = Graphics.FromImage(finishImg);
                g.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿  
                switch (dType)
                {
                    case DrawType.Line:
                        g.DrawLine(p, StartPoint, EndPoint);
                        break;
                    case DrawType.Pen:
                        g.DrawLine(p, StartPoint, EndPoint);
                        StartPoint = EndPoint;
                        break;
                    case DrawType.Rect:
                        Point leftTop = new Point(StartPoint.X, StartPoint.Y);
                        int width = Math.Abs(StartPoint.X - e.X), height = Math.Abs(StartPoint.Y - e.Y);
                        if (e.X < StartPoint.X)
                            leftTop.X = e.X;
                        if (e.Y < StartPoint.Y)
                            leftTop.Y = e.Y;
                        Rectangle rect = new Rectangle(leftTop, new Size(width, height));
                        g.DrawRectangle(p, rect);
                        break;
                    case DrawType.Ellipse:
                        leftTop = new Point(StartPoint.X, StartPoint.Y);
                        int Ewidth = Math.Abs(StartPoint.X - e.X), Eheight = Math.Abs(StartPoint.Y - e.Y);
                        if (e.X < StartPoint.X)
                            leftTop.X = e.X;
                        if (e.Y < StartPoint.Y)
                            leftTop.Y = e.Y;
                        rect = new Rectangle(leftTop, new Size(Ewidth, Eheight));
                        g.DrawEllipse(p, rect);
                        break;
                    case DrawType.Eraser:
                        Pen pen1 = new Pen(Color.White, 20);
                        pen1.StartCap = LineCap.Round;
                        pen1.StartCap = LineCap.Round;
                        g.DrawLine(pen1, StartPoint, EndPoint);
                        StartPoint = EndPoint;
                        pen1.Dispose();
                        break;
                    case DrawType.Write:  //写字前画虚线框  
                        leftTop = new Point(StartPoint.X, StartPoint.Y);
                        int w = Math.Abs(StartPoint.X - e.X);
                        int h = Math.Abs(StartPoint.Y - e.Y);
                        if (e.X < StartPoint.X)
                            leftTop.X = e.X;
                        if (e.Y < StartPoint.Y)
                            leftTop.Y = e.Y;
                        FontRect = new Rectangle(leftTop, new Size(w, h));
                        Pen pRect = new Pen(Color.Black);
                        pRect.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        g.DrawRectangle(pRect, FontRect);
                        pRect.Dispose();
                        break;
                }
                reDraw();
            }
        }


        private void picDraw_MouseUp(object sender, MouseEventArgs e)
        {
            GetCenterPoint();
            MatrixTransformation();

            IsDraw = false;
            originImg = (Bitmap)finishImg;
            if (dType == DrawType.Write)
            {
                //清除虚线框  
                Pen pRect = new Pen(Color.White);
                g.DrawRectangle(pRect, FontRect);
                pRect.Dispose();

                //写字文本框 呈现  
                txtWrite.SetBounds(FontRect.Left, FontRect.Top, FontRect.Width, FontRect.Height);
                txtWrite.Font = font;
                FontPoint = FontRect.Location;
                txtWrite.Visible = true;
                txtWrite.Focus();
            }

            //此句的作用是避免窗体最小化后还原窗体时，画布内容“丢失”  
            //其实没有丢失，只是没刷新而已，读者可以在画布任意处作画，便可还原画布内容  
            picDraw.Image = originImg;
        }
        /// <summary>  
        /// 重绘绘图区（二次缓冲技术）  
        /// </summary>  
        private void reDraw()
        {
            Graphics graphics = picDraw.CreateGraphics();
            graphics.DrawImage(finishImg, new Point(0, 0));
            graphics.Dispose();
        }
        /// <summary>  
        /// 在画布 写字  
        /// </summary>  
        /// <param name="str"></param>  
        private void DrawString(string str)
        {
            g.DrawString(str, font, new SolidBrush(DrawColor), FontPoint);
            reDraw();
        }
        /// <summary>  
        /// 在画布 作画  
        /// </summary>  
        /// <param name="img"></param>  
        private void DrawImage(Image img)
        {
            g = Graphics.FromImage(finishImg);
            g.DrawImage(img, new Point(0, 0));
            reDraw();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            txtWrite.Visible = false;
            txtWrite.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DrawImage(Image.FromFile(ofd.FileName));
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            txtWrite.Visible = false;
            txtWrite.Text = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "jpg|*.jpg|png|*.png|bmp|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                finishImg.Save(sfd.FileName);
            }
        }
        /// <summary>  
        /// 画笔颜色设置  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = DrawColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                DrawColor = cd.Color;
            }
        }
        /// <summary>  
        /// 画笔宽度设置  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void cmbThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            PenWidth = Convert.ToSingle(cmbThickness.Text);
        }
    }
    /// <summary>  
    /// 画笔类型  
    /// </summary>  
    enum DrawType
    {
        None,
        Pen,
        Line,
        Rect,
        Ellipse,
        Eraser,
        Write
    }
}
