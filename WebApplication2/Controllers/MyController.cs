using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApplication2.methods;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        // GET: My

        public ActionResult Index()
        {
            return View();
        }

        public int EmployeeId(int id)
        {
            return id;
        }
        public string EmployeeDetails(int id, string name, int age, string dept)
        {
            return "Id :" + id + ", Name :" + name + ", Age :" + age + ", Dept :" + dept;
        }

        public ActionResult Course()
        {

            ViewBag.course = new List<string>()
            {"java","python","php","dot net" };
            return View();
        }
        public ActionResult Cityview()
        {
            ViewBag.city = new List<string>()
            {"Chennai","Madurai","Tiruvallur","Avadi","Arakkonam"};
            return View();
        }
        public ActionResult Cityviewdata()
        {
            ViewData["City"] = new List<string>()
            {"Chennai","Madurai","Tiruvallur","Avadi","Arakkonam"};
            return View();
        }
        public ActionResult Student()
        {

            VelTech v = new VelTech()
            {
                id = 1,
                name = "senthil",
                age = 21,
                dept = "cse"
            };
            return View(v);
        }

        List<VelTech> l = new List<VelTech>()
        {
            new VelTech()
            {
                id = 1,
                name = "senthil",
                age = 21,
                dept = "cse"
            },
            new VelTech()
            {
                id = 2,
                name = "prathap",
                age = 20,
                dept = "cse"
            },
            new VelTech()
            {
                id = 3,
                name = "nithish",
                age = 21,
                dept = "IT"
            },
        };
        public ActionResult ShowAll()
        {
            return View(l);
        }

        //List<Register> li = new List<Register>()
        //{
        //    new Register{std_id=101,std_name="senthil",std_age=21,std_dept="cse",std_cgpa=8.4},
        //    new Register{std_id=102,std_name="sanjvu",std_age=22,std_dept="cse",std_cgpa=8.5},
        //    new Register{std_id=103,std_name="nithish",std_age=21,std_dept="ece",std_cgpa=8.6},
        //    new Register{std_id=104,std_name="prathap",std_age=22,std_dept="eee",std_cgpa=9},
        //    new Register{std_id=105,std_name="sasi",std_age=20,std_dept="it",std_cgpa=8.9 },
        //    new Register{std_id=106,std_name="manoj",std_age=20,std_dept="it",std_cgpa=8.9}
        //};
        //public ActionResult Register()
        //{
        //    return View(li);
        //}

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public String Insert(form1 f)
        {
            mvc_practice obj = new mvc_practice();
            int res = obj.InsertMethod(f);
            string result = res >= 1 ? "INSERTED SUCESSFULLY " : "NOT INSERTED";
            return result;
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public string Update(form1 f)
        {
            mvc_practice obj = new mvc_practice();
            int res = obj.UpdateMethod(f);
            string result = res >= 1 ? "UPDATED SUCESSFULLY" : " NOT UPDATED";
            return result;
        }
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]

        public string Delete(form1 f)
        {
            mvc_practice m = new mvc_practice();
            int res = m.DeleteMethod(f);
            string result = res > 0 ? "Deleted Sucessfully" : "Not Deleted";
            return result;
        }



        public ActionResult Updatetb()
        {
            return View();
        }

        [HttpPost]

        public string Updatetb(form1 f)
        {
            mvc_practice m = new mvc_practice();
            int res = m.DeleteMethod(f);
            string result = res > 0 ? "Deleted Sucessfully" : "Not Deleted";
            return result;
        }
        public ActionResult Grid()
        {
            mvc_practice m = new mvc_practice();
            List<form1> li = new List<form1>();
            li = m.ShowAll_Method();
 
            return View(li);
        }
        public ActionResult ShowId()
        {
            return View();
        }

     
        public ActionResult ShowIdGRid(form1 f)
        {
            mvc_practice m = new mvc_practice();
            form1 li = new form1();
            li = m.ShowSlingle_method(f);
            return View(li);
        }
    }
}