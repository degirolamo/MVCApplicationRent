using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;

namespace MVCApplicationRent.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        { 
            MaterialRESTService m = new MaterialRESTService();
            List<Material> listMaterial = m.getMaterials();
        
            return View(listMaterial);
        }
        public ActionResult EditMaterial(int id)
        {
            MaterialRESTService m = new MaterialRESTService();
            Material material = m.getMaterial(id);
            return View(material);
        }
        [HttpPost]
        public ActionResult EditMaterial(int id, Material material)
        {
            MaterialRESTService m = new MaterialRESTService();
            m.PutMaterial(material);
            return RedirectToAction("DetailsMaterial", new { id = id });
        }
        public ActionResult DetailsMaterial(int id)
        {
            MaterialRESTService m = new MaterialRESTService();
            Material material = m.getMaterial(id);
            return View(material);
        }
        public ActionResult DeleteMaterial(int id)
        {
            MaterialRESTService m = new MaterialRESTService();
            Material material = m.getMaterial(id);
            return View(material);
        }
        [HttpPost]
        public ActionResult DeleteMaterial(int id, string __RequestVerificationToken)
        {
            MaterialRESTService m = new MaterialRESTService();
            m.DeleteMaterial(id);
            return RedirectToAction("Index");
        }
        public ActionResult AddMaterial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMaterial(Material material)
        {
            MaterialRESTService m = new MaterialRESTService();
            m.PostMaterial(material);
            return RedirectToAction("Index");
        }
    }
}