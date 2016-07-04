using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WebAPITest.Controller
{
    public class UploadController : ApiController
    {
        public string postData()
        {
            {
                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
                HttpRequestBase request = context.Request;
                string postType = request.Form["postType"];
                if (postType == "START")
                {
                    string fileType = request.Form["fileType"];
                    string fileName = DateTime.Now.ToFileTime().ToString();
                    string jsonData = request.Form["json"];
                    byte[] data = HexToByte(jsonData);
                    FileStream fileStream = new FileStream(@"D:\upload\file\" + fileName + fileType, FileMode.Create);
                    fileStream.Close();
                    FileStream jsonStream = new FileStream(@"D:\upload\file\" + fileName + ".txt", FileMode.Create);
                    jsonStream.Write(data, 0, data.Length);
                    jsonStream.Close();

                    return fileName + fileType;
                }
                if (postType == "TRANS")
                {
                    string fileName = request.Form["fileName"];
                    string fileData = request.Form["data"];
                    byte[] data = HexToByte(fileData);
                    FileStream fileStream = new FileStream(@"D:\upload\file\" + fileName, FileMode.Append);
                    fileStream.Write(data, 0, data.Length);
                    fileStream.Close();
                    fileStream = new FileStream(@"D:\upload\file\" + fileName, FileMode.Open);
                    string result = fileStream.Length.ToString();
                    fileStream.Close();

                    return result;
                }
                if (postType == "END")
                {
                    string fileName = request.Form["fileName"];
                    string fileData = request.Form["data"];
                    byte[] data = HexToByte(fileData);
                    FileStream fileStream = new FileStream(@"D:\upload\file\" + fileName, FileMode.Append);
                    fileStream.Write(data, 0, data.Length);
                    fileStream.Close();

                    return "END";
                }
            }
            return "UNKNOW";
        }

        private static byte[] HexToByte(string hexString)
        {

            byte[] returnByte = null;
            if (hexString != null)
            {
                try
                {
                    returnByte = new byte[hexString.Length / 2];
                    for (int i = 0; i < returnByte.Length; i++)
                    {
                        returnByte[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                    }
                }
                finally { }
            }
            return returnByte;
        }
    }
}