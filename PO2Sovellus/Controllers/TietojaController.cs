using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Controllers
{
    [Route("[controller]")]
    public class TietojaController : Controller
    {
        [Route("")]
        public string Oikeudet()
        {
            return ("Copyright (c) SoftaFirma Co.");
        }

        [Route("[action]/{id}")]
        public string Palaute(string id = "")
        {
            if(id.Length > 50)
            {
                string trimmed = id.Substring(0, 50);
                trimmed += "...";

                return ($"Palaute saatu {DateTime.Now.ToLocalTime()} Teksti: {trimmed}");
            }

            return ($"Palaute saatu {DateTime.Now.ToLocalTime()} Teksti: {id}");
        }
    }
}
