using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    public class Arco
    {
        public Vertice Sorgente { get; set; }   
        public Vertice Destinazione { get; set; }
        public int Peso { get; set; }
        public Arco(Vertice sorgente, Vertice destinazione, int peso)
        {
            Sorgente = sorgente;
            Destinazione = destinazione;
            Peso = peso;
        }
    }
}
