
using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace 上传
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            //获取嫌疑人信息
            string name = textBox_name.Text.Trim();
            int age = Convert.ToInt32(textBox_age.Text);
            string sex = textBox_sex.Text.Trim();

            CriminalSuspect person = new CriminalSuspect();
            person.Name = name;
            person.Age = age;
            person.Sex = sex;

            //嫌疑人对象转换成JSON格式
            string CriminalJson = JsonConvert.SerializeObject(person, Formatting.Indented);

            //显示JSON数据格式
            MessageBox.Show(CriminalJson);


            //文件路径
            string PicturePath = textPath.Text.ToString();

            //获取文件名
            string PictureName = PicturePath.Substring(PicturePath.LastIndexOf(@"\") + 1);


            //PicturePath = PicturePath.Replace(" ", "*");

            //转换为二进制
            byte[] PictureBuffer = ReadImageFile(PicturePath);
            string PictureStr = BitConverter.ToString(PictureBuffer);


            //RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command");
            //string s = key.GetValue("").ToString();
            //System.Diagnostics.Process.Start(s.Substring(0, s.Length - 8), "http://localhost:23779/UploadPicTest.aspx");
            //MessageBox.Show(PostWebRequest("http://localhost:23779/UploadPicTest.aspx", PictureStr, Encoding.UTF8));


            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            byte[] arrB = encode.GetBytes("PictureName=" + PictureName + "&Picture=" + PictureStr + "&CriminalJson=" + CriminalJson);


            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://localhost:23779/UploadPicTest.aspx");
            myReq.Method = "POST";
            myReq.ContentType = "application/x-www-form-urlencoded";
            myReq.ContentLength = arrB.Length;
            Stream outStream = myReq.GetRequestStream();

            outStream.Write(arrB, 0, arrB.Length);
            outStream.Close();


            //接收HTTP做出的响应
            WebResponse myResp = myReq.GetResponse();
            Stream ReceiveStream = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(ReceiveStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            string str = null;
            while (count > 0)
            {
                str += new String(read, 0, count);
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            myResp.Close();

            //      MessageBox.Show(str);


        }

        private void SelectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK && (openFileDialog1.FileName != ""))
            {
                pictureBox.ImageLocation = openfile.FileName;
                textPath.Text = openfile.FileName;
            }
            openfile.Dispose();
        }

        private static byte[] ReadImageFile(string img)
        {
            FileInfo fileinfo = new FileInfo(img);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }



        private string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

    }


}
