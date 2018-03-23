using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sovellus.Model.Entities;
using PO2Sovellus.Services;
using PO2Sovellus.ViewModels;
using Sovellus.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace PO2Sovellus.Controllers
{
    [Authorize]
    public class EtusivuController : Controller
    {
        private ITervehtija _tervehtija;
        private IRavintolaRepository _ravintolaData;

        public EtusivuController(IRavintolaRepository ravintolaData, ITervehtija tervehtija)
        {
            _tervehtija = tervehtija;
            _ravintolaData = ravintolaData;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            EtusivuViewModel data = new EtusivuViewModel { Ravintolat = _ravintolaData.HaeKaikki(true), Otsikko = _tervehtija.GetTervehdys() };

            return View(data);
        }

        //GET
        [HttpGet]
        public IActionResult Muuta(int id)
        {
            Ravintola haettava = _ravintolaData.Hae(id);
            if(haettava != null)
            {
                RavintolaEditViewModel vm = new RavintolaEditViewModel
                {
                    Id = haettava.Id,
                    Katuosoite = haettava.Katuosoite,
                    KaupunkiId = haettava.KaupunkiId,
                    KotisivuUrl = haettava.KotisivuUrl,
                    KuvaUrl = haettava.KuvaUrl,
                    Nimi = haettava.Nimi,
                    Postinro = haettava.Postinro,
                    TyyppiId = haettava.TyyppiId,
                    RavintolaTyypit = _ravintolaData.HaeRavintolaTyypit(),
                    Kaupungit = _ravintolaData.HaeKaupungit()
                };

                return View(vm);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Muuta(int id, RavintolaEditViewModel muutettu)
        {
            Ravintola haettava = _ravintolaData.Hae(id);
            if(ModelState.IsValid)
            {
                haettava.Nimi = muutettu.Nimi;
                haettava.KaupunkiId = muutettu.KaupunkiId;
                haettava.TyyppiId = muutettu.TyyppiId;
                haettava.Katuosoite = muutettu.Katuosoite;
                haettava.Postinro = muutettu.Postinro;
                haettava.KotisivuUrl = muutettu.KotisivuUrl;
                haettava.KuvaUrl = muutettu.KuvaUrl;

                _ravintolaData.Muuta(haettava);
                return RedirectToAction("Tiedot", new { id = muutettu.Id });

            }
            else
            {
                muutettu.RavintolaTyypit = _ravintolaData.HaeRavintolaTyypit();
                muutettu.Kaupungit = _ravintolaData.HaeKaupungit();
                return View(muutettu);
            }
        }

        public IActionResult Tiedot(int id)
        {
            Ravintola data = _ravintolaData.Hae(id, true);

            if(data == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult Uusi()
        {
            return View(new RavintolaEditViewModel
            {
                RavintolaTyypit = _ravintolaData.HaeRavintolaTyypit(),
                Kaupungit = _ravintolaData.HaeKaupungit()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Uusi(RavintolaEditViewModel malli)
        {
            if (!ModelState.IsValid)
            {
                malli.RavintolaTyypit = _ravintolaData.HaeRavintolaTyypit();
                malli.Kaupungit = _ravintolaData.HaeKaupungit();
                return View(malli);
            }

            var uusi = new Ravintola
            {
                Nimi = malli.Nimi,
                KaupunkiId = malli.KaupunkiId,
                TyyppiId = malli.TyyppiId,
                Katuosoite = malli.Katuosoite,
                Postinro = malli.Postinro,
                KotisivuUrl = malli.KotisivuUrl,
                KuvaUrl = malli.KuvaUrl
            };

            uusi = _ravintolaData.Lisaa(uusi);

            return RedirectToAction("Tiedot", new { id = uusi.Id });
        }
    }
}

