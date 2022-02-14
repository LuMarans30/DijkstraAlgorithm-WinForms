using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra
{
    internal class PesoNodo : Label
    {
        private int peso;

        public int Peso
        {
            get { return peso; }
            set { peso = value; Text = peso.ToString(); }
        }

        public Vertice Vertice { get; }

        public PesoNodo()
        {
            peso = int.MaxValue;
            Text = "∞";
        }

        public PesoNodo(Vertice vertice):this()
        {
            Vertice = vertice;
        }


    }
}
