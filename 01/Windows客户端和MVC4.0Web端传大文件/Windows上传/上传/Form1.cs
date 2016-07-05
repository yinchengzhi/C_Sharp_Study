
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


            //转换为二进制
            byte[] PictureBuffer = ReadImageFile(PicturePath);
            string PictureStr = BitConverter.ToString(PictureBuffer);


            SendPost(PicturePath);


        }

        //Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        ////byte[] arrB = encode.GetBytes("PictureName=" + PictureName + "&Picture=" + PictureStr + "&CriminalJson=" + CriminalJson);
        //byte[] arrB = encode.GetBytes("Picture=" + PictureStr);

        //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://localhost:1246/Upload/Upload");

        //myReq.Method = "POST";
        //myReq.ContentType = "multipart/form-data";
        //myReq.ContentLength = arrB.Length;
        //Stream outStream = myReq.GetRequestStream();
        //outStream.Write(arrB, 0, arrB.Length);
        //outStream.Close();


        ////接收HTTP做出的响应
        //WebResponse myResp = myReq.GetResponse();
        //Stream ReceiveStream = myResp.GetResponseStream();
        //StreamReader readStream = new StreamReader(ReceiveStream, encode);
        //Char[] read = new Char[256];
        //int count = readStream.Read(read, 0, 256);
        //string str = null;
        //while (count > 0)
        //{
        //    str += new String(read, 0, count);
        //    count = readStream.Read(read, 0, 256);
        //}
        //readStream.Close();
        //myResp.Close();


        private void SendPost(string PicturePath)
        {
            CredentialCache credentialCache = new CredentialCache();
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:1246/Upload/Upload");
            httpWebRequest.Credentials = credentialCache;
            httpWebRequest.CookieContainer = cookies;
            WebResponse webResponse = httpWebRequest.GetResponse();
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://localhost:1246/Upload/Upload");
            httpWebRequest2.Credentials = credentialCache;
            httpWebRequest2.CookieContainer = cookies;
            httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest2.Method = "POST";

            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"file\"; filename=\"");
            sb.Append(Path.GetFileName(PicturePath));
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);
            // Build the trailing boundary string as a byte array 
            // ensuring the boundary appears on a line by itself 
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            FileStream fileStream = new FileStream(PicturePath, FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            httpWebRequest2.ContentLength = length;

            Stream requestStream = httpWebRequest2.GetRequestStream();

            //write out our post header
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            //Write out the file contents
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            //Write out the trailing boundary
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
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



    }


}
