using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO2Sovellus.ViewModels;
using Sovellus.Data.Repositories;
using Sovellus.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Controllers.Api
{
    [Route("api/ravintola")]
    public class RavintolaController : Controller
    {
        private IRavintolaRepository _ravintolaData;
        private ILogger<RavintolaController> _logger;

        public RavintolaController(IRavintolaRepository ravintolaData, ILogger<RavintolaController> logger)
        {
            _ravintolaData = ravintolaData;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                Ravintola malli = _ravintolaData.Hae(id,true);
                if (malli == null)
                {
                    return BadRequest("Ravintolaa ei löytynyt.");
                }
                return Ok(malli);
            }
            catch (Exception e)
            {
                _logger.LogError($"Ravintolan haku epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei löytynyt");
            }
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]RavintolaApiViewModel malli)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Ravintola uusi = Mapper.Map<Ravintola>(malli);

                    uusi = _ravintolaData.Lisaa(uusi);

                    if (uusi != null)
                    {
                        return Created($"api/ravintola/{uusi.Id}", uusi);
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError($"Ravintolan lisäys epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei voitu lisätä.");
            }
        }

        [HttpPut("")]
        public IActionResult Put([FromBody]RavintolaApiViewModel malli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Ravintola muutettava = Mapper.Map<Ravintola>(malli);
                    muutettava = _ravintolaData.Muuta(muutettava);
                    if (muutettava != null)
                    {
                        return Ok(muutettava);
                    }
                }
                return BadRequest(ModelState);

            }
            catch (Exception e)
            {
                _logger.LogError($"Ravintolan päivitys epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei voitu muuttaa.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                Ravintola poistettava = _ravintolaData.Hae(id);
                if (poistettava != null)
                {
                    if (_ravintolaData.Poista(poistettava))
                    {
                        return Ok();
                    }
                }
                return BadRequest("Ravintolaa ei voitu poistaa.");
            }
            catch (Exception e)
            {
                _logger.LogError($"Ravintolan poisto epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei voitu poistaa.");
            }
        }

        [HttpGet("~/api/kaupungit")]
        public IActionResult GetKaupungit()
        {
            try
            {
                List<string> malli = _ravintolaData.HaeRavintolaKaupungit();
                if (malli == null)
                {
                    return BadRequest("Kaupunkinimiä ei löytynyt.");
                }
                return Ok(malli);
            }
            catch (Exception e)
            {
                _logger.LogError($"Kaupunkinimien haku epäonnistui: {e.Message}");
                return BadRequest("Kaupunkinimiä ei löytynyt.");
            }
        }
        [HttpGet("~/api/{nimi}/ravintolat")]
        public IActionResult Get(string nimi)
        {
            try
            {
                List<Ravintola> malli = _ravintolaData.HaeKaupunginRavintolat(nimi);
                if (malli == null)
                {
                    return BadRequest("Ravintolaa ei löytynyt.");
                }
                return Ok(malli);
            }
            catch (Exception e)
            {
                _logger.LogError($"Ravintolan haku epäonnistui: {e.Message}");
                return BadRequest("Ravintolaa ei löytynyt.");
            }
        }
    }
}
