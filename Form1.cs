using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;

namespace Dijkstra
{
    public partial class Form1 : Form
    {
        Grafo g;
        Vertice dest = null;
        int i = 0;
        List<Vertice> list = new List<Vertice>();
        Vertice sorg = null;

        public Form1()
        {
            InitializeComponent();

            Icon icon = new Icon("../../Resources/appicon.ico");
            this.Icon = icon;
            g = new Grafo();
            g.Location = new Point(220, 20);
            NuovoVertice nv = new NuovoVertice();
            Vertice v = new Vertice(char.ConvertFromUtf32(i + 65).ToString());
            i++;
            panel1.Controls.Add(v);
            g.AggiungiVertice(v);
            Controls.Add(g);

        }

        private void nuovoArcoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nuovo Arco
            NuovoArco fmArco = new NuovoArco();
            // listaNodi = new List<Vertice>();
            foreach (Control c in g.Controls)
            {

                if (c is Postazione && c.Controls.Count > 0)
                {
                    Vertice vx = (Vertice)c.Controls[0];
                    Postazione px = (Postazione)c;
                    vx.Posx = px.i * 60;
                    vx.Posy = px.j * 60;
                    fmArco.cmbPartenza.Items.Add(vx.Nome);
                    fmArco.cmbArrivo.Items.Add(vx.Nome);
                    // listaNodi.Add(vx);
                }
            }
            fmArco.cmbPartenza.Text = fmArco.cmbPartenza.Items[0].ToString();
            fmArco.cmbArrivo.Text = fmArco.cmbArrivo.Items[0].ToString();
            if (fmArco.ShowDialog() == DialogResult.OK)
            {

                //for (int i = 0; i < g.nonVisitati.Count; i++)
                //{
                //    if (listaNodi[i].Nome == fmArco.cmbArrivo.Text)
                //        dest = listaNodi[i];
                //    if (listaNodi[i].Nome == fmArco.cmbPartenza.Text)
                //        sorg = listaNodi[i];

                //}
                dest = g.DaNome(fmArco.cmbArrivo.Text);
                sorg = g.DaNome(fmArco.cmbPartenza.Text);
                sorg.listaAdiacenti.Add(new Arco(dest, Convert.ToInt32(fmArco.txtPeso.Text)));


                g.Refresh();

            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }

        private void sorgenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            Vertice sorgente = null;
            Vertice arrivo = null;
            FrmPercorsoMinimo fmPm = new FrmPercorsoMinimo();
            if (listBox1.Items.Count != 0)
            {
                listBox1.Items.Clear();
            }

            foreach (Vertice v in g.nonVisitati)
            {
                fmPm.cmbPartenza.Items.Add(v.Nome);
                fmPm.cmbArrivo.Items.Add(v.Nome);
            }

            fmPm.cmbPartenza.Text = fmPm.cmbPartenza.Items[0].ToString();
            fmPm.cmbArrivo.Text = fmPm.cmbArrivo.Items[0].ToString();
            if (fmPm.ShowDialog() == DialogResult.OK)
            {
                sorgente = g.DaNome(fmPm.cmbPartenza.Text);
                arrivo = g.DaNome(fmPm.cmbArrivo.Text);
                g.InizializzaSorgenteSingola(sorgente);
                while (g.frontiera.Count > 0)
                {
                    g.Visita();

                    for (Arco arco = null; (arco = g.Attivo.Estrai()) != null; g.Relax(arco), g.SpostaFrontiera(arco.Destinazione)) ;
                }
            }

            do
            {
                listBox1.Items.Insert(0, arrivo.Nome + " " + arrivo.Peso.ToString());
                arrivo.BackColor = Color.DarkBlue;
                arrivo.Font = new Font("Arial", 10F);
                arrivo.ForeColor = Color.Blue;
                string s = arrivo.Nome + "=" + arrivo.Peso.ToString();
                arrivo.Text = s;
                arrivo.TextAlign = ContentAlignment.MiddleLeft;
                arrivo = arrivo.Predecessore;
            } while (arrivo.GetHashCode() != sorgente.GetHashCode());

            listBox1.Items.Insert(0, sorgente.Nome + " " + sorgente.Peso.ToString());
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

        private void V_Click(object sender, EventArgs e)
        {
            

        }
    }
}
