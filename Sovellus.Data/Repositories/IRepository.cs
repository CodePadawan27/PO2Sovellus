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

    public interface IRavintolaRepository : IRepository<Ravintola, int> { }
    public interface IArviointiRepository : IRepository<Arviointi, long> { }
    public interface IUutinenRepository : IRepository<Uutinen, long> { }
}
