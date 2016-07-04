namespace UploadTest
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
            this.choose = new System.Windows.Forms.Button();
            this.upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choose
            // 
            this.choose.Location = new System.Drawing.Point(78, 26);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(120, 60);
            this.choose.TabIndex = 0;
            this.choose.Text = "选择文件";
            this.choose.UseVisualStyleBackColor = true;
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(78, 118);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(120, 60);
            this.upload.TabIndex = 1;
            this.upload.Text = "上传文件";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 201);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.choose);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.Button upload;
    }
}

