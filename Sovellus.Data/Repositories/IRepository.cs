using Sovellus.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sovellus.Data.Repositories
{
    public interface IRepository<T, U>
    {
        ICollection<T> HaeKaikki();
        T Hae(U id);
        T Lisaa(T uusi);
        T Muuta(T muutettava);
        bool Poista(T poistettava);
    }

    public interface IRavintolaRepository : IRepository<Ravintola, int>
    {
        List<string> HaeRavintolaKaupungit();
        List<Ravintola> HaeKaupunginRavintolat(string kaupunki);
        List<Kaupunki> HaeKaupungit();
        List<RavintolaTyyppi> HaeRavintolaTyypit();
        Ravintola Hae(int id, bool navigation);
        ICollection<Ravintola> HaeKaikki(bool navigation);
    }
    public interface IArviointiRepository : IRepository<Arviointi, long>
    {
        List<Arviointi> HaeRavintolanUusimmat(int id, int lkm);

    }
    public interface IUutinenRepository : IRepository<Uutinen, long> { }
}
