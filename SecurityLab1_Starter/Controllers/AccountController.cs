
using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using ServiceStack.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthDemo.Controllers
{
    public class AccountController : Controller
    {
        SecurityLab1_Starter.Infrastructure.Abstract.IAuthProvider authProvider;

        public AccountController(SecurityLab1_Starter.Infrastructure.Abstract.IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    Logger logger = new Logger();
                    using (StreamWriter w = System.IO.File.AppendText("C:\\Users\\Haroon\\source\\repos\\420-613-LA-Security-Lab1-Starter\\SecurityLab1_Starter\\useraccess.log"))
                    {
                        logger.Log(model.UserName + " logged in.", w);
                    }

                    return Redirect(Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Logger logger = new Logger();
            using (StreamWriter w = System.IO.File.AppendText("C:\\Users\\Haroon\\source\\repos\\420-613-LA-Security-Lab1-Starter\\SecurityLab1_Starter\\useraccess.log"))
            {
                logger.Log(User.Identity.Name + " logged out.", w);
            }
            FormsAuthentication.SignOut();
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}