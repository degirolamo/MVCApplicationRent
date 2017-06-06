using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplicationRent.Models
{
    public class RentAndClient
    {
        public Rent rent { get; set; }
        public List<Client> clients{get; set;}
        public List<Material> materials { get; set; }
    }
}