using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus
{
    public class Tervehtija : ITervehtija
    {
        private string _tervehdys;

        public Tervehtija(IConfiguration configuration)
        {
            _tervehdys = configuration["Tervehdys"];
        }
        public string GetTervehdys()
        {
            return _tervehdys;
        }
    }
}
