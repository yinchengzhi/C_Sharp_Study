using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UploadTest
{
    public partial class Form1 : Form
    {
        string[] filePathes = null;
        static long SIZE = 1024 * 1024 * 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathes = fileDialog.FileNames;
                MessageBox.Show("已选择" + filePathes.Length.ToString() + "个文件");
            }
        }

        private void upload_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < filePathes.Length; i++)
            {
                Thread uploadThread = new Thread(new ParameterizedThreadStart(Upload));
                uploadThread.IsBackground = true;
                uploadThread.Start(filePathes[i]);
                uploadThread.Join();
            }
        }

        public static void Upload(object obj)
        {
            string filePath = obj as string;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream, Encoding.Default);
            string fileName = filePath.Substring(filePath.LastIndexOf("."));
            string json = "name=陆启豪,age=18,sex=男";
            string postType = "START";
            string postResult = "0";
            string postData = null;
            string data = null;
            bool firstFlag = true;
            long fileLen = fileStream.Length;
            long offset = 0;
            do
            {
                if (postType == "TRANS")
                {
                    offset = Convert.ToInt64(postResult);
                    binaryReader.BaseStream.Position = offset;
                    byte[] bufArray = null;
                    if (fileLen - offset >= SIZE)
                    {
                        bufArray = binaryReader.ReadBytes((int)SIZE);
                        postType = "TRANS";
                    }
                    else
                    {
                        bufArray = binaryReader.ReadBytes((int)(fileLen - offset));
                        postType = "END";
                    }
                    data = ByteToHex(bufArray);
                    postData = "postType=" + postType + "&fileName=" + fileName + "&data=" + data;
                }
                if (postType == "START")
                {
                    json = ByteToHex(Encoding.Default.GetBytes(json));
                    postData = "postType=" + postType + "&fileType=" + fileName + "&json=" + json;
                    postType = "TRANS";
                }
                if (firstFlag)
                {
                    fileName = HttpPost(postData);
                    firstFlag = false;
                }
                else
                {
                    postResult = HttpPost(postData);
                    if (postResult == "END") break;
                    offset = Convert.ToInt64(postResult);
                }
            } while (true);
            MessageBox.Show("上传完成");
        }
        public static string HttpPost(string postDatastr)
        {
            byte[] postData = Encoding.Default.GetBytes(postDatastr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:19060/api/upload/postdata");
            CookieContainer cookie = new CookieContainer();
            request.AllowWriteStreamBuffering = false;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.CookieContainer = cookie;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
            string result = streamReader.ReadToEnd();
            requestStream.Close();
            streamReader.Close();

            return result.Replace("\"", string.Empty);
        }
        public static string ByteToHex(byte[] array)
        {
            string result=BitConverter.ToString(array);
            result = result.Replace("-", string.Empty);
            return result;
        }
    }
}
