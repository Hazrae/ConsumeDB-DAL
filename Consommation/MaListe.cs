using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Consommation
{
    public class MaListe<T>
    {
        T[] monTableau;
        public void Add(T t)
        {
            monTableau[0] = t;
        }

    }
}
