using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.Net_MVC4._0_Upload.Models
{
    public class UploadModel
    {
        [Display(Name = "姓名")]
        [Required]
        public string Name
        {
            get;
            set;
        }
        [Display(Name = "年龄")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Age
        {
            get;
            set;
        }
        [Display(Name = "性别")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Sex
        {
            get;
            set;
        }

        public string AttachmentPath
        {
            get;
            set;
        }
    }
}