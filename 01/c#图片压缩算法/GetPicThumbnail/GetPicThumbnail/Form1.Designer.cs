namespace GetPicThumbnail
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
            this.Compression = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ChoosePicture = new System.Windows.Forms.Button();
            this.text_picturePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Compression
            // 
            this.Compression.Location = new System.Drawing.Point(197, 216);
            this.Compression.Name = "Compression";
            this.Compression.Size = new System.Drawing.Size(75, 23);
            this.Compression.TabIndex = 0;
            this.Compression.Text = "压缩";
            this.Compression.UseVisualStyleBackColor = true;
            this.Compression.Click += new System.EventHandler(this.Compression_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(49, 23);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(142, 126);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // ChoosePicture
            // 
            this.ChoosePicture.Location = new System.Drawing.Point(197, 173);
            this.ChoosePicture.Name = "ChoosePicture";
            this.ChoosePicture.Size = new System.Drawing.Size(75, 23);
            this.ChoosePicture.TabIndex = 2;
            this.ChoosePicture.Text = "选择图片";
            this.ChoosePicture.UseVisualStyleBackColor = true;
            this.ChoosePicture.Click += new System.EventHandler(this.ChoosePicture_Click);
            // 
            // text_picturePath
            // 
            this.text_picturePath.Location = new System.Drawing.Point(49, 173);
            this.text_picturePath.Name = "text_picturePath";
            this.text_picturePath.Size = new System.Drawing.Size(142, 21);
            this.text_picturePath.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.text_picturePath);
            this.Controls.Add(this.ChoosePicture);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.Compression);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Compression;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button ChoosePicture;
        private System.Windows.Forms.TextBox text_picturePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

