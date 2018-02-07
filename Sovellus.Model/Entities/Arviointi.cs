using System;
using System.Collections.Generic;
using System.Text;

namespace Sovellus.Model.Entities
{
    public class Arviointi
    {
        public long Id { get; set; }
        public int RavintolaId { get; set; }
        public short Arvio { get; set; }
        public string Teksti { get; set; }
        public short? HintaLaatu { get; set; }
        public short? Palvelu { get; set; }
        public short? Ymparisto { get; set; }
        public DateTime Aika { get; set; }

        public Ravintola Ravintola { get; set; }

    }
}
