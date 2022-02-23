using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Resources;

namespace Dijkstra
{
    public partial class Form1 : Form
    {
        private Grafo g;
        Vertice dest = null;
        int i = 0;
        List<Vertice> vertici = new List<Vertice>();
        bool sorgFlag=false;
        Vertice sorg = null;

        public Form1()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;
            g = new Grafo();
            g.Location = new Point(220, 20);
            NuovoVertice nv = new NuovoVertice();
            Vertice v = new Vertice(char.ConvertFromUtf32(i + 65).ToString());
            v.Click += V_Click;
            i++;
            panel1.Controls.Add(v);
            g.AggiungiVertice(v);
            Controls.Add(g);

        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }

        private void sorgenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vertice sorgente = null;
            FrmPercorsoMinimo fmPm = new FrmPercorsoMinimo();

            foreach (Vertice v in g.nonVisitati)
            {
                v.lblPeso.Text = Vertice.INFINITY;
                fmPm.cmbPartenza.Items.Add(v.Nome);
            }

            fmPm.cmbPartenza.Text = fmPm.cmbPartenza.Items[0].ToString();
            if (fmPm.ShowDialog() == DialogResult.OK)
            {
                sorgente = g.DaNome(fmPm.cmbPartenza.Text);
                sorgente.lblPeso.Text = "0";
                sorgente.Peso = 0;
                sorgente.Visitato = true;
                g.Attivo = sorgente;
                sorgente.BackgroundImage = Properties.Resources.yellow_circle;

                Console.WriteLine("Vertice attivo (sorgente), Nome: " + g.Attivo.Nome + " ; Peso: " + g.Attivo.Peso);
                Console.WriteLine("Adiacenti al vertice attivo: ");
                foreach (Arco a in g.Attivo.listaAdiacenti)
                {
                    Console.WriteLine("Arco adiacente, Peso: " + a.Peso + " ; Nome Destinazione: " +
                                      a.Destinazione.Nome + " ; Peso destinazione: " + a.Destinazione.Peso);
                }

                g.SpostaVisitati(sorgente);

                Console.WriteLine("Il vertice attivo viene spostato in visitati");

                while (g.nonVisitati.Count > 0)
                {
                    Arco arco = null;
                    //g.nonVisitati.Sort();

                    Console.WriteLine("Num. non visitati --> " + g.nonVisitati.Count + " ; Num. visitati --> " +
                                      g.visitati.Count);

                    while ((arco = g.Attivo.Estrai()) != null)
                    {
                        Console.WriteLine(" PRIMA RELAX: estrai nuovo arco, Nome destinazione: " +
                                          arco.Destinazione.Nome + " ; Peso: " + arco.Peso +
                                          " ; Peso nodo di destinazione: " + arco.Destinazione.Peso);

                        g.Relax(arco);

                        Console.WriteLine("DOPO RELAX: estrai nuovo arco, Nome destinazione: " +
                                          arco.Destinazione.Nome + " ; Peso: " + arco.Peso +
                                          " ; Peso nodo di destinazione: " + arco.Destinazione.Peso);
                    }

                    g.nonVisitati.Sort();
                    g.Attivo = g.nonVisitati[0];


                    Console.WriteLine("vertice attivo, con peso minore, Nome: " + g.Attivo.Nome + " ; Peso: " +
                                      g.Attivo.Peso);
                    Console.WriteLine("Adiacenti al vertice attivo: ");
                    foreach (Arco a in g.Attivo.listaAdiacenti)
                    {
                        Console.WriteLine("Arco adiacente, Peso: " + a.Peso + " ; Nome Destinazione: " +
                                          a.Destinazione.Nome + " ; Peso nodo di destinazione: " + a.Destinazione.Peso);
                    }

                    g.SpostaVisitati(g.Attivo);

                    Console.WriteLine("Vertice attivo viene spostato in visitati");
                }

                Console.WriteLine("Num. non visitati: " + g.nonVisitati.Count + " ; Tutti i nodi sono stati visitati");
                Console.WriteLine("");
                Console.WriteLine("Nodi visitati:");
                foreach (Vertice v in g.visitati)
                {
                    Console.WriteLine("Nome: " + v.Nome + " ; Peso: " + v.Peso);
                }


                visualizzaGrafiToolStripMenuItem.Enabled = true;
                percorsoMinimoToolStripMenuItem.Enabled = false;
            }
        }


        private void panel1_MouseHover(object sender, EventArgs e)
        {
            NuovoVertice nv = new NuovoVertice();
            //Vertice v = new Vertice(char.ConvertFromUtf32(i + 65).ToString());
            Vertice v = new Vertice(char.ConvertFromUtf32(i + 65).ToString());
            v.Click += V_Click;
            i++;
            panel1.Controls.Add(v);
            g.AggiungiVertice(v);
        }

        private void aggiungiArco(object sender, EventArgs e)
        {
            NuovoArco fmArco = new NuovoArco();
            foreach (Control c in g.Controls)
            {

                if (c is Postazione && c.Controls.Count > 0)
                {
                    Vertice vx = (Vertice)c.Controls[0];
                    Postazione px = (Postazione)c;
                    vx.Posx = px.i * 60;
                    vx.Posy = px.j * 60;
                }
            }
            if (fmArco.ShowDialog()==DialogResult.OK)
            {
                sorg.listaAdiacenti.Add(new Arco(dest, Convert.ToInt32(fmArco.txtPeso.Text)));
                dest.listaAdiacenti.Add(new Arco(sorg, Convert.ToInt32(fmArco.txtPeso.Text)));
                g.Refresh();
            }
        }

        private void V_Click(object sender, EventArgs e)
        {
            Vertice v = (Vertice)sender;
            sorgFlag=!sorgFlag;
            if (!sorgFlag)
            {
                dest = v;
                aggiungiArco(this,e);
            }
            else
                sorg = v;
        }

        private void visualizzaGrafiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VsGrafi frameGrafi = new VsGrafi();

            vertici = g.nonVisitati.Concat(g.visitati).ToList();

            foreach (Vertice v in g.visitati)
            {
                string[] riga = { v.Nome, v.Peso.ToString() };
                frameGrafi.dataGrafo.Rows.Add(riga);
            }

            int height = frameGrafi.dataGrafo.Location.Y + frameGrafi.dataGrafo.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in frameGrafi.dataGrafo.Rows)
            {
                height += dr.Height; // Row height.
            }
            frameGrafi.dataGrafo.Height = height;

            frameGrafi.dataGrafo.Update();
            frameGrafi.dataGrafo.Refresh();

            foreach (Vertice v in vertici)
            {
                v.lblPeso.Text = v.Peso.ToString();
            }

            if (DialogResult.OK == frameGrafi.ShowDialog())
            {


            }
        }
    }
}
