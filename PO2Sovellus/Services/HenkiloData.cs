using PO2Sovellus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Services
{
    public class HenkiloData
    {
    }

    public class InMemoryHenkiloData : IData<Henkilo>
    {
        List<Henkilo> _henkilot;

        public InMemoryHenkiloData()
        {
            _henkilot = new List<Henkilo>
            {
                new Henkilo { Id = 1, Etunimi = "Matti", Sukunimi = "Meikäläinen"},
                new Henkilo { Id = 2, Etunimi = "Matti", Sukunimi = "Mainio"},
                new Henkilo { Id = 3, Etunimi = "Jussi", Sukunimi = "Juonio"},
                new Henkilo { Id = 4, Etunimi = "Maija", Sukunimi = "Maitoparta"},
                new Henkilo { Id = 5, Etunimi = "Pekka", Sukunimi = "Töpöhäntä"},
            };
        }

        public IEnumerable<Henkilo> HaeKaikki()
        {
            return _henkilot;
        }
    }
}
