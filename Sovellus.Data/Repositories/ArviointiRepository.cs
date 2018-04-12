using Sovellus.Data.Repositories;
using Sovellus.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sovellus.Data
{
    public class ArviointiRepository : EntityBaseRepository, IArviointiRepository
    {
        public ArviointiRepository(SovellusContext context) :base(context) { }

        public List<Arviointi> HaeRavintolanUusimmat(int id, int lkm = 5)
        {
            return _context.Arvioinnit
            .Where(a => a.RavintolaId == id)
            .OrderByDescending(a => a.Aika)
            .Take(lkm)
            .ToList();
        }

        public Arviointi Hae(long id)
        {
            return _context.Arvioinnit.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Arviointi> HaeKaikki()
        {
            return _context.Arvioinnit.ToList();
        }

        public Arviointi Lisaa(Arviointi uusi)
        {
            //long id = _context.Arvioinnit.Count() > 0 ? _context.Arvioinnit.Max(a => a.Id) + 1 : 1;
            //uusi.Id = id;
            _context.Arvioinnit.Add(uusi);
            _context.SaveChanges();
            return uusi;
        }

        public Arviointi Muuta(Arviointi muutettava)
        {
            Arviointi a = Hae(muutettava.Id);
            if( a != null)
            {
                a.Arvio = muutettava.Arvio;
                a.Id = muutettava.Id;
                a.RavintolaId = muutettava.RavintolaId;
                a.Teksti = muutettava.Teksti;
                return a;
            }
            else
            {
                return null;
            }
        }

        public bool Poista(Arviointi poistettava)
        {
            Arviointi a = Hae(poistettava.Id);
            if ( a != null)
            {
                _context.Arvioinnit.Remove(a);
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
