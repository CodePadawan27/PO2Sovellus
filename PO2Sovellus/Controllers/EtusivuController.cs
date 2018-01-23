using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO2Sovellus.Models;
using PO2Sovellus.Services;

namespace PO2Sovellus.Controllers
{
    public class EtusivuController : Controller
    {
        private IData<Henkilo> _henkiloData;

        public EtusivuController(IData<Henkilo> henkiloData)
        {
            _henkiloData = henkiloData;
        }

        public IActionResult Index()
        {
            var data = _henkiloData.HaeKaikki();

            return View(data);
        }
    }
}
