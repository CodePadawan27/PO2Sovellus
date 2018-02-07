using System;
using System.Collections.Generic;
using System.Text;

namespace Sovellus.Model.Entities
{
    public class Alue
    {
        public int Id { get; set; }
        public string Nimi { get; set; }

        public List<Kaupunki> Kaupungit { get; set; }
    }
}
