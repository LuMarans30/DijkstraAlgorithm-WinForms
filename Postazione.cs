using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization;



namespace Dijkstra
{
    public class Postazione : System.Windows.Forms.Panel
    {

        public int i { get; set; }
        public int j {get;set;}

        public Postazione()
        {

            this.AllowDrop = true;
            this.BackColor = Color.Transparent;
            this.Size = new System.Drawing.Size(60,60);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(Postazione_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(Postazione_DragEnter);
         
        }
        public Postazione(int i, int j)
            : this()
        {
            this.i =j ;
            this.j = i;
        }

        private void Postazione_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Vertice)))
            {
                Vertice vert = (Vertice)e.Data.GetData(typeof(Vertice));
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void Postazione_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(Vertice)))
            {
                Vertice v = (Vertice)e.Data.GetData(typeof(Vertice));
                v.Location = new Point(0, 0);

                this.Controls.Add(v);
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);
        }
    }
}