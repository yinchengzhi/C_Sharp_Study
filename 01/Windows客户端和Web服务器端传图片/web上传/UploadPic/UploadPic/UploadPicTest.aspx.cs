using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Text;
using System.Collections.Specialized;



namespace UploadPic
{

    public partial class UploadPicTest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack)
            {
                Doit();
               
            }

            string type = "";
            string Re = "";
            Re += "数据传送方式：";
            if (Request.RequestType.ToUpper() == "POST")
            {
                type = "POST";
                Re += type + "<br/>参数分别是：<br/>";
                SortedList table = Param();
                if (table != null)
                {
                    foreach (DictionaryEntry De in table) { Re += "参数名：" + De.Key + " 值：" + De.Value + "<br/>"; }
                }
                else
                { Re = "你没有传递任何参数过来！"; }
            }
            else
            {
                type = "GET";
                Re += type + "<br/>参数分别是：<br/>";
                NameValueCollection nvc = GETInput();
                if (nvc.Count != 0)
                {

                    for (int i = 0; i < nvc.Count; i++)
                    {
                        Re += "参数名：" + nvc.GetKey(i) + " 值：" + nvc.GetValues(i)[0] + "<br/>";
                    }
                }
                else
                { Re = "你没有传递任何参数过来！"; }
            }


            PictureShow();
            Response.Write("<script>alert('我是弹出来的！')</script>");
            Response.Write(Re);

        }





        //获取GET返回来的数据
        private NameValueCollection GETInput()
        { return Request.QueryString; }
        // 获取POST返回来的数据
        private string PostInput()
        {
            try
            {
                System.IO.Stream s = Request.InputStream;
                int count = 0;
                byte[] buffer = new byte[1024];
                StringBuilder builder = new StringBuilder();
                while ((count = s.Read(buffer, 0, 1024)) > 0)
                {
                    builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
                }
                s.Flush();
                s.Close();
                s.Dispose();
                return builder.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }
        private SortedList Param()
        {
            string POSTStr = PostInput();
            SortedList SortList = new SortedList();
            int index = POSTStr.IndexOf("&");
            string[] Arr = { };
            if (index != -1) //参数传递不只一项
            {
                Arr = POSTStr.Split('&');
                for (int i = 0; i < Arr.Length; i++)
                {
                    int equalindex = Arr[i].IndexOf('=');
                    string paramN = Arr[i].Substring(0, equalindex);
                    string paramV = Arr[i].Substring(equalindex + 1);
                    if (!SortList.ContainsKey(paramN)) //避免用户传递相同参数
                    { SortList.Add(paramN, paramV); }
                    else //如果有相同的，一直删除取最后一个值为准
                    { SortList.Remove(paramN); SortList.Add(paramN, paramV); }
                }
            }
            else //参数少于或等于1项
            {
                int equalindex = POSTStr.IndexOf('=');
                if (equalindex != -1)
                { //参数是1项
                    string paramN = POSTStr.Substring(0, equalindex);
                    string paramV = POSTStr.Substring(equalindex + 1);
                    SortList.Add(paramN, paramV);

                }
                else //没有传递参数过来
                { SortList = null; }
            }
            return SortList;
        }

        private void Doit()
        {
            lbUploadPhoto_Click();
        }

        private static byte[] HexToByte(string hexString)
        {
            
            byte[] returnByte = new byte[hexString.Length / 2];
            for (int i = 0; i < returnByte.Length; i++)
            {
                returnByte[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnByte;
        }


        protected void PictureShow()
        {

            string PictureStr = Request.Form["PictureName"];
            if (PictureStr != null)
            {
                PictureStr = PictureStr.Replace("-", string.Empty);
                byte[] PictureByte = HexToByte(PictureStr);
                if (!File.Exists("D:\\Picture.png"))
                {
                    FileStream fs = new FileStream("D:\\Picture.png", FileMode.Create);
                    fs.Write(PictureByte, 0, PictureByte.Length);
                    fs.Close();
                }
                else
                {
                    FileStream fs = new FileStream("D:\\Picture.png", FileMode.Create);
                    fs.Write(PictureByte, 0, PictureByte.Length);
                    fs.Close();
                }
            }

            ////取得文件的扩展名,并转换成小写
            //string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
            ////验证上传文件是否图片格式

            //string filepath = "/upload/images/";
            //string activitecode = Guid.NewGuid().ToString().Replace("-", "");
            //if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
            //{
            //    Directory.CreateDirectory(Server.MapPath(filepath));
            //}
            //string virpath = filepath + activitecode + fileExtension;//这是存到服务器上的虚拟路径
            //string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
            //pic_upload.PostedFile.SaveAs(mappath);//保存图片
            //                                      //显示图片
            //pic.ImageUrl = virpath;
            ////清空提示
            //lbl_pic.Text = "";

        }



        /// <summary>上传图片 </summary>
        protected void lbUploadPhoto_Click()
        {
            Boolean fileOk = false;

            if (pic_upload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (pic_upload.PostedFile.ContentLength < 8192000)
                    {
                        string filepath = "/upload/images/";
                        string activitecode = Guid.NewGuid().ToString().Replace("-", "");
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        string virpath = filepath + activitecode + fileExtension;//这是存到服务器上的虚拟路径
                        string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                        pic_upload.PostedFile.SaveAs(mappath);//保存图片
                        //显示图片
                        pic.ImageUrl = virpath;
                        //清空提示
                        lbl_pic.Text = "";
                    }
                    else
                    {
                        pic.ImageUrl = "";
                        lbl_pic.Text = "文件大小超出8M！请重新选择！";
                    }
                }
                else
                {
                    pic.ImageUrl = "";
                    lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                }
            }
            else
            {
                pic.ImageUrl = "";
                lbl_pic.Text = "请选择要上传的图片！";
            }
        }

        /// <summary>验证是否指定的图片格式 </summary>
        public bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }
    }
}