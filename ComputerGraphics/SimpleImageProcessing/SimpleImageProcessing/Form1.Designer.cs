namespace SimpleImageProcessing
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PicturePath = new System.Windows.Forms.TextBox();
            this.Select_Picrture = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(76, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 259);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PicturePath
            // 
            this.PicturePath.Location = new System.Drawing.Point(76, 306);
            this.PicturePath.Name = "PicturePath";
            this.PicturePath.Size = new System.Drawing.Size(277, 21);
            this.PicturePath.TabIndex = 1;
            // 
            // Select_Picrture
            // 
            this.Select_Picrture.Location = new System.Drawing.Point(359, 304);
            this.Select_Picrture.Name = "Select_Picrture";
            this.Select_Picrture.Size = new System.Drawing.Size(75, 23);
            this.Select_Picrture.TabIndex = 2;
            this.Select_Picrture.Text = "选择图片";
            this.Select_Picrture.UseVisualStyleBackColor = true;
            this.Select_Picrture.Click += new System.EventHandler(this.Select_Picrture_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(359, 408);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 3;
            this.Run.Text = "生成";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 458);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.Select_Picrture);
            this.Controls.Add(this.PicturePath);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PicturePath;
        private System.Windows.Forms.Button Select_Picrture;
        private System.Windows.Forms.Button Run;
    }
}

