using System;
using System.Collections.Generic;
using System.Text;

namespace Sovellus.Model.Entities
{
    public class Kaupunki
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public int AlueId { get; set; }

        public Alue Alue { get; set; }
        public List<Ravintola> Ravintolat { get; set; }
    }
}
