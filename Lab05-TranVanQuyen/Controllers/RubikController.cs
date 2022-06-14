using Lab05_TranVanQuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05_TranVanQuyen.Controllers
{
    public class RubikController : Controller
    {
        // GET: Rubik
        MyData data = new MyData();
        public ActionResult Index()
        {
            var all_rubik = from s in data.Rubik select s;
            return View(all_rubik);
        }
        public ActionResult Detail(int id)
        {
            var D_rubik = data.Rubik.Where(m => m.id == id).First();
            return View(D_rubik);

        }
    }
}