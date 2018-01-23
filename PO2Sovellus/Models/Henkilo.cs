using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Models
{
    public class Henkilo
    {
        public int Id { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }

        public static IEnumerable<Henkilo> GeneroiData(int lkm)
        {
            List<Henkilo> paluu = new List<Henkilo>();

            for (int i = 1; i <= lkm; i++)
            {
                paluu.Add(new Henkilo { Id = i, Etunimi = "Matti", Sukunimi = "Meikäläinen" });
            }

            return paluu;
        }
    }
}
