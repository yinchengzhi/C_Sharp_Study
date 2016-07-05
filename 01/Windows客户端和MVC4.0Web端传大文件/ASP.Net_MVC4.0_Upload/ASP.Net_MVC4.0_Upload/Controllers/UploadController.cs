using ASP.Net_MVC4._0_Upload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace ASP.Net_MVC4._0_Upload.Controllers
{
    public class UploadController : Controller
    {
      
        //
        // GET: /Upload/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
        /// <summary>
        /// 提交方法
        /// </summary>
        /// <param name="um">模型数据</param>
        /// <param name="file">上传的文件对象，此处的参数名称要与View中的上传标签名称相同</param>
        /// <returns></returns>
        /// 

       // string PicturePath = "";

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return Content("没有文件！", "text/plain");
            }

            StringBuilder info = new StringBuilder();
            foreach (string filePicture in Request.Files)
            {
                HttpPostedFileBase postFile = Request.Files[filePicture];
                if (postFile.ContentLength == 0)
                    continue;
                string newFilePath = @"D:/";                                           //save path
                postFile.SaveAs(newFilePath + Path.GetFileName(postFile.FileName));
                info.AppendFormat("Upload File:{0}/r/n", postFile.FileName);            //info 
            }
            ViewData["Info"] = info;

            //return View("Index");
            //return RedirectToAction("Show");

            return View();
        }



        public ActionResult Show()
        {
            return View();
        }


    }
}
