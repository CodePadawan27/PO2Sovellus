﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO2Sovellus.Services
{
    public interface IData<T>
    {
        IEnumerable<T> HaeKaikki();

        T Hae(int id);
        T Lisaa(T uusi);
    }
}
