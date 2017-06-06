using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace MVCApplicationRent.Controllers
{
    public class ClientController : Controller

    {  // GET: Clients
        public ActionResult Index()
        {
            ClientRESTService c = new ClientRESTService();
            List <Client> listClient = c.getClients();

            return View(listClient);
        }
        public ActionResult EditClient(int id)
        {
            ClientRESTService c = new ClientRESTService();
            Client client = c.getClient(id);
            return View(client);
        }
        [HttpPost]
        public ActionResult EditClient(int id, Client client)
        {
            ClientRESTService c = new ClientRESTService();
            c.PutClient(client);
            return RedirectToAction("DetailsClient", new { id = id });
        }
        
        public ActionResult DetailsClient(int id)
        {
            ClientRESTService c = new ClientRESTService();
            Client client = c.getClient(id);
            return View(client);
        }
        public ActionResult DeleteClient(int id)
        {
            ClientRESTService c = new ClientRESTService();
            Client client = c.getClient(id);
            return View(client);
        }
        [HttpPost]
        public ActionResult DeleteClient(int id, string __RequestVerificationToken)
        {
            ClientRESTService c = new ClientRESTService();
            c.DeleteClient(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            ClientRESTService c = new ClientRESTService();
            c.PostClient(client);
            return RedirectToAction("Index");
        }
    }
}