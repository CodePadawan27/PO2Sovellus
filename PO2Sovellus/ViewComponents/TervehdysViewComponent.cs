using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.ViewComponents
{
    public class TervehdysViewComponent : ViewComponent
    {
        private ITervehtija _tervehdys;

        public TervehdysViewComponent(ITervehtija tervehdys)
        {
            _tervehdys = tervehdys;
        }

        public IViewComponentResult Invoke()
        {
            var malli = _tervehdys.GetTervehdys();
            return View("Oletus", malli);
        }
    }
}
