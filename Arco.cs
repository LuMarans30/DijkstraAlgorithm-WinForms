using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    class Arco
    {
        public Vertice Destinazione { get; set; }
        public int Peso { get; set; }
        public Arco(Vertice destinazione, int peso)
        {
            //Sorgente = sorgente;
            Destinazione = destinazione;
            Peso = peso;
        }
    }
}
