using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization;



namespace Dijkstra
{
    /// <summary>
    /// Descrizione di riepilogo per Postazione.
    /// </summary>
    /// 

    public class Postazione : System.Windows.Forms.Panel
    {

        public int i { get; set; }
        public int j{get;set;}

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
            //this.DoubleClick+=new EventHandler(Postazione_DoubleClick);
        }

        private void Postazione_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Vertice)))
            {
                Vertice vert = (Vertice)e.Data.GetData(typeof(Vertice));
                e.Effect = DragDropEffects.Move;
                // OnDragDrop(new DragEventArgs(e.Data,e.KeyState,e.X,e.Y,e.AllowedEffect,e.Effect));
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void Postazione_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(Vertice)))
            {
                Vertice l3 = (Vertice)e.Data.GetData(typeof(Vertice));
                l3.Location = new Point(0, 0);

                this.Controls.Add(l3);
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