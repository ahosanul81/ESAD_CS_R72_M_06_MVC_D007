using ESAD_CS_R72_M_06_MVC_D007.Models;
using ESAD_CS_R72_M_06_MVC_D007.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESAD_CS_R72_M_06_MVC_D007.Controllers
{
    public class ToysController : Controller
    {
        ToyDbContext db = new ToyDbContext();
        // GET: Toys
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "cId", "cName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToyVM tvm)
        {
            if (ModelState.IsValid)
            {
                if (tvm.Picture != null)
                {
                    string fileName = DateTime.Now.Ticks + Path.GetExtension(tvm.Picture.FileName);
                    string picturePath = "~/Images/" + fileName;
                    tvm.Picture.SaveAs(Server.MapPath(picturePath));
                }
                Toy t = new Toy
                {
                    ToyName = tvm.ToyName,
                    Price = tvm.Price,
                    StoreDate = tvm.StoreDate,
                    PicturePath = tvm.PicturePath,
                    cId = tvm.cId
                };
                db.Toys.Add(t);
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }
    }
}