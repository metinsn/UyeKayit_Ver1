using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UyeKayit_Ver1.DAL.Repositories;
using UyeKayit_Ver1.Entity.Models;
using UyeKayit_Ver1.Entity.ViewModels;

namespace UyeKayit_Ver1.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            TempData["memoryList"] = null;

            if (TempData["list"] != null)
            {
                var result = TempData["list"] as List<PersonVM>;
                return View(result);
            }
            else
            {
                if (id.HasValue)
                {
                    var result = PersonRepo.GetAllPersonVM((int)id);
                    TempData["memoryList"] = result;
                    return View(result);
                }
                else
                {
                    var result = PersonRepo.GetAllPersonVM();
                    result = result.OrderBy(p => p.Fname).ToList();
                    return View(result);
                }
            }
        }

        [HttpPost]
        public ActionResult Login(Admin model)
        {
            var result = AdminRepo.AdminValid(model);

            if(result != null)
            {
                Session["Id"] = result.Id;
                Session["NickName"] = result.NickName;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            if (Session["Id"] != null)
            {
                var result = PersonTypeRepo.GetAll();
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult Add(Person model)
        {
            PersonRepo.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Sort(int id)
        {
            List<PersonVM> personList = new List<PersonVM>();

            if (TempData["memoryList"] != null)
            {
                personList = TempData["memoryList"] as List<PersonVM>;
            }
            else
            {
                personList = PersonRepo.GetAllPersonVM();
            }

            switch (id)
            {
                case 1:
                    personList = personList.OrderBy(p => p.Fname).ToList();
                    break;
                case 2:
                    personList = personList.OrderBy(p => p.Lname).ToList();
                    break;
                case 3:
                    personList = personList.OrderBy(p => p.PersonTypeName).ToList();
                    break;
                default:
                    break;
            }

            TempData["list"] = personList;

            return RedirectToAction("Index");
        }

        public ActionResult AddType()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddType(PersonType model)
        {
            bool state = PersonTypeRepo.Add(model);

            if (state)
            {
                ViewBag.MessageTrue = model.Name + " Eklendi!";
            }
            else
            {
                ViewBag.MessageFalse = model.Name + " Kayıtlı!";
            } 

            return View();
        }
        public ActionResult Delete(int id)
        {
            PersonRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}