using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PO2Sovellus.ViewModels;
using Sovellus.Data.Repositories;
using Sovellus.Model.Entities;
using System;
namespace PO2Sovellus.Controllers.Api
{
    [Route("api/arvioinnit")]
    public class ArviointiController : Controller
    {
        private IArviointiRepository _arviointiData;
        private ILogger<ArviointiController> _logger;
        public ArviointiController(IArviointiRepository arviointiData,
        ILogger<ArviointiController> logger)
        {
            _arviointiData = arviointiData;
            _logger = logger;
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var malli = _arviointiData.HaeRavintolanUusimmat(id, 5);
                if (malli == null)
                {
                    return BadRequest("Arviointeja ei löytynyt.");
                }
                return Ok(malli);
            }
            catch (Exception e)
            {
                _logger.LogError($"Arviointien haku epäonnistui: {e.Message}");
                return BadRequest("Arviointeja ei löytynyt.");
            }
        }
        [HttpPost("")]
        public IActionResult Post([FromBody]ArviointiApiViewModel malli)
        {

            try
                {
                    if (ModelState.IsValid)
                    {
                        malli.Aika = DateTime.Now;
//                        Mapper.Initialize(config => {
//                            config.CreateMap<ArviointiApiViewModel,
//Arviointi>().ReverseMap();
//                        });
                        Arviointi uusi = Mapper.Map<Arviointi>(malli);
                        uusi = _arviointiData.Lisaa(uusi);
                        if (uusi != null)
                        {
                            return Created($"api/arvioinnit/{uusi.RavintolaId}", uusi);
                        }
                    }
                    return BadRequest(ModelState);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Arvioinnin lisääminen epäonnistui: {e.Message}");
                    return BadRequest("Arviointia ei voitu lisätä.");
                }
            }
        }
    }

