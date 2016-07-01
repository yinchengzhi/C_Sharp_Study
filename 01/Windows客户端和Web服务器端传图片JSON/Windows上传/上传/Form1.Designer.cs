namespace 上传
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
            this.UploadButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectPicture = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_age = new System.Windows.Forms.TextBox();
            this.textBox_sex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(495, 389);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(101, 41);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "上传";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(85, 33);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(201, 210);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择照片的路径：";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(85, 290);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(201, 21);
            this.textPath.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectPicture
            // 
            this.SelectPicture.Location = new System.Drawing.Point(136, 344);
            this.SelectPicture.Name = "SelectPicture";
            this.SelectPicture.Size = new System.Drawing.Size(101, 23);
            this.SelectPicture.TabIndex = 4;
            this.SelectPicture.Text = "选择图片";
            this.SelectPicture.UseVisualStyleBackColor = true;
            this.SelectPicture.Click += new System.EventHandler(this.SelectPicture_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(407, 33);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(146, 21);
            this.textBox_name.TabIndex = 5;
            // 
            // textBox_age
            // 
            this.textBox_age.Location = new System.Drawing.Point(407, 104);
            this.textBox_age.Name = "textBox_age";
            this.textBox_age.Size = new System.Drawing.Size(146, 21);
            this.textBox_age.TabIndex = 6;
            // 
            // textBox_sex
            // 
            this.textBox_sex.Location = new System.Drawing.Point(407, 180);
            this.textBox_sex.Name = "textBox_sex";
            this.textBox_sex.Size = new System.Drawing.Size(146, 21);
            this.textBox_sex.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "年龄：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "性别：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 457);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_sex);
            this.Controls.Add(this.textBox_age);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.SelectPicture);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.UploadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SelectPicture;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_age;
        private System.Windows.Forms.TextBox textBox_sex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

