namespace GDIDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picDraw = new System.Windows.Forms.PictureBox();
            this.btnArrow = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnPen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbThickness = new System.Windows.Forms.ComboBox();
            this.txtWrite = new System.Windows.Forms.TextBox();
            this.Text_Coordinate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_CenterPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.start_transform = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.end_transform = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // picDraw
            // 
            this.picDraw.Location = new System.Drawing.Point(164, 12);
            this.picDraw.Name = "picDraw";
            this.picDraw.Size = new System.Drawing.Size(639, 530);
            this.picDraw.TabIndex = 0;
            this.picDraw.TabStop = false;
            this.picDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDraw_MouseDown);
            this.picDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDraw_MouseMove);
            this.picDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDraw_MouseUp);
            // 
            // btnArrow
            // 
            this.btnArrow.Location = new System.Drawing.Point(12, 12);
            this.btnArrow.Name = "btnArrow";
            this.btnArrow.Size = new System.Drawing.Size(75, 23);
            this.btnArrow.TabIndex = 1;
            this.btnArrow.Text = "箭头";
            this.btnArrow.UseVisualStyleBackColor = true;
            this.btnArrow.Click += new System.EventHandler(this.btnArrow_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(12, 332);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "画笔颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 294);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 265);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 219);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清屏";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(12, 190);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "写字";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.Location = new System.Drawing.Point(12, 161);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(75, 23);
            this.btnEraser.TabIndex = 7;
            this.btnEraser.Text = "橡皮擦";
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(12, 132);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(75, 23);
            this.btnEllipse.TabIndex = 8;
            this.btnEllipse.Text = "椭圆";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnRect
            // 
            this.btnRect.Location = new System.Drawing.Point(12, 103);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(75, 23);
            this.btnRect.TabIndex = 9;
            this.btnRect.Text = "矩形";
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(12, 74);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 10;
            this.btnLine.Text = "线";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnPen
            // 
            this.btnPen.Location = new System.Drawing.Point(12, 45);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(75, 23);
            this.btnPen.TabIndex = 11;
            this.btnPen.Text = "笔";
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "画笔粗细";
            // 
            // cmbThickness
            // 
            this.cmbThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThickness.FormattingEnabled = true;
            this.cmbThickness.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmbThickness.Location = new System.Drawing.Point(12, 383);
            this.cmbThickness.Name = "cmbThickness";
            this.cmbThickness.Size = new System.Drawing.Size(75, 20);
            this.cmbThickness.TabIndex = 13;
            this.cmbThickness.SelectedIndexChanged += new System.EventHandler(this.cmbThickness_SelectedIndexChanged);
            // 
            // txtWrite
            // 
            this.txtWrite.Location = new System.Drawing.Point(319, 103);
            this.txtWrite.Multiline = true;
            this.txtWrite.Name = "txtWrite";
            this.txtWrite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWrite.Size = new System.Drawing.Size(100, 21);
            this.txtWrite.TabIndex = 14;
            this.txtWrite.Visible = false;
            // 
            // Text_Coordinate
            // 
            this.Text_Coordinate.Location = new System.Drawing.Point(10, 459);
            this.Text_Coordinate.Name = "Text_Coordinate";
            this.Text_Coordinate.Size = new System.Drawing.Size(146, 21);
            this.Text_Coordinate.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "鼠标坐标点显示:";
            // 
            // Text_CenterPoint
            // 
            this.Text_CenterPoint.Location = new System.Drawing.Point(12, 521);
            this.Text_CenterPoint.Name = "Text_CenterPoint";
            this.Text_CenterPoint.Size = new System.Drawing.Size(144, 21);
            this.Text_CenterPoint.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "椭圆中心点：";
            // 
            // start_transform
            // 
            this.start_transform.Location = new System.Drawing.Point(616, 456);
            this.start_transform.Name = "start_transform";
            this.start_transform.Size = new System.Drawing.Size(179, 21);
            this.start_transform.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "转换后的起始点：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "转换后的结束点：";
            // 
            // end_transform
            // 
            this.end_transform.Location = new System.Drawing.Point(616, 499);
            this.end_transform.Name = "end_transform";
            this.end_transform.Size = new System.Drawing.Size(179, 21);
            this.end_transform.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 554);
            this.Controls.Add(this.end_transform);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.start_transform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Text_CenterPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Text_Coordinate);
            this.Controls.Add(this.txtWrite);
            this.Controls.Add(this.cmbThickness);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPen);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.btnRect);
            this.Controls.Add(this.btnEllipse);
            this.Controls.Add(this.btnEraser);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnArrow);
            this.Controls.Add(this.picDraw);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDraw;
        private System.Windows.Forms.Button btnArrow;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbThickness;
        private System.Windows.Forms.TextBox txtWrite;
        private System.Windows.Forms.TextBox Text_Coordinate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_CenterPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox start_transform;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox end_transform;
    }
}

