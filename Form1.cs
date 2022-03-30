using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;

namespace Dijkstra
{
    public partial class Form1 : Form
    {
        public static Grafo g;
        private Vertice dest = null;
        public Vertice sorgente = null;
        private Vertice sorg = null;
        private int i = 0;
        public static List<Vertice> vertici = new List<Vertice>();
        public static List<Vertice> bellManVertici = new List<Vertice>();
        private bool sorgFlag=false;

        public Form1()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
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

        public static void routingGerarchico()
        {
            
        }

        public static void dijkstra()
        {

            while (g.nonVisitati.Count > 0)
            {
                Arco arco;

                while ((arco = g.Attivo.Estrai()) != null)
                {                   
                    g.Relax(arco);
                }
                
                g.nonVisitati.Sort();
                g.Attivo = g.nonVisitati[0];
                g.SpostaVisitati(g.Attivo);
            }

        }


        public static void bellmanFord()
        {
            List<Vertice> vertici = new List<Vertice>();
            vertici.Add(g.Attivo);
            vertici.AddRange(g.nonVisitati);
            bool flag = true;
            while (flag)
            {
                flag = false;
                foreach (Vertice vertice in vertici)
                {
                    foreach (Arco arco in vertice.listaAdiacenti)
                    {
                        if(g.Aggiornamento(arco))
                            flag = true;
                    }
                }
            }

            bellManVertici = vertici;

        }

        private void sorgenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

                g.SpostaVisitati(g.Attivo);
            }

            visualizzaGrafiToolStripMenuItem.Enabled = true; 
            percorsoMinimoToolStripMenuItem.Enabled = false;          
        }


        private void panel1_MouseHover(object sender, EventArgs e)
        {
            NuovoVertice nv = new NuovoVertice();
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
                sorg.listaAdiacenti.Add(new Arco(sorg, dest, Convert.ToInt32(fmArco.txtPeso.Text)));
                dest.listaAdiacenti.Add(new Arco(dest, sorg, Convert.ToInt32(fmArco.txtPeso.Text)));
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

            if(frameGrafi.ShowDialog() == DialogResult.OK)
            {

            }

            //g.Refresh();
        }
    }
}
