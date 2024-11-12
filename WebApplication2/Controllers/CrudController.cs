using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.methods;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CrudController : Controller
    {
        Register reg;
        // GET: Crud
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]

        public string Insert(Register r)
        {
            crud_methods c = new crud_methods();
            int res = c.Insert_method(r);
            string result = res > 0 ? "Inserted sucessfully " : "Not Inserted";
            return result;
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]

        public string Update(Register r)
        {
            crud_methods c = new crud_methods();
            int res = c.Update_method(r);
            string result = res > 0 ? "Updated sucessfully " : "Not Updated";
            return result;
        }
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]

        public string Delete(Register r)
        {
            crud_methods c = new crud_methods();
            int res = c.Delete_method(r);
            string result = res > 0 ? "Deleted sucessfully " : "Not Deleted";
            return result;
        }

        public ActionResult Grid_Show()
        {
            crud_methods c = new crud_methods();
            List<Register> li = new List<Register>();
            li = c.Showall_method();
            return View(li);
        }

        public ActionResult Grid_Show_id1()
        {
            
            return View();
        }

        public ActionResult Grid_Show_id2(Register r)
        {
            reg = new Register();
            crud_methods c = new crud_methods();
            reg = c.Showid_method(r);
            return View(reg);
        }



    }
}