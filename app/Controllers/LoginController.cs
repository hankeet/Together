using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace app.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost, ActionName("Login")]
        public void Login(FormCollection collection)
        {
            object obj = SqlHelper.ExecuteScalar("select UserId from CDBUsers where UserName=@uname and Password=@pwd",
                         new SqlParameter("@uname", collection[0]),
                         new SqlParameter("@pwd", Weibo.Models.Myencrypt.myencrypt(collection[1])));


            if (obj != null)
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                collection[0],
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                "admins"
                );
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
            }


            Response.Redirect("~/");
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}