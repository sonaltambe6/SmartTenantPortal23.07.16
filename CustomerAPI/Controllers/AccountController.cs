using CustomerAPI.Models;
using CustomerBLL.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomerAPI.Controllers
{
    //[RoutePrefix("api/loginapi")]
    public class AccountController : Controller
    {

        private CustomMembershipProvider CustomProvider
        {
            get
            {
                return new CustomMembershipProvider();
            }
        }

        [AllowAnonymous]
        [HttpPost]        
        public JsonResult UserLogin(LogOnModel model)
        {
            bool isUserValid = false;

            isUserValid = CustomProvider.ValidateUser(model.UserName, model.Password);

            if (isUserValid)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            //using (ManageCustomersEntities ctx = new ManageCustomersEntities())
            //{
            //    var _ob = ctx.UserMs.SingleOrDefault(b => b.UserName == model.UserName && b.UserPassword == model.Password);
            //    if (_ob != null)
            //    {
            //        FormsAuthentication.SignOut();
            //        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    
            //        return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };                    
            //    }
            //}
            return null;                       
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.HttpContext.User.Identity.Name != null &&
                       this.HttpContext.User.Identity!= null &&
                       this.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

    }   
}
