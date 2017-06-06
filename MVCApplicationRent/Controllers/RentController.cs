using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using BLL;
using System.Web.Mvc;
using MVCApplicationRent.Models;

namespace MVCApplicationRent.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        public ActionResult Index()
        {
            RentRESTService r = new RentRESTService();
            List<Rent> listRent = r.getRents();

            return View(listRent);
        }
        public ActionResult DetailsRent(int id)
        {
            RentRESTService r = new RentRESTService();
            Rent rent = r.getRent(id);
            return View(rent);
        }
        public ActionResult EditRent(int id)
        {
            RentRESTService r = new RentRESTService();
            Rent rent = r.getRent(id);
            return View(rent);
        }
        [HttpPost]
        public ActionResult EditRent(int id, Rent rent)
        {
            RentRESTService r = new RentRESTService();
            r.PutRent(rent);
            return RedirectToAction("DetailsRent", new { id = id });
        }
        public ActionResult DeleteRent(int id)
        {
            RentRESTService r= new RentRESTService();
            Rent rent = r.getRent(id);
            return View(rent);
        }
        [HttpPost]
        public ActionResult DeleteRent(int id, string __RequestVerificationToken)
        {
            RentRESTService r = new RentRESTService();
            r.DeleteRent(id);
            return RedirectToAction("Index");
        }
        public ActionResult AddRent()
        {
            RentAndClient rc = new RentAndClient();
            rc.clients = new ClientRESTService().getClients();
            rc.rent = new Rent();
            rc.materials = new MaterialRESTService().getMaterials();
            return View(rc);
        }
        [HttpPost]
        public ActionResult AddRent(Rent rent)
        {
            rent.Client = new ClientRESTService().getClient(rent.Client.Id);
            rent.Material = new MaterialRESTService().getMaterial(rent.Material.Id);
            RentRESTService r = new RentRESTService();
            r.PostRent(rent);
            return RedirectToAction("Index");
        }
    }
}
