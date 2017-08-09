using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.Datas
{
    public class CDBTemplate
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public class LogOnModel
        {
            [Required]
            [Display(Name ="用户名")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name ="密码")]
            public string Password { get; set; }

            [Display(Name ="下次自动登录")]
            public bool RememberMe { get; set; }

        }
    }
}