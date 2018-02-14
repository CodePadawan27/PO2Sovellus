using Microsoft.EntityFrameworkCore;
using Sovellus.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sovellus.Data.Repositories
{
    public class RavintolaRepository : EntityBaseRepository, IRavintolaRepository
    {
        public RavintolaRepository(SovellusContext context) : base(context) { }

        public Ravintola Hae(int id)
        {
            return _context.Ravintolat.FirstOrDefault(r => r.Id == id);
        }

        public Ravintola Hae(int id, bool navigation)
        {
            if(navigation)
            {
                return _context.Ravintolat
                    .Include(r => r.RavintolaTyyppi)
                    .Include(r => r.Kaupunki)
                    .FirstOrDefault(r => r.Id == id);
            }
            else
            {
                return Hae(id);
            }
        }

        public ICollection<Ravintola> HaeKaikki()
        {
            return _context.Ravintolat.ToList();
        }

        public ICollection<Ravintola> HaeKaikki(bool navigation)
        {
            if (navigation)
            {
                return _context.Ravintolat
                    .Include(r => r.RavintolaTyyppi )
                    .Include(r => r.Kaupunki)
                    .ToList();
            }
            else
            {
                return HaeKaikki();
            }
        }

        public List<Kaupunki> HaeKaupungit()
        {
            return _context.Kaupungit.ToList();
        }

        public List<RavintolaTyyppi> HaeRavintolaTyypit()
        {
            return _context.RavintolaTyypit.ToList();
        }

        public Ravintola Lisaa(Ravintola uusi)
        {
            int id = _context.Ravintolat.Count() > 0 ? _context.Ravintolat.Max(a => a.Id) + 1 : 1;
            uusi.Id = id;
            _context.Ravintolat.Add(uusi);
            _context.SaveChanges();
            return uusi;
        }

        public Ravintola Muuta(Ravintola muutettava)
        {
            Ravintola r = Hae(muutettava.Id);
            if (r != null)
            {
                r.Nimi = muutettava.Nimi;
                r.KaupunkiId = muutettava.KaupunkiId;
                r.Katuosoite = muutettava.Katuosoite;
                r.KotisivuUrl = muutettava.KotisivuUrl;
                r.KuvaUrl = muutettava.KuvaUrl;
                r.Postinro = muutettava.Postinro;
                r.TyyppiId = muutettava.TyyppiId;
                _context.SaveChanges();
                return r;
            }
            else
            {
                return null;
            }
        }

        public bool Poista(Ravintola poistettava)
        {
            Ravintola r = Hae(poistettava.Id);
            if (r != null)
            {
                _context.Ravintolat.Remove(r);
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
