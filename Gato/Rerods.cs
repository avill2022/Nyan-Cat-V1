using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gato
{
     [SerializableAttribute]
    class Rerods
    {
        public int Puntos;
        public string Nombre;
        public Rerods()
        {
            Puntos = 0;
            Nombre = "----------";
        }
         public Rerods(int P,string N)
         {
             Puntos = P;
             Nombre = N;
         }
    }
}
