using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Dijkstra
{
    public class Grafo : Panel
    {
        public List<Vertice> nonVisitati;
        public List<Vertice> visitati;
        public Vertice Attivo { get; set; }

        public Grafo()
        {
            nonVisitati = new List<Vertice>();
            visitati = new List<Vertice>();
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = Color.White;
            this.Size = new Size(1500, 900);
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 25; j++)
                {
                    Postazione p = new Postazione(i, j);

                    p.Location = new Point(j * 60, i * 60);

                    this.Controls.Add(p);
                }
        }

        public Grafo(Grafo grafo)
        {
            this.nonVisitati = new List<Vertice>(grafo.nonVisitati);
            this.visitati = new List<Vertice>(grafo.visitati);
            this.Attivo = grafo.Attivo;
        }

        public void AggiungiVertice(Vertice v)
        {
            nonVisitati.Add(v);
        }

        public void SpostaVisitati(Vertice v)
        {

            nonVisitati.Remove(v);
            visitati.Add(v);

        }

        public void Relax(Arco arco)
        {
            //  Attivo = s; 
            //  d = arco.destinazione
            //  sd è l'arco da s a d
            /*  if (d.peso > s.peso + sd.peso){
                    d.peso = s.peso + sd.peso;
                    d.predecessore = s;
                }
            */
            if (!arco.Destinazione.Visitato && arco.Destinazione.Peso > Attivo.Peso + arco.Peso)
            {
                Console.WriteLine("Relax");
                arco.Destinazione.Peso = Attivo.Peso + arco.Peso;
                arco.Destinazione.Predecessore = Attivo;
            }
        }
        
        public Vertice DaNome(string nome)
        {
             var query = from vertice in nonVisitati
                        where vertice.Nome == nome
                        select vertice;
            return query.First();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            foreach (Control c in Controls)
            {
                Postazione p = c as Postazione;
                if (p != null && p.Controls.Count > 0)
                {
                    Vertice v = p.Controls[0] as Vertice;
                    if (v != null)
                    {
                        for (int i = 0; i < v.listaAdiacenti.Count; i++)
                        {
                            Brush b = Brushes.Blue;
                            Brush y = Brushes.RosyBrown;
                            gr.DrawLine(new Pen(Color.Red, 2), new Point(v.Posx + 30, v.Posy + 30), new Point(v.listaAdiacenti[i].Destinazione.Posx + 30, v.listaAdiacenti[i].Destinazione.Posy + 30));
                            gr.DrawString(v.listaAdiacenti[i].Peso.ToString(), new Font("Arial", 14F), y, new PointF((float)((v.Posx + v.listaAdiacenti[i].Destinazione.Posx) / 2), (float)(v.Posy + v.listaAdiacenti[i].Destinazione.Posy) / 2));
                        }
                    }                
                    
                }
            }
            base.OnPaint(e);
        }
                

    }

      
}
