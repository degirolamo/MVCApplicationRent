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
        ClientRESTService ser = new ClientRESTService();
        public ActionResult Index()
        {
            Country country1 = new Country { Id = 4, Name = "Portugal" };

            Client p = new Client { Id = 5, Firstname = "Rafael", Lastname = "Peixoto", Address = "Rue des Hipsters, 6969 Crans", Country = country1, Phone = "078 377 64 27", Mail="Raf.Peixot@gmail.com"};
            ser.PostClient(p);

            return View(ser.getClients());
        }
    }
}