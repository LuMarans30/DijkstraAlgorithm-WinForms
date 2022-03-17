using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra
{
    public partial class VsGrafi : Form
    {
        public VsGrafi()
        {
            InitializeComponent();
        }

        private void rBtnDijkstra_CheckedChanged(object sender, EventArgs e)
        {

            dataGrafo.Rows.Clear();

            if (rBtnDijkstra.Checked == true)
                Form1.dijkstra();
            else
                Form1.bellmanFord();

            Form1.vertici = Form1.g.nonVisitati.Concat(Form1.g.visitati).ToList();

            foreach (Vertice v in Form1.g.visitati)
            {
                string[] riga = { v.Nome, v.Peso.ToString() };
                dataGrafo.Rows.Add(riga);
            }

            int height = dataGrafo.Location.Y + dataGrafo.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in dataGrafo.Rows)
            {
                height += dr.Height; // Row height.
            }
            dataGrafo.Height = height;

            dataGrafo.Update();
            dataGrafo.Refresh();

            foreach (Vertice v in Form1.vertici)
            {
                v.lblPeso.Text = v.Peso.ToString();
            }

        }

    }
}
