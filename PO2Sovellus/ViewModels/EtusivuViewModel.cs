using PO2Sovellus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.ViewModels
{
    public class EtusivuViewModel
    {
        public IEnumerable<Ravintola> Ravintolat { get; set; }
        public string Otsikko { get; set; } 
    }
}
