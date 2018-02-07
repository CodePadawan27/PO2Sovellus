using System;
using System.Collections.Generic;
using System.Text;

namespace Sovellus.Model.Entities
{
    public class Ravintola
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public int KaupunkiId { get; set; }
        public int? TyyppiId { get; set; }
        public string Katuosoite { get; set; }
        public string Postinro { get; set; }
        public string KuvaUrl { get; set; }
        public string KotisivuUrl { get; set; }

        public List<Arviointi> Arvioinnit { get; set; }
        public Kaupunki Kaupunki { get; set; }
        public List<Uutinen> Uutiset { get; set; }
        public RavintolaTyyppi RavintolaTyyppi { get; set; }


    }
}
