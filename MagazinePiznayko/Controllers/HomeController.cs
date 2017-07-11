using MagazinePiznayko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.IO;
using System.Diagnostics;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using System.Data.Entity;

namespace MagazinePiznayko.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
   
            public ActionResult Index()
        {            
            return View();
        }
        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult Poznayko()
        {
            return View();
        }
        public ActionResult Posnayko()
        {            
            return View();
        }
        public ActionResult Piznaykotwo()
        {
            return View();
        }
        public ActionResult Piznaykosix()
        {           
            return View();
        }
        [HttpGet]
        public ActionResult Registr()
        {
            ViewBag.pop = false;
            return View();            
        }

        private MagazineContext db = new MagazineContext();

        [HttpPost]
        public ActionResult Registr(Customer cust)
        {

            cust.idcustomer = Guid.NewGuid();
            db.customer.Add(cust);
            db.SaveChanges();

            var myResult = db.customer.Where(c=> c.name == cust.name).Select(c => new { c.name, c.product}).Distinct();
            ViewBag.name = cust.name;
            ViewBag.product = cust.product;
            ViewBag.pop = true;
            List<string> dict = new List<string>();
            foreach (var x in myResult)
            {
                string result = x.name +" придбав підписку "+ x.product;
                dict.Add(result);
            }
            ViewBag.data = dict;
            ViewBag.count = dict.Count();
            return View();
        }
    }
  

}
