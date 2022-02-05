using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Dijkstra
{
    class Grafo : Panel
    {
        public List<Vertice> nodi;
        public List<Vertice> frontiera;
        public List<Vertice> nonVisitati;
        public List<Vertice> visitati;
        public Vertice Attivo { get; set; }
        public Grafo()
        {
            nonVisitati = new List<Vertice>();
            frontiera = new List<Vertice>();
            visitati = new List<Vertice>();
            nodi = new List<Vertice>();
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = Color.White;
            this.Size = new System.Drawing.Size(600, 600);

            //this.RowCount = 4;
            //this.ColumnCount = 4;
            //this.Anchor = AnchorStyles.None;
            //this.Padding = new System.Windows.Forms.Padding(50);
            // this.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            // this.Margin = new System.Windows.Forms.Padding(50);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Postazione p = new Postazione(i, j);

                    p.Location = new Point(j * 60, i * 60);
                    //    p.ControlAdded += new ControlEventHandler(p_ControlAdded);

                    this.Controls.Add(p);

                }
        }
        public void AggiungiVertice(Vertice v)
        {
            nonVisitati.Add(v);
        }

        public void SpostaFrontiera(Vertice v)
        {

            nonVisitati.Remove(v);
            frontiera.Add(v);

        }
        public void Visita()
        {
            Attivo = frontiera.ElementAt(0);
            if (!Attivo.Visitato)
            {
                Attivo.Visitato = true;

                visitati.Add(Attivo);
            }
            frontiera.RemoveAt(0);


        }
        public void Relax(Arco arco)
        {
            if (arco.Destinazione.Peso > Attivo.Peso + arco.Peso)
            {
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
        public void InizializzaSorgenteSingola(Vertice v)
        {
            v.Peso = 0;
            SpostaFrontiera(v);
        }

        public void AggiungiNodo(Vertice v)
        {
            nodi.Add(v);
            Controls.Add(v);
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
