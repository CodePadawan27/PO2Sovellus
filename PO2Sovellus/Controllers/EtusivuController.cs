﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PO2Sovellus.Entities;
using PO2Sovellus.Services;
using PO2Sovellus.ViewModels;

namespace PO2Sovellus.Controllers
{
    public class EtusivuController : Controller
    {
        private ITervehtija _tervehtija;
        private IData<Ravintola> _ravintolaData;

        public EtusivuController(IData<Ravintola> ravintolaData, ITervehtija tervehtija)
        {
            _tervehtija = tervehtija;
            _ravintolaData = ravintolaData;
        }

        public IActionResult Index()
        {
            EtusivuViewModel data = new EtusivuViewModel { Ravintolat = _ravintolaData.HaeKaikki(), Otsikko = _tervehtija.GetTervehdys() };

            return View(data);
        }

        public IActionResult Tiedot(int id)
        {
            Ravintola malli = _ravintolaData.Hae(id);

            return View(malli);
        }

        [HttpGet]
        public IActionResult Uusi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Uusi(RavintolaEditViewModel malli)
        {
            if (ModelState.IsValid)
            {
                Ravintola uusi = new Ravintola();
                uusi.Nimi = malli.Nimi;

                uusi = _ravintolaData.Lisaa(uusi);

                return RedirectToAction("Tiedot", new { id = uusi.Id });

            }
            return View();
        }
    }
}

