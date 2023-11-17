using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using RecordOil.Models;
using System.Text;
using System.Data.Entity.Validation;
using System.Text.Json;
using Newtonsoft.Json;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using  Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Xceed.Words.NET;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Runtime.InteropServices.ComTypes;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;
using Independentsoft.Office.Word.HeaderFooter;
using Page = Independentsoft.Office.Word.Fields.Page;

namespace RecordOil.Controllers
{    [Authorize]
    public class HomeController : Controller
    {

        public RecordOilEntities db = new RecordOilEntities();
        public ActionResult Index()
        {
            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(f=>f.Priznak != 1).ToList();
                        
            return View(zay);
        }

        //----------------Пользователи--------------------------//
        public ActionResult PrintReport()
        {
            
            return PartialView();
        }
        //------------------------------------------------------//
        //----------------Организации--------------------------//

        public ActionResult Organiz()
        {
            List<Organization> organiz = new List<Organization>();
            organiz = db.Organization.OrderBy(h => h.Name).ToList();   
                        
            return View(organiz);
        }
        //------------------------------------------------------//
        
        //----------Добавление организации-----------------------//

        public ActionResult AddOrganiz()
        {            
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления организации-----------//
        [HttpPost]
        public ActionResult OrganizSave(string NaimenovanieOrg, int PriznakOrg, string UserOrg, DateTime DateOrg, string PrefixOrg)
        {
            try
            {
                Organization org = new Organization();
                org.Name = NaimenovanieOrg.Trim();
                org.Priznak = PriznakOrg;
                org.UserModific = UserOrg.Trim();
                org.DateModific = DateOrg;
                org.Prefix = PrefixOrg.Trim();
                db.Organization.Add(org);

                db.SaveChanges();

                ViewBag.Message = "Организация успешно добавлена!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
                
        // удаление организации//

        public ActionResult DeleteOrganiz(int ID)
        {
            Organization orgDel = new Organization();
            orgDel = db.Organization.FirstOrDefault(a => a.IdOrg == ID);
            return PartialView(orgDel);
        }
        //-----------------------------//

        // Подтверждение удаления организации//
        public ActionResult DeleteOrganizOK(int ID)
        {
            try
            {
                Organization orgDS = new Organization();
                orgDS = db.Organization.FirstOrDefault(a => a.IdOrg == ID);
                db.Organization.Remove(orgDS);
                db.SaveChanges();

                ViewBag.Message = "Организация удалена!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // Редактирование организации//

        public ActionResult OrganizEdit(int ID)
        {
            Organization orgEd = new Organization();
            orgEd = db.Organization.FirstOrDefault(a => a.IdOrg == ID);
                        
            return PartialView(orgEd);
        }
        //-------------------------------//

        //Сохранение редактирования организации------------//
        [HttpPost]
        public ActionResult OrganizEditSave(int ID,string NaimenovanieOrgEdit, int PriznakOrgEdit, string UserOrgEdit, DateTime DateOrgEdit, string PrefixEdit)
        {
            try
            {
                Organization orgE = new Organization();
                orgE = db.Organization.FirstOrDefault(s => s.IdOrg == ID);

                orgE.Name = NaimenovanieOrgEdit.Trim();
                orgE.Priznak = PriznakOrgEdit;
                orgE.UserModific = UserOrgEdit.Trim();
                orgE.DateModific = DateOrgEdit;
                orgE.Prefix = PrefixEdit.Trim();
                db.SaveChanges();

                ViewBag.Message = "организация изменена";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//

        //----------------Пользователи--------------------------//
        public ActionResult Users()
        {
            List<Users> users = new List<Users>();
            users = db.Users.OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//
        
        public ActionResult UsersGomel()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 3).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//

        public ActionResult UsersAU()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g => g.idFil == 14).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//


        public ActionResult UsersMozyr()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 2).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//
        
        public ActionResult UsersPinsk()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 5).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//
        
        public ActionResult UsersTurov()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 6).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//
        //----------------Пользователи--------------------------//
        public ActionResult UsersKobrin()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 7).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//
        
        public ActionResult UsersCBPO()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 8).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//
        //----------------Пользователи--------------------------//
        public ActionResult UsersNovopolock()
        {
            List<Users> users = new List<Users>();
            users = db.Users.Where(g=>g.idFil == 9).OrderBy(h => h.LastName).ToList();

            return View(users);
        }
        //------------------------------------------------------//

        //----------Добавление пользователя-----------------------//

        public ActionResult AddUsers()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g=>g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h=>h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSave(string LastName, string FirstName, string MiddleName, int idFil, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = idFil;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //---------------------------Добавление пользователей филиалов---------------------------------------------------------------------------------------------------------------------------
        //----------Добавление пользователя  ГОМЕЛЬ-----------------------//
        public ActionResult AddUsersGomel()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSaveGomel(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 3;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление пользователя  Мозырь-----------------------//
        public ActionResult AddUsersMozyr()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSaveMozyr(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 2;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление пользователя  Пинск-----------------------//
        public ActionResult AddUsersPinsk()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSavePinsk(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 5;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление пользователя  Туров-----------------------//
        public ActionResult AddUsersTurov()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSaveTurov(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 6;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление пользователя  Кобрин-----------------------//
        public ActionResult AddUsersKobrin()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSaveKobrin(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 7;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление пользователя  ЦБПО-----------------------//
        public ActionResult AddUsersCBPO()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSaveCBPO(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 8;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление пользователя  Новополоцк-----------------------//
        public ActionResult AddUsersNovopolock()
        {

            SelectList Dolj = new SelectList(db.Doljnost.OrderBy(g => g.Naimenovanie), "idDolj", "Naimenovanie");
            ViewBag.DoljUs = Dolj;

            SelectList Filial = new SelectList(db.Organization.OrderBy(h => h.Name), "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления пользователя-----------//
        [HttpPost]
        public ActionResult UsersSaveNovopolock(string LastName, string FirstName, string MiddleName, int idDolj, string UserUs, DateTime DateUs, string PhoneU)
        {
            try
            {
                Users useradd = new Users();
                useradd.LastName = LastName.Trim();
                useradd.FirstName = FirstName.Trim();
                useradd.MidleName = MiddleName.Trim();
                useradd.idFil = 9;
                useradd.idDolj = idDolj;
                useradd.Phone = PhoneU.Trim();
                useradd.UserModific = UserUs.Trim();
                useradd.DateModific = DateUs;
                db.Users.Add(useradd);

                db.SaveChanges();

                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // удаление пользователя//

        public ActionResult DeleteUsers(int ID)
        {
            Users UserDel = new Users();
            UserDel = db.Users.FirstOrDefault(a => a.IdUserrs == ID);
            return PartialView(UserDel);
        }
        //-----------------------------//

        // Подтверждение удаления пользователя//
        public ActionResult DeleteUsersOK(int ID)
        {
            try
            {
                Users UsDS = new Users();
                UsDS = db.Users.FirstOrDefault(a => a.IdUserrs == ID);
                db.Users.Remove(UsDS);
                db.SaveChanges();

                ViewBag.Message = "пользователь удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // Редактирование пользователя//

        public ActionResult UsersEdit(int ID)
        {
            //SelectList Dolj = new SelectList(db.Doljnost, "idDolj", "Naimenovanie");
            
            List<Doljnost> Dolj = new List<Doljnost>();
            Dolj = db.Doljnost.OrderBy(j=>j.Naimenovanie).ToList();
            ViewBag.DoljUsED = Dolj;

            //SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            
            List<Organization> Filial = new List<Organization>();
            Filial = db.Organization.ToList();
            ViewBag.FilUsED = Filial;

            Users UsEd = new Users();
            UsEd = db.Users.FirstOrDefault(a => a.IdUserrs == ID);
            return PartialView(UsEd);
        }
        //-------------------------------//

        //Сохранение редактирования пользователя------------//
        [HttpPost]
        public ActionResult UsersEditSave(int ID, string LastNameEdit, string FirstNameEdit, string MiddleNameEdit, int idFilEdit, int idDoljEdit, string UserUsEdit, DateTime DateUsEdit, string PhoneUE, int priznakU)
        {
            try
            {              
                Users UsE = new Users();
                UsE = db.Users.FirstOrDefault(s => s.IdUserrs == ID);
               
               //if (priznakU == 1)
               // {
               //     List<Users> LIU = new List<Users>();
               //     LIU = db.Users.Where(t => t.idFil == UsE.idFil).ToList();
               //     foreach(var i in LIU)
               //     {
               //         i.Podpisant = null;
               //     }
               // }

                UsE.LastName = LastNameEdit.Trim();
                UsE.FirstName = FirstNameEdit.Trim();
                UsE.MidleName = MiddleNameEdit.Trim();
                UsE.idDolj = idDoljEdit;
                UsE.idFil = idFilEdit;
                UsE.Phone = PhoneUE;
                UsE.UserModific = UserUsEdit.Trim();
                UsE.DateModific = DateUsEdit;
                if (priznakU == 0)
                {
                    UsE.Podpisant = null;
                }
                else
                {
                  UsE.Podpisant = 1;
                }
                
                
                db.SaveChanges();

                ViewBag.Message = "Пользователь изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//


        //----------------Должности--------------------------//
        public ActionResult Dolj()
        {
            List<Doljnost> dolj = new List<Doljnost>();
            dolj = db.Doljnost.OrderBy(h => h.Naimenovanie).ToList();

            return View(dolj);
        }
        //------------------------------------------------------//
        //----------Добавление должности-----------------------//

        public ActionResult AddDolj()
        {                        
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления должности-----------//
        [HttpPost]
        public ActionResult DoljSave(string NaimenovanieDolj, string UserDolj, DateTime DateDolj)
        {
            try
            {
                Doljnost dol = new Doljnost();
                dol.Naimenovanie = NaimenovanieDolj.Trim();
                dol.UserModific = UserDolj.Trim();
                dol.DateModific = DateDolj;
                db.Doljnost.Add(dol);

                db.SaveChanges();

                ViewBag.Message = "Должность успешно добавлена!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        // удаление должности//

        public ActionResult DeleteDolj(int ID)
        {
            Doljnost DolDel = new Doljnost();
            DolDel = db.Doljnost.FirstOrDefault(a => a.IdDolj == ID);
            

            return PartialView(DolDel);
        }
        //-----------------------------//

        // Подтверждение удаления должности//
        public ActionResult DeleteDoljOK(int ID)
        {
            try
            {
                Doljnost DoljDS = new Doljnost();
                DoljDS = db.Doljnost.FirstOrDefault(a => a.IdDolj == ID);
                db.Doljnost.Remove(DoljDS);
                db.SaveChanges();

                ViewBag.Message = "Должность удалена!";
            }
            catch
            {
            List<Users> LU = new List<Users>();
            LU = db.Users.Where(g => g.idDolj == ID).ToList();
                string str = "Ошибка удаления! Данные используются в других каталогах";
                
                foreach (var i in LU)
                {
                    str += i.FirstName + " " +  i.LastName + " ";
                    
                }
                ViewBag.Message = str;
            }

            return PartialView();
        }
        // Редактирование должности//

        public ActionResult DoljEdit(int ID)
        {            
            Doljnost DoljEd = new Doljnost();
            DoljEd = db.Doljnost.FirstOrDefault(a => a.IdDolj == ID);
            return PartialView(DoljEd);
        }
        //-------------------------------//

        //Сохранение редактирования должности------------//
        [HttpPost]
        public ActionResult DoljEditSave(int ID, string NaimenovanieDoljEdit, string UserDoljEdit, DateTime DateDoljEdit)
        {
            try
            {
                Doljnost DoljE = new Doljnost();
                DoljE = db.Doljnost.FirstOrDefault(s => s.IdDolj == ID);

                DoljE.Naimenovanie = NaimenovanieDoljEdit.Trim();
                DoljE.UserModific = UserDoljEdit.Trim();
                DoljE.DateModific = DateDoljEdit;
                db.SaveChanges();

                ViewBag.Message = "Должность изменена";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//

        //----------------Нефтепродукты--------------------------//
        public ActionResult Nefteprod()
        {
            List<Nefteproduct> neft = new List<Nefteproduct>();
            neft = db.Nefteproduct.OrderBy(h => h.Naimenovanie).ToList();

            return View(neft);
        }
        //------------------------------------------------------//

        //----------Добавление нефтепродукта-----------------------//

        public ActionResult AddNefteprod()
        {
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления нефтепродукта-----------//
        [HttpPost]
        public ActionResult NefteprodSave(string NaimenovanieNeft, string UserNeft, DateTime DateNeft, decimal PNeft, string PrimNeft)
        {
            try
            {
                Nefteproduct neft = new Nefteproduct();
                neft.Naimenovanie = NaimenovanieNeft.Trim();
                neft.UserModific = UserNeft.Trim();
                neft.DateModific = DateNeft;
                neft.P = PNeft;
                neft.Primech = PrimNeft;
                neft.PriznakIsp = 1;
                db.Nefteproduct.Add(neft);

                db.SaveChanges();

                ViewBag.Message = "Нефтепродукт успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        // удаление нефтепродукта//

        public ActionResult DeleteNeft(int ID)
        {
            Nefteproduct neftDel = new Nefteproduct();
            neftDel = db.Nefteproduct.FirstOrDefault(a => a.IdNeft == ID);
            return PartialView(neftDel);
        }
        //-----------------------------//

        // Подтверждение удаления нефтепродукта//
        public ActionResult DeleteNeftOK(int ID)
        {
            try
            {
                Nefteproduct neftDS = new Nefteproduct();
                neftDS = db.Nefteproduct.FirstOrDefault(a => a.IdNeft == ID);
                db.Nefteproduct.Remove(neftDS);
                db.SaveChanges();

                ViewBag.Message = "Нефтепродукт удалена!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // Редактирование нефтепродукта//

        public ActionResult NeftEdit(int ID)
        {
            Nefteproduct neftEd = new Nefteproduct();
            neftEd = db.Nefteproduct.FirstOrDefault(a => a.IdNeft == ID);
            return PartialView(neftEd);
        }
        //-------------------------------//

        //Сохранение редактирования нефтепродукта------------//
        [HttpPost]
        public ActionResult NeftEditSave(int ID, string NaimenovanieNeftEdit, string UserNeftEdit, DateTime DateNeftEdit, decimal PNeftEdit, string PrimNeftEdit, int PriznakNeftEdit)
        {
            try
            {
                Nefteproduct neftjE = new Nefteproduct();
                neftjE = db.Nefteproduct.FirstOrDefault(s => s.IdNeft == ID);

                neftjE.Naimenovanie = NaimenovanieNeftEdit.Trim();
                neftjE.P = PNeftEdit;
                neftjE.Primech = PrimNeftEdit;
                neftjE.PriznakIsp = PriznakNeftEdit;
                neftjE.UserModific = UserNeftEdit.Trim();
                neftjE.DateModific = DateNeftEdit;
                db.SaveChanges();

                ViewBag.Message = "Нефтепродукт изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//

        //----------------Резервуары--------------------------//
        public ActionResult Rezervuary()
        {
            List<Rezervuary> rez = new List<Rezervuary>();
            rez = db.Rezervuary.OrderByDescending(h => h.IdRez).ToList();

            return View(rez);
        }
        //------------------------------------------------------//
        //----------Добавление резервуара-----------------------//

        public ActionResult AddRezer()
        {                        
            SelectList FilialRez = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilRez = FilialRez;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления резервуара-----------//
        [HttpPost]
        public ActionResult RezerSave(string NaimenovanieRez, decimal VpolRez, decimal VItogRez, int idFilRez, string UserRez, DateTime DateRez)
        {
            try
            {
                Rezervuary rez = new Rezervuary();
                rez.Naimenovanie = NaimenovanieRez.Trim();
                rez.Vpolezn = VpolRez;
                rez.Vitog = VItogRez;
                rez.idSklad = idFilRez;
                rez.UserModific = UserRez.Trim();
                rez.DateModific = DateRez;
                db.Rezervuary.Add(rez);

                db.SaveChanges();

                ViewBag.Message = "Резервуар успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        // удаление резервуара//

        public ActionResult DeleteRezer(int ID)
        {
            Rezervuary RezerDel = new Rezervuary();
            RezerDel = db.Rezervuary.FirstOrDefault(a => a.IdRez == ID);
            return PartialView(RezerDel);
        }
        //-----------------------------//

        // Подтверждение удаления резервуара//
        public ActionResult DeleteRezerOK(int ID)
        {
            try
            {
                Rezervuary RezerDS = new Rezervuary();
                RezerDS = db.Rezervuary.FirstOrDefault(a => a.IdRez == ID);
                db.Rezervuary.Remove(RezerDS);
                db.SaveChanges();

                ViewBag.Message = "Резервуар удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // Редактирование резервуара//

        public ActionResult RezerEdit(int ID)
        {            
            SelectList FilialR = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilREZED = FilialR;

            Rezervuary RezerEd = new Rezervuary();
            RezerEd = db.Rezervuary.FirstOrDefault(a => a.IdRez == ID);
            return PartialView(RezerEd);
        }
        //-------------------------------//

        //Сохранение редактирования резервуара------------//
        [HttpPost]
        public ActionResult RezerEditSave(int ID, string NaimenovanieEdit, decimal VPolEdit, decimal VItogEdit, int idFilEdit, string UserRezEdit, DateTime DateRezEdit)
        {
            try
            {
                Rezervuary RezerE = new Rezervuary();
                RezerE = db.Rezervuary.FirstOrDefault(s => s.IdRez == ID);

                RezerE.Naimenovanie = NaimenovanieEdit.Trim();
                RezerE.Vpolezn = VPolEdit;
                RezerE.Vitog = VItogEdit;
                RezerE.idSklad = idFilEdit;
                RezerE.UserModific = UserRezEdit.Trim();
                RezerE.DateModific = DateRezEdit;
                db.SaveChanges();

                ViewBag.Message = "Резервуар изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//


        //----------------Договоры--------------------------//
        public ActionResult Dogovor()
        {
            List<Dogovory> dog = new List<Dogovory>();
            dog = db.Dogovory.OrderByDescending(h => h.DateDog).ToList();

            return View(dog);
        }
        //------------------------------------------------------//

        //----------Добавление договора-----------------------//

        public ActionResult AddDogovor()
        {
            SelectList Organiz = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilOrg = Organiz;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления договора-----------//
        [HttpPost]
        public ActionResult DogovorSave(string NumberDog, DateTime DateDogM, DateTime S, DateTime Po, int OrganizDog, string PrimDog, string UserDog, DateTime DateDog)
        {
            List<Nefteproduct> SpisNeft = new List<Nefteproduct>();
            SpisNeft = db.Nefteproduct.Where(h => h.PriznakIsp ==1).ToList();
            List<string> spneft = new List<string>();

            // Получим список месяц-год от S до Po--------------
            List<DateTime> ListDate = new List<DateTime>();

            for (DateTime ss = S; ss <= Po; ss = ss.AddMonths(1))
            {
               ListDate.Add(ss);
            }
            //--------------------------------------------------
            foreach (var i in SpisNeft)
            {
                spneft.Add(i.Naimenovanie);
            }
            ViewBag.ListDat = ListDate;
            ViewBag.SpisNeft = spneft;
            ViewBag.SpisNeft1 = SpisNeft;
            return PartialView();
        }
        //----------------------------------//


        // удаление договора//

        public ActionResult DeleteDogovor(int ID)
        {
            Dogovory DogDel = new Dogovory();
            DogDel = db.Dogovory.FirstOrDefault(a => a.IdDog == ID);
            return PartialView(DogDel);
        }
        //-----------------------------//

        // Подтверждение удаления договора//
        public ActionResult DeleteDogovorOK(int ID)
        {
            try
            {
                Dogovory DogDS = new Dogovory();
                DogDS = db.Dogovory.FirstOrDefault(a => a.IdDog == ID);
                db.Dogovory.Remove(DogDS);

                List<TableDog> ListTD = new List<TableDog>();
                ListTD = db.TableDog.Where(f => f.IdDog == ID).ToList();
                
                foreach (var t in ListTD)
                {
                    db.TableDog.Remove(t);
                }

                db.SaveChanges();

                ViewBag.Message = "Договор удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        //--------------------------------------------
        // Редактирование договора//

        public ActionResult DogovorEdit(int ID)
        {
            
            SelectList OrganizE = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilOrgE = OrganizE;
            
            //Получаем запись с номером нашим номером договора 
            Dogovory dogE = new Dogovory();
            dogE = db.Dogovory.FirstOrDefault(a => a.IdDog == ID);
            ViewBag.dogE = dogE;

            //Получаем список записей с id номера договора из таблицы TableDog            
            List<TableDog> ListTD = new List<TableDog>();
            ListTD = db.TableDog.Where(f => f.IdDog == ID).ToList();
            ViewBag.ListTD = ListTD;

            //Получаем список нефтепродуктов
            List<Nefteproduct> ListN = new List<Nefteproduct>();
            ListN = db.Nefteproduct.ToList();
            ViewBag.ListN = ListN;

            return PartialView(dogE);
        }
        //-------------------------------//

        //Сохранение редактирования договора------------//
        [HttpPost]
        public ActionResult DogovorEditSave(int ID, string NumberDogE, DateTime DateDogME, int OrganizDogE, string PrimDogE, string UserDogE, DateTime DateDogE, List<TabDog> TabDogE)
        {
            try
            {
                Dogovory dogE = new Dogovory();
                dogE = db.Dogovory.FirstOrDefault(s => s.IdDog == ID);

                dogE.NumberDog = NumberDogE.Trim();
                dogE.DateDog = DateDogME;
                dogE.IdOrg = OrganizDogE;
                dogE.Primech = PrimDogE;
                dogE.UserModific = UserDogE.Trim();
                dogE.DateModific = DateDogE;
                db.SaveChanges();

                foreach(var item in TabDogE)
                {
                    TableDog TDE = new TableDog();
                    TDE = db.TableDog.FirstOrDefault(s => s.IdTD == item.IdTd);

                    TDE.Massa = item.Massa;
                    TDE.Primech = item.Primech;                    
                    db.SaveChanges();
                }
                ViewBag.Message = "Договор успешно изменен!";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//

        public ActionResult Array()
        {
            return View();
        }
        [HttpPost]
        public string Array(List<string> names)
        {
            string fin = "";
            for (int i = 0; i < names.Count; i++)
            {
                fin += names[i]; 
            }
            return fin;                        
        }

        //-----------------------------------------------------
        [HttpPost]
        public ActionResult DogovorSaveOk(string NumberDog, DateTime DateDogM, int OrganizDog, string PrimDog, string UserDog, DateTime DateDog, List<TabDog> TabDog)
        {

            try
            {
                //Записываем данные в таблицу Dogovory
                Dogovory dog = new Dogovory();
                dog.NumberDog = NumberDog.Trim();
                dog.DateDog = DateDogM;
                dog.IdOrg = OrganizDog;
                dog.Primech = PrimDog;
                dog.UserModific = UserDog.Trim();
                dog.DateModific = DateDog;
                db.Dogovory.Add(dog);

                db.SaveChanges();
                //--------------------------------------
                //Теперь работаем с таблицей TableDog

                TableDog TD = new TableDog();

                int IDDOD = db.Dogovory.FirstOrDefault(g => g.NumberDog.Trim() == NumberDog.Trim() & g.DateDog == DateDogM).IdDog;
                
                foreach(var it in TabDog)
                {
                    int IDN = db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.IdNeft.Trim()).IdNeft;

                    TD.DateMonth = it.DateDog;
                    TD.IdDog = IDDOD;
                    TD.IdNeft = IDN;
                    TD.Massa = it.Massa;
                    TD.Primech = it.Primech;
                    TD.UserModific = UserDog;
                    TD.DateModific = DateDog;
                    db.TableDog.Add(TD);
                    db.SaveChanges();
                }
               

                ViewBag.Message = "Договор успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult Zayavki()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            SelectList Filials = new SelectList(db.Organization.Where(f=>f.Priznak ==1), "Name", "Name");
            ViewBag.FILIALS = Filials;

            List<Zayavka> zay = new List<Zayavka>();
            //zay = db.Zayavka.Where(g => g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now).OrderByDescending(g=>g.DatePlan).ThenBy(l=>l.Organization.Name).ThenByDescending(k=>k.NumberSch).ToList();
            zay = db.Zayavka.Where(g => g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();
                        
            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки АУ--------------------------//
        public ActionResult ZayavkiAU()
        {

            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.IdOrg == 14 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки НПС Гомель--------------------------//
        public ActionResult ZayavkiGomel()
        {

            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g=>g.IdOrg == 3 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult ZayavkiMozyr()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.Organization.IdOrg == 2 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult ZayavkiPinsk()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.IdOrg == 5 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult ZayavkiTurov()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.IdOrg == 6 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult ZayavkiKobrin()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.IdOrg == 7 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult ZayavkiCBPO()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.IdOrg == 8 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------------Заявки--------------------------//
        public ActionResult ZayavkiNovopolock()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<Zayavka> zay = new List<Zayavka>();
            zay = db.Zayavka.Where(g => g.IdOrg == 9 && g.DateZay >= firstOfMonth && g.DateZay <= DateTime.Now && g.DatePlan == firstlastmonth).OrderByDescending(g => g.DateZay).ThenByDescending(k => k.NumberSch).ToList();

            return View(zay);
        }
        //------------------------------------------------------//
        //----------Добавление заявки-----------------------//
        [HttpPost]
        public ActionResult AddZay(int? IDF)
        {            
            SelectList FilialZay = new SelectList(db.Users, "IdUserrs", "LastName");
            ViewBag.FilZay = FilialZay;

            SelectList FilialFil = new SelectList(db.Organization, "IdOrg", "Name");
            ViewBag.FilialFil = FilialFil;

            SelectList NeftList = new SelectList(db.Nefteproduct.Where(g=>g.PriznakIsp == 1), "Naimenovanie", "Naimenovanie");
            ViewBag.NeftList = NeftList;
            string pr = "";
            if (IDF != null)
            {
                pr = db.Organization.FirstOrDefault(y => y.IdOrg == IDF).Prefix;
            }
            else
            {
                pr = db.Organization.FirstOrDefault(y => y.IdOrg == IDF).Prefix;
            }
            
            ViewBag.IDFF = pr;

            List<Zayavka> LZSPIS = new List<Zayavka>();
            LZSPIS = db.Zayavka.Where(u => u.IdOrg == IDF).ToList();

            //var Y = Convert.ToDateTime(LZSPIS.FirstOrDefault().DateZay).Year;
            //var YN = DateTime.Now.Year;
            LZSPIS = db.Zayavka.Where(u => u.IdOrg == IDF).OrderByDescending(y=>y.DateZay).ThenByDescending(t=>t.NumberSch).ToList();
            int sch = 0;
            if (LZSPIS.Count != 0)
            {
             sch = Convert.ToInt32(LZSPIS.FirstOrDefault().NumberSch) + 1;
            }
            else
            {
                sch = 1;
            }
            ViewBag.SCH = sch;
            
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления заявки-----------//
        [HttpPost]
        public ActionResult ZaySave(string NumberZay, DateTime DateZay, DateTime DatePlan, string UserZayModif, DateTime DateZayModif, List<TabZay> TabZay, int IDF)
        {
            if (TabZay == null)
            {
                ViewBag.Message = "В потребнности указаны нули. Выберите Н/П не требуется или введите значения!";
            }
            else
            {
                try
                {
                    Users U = new Users();
                    U = db.Users.FirstOrDefault(g => g.idFil == IDF && g.Doljnost.Naimenovanie == "МОЛ");
                    //Записываем данные в таблицу Zayavka
                    Zayavka zay = new Zayavka();
                    zay.DateZay = DateZay;
                    zay.DatePlan = DatePlan;
                    zay.IdOrg = IDF;
                    zay.UserModific = UserZayModif;
                    zay.DateModific = DateZayModif;
                    zay.NumberSch = Convert.ToInt32(NumberZay);
                    db.Zayavka.Add(zay);

                    db.SaveChanges();
                    //--------------------------------------
                    //Теперь работаем с таблицей TableZay

                    TableZay TZ = new TableZay();

                    //int IZZZ = db.Zayavka.FirstOrDefault(g => (g.DatePlan == DatePlan && g.IdUser == UserFil)).IdZay;
                    List<Zayavka> ListZay = new List<Zayavka>();
                    ListZay = db.Zayavka.OrderByDescending(h => h.DateModific).ToList();
                    int IZZZ = ListZay.FirstOrDefault().IdZay;
                   
                        foreach (var it in TabZay)
                        {
                            int IDN = db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.NeftZay.Trim()).IdNeft;
                            if (db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.NeftZay.Trim()).PriznakIsp == 1)
                            {

                                TZ.IdNeftep = IDN;
                                TZ.Massa = it.Massa;
                                TZ.PlanJob = it.Plan;
                                TZ.Prim = it.Prich;
                                TZ.IdZay = IZZZ;
                                TZ.IdSklad = it.IdSklad;
                                TZ.UserModific = UserZayModif;
                                TZ.DateModific = DateZayModif;
                                db.TableZay.Add(TZ);
                                db.SaveChanges();
                            }
                        }
                    
                    ViewBag.Message = "Заявка успешно сформирована!";
                }
                catch (Exception ex)
                {


                    ViewBag.Message = ex.ToString();
                }
            }
            return PartialView();
        }
        //----------------------------------//
        //-----Сохранение добавления заявки-----------//
        [HttpPost]
        public ActionResult SoglasZay(string UserZayE, DateTime DateZayE, int ID)
        {

            try
            {
                Autorize Us = new Autorize();
                Us = db.Autorize.FirstOrDefault(j => j.Login == UserZayE && j.Users.Podpisant == 1);
                if(Us !=null)
                {
                    Zayavka Z = new Zayavka();
                    Z = db.Zayavka.FirstOrDefault(f => f.IdZay == ID);

                if(Z.UserSoglas == null)
                {
                    Z.UserSoglas = UserZayE;
                    Z.DateSoglas = DateZayE;
                    db.SaveChanges();

               ViewBag.Message = "Заявка согласована " + DateZayE.ToString("d") + " пользователем "  + UserZayE;
                }
            else
                {
                    Z.UserSoglas = null;
                    Z.DateSoglas = null;

                    db.SaveChanges();
                    ViewBag.Message = "Согласование отменено " + DateZayE.ToString("d") + " пользователем " + UserZayE;
                }
                    
            }
            else
            {
                    ViewBag.Message = "У Вас отсутствуют права для данной операции!";
            }
                 }
            
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        //-----Сохранение добавления заявки в ОННИУК----------//
        [HttpPost]
        public ActionResult SoglasZayT(string UserZayE, DateTime DateZayE, int ID)
        {

            try
            {
                Autorize Us = new Autorize();
                Us = db.Autorize.FirstOrDefault(j => j.Login == UserZayE && j.Users.Podpisant == 1);
                if (Us != null)
                {
                    Zayavka Z = new Zayavka();
                    Z = db.Zayavka.FirstOrDefault(f => f.IdZay == ID);

                    if (Z.UserSoglas == null)
                    {
                        Z.UserSoglas = UserZayE;
                        Z.DateSoglas = DateZayE;
                        db.SaveChanges();

                        ViewBag.Message = "Заявка согласована " + DateZayE.ToString("d") + " пользователем " + UserZayE;
                    }
                    else
                    {
                        Z.UserSoglas = null;
                        Z.DateSoglas = null;

                        db.SaveChanges();
                        ViewBag.Message = "Согласование отменено " + DateZayE.ToString("d") + " пользователем " + UserZayE;
                    }

                }
                else
                {
                    ViewBag.Message = "У Вас отсутствуют права для данной операции!";
                }
            }

            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //----------------------------------//


        //-----Сохранение добавления нулевой заявки-----------//
        [HttpPost]
        public ActionResult ZaySaveZero(string NumberZay, DateTime DateZay, DateTime DatePlan, string UserZayModif, DateTime DateZayModif, int IDF)
        {
            try
            {
                Users U = new Users();
                U = db.Users.FirstOrDefault(g => g.idFil == IDF && g.Doljnost.Naimenovanie == "МОЛ");
                //Записываем данные в таблицу Zayavka
                Zayavka zay = new Zayavka();
                zay.DateZay = DateZay;
                zay.DatePlan = DatePlan;
                zay.IdOrg = IDF;
                zay.UserModific = UserZayModif;
                zay.DateModific = DateZayModif;
                zay.NumberSch = Convert.ToInt32(NumberZay);
                db.Zayavka.Add(zay);
                db.SaveChanges();
                //--------------------------------------
                //Теперь работаем с таблицей TableZay

                TableZay TZ = new TableZay();                                
                List<Zayavka> ListZay = new List<Zayavka>();
                ListZay = db.Zayavka.OrderByDescending(h => h.DateModific).ToList();
                int IZZZ = ListZay.FirstOrDefault().IdZay;

                List<Sklad> skl = new List<Sklad>();
                skl = db.Sklad.Where(c => c.IdOrg == IDF).ToList();

                List<Nefteproduct> ListNeft = new List<Nefteproduct>();
                ListNeft = db.Nefteproduct.ToList();

                foreach(var item in skl)
                {
                    foreach(var p in ListNeft)
                    {
                        TZ.IdNeftep = p.IdNeft;
                        TZ.Massa = 0;
                        TZ.PlanJob = "0";
                        TZ.Prim = "0";
                        TZ.IdZay = IZZZ;
                        TZ.IdSklad = item.IdSklad;
                        TZ.UserModific = UserZayModif;
                        TZ.DateModific = DateZayModif;
                        db.TableZay.Add(TZ);
                        db.SaveChanges();
                    }
                }
                                                        

                ViewBag.Message = "Заявка успешно сформирована!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        //--------------------------------------------
        // Редактирование заявки//
        public ActionResult ZayavkaEdit(int ID)
        {

            SelectList OrganizE = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilOrgE = OrganizE;

            //Получаем запись с нашим номером заявки 
            Zayavka ZayE = new Zayavka();
            ZayE = db.Zayavka.FirstOrDefault(a => a.IdZay == ID);
            ViewBag.ZayE = ZayE;

            //Получаем список записей с id номера заявки из таблицы TableZay            
            List<TableZay> ListTZ = new List<TableZay>();
            ListTZ = db.TableZay.Where(f => f.IdZay == ID).OrderBy(u=>u.Sklad.Name).ThenBy(y=>y.Nefteproduct.Naimenovanie).ToList();
            ViewBag.ListTZ = ListTZ;

            //Получаем список нефтепродуктов
            List<Nefteproduct> ListNZ = new List<Nefteproduct>();
            ListNZ = db.Nefteproduct.ToList();
            ViewBag.ListNZ = ListNZ;

            //Получаем список остатков за предыдущий месяц
            List<OstatSklad> LO = new List<OstatSklad>();
            LO = db.OstatSklad.Where(j=>j.Sklad.Organization.IdOrg == ZayE.IdOrg).OrderByDescending(y=>y.Date).ToList();
            
           // List<OstatSklad> LOLIST = new List<OstatSklad>();
           //OstatSklad OSJo = new OstatSklad();

            //-----------НОВЫЙ АЛГОРИТМ РАСЧЕТА ОСТАТКОВ ОЧЕРЕДНОЙ РАЗ--------------------------------------------
            DateTime date = DateTime.Now;
            int Month = date.Month;
            int Year = date.Year;
            int allDayMonth = DateTime.DaysInMonth(Year, Month);
            DateTime Begin = new DateTime(Year, Month, 1);
            DateTime End = new DateTime(Year, Month, allDayMonth);

            List<OstatSklad> OSLAST1 = new List<OstatSklad>();
            OSLAST1 = db.OstatSklad.Where(f => f.Sklad.Organization.IdOrg == ZayE.IdOrg && f.Date >= Begin && f.Date <= End).OrderByDescending(g => g.Date).ToList();
            //--Опять новый алгоритм расчета остатков-----------------------------------------------------

            //----Очередной сука алгоритм расчета остатков-------------------------------------------
            DateTime date1 = Convert.ToDateTime(ZayE.DateZay);
            int Month1 = date1.Month;
            int Year1 = date1.Year;
            int allDayMonth1 = DateTime.DaysInMonth(Year1, Month1);
            DateTime Begin1 = new DateTime(Year1, Month1, 1);
            DateTime End1 = new DateTime(Year1, Month1, allDayMonth1);

            List<OstatSklad> OSLAST11 = new List<OstatSklad>();
            OSLAST11 = db.OstatSklad.Where(f => f.Sklad.Organization.IdOrg == ZayE.IdOrg && f.Date >= Begin1 && f.Date <= date1).OrderByDescending(g => g.Date).ToList();
            //-------------------------------------------------------------------

            //foreach (var i in ListTZ)
            //{
            //    if(LO.Where(d=>d.IdSkl == i.IdSklad && d.IdNeftep == i.IdNeftep).Count() != 0)
            //    {
            //        LOLIST.Add(LO.Where(d => d.IdSkl == i.IdSklad && d.IdNeftep == i.IdNeftep).FirstOrDefault());
            //    }
            //}

            ViewBag.LO = OSLAST11;
            
            return PartialView(ZayE);
        }
        //-------------------------------//

        //Сохранение редактирования заявки------------//
        [HttpPost]
        public ActionResult ZayavkaEditSave(List<TabZay> TabZayE, int ID, string UserZayE, DateTime DateZayE, string NumberDogE, DateTime DateDogME, DateTime DatePlanZE)
        {
        
            try
            {                
                foreach (var item in TabZayE)
                {
                    //Nefteproduct NID = new Nefteproduct();
                    int NID = db.Nefteproduct.FirstOrDefault(g => g.Naimenovanie.Trim() == item.NeftZay.Trim()).IdNeft;
                    Zayavka Z = new Zayavka();
                    Z = db.Zayavka.FirstOrDefault(f=>f.IdZay == ID);
                    Z.NumberSch = Convert.ToInt32(NumberDogE);
                    Z.DateZay = DateDogME;
                    Z.DatePlan = DatePlanZE;
                    db.SaveChanges();
                    TableZay TZE = new TableZay();
                    TZE = db.TableZay.FirstOrDefault(s => s.IdTable == item.IdZay);
                    TZE.IdNeftep = NID;
                    TZE.Massa = item.Massa;
                    TZE.PlanJob = item.Plan;
                    TZE.Prim = item.Prich;
                    
                    TZE.UserModific = UserZayE;
                    TZE.DateModific = DateZayE;
                    Z.UserModific = UserZayE;
                    db.SaveChanges();
                    
                    
                }
                ViewBag.Message = "Заявка успешно изменена!";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//

        // Редактирование заявки в ОННИУК//
        public ActionResult ZayavkaTotalsEdit(int ID)
        {

            SelectList OrganizE = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilOrgE = OrganizE;

            //Получаем запись с нашим номером заявки 
            Zayavka ZayE = new Zayavka();
            ZayE = db.Zayavka.FirstOrDefault(a => a.IdZay == ID);
            ViewBag.ZayE = ZayE;

            //Получаем список записей с id номера заявки из таблицы TableZay            
            List<TableZay> ListTZ = new List<TableZay>();
            ListTZ = db.TableZay.Where(f => f.IdZay == ID).OrderBy(u => u.Sklad.Name).ThenBy(y => y.Nefteproduct.Naimenovanie).ToList();
            ViewBag.ListTZ = ListTZ;

            //Получаем список нефтепродуктов
            List<Nefteproduct> ListNZ = new List<Nefteproduct>();
            ListNZ = db.Nefteproduct.ToList();
            ViewBag.ListNZ = ListNZ;

            //Получаем список остатков за предыдущий месяц
            List<OstatSklad> LO = new List<OstatSklad>();
            LO = db.OstatSklad.Where(j => j.Sklad.Organization.IdOrg == ZayE.IdOrg).OrderByDescending(y => y.Date).ToList();

            List<OstatSklad> LOLIST = new List<OstatSklad>();
            OstatSklad OSJo = new OstatSklad();

            foreach (var i in ListTZ)
            {
                if (LO.Where(d => d.IdSkl == i.IdSklad && d.IdNeftep == i.IdNeftep).Count() != 0)
                {
                    LOLIST.Add(LO.Where(d => d.IdSkl == i.IdSklad && d.IdNeftep == i.IdNeftep).FirstOrDefault());
                }
            }

            ViewBag.LO = LOLIST;

            return PartialView(ZayE);
        }
        //-------------------------------//

        //Сохранение редактирования заявки------------//
        [HttpPost]
        public ActionResult ZayavkaTotalsEditSave(List<TabZay> TabZayE, int ID, string UserZayE, DateTime DateZayE)
        {

            try
            {
                foreach (var item in TabZayE)
                {
                    //Nefteproduct NID = new Nefteproduct();
                    int NID = db.Nefteproduct.FirstOrDefault(g => g.Naimenovanie.Trim() == item.NeftZay.Trim()).IdNeft;
                    Zayavka Z = new Zayavka();
                    Z = db.Zayavka.FirstOrDefault(f => f.IdZay == ID);
                    TableZay TZE = new TableZay();
                    TZE = db.TableZay.FirstOrDefault(s => s.IdTable == item.IdZay);
                    TZE.IdNeftep = NID;
                    TZE.Massa = item.Massa;
                    TZE.PlanJob = item.Plan;
                    TZE.Prim = item.Prich;
                    TZE.UserModific = UserZayE;
                    TZE.DateModific = DateZayE;
                    Z.UserModific = UserZayE;
                    db.SaveChanges();


                }
                ViewBag.Message = "Д/З успешно изменена!";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//

        // удаление заявки//
        public ActionResult DeleteZayavka(int ID)
        {
            Zayavka ZayDel = new Zayavka();
            ZayDel = db.Zayavka.FirstOrDefault(a => a.IdZay == ID);
            return PartialView(ZayDel);
        }
        //-----------------------------//

        // Подтверждение удаления заявки//
        public ActionResult DeleteZayavkaOK(int ID)
        {
            try
            {
                Zayavka ZayDS = new Zayavka();
                ZayDS = db.Zayavka.FirstOrDefault(a => a.IdZay == ID);
               
                //Сперва записываем удаляемые данные в БД перед удалением
                //--------------------------------------------------------------------
                ZayavkaDelete ZD = new ZayavkaDelete();
                ZD.Filial = ZayDS.IdOrg;
                ZD.Date = ZayDS.DateZay;
                ZD.Number = ZayDS.NumberSch;
                ZD.PlanDate = ZayDS.DatePlan;
                ZD.DateSozd = ZayDS.DateModific;
                ZD.UserSozd = ZayDS.UserModific;
                ZD.DateDelete = DateTime.Now;
                ZD.UserDelete = User.Identity.GetUserName();
                db.ZayavkaDelete.Add(ZD);
                db.SaveChanges();

                //Получаем ID записи заявки
                List<ZayavkaDelete> IDZAYDELList = new List<ZayavkaDelete>();
                IDZAYDELList = db.ZayavkaDelete.OrderByDescending(o => o.DateSozd).ToList();
                int IDZAYDEL = IDZAYDELList.FirstOrDefault().ID;

                //Теперь заполним таблицу TableZayDelete перед удалением
                
                List<TableZay> ListTZ = new List<TableZay>();
                ListTZ = db.TableZay.Where(f => f.IdZay == ID).ToList();
                
                TableZayDelete TZD = new TableZayDelete();

                foreach (var t in ListTZ)
                {
                    TZD.IDNeft = t.IdNeftep;
                    TZD.Massa = t.Massa;
                    TZD.IdSklad = t.IdSklad;
                    TZD.IdZay = IDZAYDEL;
                    db.TableZayDelete.Add(TZD);
                    db.SaveChanges();
                }

                db.Zayavka.Remove(ZayDS);

                foreach (var t in ListTZ)
                {
                    db.TableZay.Remove(t);
                }

                db.SaveChanges();

                ViewBag.Message = "Заявка удалена!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        //--------------------------------------------
                
        // удаление заявки//
        public ActionResult DeleteZayavkaAll(int ID)
        {
            Zayavka ZayDel = new Zayavka();
            ZayDel = db.Zayavka.FirstOrDefault(a => a.IdZay == ID);
            return PartialView(ZayDel);
        }

        //-----------------------------//
        // Подтверждение удаления заявки//
        public ActionResult DeleteZayavkaAllOK(int ID)
        {
            try
            {
                Zayavka ZayDS = new Zayavka();
                ZayDS = db.Zayavka.FirstOrDefault(a => a.IdZay == ID);
                db.Zayavka.Remove(ZayDS);

                List<TableZay> ListTZ = new List<TableZay>();
                ListTZ = db.TableZay.Where(f => f.IdZay == ID).ToList();

                foreach (var t in ListTZ)
                {
                    db.TableZay.Remove(t);
                }

                db.SaveChanges();

                ViewBag.Message = "Заявка удалена!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        //--------------------------------------------

        // Закрытие заявок//

        public ActionResult ClosedMonth()
        {
            List<Zayavka> ZayClos = new List<Zayavka>();
            ZayClos = db.Zayavka.Where(a => a.Priznak != 1).ToList();
            return PartialView();
        }
        //-----------------------------//

        // Подтверждение закрытия заявок//
        public ActionResult ClosedZayavkaOK()
        {
            try
            {
                List<Zayavka> ZayZC = new List<Zayavka>();
                ZayZC = db.Zayavka.Where(a => a.Priznak != 1).ToList();
                                               
                foreach (var t in ZayZC)
                {
                    t.Priznak = 1;                    
                }
                db.SaveChanges();

                ViewBag.Message = "Прием заявок закрыт!";
            }
            catch
            {
                ViewBag.Message = "Ошибка закрытия";
            }

            return PartialView();
        }

        //Формируем сводную заявку в формате pdf/---------------------------------------------------------------------------------
       
        public ActionResult Report()
        {
            //MemoryStream workStream = new MemoryStream();
            //// Имя создаваемого файла. 
            //string strPDFFileName = string.Format("Report.pdf");
            //Document doc = new Document();
            //doc.SetPageSize(PageSize.A4.Rotate());
            //PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
            //writer.CloseStream = false;
            ////PdfWriter.GetInstance(doc, workStream).CloseStream = false;

            //// Подключение русскоязычного шрифта.
            //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            //BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //Font f08 = new Font(baseFont, 8);
            //Font f12 = new Font(baseFont, 12);
            //Font f14 = new Font(baseFont, 14);
            //Font f16 = new Font(baseFont, 16);
            //Font f12Bold = new Font(baseFont, 12, Font.BOLD);
            //Font f18Bold = new Font(baseFont, 18, Font.BOLD);
            //Font f20Bold = new Font(baseFont, 20, Font.BOLD);

            //// Открытие документа.
            //doc.Open();

            //// Создание элементов.
            //Paragraph par1 = new Paragraph("ОАО Гомельтранснефть Дружба", f12);
            //Paragraph par2 = new Paragraph("Сводная заявка нефтепродуктов", f12Bold);
            //Paragraph par3 = new Paragraph();
            //Paragraph par4 = new Paragraph("Заместитель генеральнго директора (по транспорту нефти)                                                                                                                    Булычев С.Т. ", f12);

            //par1.Alignment = Element.ALIGN_RIGHT;
            //par2.Alignment = Element.ALIGN_CENTER;
            //par4.Alignment = Element.ALIGN_LEFT;

            //PdfPTable tableKom = new PdfPTable(6);
            //PdfPCell cell1 = new PdfPCell();
            //tableKom.WidthPercentage = 100f;
            //float[] columnWidths1 = new float[] { 3f, 27f, 10f, 10f, 35f, 15f };
            //tableKom.SetWidths(columnWidths1);

            ////Используется для вывода итогов по видам нефтепродуктов
            //PdfPTable tableITOG = new PdfPTable(3);
            //PdfPCell cell3 = new PdfPCell();
            //tableITOG.WidthPercentage = 100f;
            //float[] columnWidths2 = new float[] { 40f, 10f, 50f};
            //tableITOG.SetWidths(columnWidths2);            
            ////------------------------------------------------------

            //PdfPTable tableTank = new PdfPTable(6);
            //PdfPCell cell2 = new PdfPCell();
            //tableTank.WidthPercentage = 100f;
            //float[] columnWidths = new float[] { 3f, 27f, 10f, 10f, 35f, 15f };
            //tableTank.SetWidths(columnWidths);


            //int p = 0;
            //List<TableZay> LZ = new List<TableZay>();
            //LZ = db.TableZay.ToList();

            //doc.Add(par1);
            //doc.Add(par2);
            ////doc.Add(par3);
            ////doc.Add(tableKom);                       

            ////------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //var tabZ = LZ.GroupBy(h => h.Zayavka.Users.Organization.Name);
            //foreach(var organ in tabZ)
            //{ 
            //    //Очищаем tableKom перед заполнением
            //    tableKom.Rows.Clear();

            //    par3 = new Paragraph(organ.Key, f12Bold);
            //    par3.Alignment = Element.ALIGN_LEFT;

            //    doc.Add(par3);
            //    doc.Add(new Paragraph(" ", f08));

            //    cell1 = new PdfPCell(new Phrase("№", f08));
            //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    cell1.VerticalAlignment = Element.ALIGN_CENTER;
            //    cell1.Rowspan = 2;
            //    tableKom.AddCell(cell1);

            //    cell1 = new PdfPCell(new Phrase("Вид нефтепродукта", f08));
            //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    cell1.VerticalAlignment = Element.ALIGN_CENTER;
            //    cell1.Rowspan = 2;
            //    tableKom.AddCell(cell1);

            //    cell1 = new PdfPCell(new Phrase("Остатки нефтепродукта на филиале", f08));
            //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    cell1.VerticalAlignment = Element.ALIGN_CENTER;
            //    cell1.Rowspan = 2;
            //    tableKom.AddCell(cell1);

            //    cell1 = new PdfPCell(new Phrase("Заявленное к доставке количество нефтеподукта", f08));
            //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    cell1.VerticalAlignment = Element.ALIGN_CENTER;
            //    cell1.Rowspan = 2;
            //    tableKom.AddCell(cell1);

            //    cell1 = new PdfPCell(new Phrase("Планируемые работы", f08));
            //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    cell1.VerticalAlignment = Element.ALIGN_CENTER;
            //    cell1.Rowspan = 2;
            //    tableKom.AddCell(cell1);

            //    cell1 = new PdfPCell(new Phrase("Примечание", f08));
            //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    cell1.VerticalAlignment = Element.ALIGN_CENTER;
            //    cell1.Rowspan = 2;
            //    tableKom.AddCell(cell1);

            //    doc.Add(tableKom);

            //    var tabNeft = organ.GroupBy(h => h.IdNeftep);
            //    foreach (var roww in tabNeft.ToList())
            //    {
            //        decimal? d = 0;
            //        var filter = LZ.Where(h => h.Zayavka.Users.Organization.Name   == organ.Key  && h.IdNeftep == roww.Key);
            //        foreach (var f in filter)
            //        {
            //            d = d + f.Massa;
            //        tableTank.Rows.Clear();
            //        tableITOG.Rows.Clear();
            //        p++;
            //        cell2 = new PdfPCell(new Phrase(p.ToString(), f12));
            //        tableTank.AddCell(cell2);

            //        cell2 = new PdfPCell(new Phrase((f.Nefteproduct.Naimenovanie).ToString(), f12));
            //        tableTank.AddCell(cell2);

            //        cell2 = new PdfPCell(new Phrase(("").ToString(), f12));
            //        tableTank.AddCell(cell2);

            //        cell2 = new PdfPCell(new Phrase((f.Massa).ToString(), f12));
            //        tableTank.AddCell(cell2);

            //        cell2 = new PdfPCell(new Phrase((f.PlanJob).ToString(), f12));
            //        tableTank.AddCell(cell2);

            //        string g = "";
            //        if (f.Prim == null)
            //        {
            //            g = "";
            //        }
            //        else
            //        {
            //            g = f.Prim.ToString();
            //        }
            //        cell2 = new PdfPCell(new Phrase(g, f12));

            //        tableTank.AddCell(cell2);
            //        doc.Add(tableTank);

            //        cell3 = new PdfPCell(new Phrase("ИТОГО", f12));
            //        tableITOG.AddCell(cell3);
            //        cell3 = new PdfPCell(new Phrase(d.ToString(), f12));
            //        tableITOG.AddCell(cell3);
            //        cell3 = new PdfPCell(new Phrase("", f12));
            //        tableITOG.AddCell(cell3); 


            //    }
            //      doc.Add(tableITOG);
            //        }

            //    //foreach (var Z in organ)
            //    //{

            //    //    tableTank.Rows.Clear();
            //    //    p++;
            //    //    cell2 = new PdfPCell(new Phrase(p.ToString(), f12));
            //    //    tableTank.AddCell(cell2);

            //    //    cell2 = new PdfPCell(new Phrase((Z.Nefteproduct.Naimenovanie).ToString(), f12));
            //    //    tableTank.AddCell(cell2);

            //    //    cell2 = new PdfPCell(new Phrase((""), f12));
            //    //    tableTank.AddCell(cell2);

            //    //    cell2 = new PdfPCell(new Phrase((Z.Massa).ToString(), f12));
            //    //    tableTank.AddCell(cell2);

            //    //    cell2 = new PdfPCell(new Phrase((Z.PlanJob).ToString(), f12));
            //    //    tableTank.AddCell(cell2);

            //    //    string g = "";
            //    //    if (Z.Prim == null)
            //    //    {
            //    //        g = "";
            //    //    }
            //    //    else
            //    //    {
            //    //        g = Z.Prim.ToString();
            //    //    }
            //    //    cell2 = new PdfPCell(new Phrase(g, f12));

            //    //    tableTank.AddCell(cell2);

            //    //    doc.Add(tableTank);

            //    //}
            //}
            ////-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            ////Выводим подпись Тимофеевича                                    
            //doc.Add(par4);



            //// Закрытие документа.  
            //doc.Close();

            //byte[] byteInfo = workStream.ToArray();
            //workStream.Write(byteInfo, 0, byteInfo.Length);
            //workStream.Position = 0;


            //return File(workStream, "application/pdf", strPDFFileName);
            return View();
        }

        //Заявка переделанная под новый алгоритм
        //Заполняем форму заявки спиской резервуаров для конкретного резервуара
        public ActionResult LetRes(int Fill, DateTime DatePlan, DateTime DateZay)
        {
            //-----------------Использовалось в старой заявке---------------------------------------------
            List<Rezervuary> ListRez = new List<Rezervuary>();
            ListRez = db.Rezervuary.Where(f=>f.idSklad == Fill).ToList();
            ViewBag.ListRez = ListRez;

            SelectList ListN = new SelectList(db.Nefteproduct.Where(g => g.PriznakIsp == 1), "Naimenovanie", "Naimenovanie");
            ViewBag.ListN = ListN;
            //---------------------------------------------------------------------------------------------
            List<Sklad> LS = new List<Sklad>();
            LS = db.Sklad.Where(g => g.IdOrg == Fill).OrderBy(y=>y.Name).ToList();
            ViewBag.LS = LS;

            List<OstatSklad> OS = new List<OstatSklad>();
            List<OstatSklad> OSLAST = new List<OstatSklad>();
            OSLAST = db.OstatSklad.OrderByDescending(g=>g.Date).ToList();
            if (OSLAST.Count == 0)
            {
                OS = null;
            }
            else
            {
            DateTime? LasDat = OSLAST.FirstOrDefault().Date;
            //Получаем список с остатками за последнюю дату
            OS = OSLAST.Where(h=>h.Date == LasDat).ToList();
            }
            
            ViewBag.OS = OS;

            List<Nefteproduct> NEF = new List<Nefteproduct>();
            NEF = db.Nefteproduct.OrderBy(j=>j.Naimenovanie).ToList();
            ViewBag.NEF = NEF;

            //---Новый блядь алгоритм расчета остатков очередной раз-------------------------------
            DateTime date = DateTime.Now;
            int Month = date.Month;
            int Year = date.Year;
            int allDayMonth = DateTime.DaysInMonth(Year, Month);
            DateTime Begin = new DateTime(Year, Month, 1);
            DateTime End = new DateTime(Year, Month, allDayMonth);

            List<OstatSklad> OSLAST1 = new List<OstatSklad>();
            OSLAST1 = db.OstatSklad.Where(f=>f.Sklad.Organization.IdOrg == Fill &&  f.Date>=Begin && f.Date<=End).OrderByDescending(g => g.Date).ToList();
            //------------------------------------------------------------------------------------
            //----Очередной сука алгоритм расчета остатков-------------------------------------------
            DateTime date1 = DateZay;
            int Month1 = date1.Month;
            int Year1 = date1.Year;
            int allDayMonth1 = DateTime.DaysInMonth(Year, Month);
            DateTime Begin1 = new DateTime(Year1, Month1, 1);
            DateTime End1 = new DateTime(Year1, Month1, allDayMonth);

            List<OstatSklad> OSLAST11 = new List<OstatSklad>();
            OSLAST11 = db.OstatSklad.Where(f => f.Sklad.Organization.IdOrg == Fill && f.Date >= Begin1 && f.Date <= date1).OrderByDescending(g => g.Date).ToList();
            //---------------------------------------------------------------------------------------

            return PartialView(OSLAST11);
        }
        //-----------------------------//
        //--Сохраняем остатки в БД---//
        public ActionResult OstatAdd(DateTime Date, List<TabZay> TabList)
        {
            
            return PartialView();
        }
        //------------------------------------------------------------------------------------------------------------------//
        //----------------Склады--------------------------//
        public ActionResult Sklad()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
        public ActionResult SkladAU()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g => g.IdOrg == 14).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//

        public ActionResult SkladGomel()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 3).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
        
        public ActionResult SkladMozyr()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 2).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
       
        public ActionResult SkladPinsk()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 5).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
        
        public ActionResult SkladTurov()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 6).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
       
        public ActionResult SkladKobrin()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 7).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
        
        public ActionResult SkladNovopolock()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 9).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
        
        public ActionResult SkladCBPO()
        {
            List<Sklad> sklad = new List<Sklad>();
            sklad = db.Sklad.Where(g=>g.IdOrg == 8).OrderBy(h => h.Name).ToList();

            return View(sklad);
        }
        //------------------------------------------------------//
        //----------Добавление склада-----------------------//
        public ActionResult AddSklad()
        {                       
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSave(string NameSklad, int idFilS, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = idFilS;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //--------------Добавление складов филиалов-------------------------------------------------------------------------------
        //----------Добавление склада Гомель-----------------------//
        public ActionResult AddSkladAU()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveAU(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 14;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//


        //----------Добавление склада Гомель-----------------------//
        public ActionResult AddSkladGomel()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveGomel(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 3;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//

        //----------Добавление склада Мозырь-----------------------//
        public ActionResult AddSkladMozyr()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveMozyr(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 2;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//
        //----------Добавление склада Пинск-----------------------//
        public ActionResult AddSkladPinsk()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSavePinsk(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 5;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//
        //----------Добавление склада Туров-----------------------//
        public ActionResult AddSkladTurov()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveTurov(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 6;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//
        //----------Добавление склада Кобрин-----------------------//
        public ActionResult AddSkladKobrin()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveKobrin(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 7;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//
        //----------Добавление склада ЦБПО-----------------------//
        public ActionResult AddSkladCBPO()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveCBPO(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 8;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//
        //----------Добавление склада Новополоцк-----------------------//
        public ActionResult AddSkladNovopolock()
        {
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilUs = Filial;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления склада-----------//
        [HttpPost]
        public ActionResult SkladSaveNovopolock(string NameSklad, string UserSklad, DateTime DateSklad)
        {
            try
            {
                Sklad sk = new Sklad();
                sk.Name = NameSklad.Trim();
                sk.IdOrg = 9;
                sk.UserModif = UserSklad.Trim();
                sk.DateModif = DateSklad;
                db.Sklad.Add(sk);

                db.SaveChanges();

                ViewBag.Message = "Склад успешно добавлен!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return PartialView();
        }
        //----------------------------------//
        //------------------------------------------------------------------------------------------------------------------------

        // удаление склада//

        public ActionResult DeleteSklad(int ID)
        {
            Sklad SkladDel = new Sklad();
            SkladDel = db.Sklad.FirstOrDefault(a => a.IdSklad == ID);
            return PartialView(SkladDel);
        }
        //-----------------------------//

        // Подтверждение удаления склада//
        public ActionResult DeleteSkladOK(int ID)
        {
            try
            {
                Sklad SkladDS = new Sklad();
                SkladDS = db.Sklad.FirstOrDefault(a => a.IdSklad == ID);
                db.Sklad.Remove(SkladDS);
                db.SaveChanges();

                ViewBag.Message = "Склад удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления! По данному складу есть остатки!" ;
            }

            return PartialView();
        }

        // Редактирование склада//
        public ActionResult SkladEdit(int ID)
        {            
            SelectList Filial = new SelectList(db.Organization, "idOrg", "Name");
            ViewBag.FilSkladED = Filial;

            List<Organization> LO = new List<Organization>();
            LO = db.Organization.ToList();
            ViewBag.LO = LO;

            Sklad SkladEd = new Sklad();
            SkladEd = db.Sklad.FirstOrDefault(a => a.IdSklad == ID);
            return PartialView(SkladEd);
        }
        //-------------------------------//

        //Сохранение редактирования склада------------//
        [HttpPost]
        public ActionResult SkladEditSave(int ID, string NameSkladEdit, int idFilSkladEdit, string UserSkladEdit, DateTime DateSkladEdit)
        {
            try
            {
                Sklad SkladE = new Sklad();
                SkladE = db.Sklad.FirstOrDefault(s => s.IdSklad == ID);
                SkladE.Name = NameSkladEdit.Trim();
                SkladE.IdOrg = idFilSkladEdit;
                SkladE.UserModif = UserSkladEdit.Trim();
                SkladE.DateModif = DateSkladEdit;
                db.SaveChanges();

                ViewBag.Message = "Склад изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        //----------------Остатки--------------------------//
        public ActionResult Ostatki()
        {
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.OrderBy(h => h.Date).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки АУ--------------------------//
        public ActionResult OstatkiAU()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 14 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l=>l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки Мозырь--------------------------//
        public ActionResult OstatkiMozyr()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 2 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки Гомель--------------------------//
        public ActionResult OstatkiGomel()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 3 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки Пинск--------------------------//
        public ActionResult OstatkiPinsk()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 5 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки Туров--------------------------//
        public ActionResult OstatkiTurov()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 6 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки Кобрин--------------------------//
        public ActionResult OstatkiKobrin()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 7 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки ЦБПО--------------------------//
        public ActionResult OstatkiCBPO()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 8 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------------Остатки Новополоцк--------------------------//
        public ActionResult OstatkiNovopolock()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            List<OstatSklad> OstSklad = new List<OstatSklad>();
            OstSklad = db.OstatSklad.Where(f => f.Sklad.IdOrg == 9 && f.Date >= firstOfMonth && f.Date <= DateTime.Now).OrderByDescending(g => g.Date).ThenBy(l => l.Sklad).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();

            return View(OstSklad);
        }
        //------------------------------------------------------//
        //----------Добавление остатков-----------------------//

        public ActionResult AddOstatki(int IDF, DateTime DatP)
        {
            List<Nefteproduct> LN = new List<Nefteproduct>();
            LN = db.Nefteproduct.Where(d => d.PriznakIsp == 1).OrderBy(j=>j.Naimenovanie).ToList();

            List<Sklad> SkFil = new List<Sklad>();
            SkFil = db.Sklad.Where(d => d.IdOrg == IDF).ToList();
            ViewBag.SkFil = SkFil;
            ViewBag.DatP = DatP;
            return PartialView(LN);
        }
        //--------------------------//
        //-----Сохранение добавления остатков-----------//
        [HttpPost]
        public ActionResult OstatkiSave(List<TabOst> TabOstat)
        {
            try
            {                
                Nefteproduct IDN = new Nefteproduct();
                if (TabOstat == null)
                {
                    ViewBag.Message = "Остатки не заполнены!";
                }
                else
                {
                    foreach (var item in TabOstat)
                    {
                        OstatSklad ost = new OstatSklad();
                        IDN = db.Nefteproduct.FirstOrDefault(g => g.Naimenovanie == item.IdNeft.Trim());
                        ost.Date = item.Date;
                        ost.IdNeftep = IDN.IdNeft;
                        ost.IdSkl = item.IdSklad;
                        ost.Massa = item.Mass;
                        ost.Primech = item.Prim;
                        ost.UserModific = item.UserM;
                        ost.DateModific = DateTime.Now;
                        db.OstatSklad.Add(ost);
                        db.SaveChanges();
                    }
                }
                ViewBag.Message = "Остатки добавлены!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        //---------------Добавление остатков филиалов-------------------------------------------------------------------------------------------------------------
        //----------Добавление остатков Гомель-----------------------//

        public ActionResult AddOstatkiGomel(int IDF)
        {
            List<Nefteproduct> LN = new List<Nefteproduct>();
            LN = db.Nefteproduct.Where(d => d.PriznakIsp == 1).ToList();

            List<Sklad> SkFil = new List<Sklad>();
            SkFil = db.Sklad.Where(d => d.IdOrg == IDF).ToList();
            ViewBag.SkFil = SkFil;
            return PartialView(LN);
        }
        //--------------------------//
        //-----Сохранение добавления остатков-----------//
        [HttpPost]
        public ActionResult OstatkiSaveGomel(List<TabOst> TabOstat)
        {
            try
            {
                Nefteproduct IDN = new Nefteproduct();
                foreach (var item in TabOstat)
                {
                    OstatSklad ost = new OstatSklad();
                    IDN = db.Nefteproduct.FirstOrDefault(g => g.Naimenovanie == item.IdNeft.Trim());
                    ost.Date = item.Date;
                    ost.IdNeftep = IDN.IdNeft;
                    ost.IdSkl = item.IdSklad;
                    ost.Massa = item.Mass;
                    ost.Primech = item.Prim;
                    ost.UserModific = item.UserM;
                    ost.DateModific = DateTime.Now;
                    db.OstatSklad.Add(ost);
                    db.SaveChanges();
                }


                ViewBag.Message = "Остатки добавлены!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        // удаление остатков//

        public ActionResult DeleteOstatki(int ID)
        {
            OstatSklad ostDel = new OstatSklad();
            ostDel = db.OstatSklad.FirstOrDefault(a => a.IdOstSklad == ID);
            return PartialView(ostDel);
        }
        //-----------------------------//

        // Подтверждение удаления остатков//
        public ActionResult DeleteOstatkiOK(int ID)
        {           
            try
            {
                OstatSklad ostDS = new OstatSklad();
                ostDS = db.OstatSklad.FirstOrDefault(a => a.IdOstSklad == ID);

                // Сперва записываем данную строку в таблицу перед удалением данной записи
                OstatkiDelete OD =new OstatkiDelete();
                OD.Sklad = ostDS.IdSkl;
                OD.Nefteprod = ostDS.IdNeftep;
                OD.V = ostDS.Massa;
                OD.Date = ostDS.Date;
                OD.DateSozd = ostDS.DateModific;
                OD.UserSozd = ostDS.UserModific;
                OD.DateDelete = DateTime.Now;
                OD.UserDelete = User.Identity.GetUserName();
                db.OstatkiDelete.Add(OD);
                db.SaveChanges();

                //Теперь удаляем саму запись из БД
                db.OstatSklad.Remove(ostDS);
                db.SaveChanges();

                ViewBag.Message = "Остаток удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // Редактирование остатков//
        public ActionResult OstatkiEdit(int ID)
        {
            OstatSklad ostEd = new OstatSklad();
            ostEd = db.OstatSklad.FirstOrDefault(a => a.IdOstSklad == ID);

            List<Sklad> LSO = new List<Sklad>();
            LSO = db.Sklad.Where(h => h.IdOrg == ostEd.Sklad.Organization.IdOrg).ToList();
            ViewBag.LSO = LSO;

            return PartialView(ostEd);
        }
        //-------------------------------//

        //Сохранение редактирования остатков------------//
        [HttpPost]
        public ActionResult OstatkiEditSave(int ID, decimal MassaOstatEdit, string PrimOstatEdit, string UserOstEdit, DateTime DateOstEdit, DateTime DOstEdit, int idSkladE)
        {
            try
            {
                OstatSklad ostE = new OstatSklad();
                ostE = db.OstatSklad.FirstOrDefault(s => s.IdOstSklad == ID);

                ostE.Massa = MassaOstatEdit;
                ostE.Primech = PrimOstatEdit;
                ostE.UserModific = UserOstEdit.Trim();
                ostE.DateModific = DateOstEdit;
                ostE.Date = DOstEdit;
                ostE.IdSkl = idSkladE;
                db.SaveChanges();

                ViewBag.Message = "Строка изменена";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //----------------------------------------------------------------------------------------------------//
        [HttpGet]
        public ActionResult ReportTEST(int IDF, DateTime S, DateTime Po)
        {
            
            //Получаем название филиала для отчета
            Organization or = new Organization();
            or = db.Organization.FirstOrDefault(f => f.IdOrg == IDF);

            //Получаем пользователя для отчета (руководитель)
            Users us = new Users();
            us = db.Users.FirstOrDefault(g => g.idFil == IDF & g.idDolj == 1);

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);


            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;                     
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;
            //------------------------------------------
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var a = Paragraph4.Range;
            a.Text = "ОАО \"Гомельтранснефть Дружба\"\n";
            a.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            a.Font.Underline = WdUnderline.wdUnderlineSingle;
            a.ParagraphFormat.SpaceAfter = 10;
                       

            var Paragraph5 = app.ActiveDocument.Paragraphs.Add();
            var aa = Paragraph5.Range;            
            aa.Text = or.Name +"\n";
            aa.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            aa.ParagraphFormat.SpaceAfter = 10;
                                  

            List<OstatSklad> LOS = new List<OstatSklad>();
            LOS = db.OstatSklad.Where(o=>o.Sklad.Organization.IdOrg ==IDF && o.Date >= S && o.Date <= Po).OrderByDescending(g => g.Date).ThenBy(g => g.Nefteproduct.Naimenovanie).ToList();
                      
            if (LOS == null)
            {
                var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
                var ssQ = ParagrapQ.Range;
                ssQ.Text = "Остатки нефтепродуктов за указанный период отсутствуют;";
                ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else
            {
                var res = LOS
.GroupBy(rt => new { rt.Nefteproduct.Naimenovanie, rt.Sklad.Name, rt.Nefteproduct.P, rt.Date, rt.Massa }).OrderBy(t => t.Key.Naimenovanie)
.Select(gr => new { OilProduct = gr.Key.Naimenovanie, Sklad = gr.Key.Name, Date = gr.Key.Date, Massa =gr.Key.Massa, Sum = gr.Sum(i => i.Massa), P = gr.Key.P }).OrderByDescending(h=>h.Date).ThenBy(j=>j.OilProduct).GroupBy(j => j.Sklad);
            
                    var ParagrapQQ = app.ActiveDocument.Paragraphs.Add();
                    var ssQQ = ParagrapQQ.Range;
                    ssQQ.Text = "Отчет по вводу остатков за период c " + S.ToString("d") + " по " + Po.ToString("d");
                    ssQQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    r.InsertAfter("\n\n");

                    //-------------------------------------------------------------------------------------------------------
                    var Paragraph2 = app.ActiveDocument.Paragraphs.Add();
                    var tableRange2 = Paragraph2.Range;
                    
                    Table tOsttest2 = doc.Tables.Add(tableRange2, LOS.Count + res.Select(h=>h.Key).Count(), 5);
                    tOsttest2.Borders.Enable = 1;
                    tOsttest2.Rows.Add();
                    tOsttest2.Rows[1].Cells[1].Range.Text = "Вид нефтепродукта";
                    tOsttest2.Rows[1].Cells[2].Range.Text = "Дата ввода остатков";
                    tOsttest2.Rows[1].Cells[3].Range.Text = "Плотность, т/куб.м";
                    tOsttest2.Rows[1].Cells[4].Range.Text = "Объем, куб.м";
                    tOsttest2.Rows[1].Cells[5].Range.Text = "Масса, тонн";

                    tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    int index = 1;
                foreach (var p in res)
                {
                    index++;
                    tOsttest2.Rows[index].Cells[1].Merge(tOsttest2.Rows[index].Cells[5]);
                    tOsttest2.Rows[index].Cells[1].Range.Text = p.Key.ToString();
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[index].Cells[1].Range.Font.Size = 12;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceBefore = 5;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceAfter = 5;
                    foreach (var y in p)
                    {
                        index++;
                        tOsttest2.Rows[index].Cells[1].Range.Text = y.OilProduct.ToString();
                        tOsttest2.Rows[index].Cells[2].Range.Text = Convert.ToDateTime(y.Date).ToString("d");
                        tOsttest2.Rows[index].Cells[3].Range.Text = Math.Round(Convert.ToDouble(y.P), 3).ToString();
                        tOsttest2.Rows[index].Cells[4].Range.Text = Math.Round(Convert.ToDouble(y.Massa), 0).ToString();
                        tOsttest2.Rows[index].Cells[5].Range.Text = Math.Round(Convert.ToDouble(y.Massa * y.P), 0).ToString();
                        tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Rows[index].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                }
                    ////-------------------------Вывод итогов нефтепродуктов по месяцам--------------------------------

                    //var Par1 = app.ActiveDocument.Paragraphs.Add();
                    //var PT = Par1.Range;
                    //PT.Text = "Итого по филиалу: \n";
                    //PT.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    //List<Nefteproduct> N = new List<Nefteproduct>();
                    //N = db.Nefteproduct.ToList();
                    //int indexx = 0;
                    //foreach (var y in N)
                    //{
                    //    double u = 0;
                    //    var Par = app.ActiveDocument.Paragraphs.Add();
                    //    var tab = Par.Range;
                    //    Table tb = doc.Tables.Add(tab, 1, 4);
                    //    tab.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    //    tb.Borders.Enable = 0;
                        
                    //    foreach (var item in LODATE.Where(f => f.IdNeftep == y.IdNeft))
                    //    {
                    //        u = u + Math.Round(Convert.ToDouble(item.Massa),0);
                    //    }
                    //    if (u != 0)
                    //    {
                    //        indexx++;
                    //        tb.Rows[indexx].Cells[1].Range.Text = y.Naimenovanie;
                    //        tb.Rows[indexx].Cells[2].Range.Text = "";
                    //        tb.Rows[indexx].Cells[3].Range.Text = u.ToString();
                    //        tb.Rows[indexx].Cells[4].Range.Text = Math.Round((u * Convert.ToDouble(y.P)), 0).ToString();

                    //        tb.Rows[indexx].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    //        tb.Rows[indexx].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    //        tb.Rows[indexx].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

                    //    }
                    //}                
                }
            //-----------------Вывод подписи исполнителя ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            var P = Paragraph6.Range;
            
            if (us1 == null)
            {
                P.Text = "";
            }
            else
            {
                P.Text =  us1.Doljnost.Naimenovanie + " ______________________ " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + "."  + us1.LastName;
            }
            P.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        
            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\Report.docx");
              //doc.SaveAs2(Server.MapPath("~/App_Data/Report.docx"));
            app.Documents.Open(@"C:\Install\Report.docx");
              //app.Documents.Open(Server.MapPath("~/App_Data/Report.docx"));

            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("Report.docx");
                        
            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\Report.docx");
              //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Report.docx");                       
        
    }
        //-----------------------------------------------------------------------------------------------------
        public ActionResult Reference()
        {

            return PartialView();
        }
        //-----------------Выводим на печать заявку---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult PrintZayWord(int ID)
        {

            Zayavka Z = new Zayavka();
            Z = db.Zayavka.FirstOrDefault(g => g.IdZay == ID);

            //Получаем название филиала для отчета
            Organization or = new Organization();
            or = db.Organization.FirstOrDefault(f => f.IdOrg == Z.IdOrg);

            //Получаем пользователя для отчета (руководитель)
            Users us = new Users();
            us = db.Users.FirstOrDefault(g => g.idFil == Z.IdOrg & g.Podpisant == 1);



            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);


            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";                      
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;
            r.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;


            var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
            var ssQ = ParagrapQ.Range;
            ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            Table t = doc.Tables.Add(ssQ, 1, 2);
            t.Borders.Enable = 0;

            foreach (Row row in t.Rows)
            {
                foreach (Cell cell in row.Cells)
                    if (cell.ColumnIndex == 1)
                    {
                        if (or == null)
                        {
                            cell.Range.Text = "ОАО Гомельтранснефть Дружба\n";
                        }
                        else
                        {
                            cell.Range.Text = "ОАО Гомельтранснефть Дружба \n" + or.Name;
                        }
                    }
                    else
                    {                        
                            cell.Range.Text = "Заместителю генерального директора (по транспорту нефти)\nОАО \"Гомельтранснефть Дружба\" \n" + "Булычеву С.Т.";
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    }
            }
            string Gor = "";
            string Podp = "";
            if (or.IdOrg ==2)
            {
                Gor = "г.Мозырь";
                Podp = "С.Л.Ящин";
            }
            if(or.IdOrg == 3)
            {
                Gor = "г.Гомель";
                Podp = "В.Л.Викулов";
            }
            if (or.IdOrg == 5)
            {
                Gor = "г.Оснежицы";
                Podp = "В.П.Якубец";
            }
            if (or.IdOrg == 6)
            {
                Gor = "г.Вересница";
                Podp = "В.Г.Королец";
            }
            if (or.IdOrg == 7)
            {
                Gor = "д.Жуховцы";
                Podp = "Н.Н.Куксюк";
            }
            if (or.IdOrg == 8)
            {
                Gor = "г.Гомель";
                Podp = "П.В.Мартыненко";
            }
            if (or.IdOrg == 9)
            {
                Gor = "г.Новополоцк";
                Podp = "Г.А.Снеговской";
            }
            if (or.IdOrg == 14)
            {
                Gor = "г.Гомель";
                Podp = "О.Л.Борисенко";
            }

            r.InsertAfter("\n");
            r.InsertAfter("ЗАЯВКА\n");
            if (Z.Number == null)
            {
                r.InsertAfter(Convert.ToDateTime(Z.DateZay).ToString("d") + " № " + "_______" + "\n");                
            }
            else
            {
                r.InsertAfter(Convert.ToDateTime(Z.DateZay).ToString("d") + " № "+ Z.Organization.Prefix + Z.NumberSch + "\n");
            }
            r.InsertAfter("" + Gor +"\n\n");
            r.InsertAfter("");

            r.InsertAfter("О доставке на филиал нефтепродуктов\n");
            r.InsertAfter("на " + Convert.ToDateTime(Z.DatePlan).ToString("y").ToLower() + "\n\n");
            
            DateTime S = DateTime.Now;
            DateTime Po = DateTime.Now.AddMonths(1);

            //проверка на нулевую заявку!!!!!!!
            decimal? masSum = 0;
            List<TableZay> TZq = new List<TableZay>();
            TZq = db.TableZay.Where(g => g.IdZay == ID).ToList();
            var resZayProverka = TZq
                .GroupBy(rtt => new { rtt.Nefteproduct.Naimenovanie, rtt.Sklad.Name, rtt.Nefteproduct.P, rtt.Massa })
                .Select(grt => new { OilProduct = grt.Key.Naimenovanie, Sklad = grt.Key.Name, Massa = grt.Key.Massa, P = grt.Key.P }).GroupBy(j => j.Sklad);
            foreach (var qr in TZq)
            {
                masSum = masSum + qr.Massa; 
            }

            if (masSum == 0)
            {
                
                r.InsertAfter("\t" + "Доставка нефтепродуктов на филиал не требуется."+ "\n");

            }
            else
            {
                //---------------------------------Выводим текст с остатками----------------------------------
                DateTime date1 = Convert.ToDateTime(Z.DateZay);
                int Month1 = date1.Month;
                int Year1 = date1.Year;
                int allDayMonth1 = DateTime.DaysInMonth(Year1, Month1);
                DateTime Begin1 = new DateTime(Year1, Month1, 1);

                List<OstatSklad> ListOst = new List<OstatSklad>();
                ListOst = db.OstatSklad.Where(g => g.Sklad.Organization.IdOrg == Z.Organization.IdOrg &&g.Date >= Begin1 && g.Date <= Z.DateZay).OrderByDescending(j => j.Date).OrderByDescending(h => h.Date).ToList();
                
                List<OstatSklad> ListOstLast = new List<OstatSklad>();
                OstatSklad OSTSKL = new OstatSklad();

                List<TableZay> TZ = new List<TableZay>();
                TZ = db.TableZay.Where(g => g.IdZay == ID && g.Massa != 0).ToList();
                                
                foreach (var item in TZ)
                {
                    OSTSKL = ListOst.Where(q => q.IdNeftep == item.IdNeftep && q.IdSkl == item.IdSklad).FirstOrDefault();
                    if (OSTSKL != null)
                    {
                        ListOstLast.Add(OSTSKL);
                    }
                }
                r.InsertAfter("\n");
                var res = ListOst
                .GroupBy(rt => new { rt.Nefteproduct.Naimenovanie, rt.Sklad.Name, rt.Nefteproduct.P, rt.Massa })
                .Select(gr => new { OilProduct = gr.Key.Naimenovanie, Sklad = gr.Key.Name, Massa = gr.Key.Massa, P = gr.Key.P }).GroupBy(j => j.Sklad);

                var rtr = ListOst.Count();
                var rts = res.Count();

                if(rtr == 0)
                {
                    var ParagrapQ1 = app.ActiveDocument.Paragraphs.Add();
                    var ssQ1 = ParagrapQ1.Range;
                    ssQ1.Text = "\t" + "Остатки нефтепродуктов по филиалу на " + Convert.ToDateTime(Z.DateZay).ToString("d") + " отсутствуют \n";
                    ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                    var Paragraph22 = app.ActiveDocument.Paragraphs.Add();
                    var tableRange22 = Paragraph22.Range;
                                        
                }
                else
                {
                var ParagrapQ1 = app.ActiveDocument.Paragraphs.Add();
                var ssQ1 = ParagrapQ1.Range;
                ssQ1.Text = "\t" + "Остатки нефтепродуктов по филиалу на " + Convert.ToDateTime(Z.DateZay).ToString("d") + " составили: \n";
                ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                var Paragraph22 = app.ActiveDocument.Paragraphs.Add();
                var tableRange22 = Paragraph22.Range;
                               
                Table tOsttest22 = doc.Tables.Add(tableRange22, ListOst.Count() + res.Count(), 1);
                tOsttest22.Borders.Enable = 0;
                //tOsttest22.Rows.Add();

                int index = 0;
                foreach (var p in res)
                {
                    index++;
                    tOsttest22.Rows[index].Cells[1].Range.Text = "\t" + p.Key.ToString() + ":";
                    tOsttest22.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest22.Rows[index].Cells[1].Range.Font.Size = 14;

                    foreach (var y in p)
                    {
                        index++;
                        tOsttest22.Rows[index].Cells[1].Range.Text = "\t\t" + y.OilProduct.ToString() + " - " + Math.Round(Convert.ToDouble(y.Massa), 0).ToString() + " м.куб. " + " (" + Math.Round(Convert.ToDouble(y.Massa) * Convert.ToDouble(y.P)) + " тонн)"; ;
                        tOsttest22.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                }
                }                

                List<Nefteproduct> N = new List<Nefteproduct>();
                N = db.Nefteproduct.ToList();

                r.InsertAfter("\t" + "В соответствии с планом работ филиала на " + Convert.ToDateTime(Z.DatePlan).ToString("y").ToLower() + " и планируемой заправки автотранспортной техники других филиалов ОАО \"Гомельтранснефть Дружба\" прошу доставить на филиал следующее количество нефтепродуктов:" + "\n");

                //Заполняем для заявки количество нефтепродуктов

                //---------------------------------------------------------------------------
                var resZay = TZ
                .GroupBy(rtt => new { rtt.Nefteproduct.Naimenovanie, rtt.Sklad.Name, rtt.Nefteproduct.P, rtt.Massa })
                .Select(grt => new { OilProduct = grt.Key.Naimenovanie, Sklad = grt.Key.Name, Massa = grt.Key.Massa, P = grt.Key.P }).GroupBy(j => j.Sklad);

                var Paragraph222 = app.ActiveDocument.Paragraphs.Add();
                var tableRange222 = Paragraph222.Range;

                Table tOsttest222 = doc.Tables.Add(tableRange222, TZ.Count() + resZay.Count(), 1);
                tOsttest222.Borders.Enable = 0;

                int index2 = 0;
                foreach (var p in resZay)
                {
                    index2++;
                    tOsttest222.Rows[index2].Cells[1].Range.Text = "\t" + p.Key.ToString();
                    tOsttest222.Rows[index2].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest222.Rows[index2].Cells[1].Range.Font.Size = 14;

                    foreach (var y in p)
                    {
                        index2++;
                        tOsttest222.Rows[index2].Cells[1].Range.Text = "\t\t" + y.OilProduct.ToString() + " - " + Math.Round(Convert.ToDouble(y.Massa), 0).ToString() + " м.куб." + " (" + Math.Round(Convert.ToDouble(y.Massa) * Convert.ToDouble(y.P)) + " тонн)"; ;
                        tOsttest222.Rows[index2].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    }
                }
                //------------------------------Выводим приложение----------------------------
                // r.InsertAfter("\n");
                //    var Paragraph23 = app.ActiveDocument.Paragraphs.Add();
                //var tableRange23 = Paragraph23.Range;

                //Table tOsttest23 = doc.Tables.Add(tableRange23, 1, 2);
                //    //tOsttest23.Rows.Add();
                //    tOsttest23.Cell(1, 1).SetWidth(100, WdRulerStyle.wdAdjustNone);
                //    tOsttest23.Cell(1, 2).SetWidth(350, WdRulerStyle.wdAdjustNone);

                //    tOsttest23.Rows[1].Cells[1].Range.Text = "Приложение:";
                //    tOsttest23.Rows[1].Cells[2].Range.Text = "План работ филиала на " + Convert.ToDateTime(Z.DatePlan).ToString("y").ToLower() + " с использованием автотранспортных средств.";
            }

            r.InsertAfter("\n");
                        
            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            
            if (us == null)
            {
               r.InsertAfter("                _______________                 ");
            }
            
            else
            {
                //r.InsertAfter(us.Doljnost.Naimenovanie + "  _______________  "  + " " + us.FirstName.Substring(0, 1) + "." + us.MidleName.Substring(0, 1) + "."+ us.LastName);
                r.InsertAfter("Начальник филиала " + "  _______________  " + Podp);
            }
            //------------------Выводим МОЛ с номером телефона----------------------------------------------------------
            
            r.InsertAfter("\n");
            r.InsertAfter("\n");
            r.InsertAfter("\n");

            var Paragraph3 = app.ActiveDocument.Paragraphs.Add();
            var hhh = Paragraph3.Range;
            hhh.Font.Size = 9;
            
            if (us1 == null)
            {
                hhh.Text = "";
            }
            else
            {
                hhh.Text = ( us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + "." + us1.LastName + " " + ". тел.: " + us1.Phone);
            }

            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\ReportZay.docx");
            //doc.SaveAs2(Server.MapPath("~/App_Data/Report.docx"));
            app.Documents.Open(@"C:\Install\ReportZay.docx");
            //app.Documents.Open(Server.MapPath("~/App_Data/Report.docx"));

            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("ReportZay.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\ReportZay.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ReportZay.docx");

        }
        //-----------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult GetOstatTab(int IDF, DateTime S, DateTime Po)
        {
            List<OstatSklad> ostTab = new List<OstatSklad>();
            ostTab = db.OstatSklad.Where(a => a.Sklad.Organization.IdOrg == IDF && a.Date >= S && a.Date <= Po).OrderByDescending(g=>g.Date).ThenBy(r=>r.Sklad).ThenBy(g=>g.Nefteproduct.Naimenovanie).ToList();
            return PartialView(ostTab);
        }
        //-----------------------------//

        //-------Вывод логинов и паролей------------------------------------------------
        public ActionResult LoginPassword()
        {
            List<Autorize> LogPass = new List<Autorize>();
            LogPass = db.Autorize.OrderBy(j=>j.Users.Organization.Name).ThenBy(h=>h.Users.LastName).ToList();
            return View(LogPass);
        }
        //------------------------------------------------------------------------------
        //-----------Добавление новаго logina, password, привязка пользователя и назначение ролей--------------------------
        public ActionResult AddLoginPassword()
        {                       

            List<RecordOil.Models.Roles> Rol = new List<RecordOil.Models.Roles>();
            Rol = db.Roles.ToList();
            ViewBag.Rol = Rol;

            SelectList USERSEL = new SelectList(db.Users.OrderBy(f=>f.LastName), "IdUserrs", "LastName");
            ViewBag.USERSEL = USERSEL;

            List<Users> USer = new List<Users>();
            USer = db.Users.OrderBy(f=>f.LastName).ToList();
            ViewBag.USer = USer;

            return PartialView();
        }
        //-----------------------------------------------------------------------------------------------------------------
        public ActionResult LoginPasswordSave(string Login, string Password, string idUS, string UserLog, DateTime DateLog, List<string> dd)
        {            
            try
            {
                //Записываем данные в таблицу Autorize
                Autorize aut = new Autorize();
                aut.Login = Login.Trim();
                aut.Password = Password;
                aut.UserModific = UserLog.Trim();
                aut.DateModific = DateLog;
                if(idUS =="")
                {
                    aut.RoleId = null;
                }

                else
                {
                    aut.RoleId = Convert.ToInt32(idUS);
                }                   
                db.Autorize.Add(aut);

                db.SaveChanges();
                //--------------------------------------
                //Теперь работаем с таблицей UserRoles

                TableDog TD = new TableDog();

                int IDDOD = db.Autorize.FirstOrDefault(g => g.Login.Trim() == Login.Trim()).ID;

                foreach (var it in dd)
                {
                    UserRoles ur = new UserRoles();
                    ur.IdUser = IDDOD;
                    ur.idRole = Convert.ToInt32(it);
                    db.UserRoles.Add(ur);
                    db.SaveChanges();
                }


                ViewBag.Message = "Пользователь успешно добавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

           
        //----------Получаем список заявок в зависимости от дат---------------------------------------------------------------
        [HttpPost]
        public ActionResult GetZayTab(int IDF, DateTime SZ, DateTime PoZ, DateTime SZM, DateTime PoZM)
        {
            List<Zayavka> zayTab = new List<Zayavka>();
            zayTab = db.Zayavka.Where(a => a.IdOrg == IDF && a.DateZay >= SZ && a.DateZay <= PoZ && a.DatePlan >= SZM && a.DatePlan <= PoZM).OrderByDescending(g => g.DateZay).ThenByDescending(g => g.NumberSch).ToList();
            return PartialView(zayTab);
        }
        //-----------------------------//
        //---------Печать списка заявок-------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult PrintZayList(string IDF, int Soglas, DateTime SZ, DateTime PoZ, DateTime SZM, DateTime PoZM)
        {            
            //Получаем название филиала для отчета
            //Organization or = new Organization();
            //or = db.Organization.FirstOrDefault(f => f.IdOrg == IDF);
             
            //Получаем пользователя для отчета (руководитель)
            Users us = new Users();
            us = db.Users.FirstOrDefault(g => g.idDolj == 1);

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);

            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;
            
            //------------------------------------------
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var a = Paragraph4.Range;
            a.Text = "ОАО \"Гомельтранснефть Дружба\"\n";
            a.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            a.Font.Underline = WdUnderline.wdUnderlineSingle;
            a.ParagraphFormat.SpaceAfter = 10;


            var Paragraph5 = app.ActiveDocument.Paragraphs.Add();
            var aa = Paragraph5.Range;
            //aa.Text = or.Name + "\n";
            aa.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            aa.ParagraphFormat.SpaceAfter = 10;


            //--------Выводим таблицы с заявками по месяцам-------------------------------------------------------

            List<Zayavka> LOS = new List<Zayavka>();
            

            if (IDF =="")
            {
                LOS = db.Zayavka.Where(o => o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderBy(i => i.DateZay).ToList();
                
                if (Soglas == 2)
                {
                    LOS = LOS.Where(t => t.UserSoglas != null).ToList();
                }
                else if (Soglas == 3)
                {
                    LOS = LOS.Where(t => t.UserSoglas == null).ToList();
                }

                //-----------------------------------------------------------------
                //var ListGR = db.TableZay.Join(db.Zayavka.Where(o =>o.IdOrg == IDF o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM), c => c.IdZay, u => u.IdZay, (c, o) =>
                //         new { Oil = c.Nefteproduct.Naimenovanie, sklad = c.Sklad.Name, Massa = c.Massa, p = c.Nefteproduct.P, Data = o.DateZay }).OrderBy(h => h.sklad).ThenBy(k => k.Oil).ThenBy(g => g.Data).ToList();
                //-----------------------------------------------------------------
            }
            else
            {
                int? IDFINT = null;
                IDFINT = db.Organization.FirstOrDefault(jp => jp.Name == IDF.Trim()).IdOrg;
                               
                LOS = db.Zayavka.Where(o => o.IdOrg == IDFINT && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderBy(i => i.DateZay).ToList();
                        
            if (Soglas == 2)
            {
                    LOS = db.Zayavka.Where(o => o.IdOrg == IDFINT && o.UserSoglas != null && o.IdOrg == Convert.ToInt32(IDF) && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderBy(i => i.DateZay).ToList();

                }
                else if (Soglas == 3)
            {
                    LOS = db.Zayavka.Where(o => o.IdOrg == IDFINT && o.UserSoglas == null && o.IdOrg == Convert.ToInt32(IDF) && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderBy(i => i.DateZay).ToList();

                }
            }

            if (LOS == null)
            {
                var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
                var ssQ = ParagrapQ.Range;
                ssQ.Text = "Заявки нефтепродуктов за указанный период отсутствуют;";
                ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else
            { 
                List<TableZay> TZ = new List<TableZay>();
                
                var test = LOS.Select(g => g.IdZay).Distinct();

                foreach (var it in LOS.Select(g=>g.IdZay).Distinct())
                {
                    List<TableZay> TZL = new List<TableZay>();
                    TZL = db.TableZay.Where(f => f.IdZay == it && f.Massa !=0).ToList();
                    TZ.AddRange(TZL);
                }
                List<Zayavka> ListZayID = new List<Zayavka>();
                ListZayID = db.Zayavka./*Where(h => h.IdOrg == IDF).*/ToList();

                //var res = TZ
                //.GroupBy(rt => new { rt.Nefteproduct.Naimenovanie, rt.Sklad.Name, rt.Nefteproduct.P, rt.Massa, rt.Zayavka.DateZay }).OrderBy(t => t.Key.Naimenovanie)
                //.Select(gr => new { OilProduct = gr.Key.Naimenovanie, Sklad = gr.Key.Name, Massa = gr.Key.Massa, Sum = gr.Sum(i => i.Massa), P = gr.Key.P, Data = gr.Key.DateZay }).GroupBy(j => j.Sklad);

                var res1 = TZ
                .GroupBy(rt => new { rt.Nefteproduct.Naimenovanie, rt.Sklad.Name, rt.Nefteproduct.P, rt.Massa, rt.Zayavka.DateZay }).OrderBy(t => t.Key.Naimenovanie);
                
                int ew7 = res1.Count();

                var res = res1.Select(gr => new { OilProduct = gr.Key.Naimenovanie, Sklad = gr.Key.Name, Massa = gr.Key.Massa, Sum = gr.Sum(i => i.Massa), P = gr.Key.P, Data = gr.Key.DateZay }).GroupBy(j => j.Sklad);

                var ParagrapQQ = app.ActiveDocument.Paragraphs.Add();
                    var ssQQ = ParagrapQQ.Range;
                    ssQQ.Text = "Отчет по вводу заявок за период с " +SZ.ToString("d") + " по " + PoZ.ToString("d");
                    ssQQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    r.InsertAfter("\n\n");                                
                //-------------------------------------------------------------------------------------------------------
                var Paragraph2 = app.ActiveDocument.Paragraphs.Add();
                var tableRange2 = Paragraph2.Range;
                
                int ew = res.Count();
                Table tOsttest2 = doc.Tables.Add(tableRange2, res1.Count() + res.Count(), 5);
                tOsttest2.Borders.Enable = 1;
                tOsttest2.Rows.Add();
                tOsttest2.Rows[1].Cells[1].Range.Text = "Вид нефтепродукта";
                tOsttest2.Rows[1].Cells[2].Range.Text = "Дата ввода заявки";
                tOsttest2.Rows[1].Cells[3].Range.Text = "Плотность, т/м3";
                tOsttest2.Rows[1].Cells[4].Range.Text = "Объем, м3";
                tOsttest2.Rows[1].Cells[5].Range.Text = "Масса, тонн";

                tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                int index = 1;
                foreach (var p in res)
                {
                    index++;
                    tOsttest2.Rows[index].Cells[1].Merge(tOsttest2.Rows[index].Cells[5]);
                    tOsttest2.Rows[index].Cells[1].Range.Text = p.Key.ToString();
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[index].Cells[1].Range.Font.Size = 12;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceBefore = 5;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceAfter = 5;
                    foreach (var y in p)
                    {
                        index++;
                        tOsttest2.Rows[index].Cells[1].Range.Text = y.OilProduct.ToString();
                        tOsttest2.Rows[index].Cells[2].Range.Text = Convert.ToDateTime(y.Data).ToString("d");
                        tOsttest2.Rows[index].Cells[3].Range.Text = Math.Round(Convert.ToDouble(y.P), 3).ToString();
                        tOsttest2.Rows[index].Cells[4].Range.Text = Math.Round(Convert.ToDouble(y.Massa), 0).ToString();
                        tOsttest2.Rows[index].Cells[5].Range.Text = Math.Round(Convert.ToDouble(y.Massa * y.P), 0).ToString();
                        tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Rows[index].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                }
                //-------------------------Вывод итогов нефтепродуктов по месяцам--------------------------------

                    var Par1 = app.ActiveDocument.Paragraphs.Add();
                    var PT = Par1.Range;
                    PT.Text = "Итого по филиалу: \n";
                    PT.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                
                var resITOG = TZ
.GroupBy(rt => new { rt.Nefteproduct.Naimenovanie, rt.Sklad.Name, rt.Nefteproduct.P, rt.Massa }).OrderBy(t => t.Key.Naimenovanie)
.Select(gr => new { OilProduct = gr.Key.Naimenovanie, Sklad = gr.Key.Name, Massa = gr.Key.Massa, SumM = gr.Sum(i => i.Massa), P = gr.Key.P }).GroupBy(j => j.OilProduct);

                var Par = app.ActiveDocument.Paragraphs.Add();
                var tab = Par.Range;
                Table tb = doc.Tables.Add(tab, resITOG.Select(f=>f.Key).Count(), 5);
                tab.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                tb.Borders.Enable = 0;

                int index1 = 0;                
                foreach (var p in resITOG)
                {    
                    double Summm = 0;
                    double SummmP = 0;
                    foreach (var it in p)
                    {
                        if(it.OilProduct == p.Key)
                        { Summm += Math.Round(Convert.ToDouble(it.Massa));
                            SummmP += Math.Round(Convert.ToDouble(it.Massa * it.P));
                        }
                    }
                    index1++;
                    tb.Rows[index1].Cells[1].Range.Text = p.Key;
                    tb.Rows[index1].Cells[2].Range.Text = "";
                    tb.Rows[index1].Cells[3].Range.Text = "";
                    tb.Rows[index1].Cells[4].Range.Text = Math.Round(Convert.ToDouble(Summm),0).ToString();
                    tb.Rows[index1].Cells[5].Range.Text = Math.Round(Convert.ToDouble(SummmP), 0).ToString();
                    tb.Rows[index1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tb.Rows[index1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tb.Rows[index1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tb.Rows[index1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tb.Rows[index1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                }            
            }

            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            var P = Paragraph6.Range;

            if (us1 == null)
            {
                P.Text = "";
            }
            else
            {
                P.Text = us1.Doljnost.Naimenovanie + " ______________________ " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + "." + us1.LastName;
            }
            P.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        
            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\Report.docx");            
            app.Documents.Open(@"C:\Install\Report.docx");            
            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("Report.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\Report.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Report.docx");

        }

        //---НОВЫЙ СПИСОК ЗАЯВОК ПЕРЕДЕЛАННЫЙ-----------------------------------------------------------------------------------------------------------------------

        //---------Печать списка заявок для регистрации-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult PrintZayListRegistration(int IDF, DateTime SZ, DateTime PoZ, DateTime SZM, DateTime PoZM)
        {
            //Получаем название филиала для отчета
            Organization or = new Organization();
            or = db.Organization.FirstOrDefault(f => f.IdOrg == IDF);

            //Получаем пользователя для отчета (руководитель)
            Users us = new Users();
            us = db.Users.FirstOrDefault(g => g.idDolj == 1);

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);

            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;

            //------------------------------------------
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var a = Paragraph4.Range;
            a.Text = "ОАО \"Гомельтранснефть Дружба\"\n";
            a.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            a.Font.Underline = WdUnderline.wdUnderlineSingle;
            a.ParagraphFormat.SpaceAfter = 10;


            var Paragraph5 = app.ActiveDocument.Paragraphs.Add();
            var aa = Paragraph5.Range;
            aa.Text = or.Name + "\n";
            aa.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            aa.ParagraphFormat.SpaceAfter = 10;


            //--------Выводим таблицы с заявками по месяцам-------------------------------------------------------

            List<Zayavka> LOS = new List<Zayavka>();
            LOS = db.Zayavka.Where(o => o.IdOrg == IDF && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderByDescending(i => i.DateZay).ThenByDescending(k=>k.NumberSch).ToList();

            string Gor = "";
            string Podp = "";
            if (IDF == 2)
            {
                Gor = "г.Мозырь";
                Podp = "С.Л.Ящин";
            }
            if (IDF == 3)
            {
                Gor = "г.Гомель";
                Podp = "В.Л.Викулов";
            }
            if (IDF == 5)
            {
                Gor = "г.Оснежицы";
                Podp = "В.П.Якубец";
            }
            if (IDF == 6)
            {
                Gor = "г.Вересница";
                Podp = "В.Г.Королец";
            }
            if (IDF == 7)
            {
                Gor = "д.Жуховцы";
                Podp = "Н.Н.Куксюк";
            }
            if (IDF == 8)
            {
                Gor = "г.Гомель";
                Podp = "П.В.Мартыненко";
            }
            if (IDF == 9)
            {
                Gor = "г.Новополоцк";
                Podp = "Г.А.Снеговской";
            }
            if (IDF == 14)
            {
                Gor = "г.Гомель";
                Podp = "О.Л.Борисенко";
            }
            
            if (LOS == null)
            {
                var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
                var ssQ = ParagrapQ.Range;
                ssQ.Text = "Заявки нефтепродуктов за указанный период отсутствуют;";
                ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else
            {
                List<TableZay> TZ = new List<TableZay>();

                var test = LOS.Select(g => g.IdZay).Distinct();

                foreach (var it in LOS.Select(g => g.IdZay).Distinct())
                {
                    List<TableZay> TZL = new List<TableZay>();
                    TZL = db.TableZay.Where(f => f.IdZay == it).ToList();
                    TZ.AddRange(TZL);
                }
                List<Zayavka> ListZayID = new List<Zayavka>();
                ListZayID = db.Zayavka.Where(h => h.IdOrg == IDF).ToList();
                //-------------------------------------------------------------------------------------------------------
                var ListGR = db.TableZay.Join(db.Zayavka
                    .Where(o => o.IdOrg == IDF && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM), c => c.IdZay, u => u.IdZay, (c, o) =>
                         new { Oil = c.Nefteproduct.Naimenovanie, sklad = c.Sklad.Name, Massa = c.Massa, p = c.Nefteproduct.P, Data = o.DateZay }).OrderBy(h => h.sklad).ThenBy(k => k.Oil).ThenBy(g => g.Data).ToList();
                //--------------------------------------------------------------------------------------------------------
                                
                var res = ListGR.GroupBy(j => j.sklad);

                var ParagrapQQ = app.ActiveDocument.Paragraphs.Add();
                var ssQQ = ParagrapQQ.Range;
                ssQQ.Text = "Журнал регистрации заявок на нефтепродукты \n" + "за период с " + SZ.ToString("d") + " по " + PoZ.ToString("d");
                ssQQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                r.InsertAfter("\n\n");
                //-------------------------------------------------------------------------------------------------------
                var Paragraph2 = app.ActiveDocument.Paragraphs.Add();
                var tableRange2 = Paragraph2.Range;
                tableRange2.Font.Size = 14;
                Table tOsttest2 = doc.Tables.Add(tableRange2, LOS.Count, 7);
                tOsttest2.Borders.Enable = 1;
                tOsttest2.Rows.Add();
                tOsttest2.Rows[1].Cells[1].Range.Text = "Дата";
                tOsttest2.Rows[1].Cells[2].Range.Text = "Номер заявки";
                tOsttest2.Rows[1].Cells[3].Range.Text = "Плановый месяц";
                tOsttest2.Rows[1].Cells[4].Range.Text = "Дата согласования";
                tOsttest2.Rows[1].Cells[5].Range.Text = "Кто согласовал";
                tOsttest2.Rows[1].Cells[6].Range.Text = "Дата созд./изм. заявки";
                tOsttest2.Rows[1].Cells[7].Range.Text = "Кто создал заявку";

                tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[1].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[2].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[3].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[4].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[5].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[6].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[6].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[7].Range.Font.Size = 12;

                int index = 1;
                foreach (var y in LOS)
                {
                    index++;
                    tOsttest2.Rows[index].Cells[1].Range.Text = Convert.ToDateTime(y.DateZay).ToString("d");
                    tOsttest2.Rows[index].Cells[2].Range.Text = y.Organization.Prefix +  y.NumberSch;
                    tOsttest2.Rows[index].Cells[3].Range.Text = Convert.ToDateTime(y.DatePlan).ToString("Y").ToLower();
                    if(y.DateSoglas !=null)
                    {
                    tOsttest2.Rows[index].Cells[4].Range.Text = Convert.ToDateTime(y.DateSoglas).ToString("d");
                    }
                    else
                    {
                        tOsttest2.Rows[index].Cells[4].Range.Text = "";

                    }
                    tOsttest2.Rows[index].Cells[5].Range.Text = y.UserSoglas;
                    tOsttest2.Rows[index].Cells[6].Range.Text = Convert.ToDateTime(y.DateModific).ToString("d");
                    tOsttest2.Rows[index].Cells[7].Range.Text = y.UserModific;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[1].Range.Font.Size = 10;
                    tOsttest2.Rows[index].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[2].Range.Font.Size = 10;
                    tOsttest2.Rows[index].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[3].Range.Font.Size = 10;
                    tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[4].Range.Font.Size = 10;
                    tOsttest2.Rows[index].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[5].Range.Font.Size = 10;
                    tOsttest2.Rows[index].Cells[6].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[6].Range.Font.Size = 10;
                    tOsttest2.Rows[index].Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Rows[index].Cells[7].Range.Font.Size = 10;
                }
                //-------------------------Вывод итогов нефтепродуктов по месяцам--------------------------------

                
            }

            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            var P = Paragraph6.Range;

            //if (us1 == null)
            //{
            //    P.Text = "";
            //}
            //else
            //{
            //    P.Text = us1.Doljnost.Naimenovanie + " ______________________ " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + "." + us1.LastName;
            //}
            P.Text = "Начальник филиала" + " ______________________ " + Podp;
            P.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\Report.docx");
            app.Documents.Open(@"C:\Install\Report.docx");
            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("Report.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\Report.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ReportRegistration.docx");
            
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------Печать списка заявок для регистрации-------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult PrintZayListRegistrationTot(string IDF, int Soglas, DateTime SZ, DateTime PoZ, DateTime SZM, DateTime PoZM)
        {
           
            //Получаем пользователя для отчета (руководитель)
            Users us = new Users();
            us = db.Users.FirstOrDefault(g => g.idDolj == 1);

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);

            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;

            //------------------------------------------
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var a = Paragraph4.Range;
            a.Text = "ОАО \"Гомельтранснефть Дружба\"\n";
            a.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            a.Font.Underline = WdUnderline.wdUnderlineSingle;
            a.ParagraphFormat.SpaceAfter = 10;


            //var Paragraph5 = app.ActiveDocument.Paragraphs.Add();
            //var aa = Paragraph5.Range;
            //aa.Text = or.Name + "\n";
            //aa.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            //aa.ParagraphFormat.SpaceAfter = 10;


            //--------Выводим таблицы с заявками по месяцам-------------------------------------------------------

            List<Zayavka> LOS = new List<Zayavka>();
            if (IDF == "")
            {
            LOS = db.Zayavka.Where(o =>o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderByDescending(i => i.DateZay).ThenByDescending(k => k.NumberSch).ToList();
            }
            else
            {
               int numb = db.Organization.FirstOrDefault(k => k.Name == IDF.Trim()).IdOrg;
                LOS = db.Zayavka.Where(o =>o.IdOrg == numb && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM).OrderByDescending(i => i.DateZay).ThenByDescending(k => k.NumberSch).ToList();
            }

            if (LOS == null)
            {
                var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
                var ssQ = ParagrapQ.Range;
                ssQ.Text = "Заявки нефтепродуктов за указанный период отсутствуют;";
                ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            else
            {
                List<TableZay> TZ = new List<TableZay>();

                var test = LOS.Select(g => g.IdZay).Distinct();

                foreach (var it in LOS.Select(g => g.IdZay).Distinct())
                {
                    List<TableZay> TZL = new List<TableZay>();
                    TZL = db.TableZay.Where(f => f.IdZay == it).ToList();
                    TZ.AddRange(TZL);
                }

                //-------------------------------------------------------------------------------------------------------
                //var ListGR = db.TableZay.Join(db.Zayavka
                //    .Where(o => o.IdOrg == IDF && o.DateZay >= SZ && o.DateZay <= PoZ && o.DatePlan >= SZM && o.DatePlan <= PoZM), c => c.IdZay, u => u.IdZay, (c, o) =>
                //         new { Oil = c.Nefteproduct.Naimenovanie, sklad = c.Sklad.Name, Massa = c.Massa, p = c.Nefteproduct.P, Data = o.DateZay }).OrderBy(h => h.sklad).ThenBy(k => k.Oil).ThenBy(g => g.Data).ToList();
                //--------------------------------------------------------------------------------------------------------

                //var res = ListGR.GroupBy(j => j.sklad);

                var ParagrapQQ = app.ActiveDocument.Paragraphs.Add();
                var ssQQ = ParagrapQQ.Range;
                ssQQ.Text = "Журнал регистрации заявок на нефтепродукты \n" + "за период с " + SZ.ToString("d") + " по " + PoZ.ToString("d");
                ssQQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                r.InsertAfter("\n\n");
                //-------------------------------------------------------------------------------------------------------
                var LOSGR = LOS.GroupBy(hj => hj.Organization.Name);

                var Paragraph2 = app.ActiveDocument.Paragraphs.Add();
                var tableRange2 = Paragraph2.Range;
                tableRange2.Font.Size = 14;
                Table tOsttest2 = doc.Tables.Add(tableRange2, LOS.Count +LOSGR.Count(), 7);
                tOsttest2.Borders.Enable = 1;
                tOsttest2.Rows.Add();
                tOsttest2.Rows[1].Cells[1].Range.Text = "Дата";
                tOsttest2.Rows[1].Cells[2].Range.Text = "Номер заявки";
                tOsttest2.Rows[1].Cells[3].Range.Text = "Плановый месяц";
                tOsttest2.Rows[1].Cells[4].Range.Text = "Дата согласования";
                tOsttest2.Rows[1].Cells[5].Range.Text = "Кто согласовал";
                tOsttest2.Rows[1].Cells[6].Range.Text = "Дата созд./изм. заявки";
                tOsttest2.Rows[1].Cells[7].Range.Text = "Кто создал заявку";

                tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[1].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[2].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[3].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[4].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[5].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[6].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[6].Range.Font.Size = 12;
                tOsttest2.Rows[1].Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[7].Range.Font.Size = 12;

                

                int index = 1;
                foreach (var p in LOSGR)
                {
                    index++;
                    tOsttest2.Rows[index].Cells[1].Merge(tOsttest2.Rows[index].Cells[7]);
                    tOsttest2.Rows[index].Cells[1].Range.Text = p.Key.ToString();
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    tOsttest2.Rows[index].Cells[1].Range.Font.Size = 12;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceBefore = 5;
                    tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceAfter = 5;
                    foreach (var y in p)
                    {
                        index++;
                        tOsttest2.Rows[index].Cells[1].Range.Text = Convert.ToDateTime(y.DateZay).ToString("d");
                        tOsttest2.Rows[index].Cells[2].Range.Text = y.Organization.Prefix + y.NumberSch;
                        tOsttest2.Rows[index].Cells[3].Range.Text = Convert.ToDateTime(y.DatePlan).ToString("Y").ToLower();
                        if (y.DateSoglas != null)
                        {
                            tOsttest2.Rows[index].Cells[4].Range.Text = Convert.ToDateTime(y.DateSoglas).ToString("d");
                        }
                        else
                        {
                            tOsttest2.Rows[index].Cells[4].Range.Text = "";

                        }
                        tOsttest2.Rows[index].Cells[5].Range.Text = tOsttest2.Rows[index].Cells[5].Range.Text = y.UserSoglas;
                        tOsttest2.Rows[index].Cells[6].Range.Text = Convert.ToDateTime(y.DateModific).ToString("d");
                        tOsttest2.Rows[index].Cells[7].Range.Text = y.UserModific;
                        tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Rows[index].Cells[1].Range.Font.Size = 12;
                        tOsttest2.Rows[index].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[2].Range.Font.Size = 11;
                        tOsttest2.Rows[index].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[3].Range.Font.Size = 12;
                        tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[4].Range.Font.Size = 12;
                        tOsttest2.Rows[index].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[5].Range.Font.Size = 12;
                        tOsttest2.Rows[index].Cells[6].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[6].Range.Font.Size = 12;
                        tOsttest2.Rows[index].Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Rows[index].Cells[7].Range.Font.Size = 12;
                    }
                }
                               
           
                //-------------------------Вывод итогов нефтепродуктов по месяцам--------------------------------

            }

            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            var P = Paragraph6.Range;

            if (us1 == null)
            {
                P.Text = "";
            }
            else
            {
                P.Text = us1.Doljnost.Naimenovanie + " ______________________ " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + "." + us1.LastName;
            }
            //P.Text = "Начальник отдела" + " ______________________ " + "Г.А.Киреев";
            P.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\Report.docx");
            app.Documents.Open(@"C:\Install\Report.docx");
            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("Report.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\Report.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ReportRegistration.docx");

        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------

        //------------Сводные заявки филиалов-----------------------------------------------------------------------------------------
        public ActionResult ZayTotal()
        {

            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 01);
            DateTime firstlastmonth = firstOfMonth.AddMonths(1);

            List<ZayTotal> zayT = new List<ZayTotal>();
            zayT = db.ZayTotal.Where(f=>f.DateZayTotal >=firstOfMonth && f.DateZayTotal <= DateTime.Now && f.DatePlanTotal == firstlastmonth).OrderByDescending(g => g.DateZayTotal).ThenByDescending(k => k.NumberTotalInt).ToList();

            //Получаем префикс ау
            string pref = "";
            pref = db.Organization.FirstOrDefault(y => y.IdOrg == 14).Prefix;
            ViewBag.prefA = pref;

            return View(zayT);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //----------Добавление заявки-----------------------//
        public ActionResult AddTotalZay()
        {
            SelectList FilialZay = new SelectList(db.Users, "IdUserrs", "LastName");
            ViewBag.FilZay = FilialZay;

            SelectList FilialFil = new SelectList(db.Organization, "IdOrg", "Name");
            ViewBag.FilialFil = FilialFil;

            SelectList NeftList = new SelectList(db.Nefteproduct.Where(g => g.PriznakIsp == 1), "Naimenovanie", "Naimenovanie");
            ViewBag.NeftList = NeftList;

            string prefAU = "";
            if (db.Organization.FirstOrDefault(a => a.IdOrg == 14).Prefix != null)
            {
                prefAU = db.Organization.FirstOrDefault(a => a.IdOrg == 14).Prefix;
            }
            else
            {
                prefAU = "";
            }
            
            ViewBag.PrefAU = prefAU;

            List<ZayTotal> LZSPIS = new List<ZayTotal>();            
            LZSPIS = db.ZayTotal.OrderByDescending(y => y.DateZayTotal).ThenByDescending(t => t.NumberTotalInt).ToList();
            int sch = 0;
            if (LZSPIS.Count != 0)
            {
                sch = Convert.ToInt32(LZSPIS.FirstOrDefault().NumberTotalInt) + 1;
            }
            else
            {
                sch = 1;
            }
            ViewBag.SCHT = sch;

            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления сводной заявки-----------//
        [HttpPost]
        public ActionResult ZayTotalSave(int NumberZayTotal, DateTime DateZayTotal, DateTime DatePlanTotal, string UserTotalModific, DateTime DateTotalModific, List<TabZayTotal> TabZay, List<TabDog> MDTITOG)
        {
            if (TabZay != null)
            {
                try
                {
                    Users U = new Users();
                    //Записываем данные в таблицу Zayavka
                    ZayTotal zay = new ZayTotal();
                    zay.DateZayTotal = DateZayTotal;
                    zay.DatePlanTotal = DatePlanTotal;
                    zay.UserModific = UserTotalModific;
                    zay.DateModific = DateTotalModific;
                    zay.NumberTotalInt = NumberZayTotal;
                    db.ZayTotal.Add(zay);

                    db.SaveChanges();
                    //--------------------------------------
                    //Теперь работаем с таблицей TableZayTotal

                    TableZayTotal TZ = new TableZayTotal();

                    //int IZZZ = db.Zayavka.FirstOrDefault(g => (g.DatePlan == DatePlan && g.IdUser == UserFil)).IdZay;
                    List<ZayTotal> ListZay = new List<ZayTotal>();
                    ListZay = db.ZayTotal.OrderByDescending(h => h.DateModific).ToList();
                    int IZZZ = ListZay.FirstOrDefault().id;

                    foreach (var it in TabZay)
                    {
                        int IDN = db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.neftTotal.Trim()).IdNeft;
                        int IDF = db.Sklad.FirstOrDefault(h => h.Name.Trim() == it.filialTotal.Trim()).IdSklad;
                        if (db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.neftTotal.Trim()).PriznakIsp == 1)
                        {

                            TZ.idNeft = IDN;
                            TZ.Oststok = it.OstTotal;
                            TZ.Potrebnost = it.PotrebTotal;
                            TZ.idFilial = IDF;
                            TZ.DostavkaFact = it.DostavkaTotal;
                            TZ.NalichSkladHran = it.NalSkladTotal;
                            TZ.PlanV = it.PlanVITOG;
                            TZ.idZayTotal = IZZZ;
                            TZ.UserModific = UserTotalModific;
                            TZ.DateModific = DateTotalModific;
                            db.TableZayTotal.Add(TZ);
                            db.SaveChanges();
                        }
                    }
                    //--------------------------------------------
                    //Теперь работаем с таблицей MassDostTotal

                    MassDostTotal MDT = new MassDostTotal();

                    foreach (var it in MDTITOG)
                    {
                        int IDN = db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.IdNeft.Trim()).IdNeft;

                        MDT.IdZayTotal = IZZZ;
                        MDT.IdNeft = IDN;
                        MDT.Massa = it.Massa;

                        db.MassDostTotal.Add(MDT);
                        db.SaveChanges();

                        //--------------------------------------------
                        ViewBag.Message = "Д/З успешно сформирована!";
                    }
                }

                catch (Exception ex)
                {


                    ViewBag.Message = ex.ToString();
                }

            }
            else
            {
                ViewBag.Message = "Отсутствуют согласованные заявки";
            }
                return PartialView();
            
        }
        //----------------------------------//
        //Заполняем форму заявки спиской резервуаров для конкретного резервуара
        public ActionResult LetResTotal(DateTime DatePlanTotal, string UserTotalModific, DateTime DateTotalModific, DateTime DateZayTotal)
        {

            List<Zayavka> LZ = new List<Zayavka>();
            LZ = db.Zayavka.Where(h => h.DatePlan == DatePlanTotal).ToList();

            List<TableZay> TZList = new List<TableZay>();
            
            foreach (var item in LZ)
            {
                TZList.AddRange(db.TableZay.Where(j => j.IdZay == item.IdZay && j.Massa != 0).ToList());
            }

            var TZList1 = db.TableZay.Join(db.Zayavka
                   .Where(o => o.DatePlan == DatePlanTotal && o.IdOrg !=14), c => c.IdZay, u => u.IdZay, (c, o) =>
                        new { Oil = c.Nefteproduct.Naimenovanie, sklad = c.Sklad.Name, Massa = c.Massa, p = c.Nefteproduct.P, Data = o.DateZay, DSogl = o.DateSoglas })
                .OrderBy(h => h.sklad).ThenBy(k => k.Oil).ThenBy(g => g.Data).ToList();

            //-------------------------------------------------------------------------------------------------------
            //Работаем с таблицей остатков АУ
            DateTime date1 = Convert.ToDateTime(DateZayTotal);
            int Month1 = date1.Month;
            int Year1 = date1.Year;
            int allDayMonth1 = DateTime.DaysInMonth(Year1, Month1);
            DateTime Begin1 = new DateTime(Year1, Month1, 1);
            DateTime End1 = new DateTime(Year1, Month1, allDayMonth1);

            List<OstatSklad> OstatAU = new List<OstatSklad>();
            OstatAU = db.OstatSklad.Where(tt => tt.Sklad.Organization.IdOrg == 14 && tt.Date >= Begin1 && tt.Date <= DateZayTotal).OrderByDescending(jjj => jjj.Date).ToList();
            //--------------------------------------------------------------------------------------------------------
            
            List<OstatSklad> LO = new List<OstatSklad>();
            List<OstatSklad> LOSUM = new List<OstatSklad>();

            List<int> LZDin = new List<int>();
            LZDin = LZ.Select(d => d.Organization.IdOrg).Distinct().ToList();

            foreach (var item in LZDin)
            {
                if(db.OstatSklad.Where(j => j.Sklad.Organization.IdOrg == item).OrderByDescending(g => g.Date).ToList().FirstOrDefault() ==null)
                {
                    LO = null;
                }
                else
                {
                DateTime? Ldate = db.OstatSklad.Where(j => j.Sklad.Organization.IdOrg == item).OrderByDescending(g => g.Date).ToList().FirstOrDefault().Date;
                LO = db.OstatSklad.Where(j => j.Sklad.Organization.IdOrg == item && j.Date == Ldate).ToList();    
                 LOSUM.AddRange(LO);
                }     
            }
            List<TabZay> tabZays = new List<TabZay>();
            
            var LOList = LOSUM.GroupBy(r => new { r.Nefteproduct.Naimenovanie, r.Sklad.Name, r.Nefteproduct.P }).OrderBy(t => t.Key.Naimenovanie)
 .Select(gr => new { OilProduct = gr.Key.Naimenovanie, Filial = gr.Key.Name, Sum = gr.Sum(i => i.Massa), gr.Key.P });

            foreach(var u in LOList)
            {
                TabZay tabZ = new TabZay { IdZay = 1, NeftZay = u.OilProduct, Massa = Convert.ToDecimal(u.Sum), Plan = "1", Prich = u.Filial, IdSklad = 1 };                            
                
                tabZays.Add(tabZ);
            }

            ViewBag.tabZays = tabZays;
            ViewBag.TZList1 = TZList1;
            ViewBag.OstatAU = OstatAU;

            

            return PartialView(TZList);
        }

        //----Редактирование сводной заявки-------------------------------------------------------------
        public ActionResult ZayavkaTotalEdit(int ID)
        {
                     
            //Получаем запись с нашим номером заявки 
            ZayTotal ZayE = new ZayTotal();
            ZayE = db.ZayTotal.FirstOrDefault(a => a.id == ID);
            ViewBag.ZayETotal = ZayE;

            //Получаем список записей с id номера заявки из таблицы TableZay            
            List<TableZayTotal> ListTZ = new List<TableZayTotal>();
            ListTZ = db.TableZayTotal.Where(f => f.idZayTotal == ID).ToList();
            ViewBag.ListTZTotal = ListTZ;

            //Получаем префикс ау
            string pref = "";
            pref = db.Organization.FirstOrDefault(y => y.IdOrg == 14).Prefix;
            ViewBag.prefA = pref;

            List<OstatSklad> OstatAU = new List<OstatSklad>();

            DateTime date1 = Convert.ToDateTime(ZayE.DateZayTotal);
            int Month1 = date1.Month;
            int Year1 = date1.Year;
            int allDayMonth1 = DateTime.DaysInMonth(Year1, Month1);
            DateTime Begin1 = new DateTime(Year1, Month1, 1);
            DateTime End1 = new DateTime(Year1, Month1, allDayMonth1);

            OstatAU = db.OstatSklad.Where(tt => tt.Sklad.Organization.IdOrg == 14 && tt.Date >= Begin1 && tt.Date <= ZayE.DateZayTotal).OrderByDescending(jjj => jjj.Date).ToList();
            ViewBag.OstatAU = OstatAU;
            return PartialView(ListTZ);
        }
        //-------------------------------//

        //Сохранение редактирования сводной заявки------------//
        [HttpPost]
        public ActionResult ZayavkaTotalEditSave(int IDF, string UserTotalModific, DateTime DateTotalModific, List<TabZayTotal> TabZay, List<TabDog> MDTITOG, int NumberZED)
        {

            try
            {
                ZayTotal ZT = new ZayTotal();
                ZT = db.ZayTotal.FirstOrDefault(f => f.id == IDF);
                ZT.UserModific = UserTotalModific;
                ZT.DateModific = DateTotalModific;
                db.SaveChanges();
                foreach (var item in TabZay)
                {

                    //Nefteproduct NID = new Nefteproduct();
                    int NID = db.Nefteproduct.FirstOrDefault(g => g.Naimenovanie.Trim() == item.neftTotal.Trim()).IdNeft;

                    TableZayTotal TZE = new TableZayTotal();
                    TZE = db.TableZayTotal.FirstOrDefault(s => s.id == item.ID);
                    TZE.idNeft = NID;
                    TZE.Potrebnost = item.PotrebTotal;
                    TZE.Oststok = item.OstTotal;
                    TZE.DostavkaFact = item.DostavkaTotal;
                    TZE.NalichSkladHran = item.NalSkladTotal;
                    TZE.PlanV = item.PlanVITOG;
                    TZE.ZayTotal.NumberTotalInt = NumberZED;
                    db.SaveChanges();
                    }
                    //Теперь работаем с таблицей MassDostTotal

                    //MassDostTotal MDT = new MassDostTotal();
                 
                    foreach (var it in MDTITOG)
                    {
                        int IDN = db.Nefteproduct.FirstOrDefault(h => h.Naimenovanie.Trim() == it.IdNeft.Trim()).IdNeft;
                    MassDostTotal MDT = new MassDostTotal();
                    MDT = db.MassDostTotal.FirstOrDefault(s => s.IdT == it.IdTd);
                    MDT.IdZayTotal = IDF;
                        MDT.IdNeft = IDN;
                        MDT.Massa = it.Massa;
                                               
                        db.SaveChanges();

                    }
                    ViewBag.Message = "Д/З успешно изменена!";
                
            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // удаление заявки//

        public ActionResult DeleteZayavkaTotal(int ID)
        {
            ZayTotal ZayDel = new ZayTotal();
            ZayDel = db.ZayTotal.FirstOrDefault(a => a.id == ID);

            return PartialView(ZayDel);
        }
        //-----------------------------//

        // Подтверждение удаления заявки//
        public ActionResult DeleteZayavkaTotalOK(int ID)
        {
            try
            {
                ZayTotal ZayDS = new ZayTotal();
                ZayDS = db.ZayTotal.FirstOrDefault(a => a.id == ID);
                db.ZayTotal.Remove(ZayDS);

                List<TableZayTotal> ListTZ = new List<TableZayTotal>();
                ListTZ = db.TableZayTotal.Where(f => f.idZayTotal == ID).ToList();

                foreach (var t in ListTZ)
                {
                    db.TableZayTotal.Remove(t);
                }


                List<MassDostTotal> ListMass = new List<MassDostTotal>();
                ListMass = db.MassDostTotal.Where(hq => hq.IdZayTotal == ID).ToList();
                foreach (var tq in ListMass)
                {
                    db.MassDostTotal.Remove(tq);
                }
                db.SaveChanges();

                ViewBag.Message = "Д/З удалена!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        //--------------------------------------------
        //----------Получаем список сводных заявок в зависимости от дат---------------------------------------------------------------
        [HttpPost]
        public ActionResult GetZayTabTotal(DateTime SZTotal, DateTime PoZTotal, DateTime SZMTotal, DateTime PoZMTotal)
        {
            List<ZayTotal> zayTabTotal = new List<ZayTotal>();
            zayTabTotal = db.ZayTotal.Where(a => a.DateZayTotal >= SZTotal && a.DateZayTotal <= PoZTotal && a.DatePlanTotal >= SZMTotal && a.DatePlanTotal <= PoZMTotal).OrderByDescending(g => g.DateZayTotal).ThenByDescending(g => g.NumberTotalInt).ToList();

            //Получаем префикс ау
            string pref = "";
            pref = db.Organization.FirstOrDefault(y => y.IdOrg == 14).Prefix;
            ViewBag.prefA = pref;

            return PartialView(zayTabTotal);
        }
        //-----------------------------//
                //---------Печать списка сводных заявок-------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult PrintZayListTotal(DateTime SZTotal, DateTime PoZTotal, DateTime SZMTotal, DateTime PoZMTotal)
        {            
            decimal? sumost = 0;
            decimal? sumpotr = 0;
            decimal? sumdost = 0;
            int shet = 0;
            
            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);

            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;

            //------------------------------------------
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var a = Paragraph4.Range;
            a.Text = "ОАО \"Гомельтранснефть Дружба\"\n";
            a.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            a.Font.Underline = WdUnderline.wdUnderlineSingle;
            a.ParagraphFormat.SpaceAfter = 10;
            
            //--------Выводим таблицы с заявками по месяцам-------------------------------------------------------

            List<ZayTotal> LOS = new List<ZayTotal>();
            LOS = db.ZayTotal.Where(o => o.DateZayTotal >= SZTotal && o.DateZayTotal <= PoZTotal && o.DatePlanTotal >= SZMTotal && o.DatePlanTotal <= PoZMTotal).OrderBy(i => i.DateZayTotal).ToList();

           
            if (LOS.Count == 0)
            {
                r.InsertAfter("\n");
                var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
                var ssQ = ParagrapQ.Range;
                ssQ.Text = "Заявки нефтепродуктов за указанный период отсутствуют;";
                ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                r.InsertAfter("\n");
                r.InsertAfter("\n");
            }
            else
            {
                foreach (var d in LOS)
                {
                    List<TableZayTotal> LODATE = new List<TableZayTotal>();
                    LODATE = db.TableZayTotal.Where(s => s.idZayTotal == d.id).ToList();

                    var ParagrapQQ = app.ActiveDocument.Paragraphs.Add();
                    var ssQQ = ParagrapQQ.Range;
                    ssQQ.Text = "Отчет по вводу сводных заявок за период с "   + Convert.ToDateTime(SZTotal).ToString("Y") +" по " + Convert.ToDateTime(PoZTotal).ToString("Y");
                    ssQQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    r.InsertAfter("\n\n");
                
                //-------------------------------------------------------------------------------------------------------
                var Paragraph2 = app.ActiveDocument.Paragraphs.Add();
                var tableRange2 = Paragraph2.Range;

                    //-------------------------------------------------------
                    var ListGR = db.TableZayTotal.Join(db.ZayTotal
                    .Where(o => o.DateZayTotal >= SZTotal && o.DateZayTotal <= PoZTotal && o.DatePlanTotal >= SZMTotal && o.DatePlanTotal <= PoZMTotal), c => c.idZayTotal, u => u.id, (c, o) =>
                         new { Oil = c.Nefteproduct.Naimenovanie, sklad = c.Sklad.Name, Massa = c.Potrebnost, p = c.Nefteproduct.P, Data = o.DateZayTotal }).OrderBy(h => h.sklad).ThenBy(k => k.Oil).ThenBy(g => g.Data).ToList();
                    //--------------------------------------------------------------------------------------------------------

                    //                var res = TZ
                    //.GroupBy(rt => new { rt.Nefteproduct.Naimenovanie, rt.Sklad.Name, rt.Nefteproduct.P, rt.Massa }).OrderBy(t => t.Key.Naimenovanie)
                    //.Select(gr => new { OilProduct = gr.Key.Naimenovanie, Sklad = gr.Key.Name, Massa = gr.Key.Massa, Sum = gr.Sum(i => i.Massa), P = gr.Key.P }).GroupBy(j => j.Sklad);

                    var res = ListGR.GroupBy(j => j.sklad);
                    //-------------------------------------------------------

                    //var res = LODATE.GroupBy(h => h.Organization.Name).ToList();

                Table tOsttest2 = doc.Tables.Add(tableRange2, ListGR.Count + res.Count(), 5);
                tOsttest2.Borders.Enable = 1;
                tOsttest2.Rows.Add();
                tOsttest2.Rows[1].Cells[1].Range.Text = "Вид нефтепродукта";
                tOsttest2.Rows[1].Cells[2].Range.Text = "Дата ввода заявки";
                tOsttest2.Rows[1].Cells[3].Range.Text = "Плотность, т/м3";
                tOsttest2.Rows[1].Cells[4].Range.Text = "Объем, м3";
                tOsttest2.Rows[1].Cells[5].Range.Text = "Масса, тонн";
                
                tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    int index = 1;
                    foreach (var p in res)
                    {
                        index++;
                        tOsttest2.Rows[index].Cells[1].Merge(tOsttest2.Rows[index].Cells[5]);
                        tOsttest2.Rows[index].Cells[1].Range.Text = p.Key.ToString();
                        tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        tOsttest2.Rows[index].Cells[1].Range.Font.Size = 12;
                        tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceBefore = 5;
                        tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.SpaceAfter = 5;
                        foreach (var y in p)
                        {
                            index++;
                            tOsttest2.Rows[index].Cells[1].Range.Text = y.Oil.ToString();
                            tOsttest2.Rows[index].Cells[2].Range.Text = Convert.ToDateTime(y.Data).ToString("d");
                            tOsttest2.Rows[index].Cells[3].Range.Text = Math.Round(Convert.ToDouble(y.p), 3).ToString();
                            tOsttest2.Rows[index].Cells[4].Range.Text = Math.Round(Convert.ToDouble(y.Massa), 0).ToString();
                            tOsttest2.Rows[index].Cells[5].Range.Text = Math.Round(Convert.ToDouble(y.Massa * y.p), 0).ToString();
                            tOsttest2.Rows[index].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            tOsttest2.Rows[index].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            tOsttest2.Rows[index].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            tOsttest2.Rows[index].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        }
                    }
                    r.InsertAfter("\n");
                }
            }

            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            var P = Paragraph6.Range;
            if (us1 == null)
            {
                P.Text = "";
            }
            else
            {
                P.Text = us1.Doljnost.Naimenovanie + " ______________________ " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + "." + us1.LastName;
            }
            P.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\Report.docx");
            app.Documents.Open(@"C:\Install\Report.docx");
            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("Report.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\Report.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Report.docx");

        }
        //----------------------------------------------------------------------------------------
        //-----------------Выводим на печать сводную заявку---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult PrintZayTotalWord(int IDF)
        {

            decimal? sumost = 0;
            decimal? sumpotr = 0;
            decimal? sumdost = 0;
            int shet = 0;
            decimal? Nalich = 0;
            decimal? planV = 0;

            ZayTotal Z = new ZayTotal();
            Z = db.ZayTotal.FirstOrDefault(g => g.id == IDF);
           
            string ORG = "";
              if (db.Organization.FirstOrDefault(jk => jk.IdOrg == 14)!= null)
            {
             ORG = db.Organization.FirstOrDefault(jk => jk.IdOrg == 14).Prefix;
            }
              else
            {
                ORG = "";
            }
            
              //---------Получаем остатки за месяц даты заявки общей по АУ-------------------------------
              DateTime date1 = Convert.ToDateTime(Z.DateZayTotal);
            int Month1 = date1.Month;
            int Year1 = date1.Year;
            int allDayMonth1 = DateTime.DaysInMonth(Year1, Month1);
            DateTime Begin1 = new DateTime(Year1, Month1, 1);
            DateTime End1 = new DateTime(Year1, Month1, allDayMonth1);

            List<OstatSklad> OSLAST11 = new List<OstatSklad>();
            OSLAST11 = db.OstatSklad.Where(f => f.Sklad.Organization.IdOrg == 14 && f.Date >= Begin1 && f.Date <= date1).OrderByDescending(g => g.Date).ToList();
            //Группирую список остатков по складам--------------------------
            var OSLAST111 = OSLAST11.GroupBy(y => y.Nefteproduct.Naimenovanie).Select(gg => new { neftprod = gg.Key, summ = gg.Sum(i=>i.Massa)});
            //----------------------------------------
            //Получаем наличие на складах АУ-------------
            List<MassDostTotal> PlanVSkl = new List<MassDostTotal>();
            PlanVSkl = db.MassDostTotal.Where(jh => jh.IdZayTotal == IDF).ToList();
            //-----------------------------------------------------

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);

            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);            
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;
            r.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

            //---------------РАБОТАЕМ С КОЛОНТИТУЛАМИ------------------------------     

            doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.RestartNumberingAtSection = true;

            doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = false;

            doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.StartingNumber = 1;
            //Вставка номера страницы в колонтитул            
            doc.Fields.Add(doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                          
                app.ActiveDocument.Sections[1].                           
               Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].
               Range.Font.Size = 12;
            app.ActiveDocument.Sections[1].                           
               Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].
               Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            
            //---------------------------------------------

            var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
            var ssQ = ParagrapQ.Range;            

            Table t = doc.Tables.Add(ssQ, 1, 2);
            t.Borders.Enable = 0;

            t.Rows[1].Cells[1].Range.Text = "Отдел по нефти, нефтепродуктам и управления качеством";
            t.Rows[1].Cells[2].Range.Text = "Генеральному директору\nОАО \"Гомельтранснефть Дружба\" \n" + "Борисенко О.Л.";
            
            ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            
            r.InsertAfter("\n");
            r.InsertAfter("ДОКЛАДНАЯ ЗАПИСКА\n");
            if (Z.NumberTotalInt == null)
            {
                r.InsertAfter(Convert.ToDateTime(Z.DateZayTotal).ToString("d") + " № " + "_______" + "\n");
            }
            else
            {
                r.InsertAfter(Convert.ToDateTime(Z.DateZayTotal).ToString("d") + " № " + ORG  + Z.NumberTotalInt + "\n");
            }
            r.InsertAfter("г. Гомель\n");
            r.InsertAfter("\n");

            r.InsertAfter("О согласовании закупки\nнефтепродуктов \n");
            r.InsertAfter("\n");

            //----Вывод текста из заявки-------------------------------------------------------------
            
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var Par4 = Paragraph4.Range;
            Par4.Text = "\tВ соответствии с приказом генерального директора от 09.04.2021 №292 и от 30.01.2023 №78 ответственными лицами по филиалам согласованы с руководителями филиалов и сформированы в программном комплексе " +
                "\"Заявки на нефтепродукты\" заявки по доставке нефтепродуктов на филиалы, сформированные с учётом наличия имеющихся на филиалах остатков нефтепродуктов в текущем месяце и планов работ на " 
                + (Convert.ToDateTime(Z.DatePlanTotal).ToString("y")).ToLower() + " года.";
                
            var Paragraph5 = app.ActiveDocument.Paragraphs.Add();
            var Par5 = Paragraph4.Range;
            Par5.Text = "\tСуммарная потребность в нефтепродуктах по филиалам на " + (Convert.ToDateTime(Z.DatePlanTotal).ToString("y")).ToLower() + " года составила:";                
            r.InsertAfter("\n");

            //var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            //var Par6 = Paragraph6.Range;
            //Par6.Text = "Суммарная потребность нефтепродуктов по филиалам на " + Convert.ToDateTime(Z.DateZayTotal).ToString("d");
            //Par6.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            //Par6.Font.Size = 14;            
            //r.InsertAfter("\n");
            //-------------------------------------------------------------------------------------------------------            
            
            List<TableZayTotal> LODATE = new List<TableZayTotal>();
            LODATE = db.TableZayTotal.Where(s => s.idZayTotal == IDF).ToList();

            List<TableZayTotal> LODATEDIST = new List<TableZayTotal>();
            LODATEDIST = LODATE.Distinct().ToList();

            var res = LODATE.GroupBy(h => h.Nefteproduct.Naimenovanie).ToList();
            List<TableZayTotal> LODATEWITHOUT14 = new List<TableZayTotal>();
            LODATEWITHOUT14 = LODATE.Where(j => j.Sklad.Organization.IdOrg != 14).ToList();

            var Paragraph77 = app.ActiveDocument.Paragraphs.Add();
            var tableRange77 = Paragraph77.Range;            
            Table tOsttest2 = doc.Tables.Add(tableRange77, LODATEWITHOUT14.Count + res.Count , 7);
            tOsttest2.Borders.Enable = 1;
            tOsttest2.Range.Font.Size = 9;
                         
            tOsttest2.Rows.Add();
            tOsttest2.Rows[1].Cells[1].Range.Text = "Наименование\nнефтепродукта";
            tOsttest2.Rows[1].Cells[2].Range.Text = "Наименование филиала";
            tOsttest2.Rows[1].Cells[3].Range.Text = "Остаток\nт";
            tOsttest2.Rows[1].Cells[4].Range.Text = "Заказано филиалами\nт";
            tOsttest2.Rows[1].Cells[5].Range.Text = "Факт. доставка на филиал, т (с учётом вместимости бензовоза)";
            tOsttest2.Rows[1].Cells[6].Range.Text = "Наличие на складах ОАО\nт";
            tOsttest2.Rows[1].Cells[7].Range.Text = "К закупке\nт";

            tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Rows[1].Cells[5].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Rows[1].Cells[5].Range.Font.Size = 7;
            tOsttest2.Rows[1].Cells[6].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Rows[1].Cells[7].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            tOsttest2.Rows[1].Cells[1].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Rows[1].Cells[2].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Rows[1].Cells[3].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Rows[1].Cells[4].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Rows[1].Cells[5].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Rows[1].Cells[6].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Rows[1].Cells[7].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            tOsttest2.Rows[1].Cells[1].Width = 77;
            tOsttest2.Rows[1].Cells[2].Width = 160;
            tOsttest2.Rows[1].Cells[3].Width = 45;
            tOsttest2.Rows[1].Cells[4].Width = 57;
            tOsttest2.Rows[1].Cells[5].Width = 48;
            tOsttest2.Rows[1].Cells[6].Width = 45;
            tOsttest2.Rows[1].Cells[7].Width = 43;


            int ind = 1;
            foreach (var com in res)
            {
                sumost = 0;
                sumpotr = 0;
                sumdost = 0;


                foreach (var y in com)
                {

                        if(PlanVSkl.FirstOrDefault(u => u.Nefteproduct.Naimenovanie == com.Key) !=null)
                        {
                         planV = PlanVSkl.FirstOrDefault(u => u.Nefteproduct.Naimenovanie == com.Key).Massa;
                        }
                        else
                        {
                            planV = 0;
                        }

                    if (y.Sklad.Organization.IdOrg == 14)
                    {
                        
                    }
                    if (y.Sklad.Organization.IdOrg != 14)
                    {
                        sumost = sumost + y.Oststok;
                        sumpotr = sumpotr + y.Potrebnost * y.Nefteproduct.P;
                        sumdost = sumdost + y.DostavkaFact;
                        if(OSLAST111.FirstOrDefault(v => v.neftprod == com.Key)!= null)
                        {
                          Nalich = OSLAST111.FirstOrDefault(v=>v.neftprod == com.Key).summ * y.Nefteproduct.P;
                        }
                        else
                        {
                            Nalich = 0;
                        }                        
                                               
                        ind++;

                        tOsttest2.Cell(ind, 1).Range.Text = com.Key;
                        tOsttest2.Cell(ind, 2).Range.Text = y.Sklad.Name;
                        tOsttest2.Cell(ind, 3).Range.Text = Math.Round(Convert.ToDouble(y.Oststok),0).ToString();
                        tOsttest2.Cell(ind, 4).Range.Text = Math.Round(Convert.ToDouble(y.Potrebnost * y.Nefteproduct.P), 0).ToString();
                        tOsttest2.Cell(ind, 5).Range.Text = Math.Round(Convert.ToDouble(y.DostavkaFact),0).ToString();
                        tOsttest2.Cell(ind, 6).Range.Text = "";
                        tOsttest2.Cell(ind, 7).Range.Text = "";

                        tOsttest2.Cell(ind, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Cell(ind, 1).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Cell(ind, 2).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Cell(ind, 3).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Cell(ind, 4).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Cell(ind, 5).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Cell(ind, 6).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 7).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        tOsttest2.Cell(ind, 7).Range.Font.Size = 9;
                        tOsttest2.Cell(ind, 1).Width = 77;
                        tOsttest2.Cell(ind, 2).Width = 160;
                        tOsttest2.Cell(ind, 3).Width = 45;
                        tOsttest2.Cell(ind, 4).Width = 57;
                        tOsttest2.Cell(ind, 5).Width = 48;
                        tOsttest2.Cell(ind, 6).Width = 45;
                        tOsttest2.Cell(ind, 7).Width = 43;
                    }
                }
                    ind++;
                    tOsttest2.Cell(ind, 1).Range.Text = "ИТОГО:";
                tOsttest2.Cell(ind, 1).Width = 77;
                tOsttest2.Cell(ind, 2).Width = 160;
                tOsttest2.Cell(ind, 3).Width = 45;
                tOsttest2.Cell(ind, 4).Width = 57;
                tOsttest2.Cell(ind, 5).Width = 48;
                tOsttest2.Cell(ind, 6).Width = 45;
                tOsttest2.Cell(ind, 7).Width = 43;
                tOsttest2.Cell(ind, 1).Merge(tOsttest2.Cell(ind, 2));
                    tOsttest2.Cell(ind, 1).Range.Font.Bold = 1;
                    tOsttest2.Cell(ind, 1).Range.Font.Size = 9;
                    tOsttest2.Cell(ind, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    tOsttest2.Cell(ind, 2).Range.Text = Math.Round(Convert.ToDouble(sumost),0).ToString();
                    tOsttest2.Cell(ind, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tOsttest2.Cell(ind, 2).Range.Font.Bold = 1;
                    tOsttest2.Cell(ind, 2).Range.Font.Size = 9;
                    tOsttest2.Cell(ind, 3).Range.Text = Math.Round(Convert.ToDouble(sumpotr),0).ToString();
                    tOsttest2.Cell(ind, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tOsttest2.Cell(ind, 3).Range.Font.Bold = 1;
                    tOsttest2.Cell(ind, 3).Range.Font.Size = 9;
                    tOsttest2.Cell(ind, 4).Range.Text = Math.Round(Convert.ToDouble(sumdost),0).ToString();
                    tOsttest2.Cell(ind, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tOsttest2.Cell(ind, 4).Range.Font.Bold = 1;
                    tOsttest2.Cell(ind, 4).Range.Font.Size = 9;
                    tOsttest2.Cell(ind, 5).Range.Text = Math.Round(Convert.ToDouble(Nalich),0).ToString();
                    tOsttest2.Cell(ind, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tOsttest2.Cell(ind, 5).Range.Font.Bold = 1;
                    tOsttest2.Cell(ind, 5).Range.Font.Size = 9;
                    tOsttest2.Cell(ind, 6).Range.Text = Math.Round(Convert.ToDouble(planV),0).ToString();
                    tOsttest2.Cell(ind, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    tOsttest2.Cell(ind, 6).Range.Font.Bold = 1;
                    tOsttest2.Cell(ind, 6).Range.Font.Size = 9;
                
            }
            r.InsertAfter("\n");

            //------------------------------------------------------------------------------------------------------
            var PLV = PlanVSkl.Where(hh => hh.Massa != 0).ToList();
            if (PLV.Count != 0)
            {

                var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
                var Par6 = Paragraph6.Range;
                Par6.Text = "\tС учётом фактической доставки автомобильными цистернами нефтепродуктов на филиалы прошу согласовать на " + (Convert.ToDateTime(Z.DatePlanTotal).ToString("y")).ToLower() + " года закупку следующих нефтепродуктов:";
                Par6.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                Par6.Font.Size = 14;
                r.InsertAfter("\n");

                //-----------------------------------------------------------------------------------------------
                var Paragraph88 = app.ActiveDocument.Paragraphs.Add();
                var tableRange88 = Paragraph88.Range;
                Table tOsttest88 = doc.Tables.Add(tableRange88, PLV.Count, 2);
                tOsttest88.Borders.Enable = 0;
                tOsttest88.Range.Font.Size = 14;
                //Выводим количество к доставке
                int number = 0;
                foreach (var item in PLV)
                {
                    number++;
                    tOsttest88.Rows[number].Cells[1].Range.Text = "\t" + item.Nefteproduct.Naimenovanie + " -";
                    tOsttest88.Rows[number].Cells[2].Range.Text = Math.Round(Convert.ToDouble(item.Massa), 0).ToString() + " т";
                    tOsttest88.Cell(number, 1).Width = 155;
                    tOsttest88.Cell(number, 2).Width = 70;

                }
            }            
            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph10 = app.ActiveDocument.Paragraphs.Add();
            var Par10 = Paragraph10.Range;
            Par10.Text = "Начальник отдела                _______________                 Г.А.Киреев";
            Par10.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            Par10.Font.Size = 14;

            //------------------Выводим МОЛ с номером телефона----------------------------------------------------------
            r.InsertAfter("\n");
            r.InsertAfter("\n");
            r.InsertAfter("\n");

            var Paragraph3 = app.ActiveDocument.Paragraphs.Add();
            var hhh = Paragraph3.Range;
            hhh.Font.Size = 9;

            if (us1 == null)
            {
                hhh.Text = "";
            }
            else
            {
                hhh.Text = (us1.LastName + " " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + ". тел.: " + us1.Phone);
            }
            hhh.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            r.InsertAfter("\n");
            
            //-----------------------------------------------------------------------------------------------------------

            doc.SaveAs2(@"C:\Install\ReportZay.docx");
            //doc.SaveAs2(Server.MapPath("~/App_Data/Report.docx"));
            app.Documents.Open(@"C:\Install\ReportZay.docx");
            //app.Documents.Open(Server.MapPath("~/App_Data/Report.docx"));

            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("ReportZay.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\ReportZay.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ReportZay.docx");                      
                        
        }
        //----------------------------------------------------------------------------------------------------
                
            //------------------------------------------------------------------------

            //-----------------Выводим на печать д/з на доставку---------------------------------------------------------------------------------------------------------------
            [HttpGet]
        public ActionResult PrintZayTotalWordDost(int IDF)
        {

            decimal? sumost = 0;
            decimal? sumpotr = 0;
            decimal? sumdost = 0;
            int shet = 0;
            decimal? Nalich = 0;
            decimal? planV = 0;

            ZayTotal Z = new ZayTotal();
            Z = db.ZayTotal.FirstOrDefault(g => g.id == IDF);

            string ORG = "";
            if (db.Organization.FirstOrDefault(jk => jk.IdOrg == 14) != null)
            {
                ORG = db.Organization.FirstOrDefault(jk => jk.IdOrg == 14).Prefix;
            }
            else
            {
                ORG = "";
            }

            //---------Получаем остатки за месяц даты заявки общей по АУ-------------------------------
            DateTime date1 = Convert.ToDateTime(Z.DateZayTotal);
            int Month1 = date1.Month;
            int Year1 = date1.Year;
            int allDayMonth1 = DateTime.DaysInMonth(Year1, Month1);
            DateTime Begin1 = new DateTime(Year1, Month1, 1);
            DateTime End1 = new DateTime(Year1, Month1, allDayMonth1);

            List<OstatSklad> OSLAST11 = new List<OstatSklad>();
            OSLAST11 = db.OstatSklad.Where(f => f.Sklad.Organization.IdOrg == 14 && f.Date >= Begin1 && f.Date <= date1).OrderByDescending(g => g.Date).ToList();
            //Группирую список остатков по складам--------------------------
            var OSLAST111 = OSLAST11.GroupBy(y => y.Nefteproduct.Naimenovanie).Select(gg => new { neftprod = gg.Key, summ = gg.Sum(i => i.Massa) });
            //----------------------------------------
            //Получаем наличие на складах АУ-------------
            List<MassDostTotal> PlanVSkl = new List<MassDostTotal>();
            PlanVSkl = db.MassDostTotal.Where(jh => jh.IdZayTotal == IDF).ToList();
            //-----------------------------------------------------

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);


            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 14;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;
            r.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

            //---------------РАБОТАЕМ С КОЛОНТИТУЛАМИ------------------------------     

            doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.RestartNumberingAtSection = true;

            doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.ShowFirstPageNumber = false;

            doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.StartingNumber = 1;
            //Вставка номера страницы в колонтитул            
            doc.Fields.Add(doc.Sections.First.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);

            app.ActiveDocument.Sections[1].
           Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].
           Range.Font.Size = 12;
            app.ActiveDocument.Sections[1].
               Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].
               Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            //---------------------------------------------

            var ParagrapQ = app.ActiveDocument.Paragraphs.Add();
            var ssQ = ParagrapQ.Range;

            Table t = doc.Tables.Add(ssQ, 1, 2);
            t.Borders.Enable = 0;

            t.Cell(1, 1).Range.Text = "Отдел по нефти, нефтепродуктам и управления качеством";
            t.Cell(1, 2).Range.Text = "Заместителю генерального директора\nОАО \"Гомельтранснефть Дружба\"\n(по транспорту нефти)\n" + "Булычеву С.Т.";
            t.Cell(1, 1).Width = 230;
            t.Cell(1, 2).Width = 330;
            ssQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            r.InsertAfter("\n");
            r.InsertAfter("ДОКЛАДНАЯ ЗАПИСКА\n");
            if (Z.NumberTotalInt == null)
            {
                r.InsertAfter(Convert.ToDateTime(Z.DateZayTotal).ToString("d") + " № " + "_______" + "\n");
            }
            else
            {
                r.InsertAfter(Convert.ToDateTime(Z.DateZayTotal).ToString("d") + " № " + ORG + Z.NumberTotalInt + "\n");
            }
            r.InsertAfter("г. Гомель\n");
            r.InsertAfter("\n");

            r.InsertAfter("О доставке нефтепродуктов\nна филиалы\n");
            r.InsertAfter("\n");

            //----Вывод текста из заявки-------------------------------------------------------------

            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var Par4 = Paragraph4.Range;
            Par4.Text = "\tВ соответствии с приказом генерального директора от 09.04.2021 №292 и от 30.01.2023 №78 ответственными лицами по филиалам согласованы с руководителями филиалов и сформированы в программном комплексе " +
                "\"Заявки на нефтепродукты\" заявки по доставке нефтепродуктов на филиалы, сформированные с учётом наличия имеющихся на филиалах остатков нефтепродуктов в текущем месяце и планов работ на "
                + (Convert.ToDateTime(Z.DatePlanTotal).ToString("y")).ToLower() + " года.";

            var Paragraph5 = app.ActiveDocument.Paragraphs.Add();
            var Par5 = Paragraph4.Range;
            Par5.Text = "\tСуммарная потребность в нефтепродуктах по филиалам на " + (Convert.ToDateTime(Z.DatePlanTotal).ToString("y")).ToLower() + " года составила:\n";
            r.InsertAfter("\n");

            //-----------------------ТЕСТ. УДАЛИТЬ ПОСЛЕ РАЗРАБОТКИ-------------------------------------
                        
            //------------------------------------------------------------

            List<TableZayTotal> LODATE = new List<TableZayTotal>();
            LODATE = db.TableZayTotal.Where(s => s.idZayTotal == IDF).ToList();

            List<TableZayTotal> LODATEDIST = new List<TableZayTotal>();
            LODATEDIST = LODATE.Distinct().ToList();

            var LODATEGR = LODATE.GroupBy(u => u.Sklad.Name);

            var res = LODATE.GroupBy(h => h.Nefteproduct.Naimenovanie).ToList();
            List<TableZayTotal> LODATEWITHOUT14 = new List<TableZayTotal>();
            LODATEWITHOUT14 = LODATE.Where(j => j.Sklad.Organization.IdOrg != 14).ToList();

            var Paragraph77 = app.ActiveDocument.Paragraphs.Add();
            var tableRange77 = Paragraph77.Range;
            Table tOsttest2 = doc.Tables.Add(tableRange77, LODATEGR.Count() +2, 11);
            tOsttest2.Borders.Enable = 1;
            tOsttest2.Range.Font.Size = 9;

            tOsttest2.Rows.Add();
            tOsttest2.Cell(1, 1).Range.Text = "Наименование филиала";
            tOsttest2.Cell(1, 2).Range.Text = "Бензин\nАИ-92";
            tOsttest2.Cell(1, 2).Merge(tOsttest2.Cell(1, 3));
            tOsttest2.Cell(1, 3).Range.Text = "Бензин\nАИ-95";
            tOsttest2.Cell(1, 3).Merge(tOsttest2.Cell(1, 4));
            tOsttest2.Cell(1, 4).Range.Text = "ДТЛ";
            tOsttest2.Cell(1, 4).Merge(tOsttest2.Cell(1, 5));
            tOsttest2.Cell(1, 5).Range.Text = "ДТЗ";
            tOsttest2.Cell(1, 5).Merge(tOsttest2.Cell(1, 6));
            tOsttest2.Cell(1, 6).Range.Text = "Печное топливо";
            tOsttest2.Cell(1, 6).Merge(tOsttest2.Cell(1, 7));
            
            tOsttest2.Cell(1, 1).Merge(tOsttest2.Cell(2, 1));
                        
            tOsttest2.Cell(2, 2).Range.Text = "V,\nм.куб";
            tOsttest2.Cell(2, 3).Range.Text = "М,\nтн.";
            tOsttest2.Cell(2, 4).Range.Text = "V,\nм.куб";
            tOsttest2.Cell(2, 5).Range.Text = "М,\nтн.";
            tOsttest2.Cell(2, 6).Range.Text = "V,\nм.куб";
            tOsttest2.Cell(2, 7).Range.Text = "М,\nтн.";
            tOsttest2.Cell(2, 8).Range.Text = "V,\nм.куб";
            tOsttest2.Cell(2, 9).Range.Text = "М,\nтн.";
            tOsttest2.Cell(2,10).Range.Text = "V,\nм.куб";
            tOsttest2.Cell(2, 11).Range.Text = "М,\nтн.";
            
            tOsttest2.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(1, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(1, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(1, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(1, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(1, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(1, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(1, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(1, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(1, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        
            tOsttest2.Cell(1, 1).Width = 160;
            tOsttest2.Cell(1, 2).Width = 62;
            tOsttest2.Cell(1, 3).Width = 62;
            tOsttest2.Cell(1, 4).Width = 62;
            tOsttest2.Cell(1, 5).Width = 62;
            tOsttest2.Cell(1, 6).Width = 62;
                        
            tOsttest2.Cell(2, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 7).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 7).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 8).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 8).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 9).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 9).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 10).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 10).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 11).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(2, 11).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tOsttest2.Cell(2, 2).Range.Font.Size = 8;
            tOsttest2.Cell(2, 3).Range.Font.Size = 8;
            tOsttest2.Cell(2, 4).Range.Font.Size = 8;
            tOsttest2.Cell(2, 5).Range.Font.Size = 8;
            tOsttest2.Cell(2, 6).Range.Font.Size = 8;
            tOsttest2.Cell(2, 6).Range.Font.Size = 8;
            tOsttest2.Cell(2, 7).Range.Font.Size = 8;
            tOsttest2.Cell(2, 8).Range.Font.Size = 8;
            tOsttest2.Cell(2, 9).Range.Font.Size = 8;
            tOsttest2.Cell(2, 10).Range.Font.Size = 8;
            tOsttest2.Cell(2, 11).Range.Font.Size = 8;
            
            tOsttest2.Cell(2, 2).Width  = 31;
            tOsttest2.Cell(2, 3).Width  = 31;
            tOsttest2.Cell(2, 4).Width  = 31;
            tOsttest2.Cell(2, 5).Width  = 31;
            tOsttest2.Cell(2, 6).Width  = 31;
            tOsttest2.Cell(2, 7).Width  = 31;
            tOsttest2.Cell(2, 8).Width  = 31;
            tOsttest2.Cell(2, 9).Width  = 31;
            tOsttest2.Cell(2, 10).Width = 31;
            tOsttest2.Cell(2, 11).Width = 31;

//----------Переменные для ИТОГО---------------
                double AI92ITOG = 0;
                double AI95ITOG = 0;
                double DTLITOG = 0;
                double DTZITOG = 0;
                double PECHITOG = 0;

                double AI92ITOGT = 0;
                double AI95ITOGT = 0;
                double DTLITOGT = 0;
                double DTZITOGT = 0;
                double PECHITOGT = 0;

            int ind = 2;
            foreach (var com in LODATEGR)
            {
            double AI92 = 0;
            double AI92T = 0;
            double AI95 = 0;
            double AI95T = 0;
            double PECH = 0;
            double PECHT = 0;
            double DTL = 0;
            double DTLT = 0;
            double DTZ = 0;
            double DTZT = 0;
                
                ind++;

                foreach(var iu in com)
                {                    
                    if(iu.idNeft == 2)
                    {
                        AI95 = Math.Round(Convert.ToDouble(iu.DostavkaFact),0);
                        AI95T = Math.Round(AI95 / Convert.ToDouble(iu.Nefteproduct.P),0);
                        
                        AI95ITOG = AI95ITOG + AI95;
                        AI95ITOGT = AI95ITOGT + AI95T;
                    }
                    if (iu.idNeft == 4)
                    {
                        DTL = Math.Round(Convert.ToDouble(iu.DostavkaFact), 0);
                        DTLT = Math.Round(DTL / Convert.ToDouble(iu.Nefteproduct.P), 0);
                        
                        DTLITOG = DTLITOG + DTL;
                        DTLITOGT = DTLITOGT + DTLT;
                    }
                    if (iu.idNeft == 5)
                    {
                        AI92 = Math.Round(Convert.ToDouble(iu.DostavkaFact), 0);
                        AI92T = Math.Round(AI92 / Convert.ToDouble(iu.Nefteproduct.P), 0);

                        AI92ITOG = AI92ITOG + AI92;
                        AI92ITOGT = AI92ITOGT + AI92T;
                    }
                    if (iu.idNeft == 11)
                    {
                        DTZ = Math.Round(Convert.ToDouble(iu.DostavkaFact), 0);
                        DTZT = Math.Round(DTZ / Convert.ToDouble(iu.Nefteproduct.P), 0);

                        DTZITOG = DTZITOG + DTZ;
                        DTZITOGT = DTZITOGT + DTZT;
                    }
                    if (iu.idNeft == 8)
                    {
                        PECH = Math.Round(Convert.ToDouble(iu.DostavkaFact), 0);
                        PECHT = Math.Round(PECH / Convert.ToDouble(iu.Nefteproduct.P), 0);

                        PECHITOG = PECHITOG + PECH;
                        PECHITOGT = PECHITOGT + PECHT;
                    }
                }
                tOsttest2.Cell(ind, 1).Range.Text = com.Key;
               
                if (AI92T != 0)
                {
                tOsttest2.Cell(ind, 2).Range.Text = AI92T.ToString();
                }
                else
                {
                tOsttest2.Cell(ind, 2).Range.Text = "";
                }

                if (AI92 != 0)
                {
                    tOsttest2.Cell(ind, 3).Range.Text = AI92.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 3).Range.Text = "";
                }

                if (AI95T != 0)
                {
                    tOsttest2.Cell(ind, 4).Range.Text = AI95T.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 4).Range.Text = "";
                }

                if (AI95 != 0)
                {
                    tOsttest2.Cell(ind, 5).Range.Text = AI95.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 5).Range.Text = "";
                }

                if (DTLT != 0)
                {
                    tOsttest2.Cell(ind, 6).Range.Text = DTLT.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 6).Range.Text = "";
                }

                if (DTL != 0)
                {
                    tOsttest2.Cell(ind, 7).Range.Text = DTL.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 7).Range.Text = "";
                }

                if (DTZT != 0)
                {
                    tOsttest2.Cell(ind, 8).Range.Text = DTZT.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 8).Range.Text = "";
                }

                if (DTZ != 0)
                {
                    tOsttest2.Cell(ind, 9).Range.Text = DTZ.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 9).Range.Text = "";
                }

                if (PECHT != 0)
                {
                    tOsttest2.Cell(ind, 10).Range.Text = PECHT.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 10).Range.Text = "";
                }

                if (PECH != 0)
                {
                    tOsttest2.Cell(ind, 11).Range.Text = PECH.ToString();
                }
                else
                {
                    tOsttest2.Cell(ind, 11).Range.Text = "";
                }

                
                tOsttest2.Cell(ind, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                tOsttest2.Cell(ind, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 7).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 8).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 9).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 10).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 11).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Cell(ind, 1).Width = 160;
                tOsttest2.Cell(ind, 2).Width = 31;
                tOsttest2.Cell(ind, 3).Width = 31;
                tOsttest2.Cell(ind, 4).Width = 31;
                tOsttest2.Cell(ind, 5).Width = 31;
                tOsttest2.Cell(ind, 6).Width = 31;
                tOsttest2.Cell(ind, 7).Width = 31;
                tOsttest2.Cell(ind, 8).Width = 31;
                tOsttest2.Cell(ind, 9).Width = 31;
                tOsttest2.Cell(ind, 10).Width = 31;
                tOsttest2.Cell(ind, 11).Width = 31;
            }
            
            //-------Заполняем итоги------------------------------------------
            tOsttest2.Cell(LODATEGR.Count() + 3, 1).Range.Text = "ИТОГО:";
            tOsttest2.Cell(LODATEGR.Count() + 3, 2).Range.Text = Math.Round(AI92ITOGT,0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 3).Range.Text = Math.Round(AI92ITOG,0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 4).Range.Text = Math.Round(AI95ITOGT, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 5).Range.Text = Math.Round(AI95ITOG, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 6).Range.Text = Math.Round(DTLITOGT, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 7).Range.Text = Math.Round(DTLITOG, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 8).Range.Text = Math.Round(DTZITOGT, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 9).Range.Text = Math.Round(DTZITOG, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 10).Range.Text = Math.Round(PECHITOGT, 0).ToString();
            tOsttest2.Cell(LODATEGR.Count() + 3, 11).Range.Text = Math.Round(PECHITOG, 0).ToString();

            tOsttest2.Cell(LODATEGR.Count() + 3, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            tOsttest2.Cell(LODATEGR.Count() + 3, 1).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 2).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 3).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 4).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 5).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 6).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 7).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 7).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 8).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 8).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 9).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 9).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 10).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 10).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 11).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            tOsttest2.Cell(LODATEGR.Count() + 3, 11).Range.Font.Bold = 1;
            tOsttest2.Cell(LODATEGR.Count() + 3, 1).Width = 160;
            tOsttest2.Cell(LODATEGR.Count() + 3, 2).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 3).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 4).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 5).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 6).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 7).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 8).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 9).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 10).Width = 31;
            tOsttest2.Cell(LODATEGR.Count() + 3, 11).Width = 31;
            //-------------------------------------------------
            r.InsertAfter("\n");

            //------------------------------------------------------------------------------------------------------
            var Paragraph6 = app.ActiveDocument.Paragraphs.Add();
            var Par6 = Paragraph6.Range;
            Par6.Text = "\tПрошу дать распоряжение начальнику филиала \"ЦБПО\" Мартыненко П.А. обеспечить доставку нефтепродуктов на филиалы ОАО автомобильным транспортом филиала \"ЦБПО\" в соответствии с вышеуказанной потребностью. ";
            Par6.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            Par6.Font.Size = 14;
            r.InsertAfter("\n");

            //--------------СТЕРЕТЬ ПОСЛЕ НАСТРОЙКИ---------------------------------------------------------------------------------
            
            //-----------------------------------------------------------------------------------------------
            //-----------------Вывод подписи начальника филиала ----------------------------------------------------
            r.InsertAfter("\n");

            var Paragraph10 = app.ActiveDocument.Paragraphs.Add();
            var Par10 = Paragraph10.Range;
            Par10.Text = "Начальник отдела                _______________                 Г.А.Киреев";
            Par10.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            Par10.Font.Size = 14;

            //------------------Выводим МОЛ с номером телефона----------------------------------------------------------
            r.InsertAfter("\n");
            r.InsertAfter("\n");
            r.InsertAfter("\n");

            var Paragraph3 = app.ActiveDocument.Paragraphs.Add();
            var hhh = Paragraph3.Range;
            hhh.Font.Size = 9;

            if (us1 == null)
            {
                hhh.Text = "";
            }
            else
            {
                hhh.Text = (us1.LastName + " " + us1.FirstName.Substring(0, 1) + "." + us1.MidleName.Substring(0, 1) + ". тел.: " + us1.Phone);
            }
            hhh.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;


            r.InsertAfter("\n");

            doc.SaveAs2(@"C:\Install\ReportZay.docx");
            //doc.SaveAs2(Server.MapPath("~/App_Data/Report.docx"));
            app.Documents.Open(@"C:\Install\ReportZay.docx");
            //app.Documents.Open(Server.MapPath("~/App_Data/Report.docx"));

            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("ReportZay.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\ReportZay.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ReportZay.docx");
        }       
           
            //----------Получаем список заявок в зависимости от дат---------------------------------------------------------------
            [HttpPost]
        public ActionResult GetZayTotalTab(string IdOrg, int Soglas, DateTime SZ, DateTime PoZ, DateTime SZM, DateTime PoZM)
        {
            List<Zayavka> zayTab = new List<Zayavka>();
            if (IdOrg == "")
            {
                zayTab = db.Zayavka.Where(a => a.DateZay >= SZ && a.DateZay <= PoZ && a.DatePlan >= SZM && a.DatePlan <= PoZM).OrderByDescending(g => g.DatePlan).ThenBy(l => l.Organization.Name).ThenByDescending(k => k.NumberSch).ToList();
            }
            else
            {                
                zayTab = db.Zayavka.Where(a => a.Organization.Name.Trim() == IdOrg.Trim() && a.DateZay >= SZ && a.DateZay <= PoZ && a.DatePlan >= SZM && a.DatePlan <= PoZM).OrderByDescending(g => g.DatePlan).ThenBy(l => l.Organization.Name).ThenByDescending(k => k.NumberSch).ToList();
            }
            if (Soglas == 2)
            {
                zayTab = zayTab.Where(t => t.UserSoglas != null).ToList();
            }
            else if (Soglas == 3)
            {
                zayTab = zayTab.Where(t => t.UserSoglas == null).ToList();
            }

            

            return PartialView(zayTab);
        }
        //-----------------------------//
        // удаление логина пользователя//

        public ActionResult DeleteLogin(int ID)
        {
            Autorize aut = new Autorize();
            aut = db.Autorize.FirstOrDefault(a => a.ID == ID);
            return PartialView(aut);
        }
        //-----------------------------//

        // Подтверждение удаления логина пользователя//
        public ActionResult DeleteLoginOK(int ID)
        {
            try
            {
                List<UserRoles> UsRol = new List<UserRoles>();
                UsRol = db.UserRoles.Where(h=>h.IdUser == ID).ToList();
               
                    db.UserRoles.RemoveRange(UsRol);
                    db.SaveChanges();
               
                Autorize orgDS = new Autorize();
                orgDS = db.Autorize.FirstOrDefault(a => a.ID == ID);
                db.Autorize.Remove(orgDS);
                db.SaveChanges();

                ViewBag.Message = "Пользователь удален!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Ошибка удаления";
                
            }

            return PartialView();
        }

        // Редактирование логина и пароля//

        public ActionResult LoginEdit(int ID)
        {
            List<Users> us = new List<Users>();
            us = db.Users.OrderBy(j=>j.LastName).ToList();
            us = db.Users.OrderBy(j=>j.LastName).ToList();
            ViewBag.USLOG = us;

            List<UserRoles> ur = new List<UserRoles>();
            ur = db.UserRoles.Where(j => j.IdUser == ID).ToList();
            ViewBag.UR = ur;

            Autorize Au =new Autorize();
            Au = db.Autorize.FirstOrDefault(g => g.ID == ID);

           
            List<RecordOil.Models.Roles> LR = new List<RecordOil.Models.Roles>();
            LR = db.Roles.ToList();
            ViewBag.LR = LR;

            return PartialView(Au);
        }
        //-------------------------------//

        //Сохранение редактирования логина и пароля------------//
        [HttpPost]
        public ActionResult LoginEditSave(int ID, string Logi, string Passw, string idFIO, string UserLog, DateTime DateLog, List<string> ddd)
        {
            try
            {
                Autorize auedit = new Autorize();
                auedit = db.Autorize.FirstOrDefault(s => s.ID == ID);

                auedit.Login = Logi.Trim();
                auedit.Password = Passw.Trim();
                auedit.UserModific = UserLog.Trim();
                auedit.DateModific = DateLog;
                if (idFIO == "")
                {
                    auedit.RoleId = null;
                }
                else
                {
                    auedit.RoleId = Convert.ToInt32(idFIO);
                }
                db.SaveChanges();
                //Теперь работаем с таблицей UsersRoles

                List<UserRoles> UsRol = new List<UserRoles>();
                UsRol = db.UserRoles.Where(h => h.IdUser == ID).ToList();

                db.UserRoles.RemoveRange(UsRol);
                db.SaveChanges();

                int IDDOD = db.Autorize.FirstOrDefault(g => g.Login.Trim() == Logi.Trim()).ID;

                foreach (var it in ddd)
                {
                    UserRoles ur = new UserRoles();
                    ur.IdUser = IDDOD;
                    ur.idRole = Convert.ToInt32(it);
                    db.UserRoles.Add(ur);
                    db.SaveChanges();
                }

                ViewBag.Message = "Login&Password изменены";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        //---Печать списка пользователей с паролями---------------------------------------------------------
        //----------------------------------------------------------------------------------------------------//
        [HttpGet]
        public ActionResult PrintLoginPassword()
        {

            //Получаем пользователя для отчета (МОЛ)
            Users us1 = new Users();
            Autorize poz = new Autorize();
            string poll = User.Identity.GetUserName();
            poz = db.Autorize.FirstOrDefault(f => f.Login == poll);
            us1 = db.Users.FirstOrDefault(g => g.IdUserrs == poz.RoleId);


            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            r.ParagraphFormat.LineSpacing = 12;
            r.Font.Size = 12;
            r.Font.Name = "Times New Roman";
            r.ParagraphFormat.SpaceBefore = 1;
            r.ParagraphFormat.SpaceAfter = 1;
            //------------------------------------------
            var Paragraph4 = app.ActiveDocument.Paragraphs.Add();
            var a = Paragraph4.Range;
            a.Text = "ОАО \"Гомельтранснефть Дружба\"\n";
            a.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            a.Font.Underline = WdUnderline.wdUnderlineSingle;
            a.ParagraphFormat.SpaceAfter = 10;
                        
                var ParagrapQQ = app.ActiveDocument.Paragraphs.Add();
                var ssQQ = ParagrapQQ.Range;
                ssQQ.Text = "Список пользователей ПК ";
                ssQQ.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                r.InsertAfter("\n\n");

            List<Autorize> AUT = new List<Autorize>();
            AUT = db.Autorize.ToList();
                //-------------------------------------------------------------------------------------------------------
                var Paragraph2 = app.ActiveDocument.Paragraphs.Add();
                var tableRange2 = Paragraph2.Range;

                Table tOsttest2 = doc.Tables.Add(tableRange2, AUT.Count, 4);
                tOsttest2.Borders.Enable = 1;
                tOsttest2.Rows.Add();
                tOsttest2.Rows[1].Cells[1].Range.Text = "Дескриптор";
                tOsttest2.Rows[1].Cells[2].Range.Text = "Пароль";
                tOsttest2.Rows[1].Cells[3].Range.Text = "Пользователь";
                tOsttest2.Rows[1].Cells[4].Range.Text = "Роль";
                
                tOsttest2.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                tOsttest2.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                                
                int index = 1;
                foreach (var p in AUT)
                {

                string str = "";
                foreach (var item in db.UserRoles.Where(g => g.IdUser == p.ID))
                {
                    str = str + item.Roles.Name + ", ";
                }
                index++;
                        tOsttest2.Cell(index, 1).Range.Text = p.Login.ToString();
                        tOsttest2.Cell(index, 2).Range.Text = p.Password.ToString();
                        tOsttest2.Cell(index, 3).Range.Text = (p.Users.LastName + " " + p.Users.FirstName.Substring(0, 1) + "." + p.Users.MidleName.Substring(0, 1) + ".").ToString();
                        tOsttest2.Cell(index, 4).Range.Text = str;
                        
                        tOsttest2.Cell(index, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Cell(index, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Cell(index, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        tOsttest2.Cell(index, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                          
                }                          
            
            //-----------------------------------------------------------------------------------------------------------
            doc.SaveAs2(@"C:\Install\Report.docx");
            //doc.SaveAs2(Server.MapPath("~/App_Data/Report.docx"));
            app.Documents.Open(@"C:\Install\Report.docx");
            //app.Documents.Open(Server.MapPath("~/App_Data/Report.docx"));

            doc.Close();
            app.Quit();

            MemoryStream stream = new MemoryStream();

            string strPDFFileName = string.Format("Report.docx");

            byte[] array = System.IO.File.ReadAllBytes(@"C:\Install\Report.docx");
            //byte[] array = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Report.docx"));

            stream.Write(array, 0, array.Length);
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Report.docx");

        }
        //-----------------------------------------------------------------------------------------------------
        //----------------Удаленные данные Остатки--------------------------//
        public ActionResult OstatkiDelete()
        {
            List<OstatkiDelete> OD = new List<OstatkiDelete>();
            OD = db.OstatkiDelete.OrderBy(h => h.Date).ToList();

            return View(OD);
        }
        //------------------------------------------------------//
        //------------------------------------------------------//
        //----------------Удаленные данные Заявки--------------------------//
        public ActionResult ZayavkiDelete()
        {
            List<ZayavkaDelete> ZD = new List<ZayavkaDelete>();
            ZD = db.ZayavkaDelete.OrderBy(h => h.Date).ToList();
            return View(ZD);
        }
        //------------------------------------------------------//

        //---------------------------Восстановление удаленных данных-----------------------------------

        //Восстановление остатков//
        public ActionResult VostOstat(int ID)
        {
            OstatkiDelete ostDel = new OstatkiDelete();
            ostDel = db.OstatkiDelete.FirstOrDefault(a => a.ID == ID);
            return PartialView(ostDel);
        }
        //-----------------------------//

        // Подтверждение удаления остатков//
        public ActionResult VostOstatOK(int ID)
        {
            try
            {
                OstatkiDelete OD = new OstatkiDelete();
                OD = db.OstatkiDelete.FirstOrDefault(a => a.ID == ID);

                // Сперва записываем данную строку в таблицу перед удалением данной записи
                OstatSklad ostDS = new OstatSklad();
               ostDS.IdSkl = OD.Sklad;
               ostDS.IdNeftep = OD.Nefteprod;
               ostDS.Massa = OD.V;
               ostDS.Date = OD.Date;
               ostDS.DateModific = DateTime.Now;
               ostDS.UserModific = User.Identity.GetUserName();
                db.OstatSklad.Add(ostDS);
                db.SaveChanges();

                //Теперь удаляем саму запись из БД
                db.OstatkiDelete.Remove(OD);
                db.SaveChanges();

                ViewBag.Message = "Остатки восстановлены!";
            }
            catch
            {
                ViewBag.Message = "Ошибка восстановления";
            }

            return PartialView();
        }
        // Восстановление заявки//
        public ActionResult VostZay(int ID)
        {
            ZayavkaDelete ZayDel = new ZayavkaDelete();
            ZayDel = db.ZayavkaDelete.FirstOrDefault(a => a.ID == ID);
            return PartialView(ZayDel);
        }
        //-----------------------------//

        // Восстановление заявки//
        public ActionResult VostZayOK(int ID)
        {
            try
            {
                ZayavkaDelete ZD = new ZayavkaDelete();
                ZD = db.ZayavkaDelete.FirstOrDefault(a => a.ID == ID);

                //Сперва записываем удаляемые данные в БД перед удалением
                //--------------------------------------------------------------------
                Zayavka ZayDS = new Zayavka();

               ZayDS.IdOrg = ZD.Filial;
               ZayDS.DateZay = ZD.Date;
               ZayDS.NumberSch = ZD.Number;
               ZayDS.DatePlan = ZD.PlanDate;
               ZayDS.DateModific = DateTime.Now;
               ZayDS.UserModific = User.Identity.GetUserName();
                db.Zayavka.Add(ZayDS);
                db.SaveChanges();

                //Получаем ID записи заявки
                List<Zayavka> IDZAYDELList = new List<Zayavka>();
                IDZAYDELList = db.Zayavka.OrderByDescending(o => o.DateModific).ToList();
                int IDZAYDEL = IDZAYDELList.FirstOrDefault().IdZay;

                //Теперь заполним таблицу tableZay перед удалением

                List<TableZayDelete> ListTZ = new List<TableZayDelete>();
                ListTZ = db.TableZayDelete.Where(f => f.IdZay == ID).ToList();

                TableZay TZD = new TableZay();

                foreach (var t in ListTZ)
                {
                    TZD.IdNeftep = t.IDNeft;
                    TZD.Massa = t.Massa;
                    TZD.IdSklad = Convert.ToInt32(t.IdSklad);
                    TZD.IdZay = IDZAYDEL;
                    db.TableZay.Add(TZD);
                    db.SaveChanges();
                }
                //Удаляем данные
                db.ZayavkaDelete.Remove(ZD);
               
                foreach (var t in ListTZ)
                {
                    db.TableZayDelete.Remove(t);
                }

                db.SaveChanges();

                ViewBag.Message = "Заявка восстановлена!";
            }
            catch
            {
                ViewBag.Message = "Ошибка восстановления";
            }

            return PartialView();
        }
        //--------------------------------------------
    }
}