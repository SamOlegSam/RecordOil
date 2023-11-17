using RecordOil.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using System.Text;
using System.Data.Entity.Validation;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Xceed.Words.NET;

namespace RecordOil.Controllers
{
    public class AccountController : Controller
    {
        public RecordOilEntities db1 = new RecordOilEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Autorize user = null;
                using (RecordOilEntities db = new RecordOilEntities())
                {
                    user = db.Autorize.FirstOrDefault(u => u.Login == model.Name && u.Password == model.Password);
                }

                if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                    
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");

                    }
            }

            return View(model);
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UsersAutorize user = null;
        //        using (UsersContext db = new UsersContext())
        //        {
        //            user = db.UserssAutorize.FirstOrDefault(u => u.Login == model.Name);
        //        }
        //        if (user == null)
        //        {
        //            // создаем нового пользователя
        //            using (UsersContext db = new UsersContext())
        //            {
        //                db.UserssAutorize.Add(new UsersAutorize { Login = model.Name, Password = model.Password, Role = model.Role });
        //                db.SaveChanges();

        //                user = db.UserssAutorize.Where(u => u.Login == model.Name && u.Password == model.Password).FirstOrDefault();
        //            }
        //            // если пользователь удачно добавлен в бд
        //            if (user != null)
        //            {
        //                FormsAuthentication.SetAuthCookie(model.Name, true);
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Пользователь с таким логином уже существует");
        //        }
        //    }

        //    return View(model);
        //}
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
