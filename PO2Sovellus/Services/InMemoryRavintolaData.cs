using PO2Sovellus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Services
{
    public class InMemoryRavintolaData : IData<Ravintola>
    {
        private static List<Ravintola> _ravintolat;
        static InMemoryRavintolaData()
        {
            _ravintolat = new List<Ravintola>
            {
                new Ravintola { Id = 1, Nimi = "SAMK Agora"},
                new Ravintola { Id = 2, Nimi = "SAMK Tekatria"},
                new Ravintola { Id = 3, Nimi = "Ravintola Sipuli"}
            };
        }
        public IEnumerable<Ravintola> HaeKaikki()
        {
            return _ravintolat;
        }
        public Ravintola Hae(int id)
        {
            return _ravintolat.FirstOrDefault(h => h.Id == id);
        }

        public Ravintola Lisaa(Ravintola uusi)
        {
            uusi.Id = _ravintolat.Count > 0 ? _ravintolat.Max(r => r.Id) + 1 : 1;

            try
            {
                _ravintolat.Add(uusi);
            }
            catch
            {

                return null;
            }
            return uusi;
        }
    }
}


