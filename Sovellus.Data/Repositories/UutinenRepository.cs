using Sovellus.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sovellus.Data.Repositories
{
    public class UutinenRepository : EntityBaseRepository, IUutinenRepository
    {
        public UutinenRepository(SovellusContext context) : base(context) { }

        public Uutinen Hae(long id)
        {
            return _context.Uutiset.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Uutinen> HaeKaikki()
        {
            return _context.Uutiset.ToList();
        }

        public Uutinen Lisaa(Uutinen uusi)
        {
            long id = _context.Uutiset.Count() > 0 ? _context.Uutiset.Max(u => u.Id) + 1 : 1;
            uusi.Id = id;
            _context.Uutiset.Add(uusi);
            _context.SaveChanges();
            return uusi;
        }

        public Uutinen Muuta(Uutinen muutettava)
        {
            Uutinen u = Hae(muutettava.Id);
            if (u != null)
            {
                u.Aika = muutettava.Aika;
                u.Id = muutettava.Id;
                u.JulkaisuAika = muutettava.JulkaisuAika;
                u.RavintolaId = muutettava.RavintolaId;
                u.Teksti = muutettava.Teksti;
                return u;
            }
            else
            {
                return null;
            }
        }

        public bool Poista(Uutinen poistettava)
        {
            Uutinen u = Hae(poistettava.Id);
            if (u != null)
            {
                _context.Uutiset.Remove(u);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}   
