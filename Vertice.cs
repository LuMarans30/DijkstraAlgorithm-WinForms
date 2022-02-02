using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dijkstra
{
    class Vertice : Label
    {
       

        public int Peso
        {
            get;
            set;
        }

        public int Posx{get;set;}
        public int Posy { get; set; }
        string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }
         public bool Visitato { get; set; }
         bool flag = false;
        public List<Arco> listaAdiacenti;
        public Vertice Predecessore { get; set; }
        public Vertice(string nome)
        {
            Predecessore = null;
            this.Peso = int.MaxValue;
            this.nome = nome;
            this.Visitato = false;
            this.BackColor= Color.White;
            this.ForeColor = Color.Red;
            this.Text = nome;
            this.Font = new Font("Courier", 16);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Size = new Size(45, 45);
            this.Margin = new Padding(30);
            listaAdiacenti = new List<Arco>();
            Abilita();
        }
        public Vertice(Vertice v):this(v.Nome)
        { 
        }
        public void Aggiungi(Arco arco)
        {
            int i = 0;
            for (; i < listaAdiacenti.Count && arco.Peso >= listaAdiacenti[i].Peso; i++) ;
            listaAdiacenti.Insert(i, arco);

        }
        public Arco Estrai()
        {
            Arco arco = null;
            if (listaAdiacenti.Count > 0)
            {
                arco = listaAdiacenti.ElementAt(0);
                listaAdiacenti.RemoveAt(0);
            }

            return arco;

        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            ////base.OnPaintBackground(pevent);
            //Graphics g = pevent.Graphics;
            //Brush b = Brushes.White;
            //g.FillEllipse(b, 0, 0,45, 45);
        }
        private void Vertice_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            flag = true;

        }

        private void Vertice_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            flag = false;
        }

        private void Vertice_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (flag)
            {
                Vertice a = (Vertice)sender;
                DataObject dataogg = new DataObject(a);
                a.DoDragDrop(dataogg, DragDropEffects.Move);
                flag = false;
                a.Disabilita();
          
            }

        }

     

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g =e.Graphics;
            Brush b1 = Brushes.White;
            g.FillRectangle(b1, 0, 0, 45, 45);
            Brush b = Brushes.Aquamarine;
            g.FillEllipse(b,0, 0, 45, 45);
            base.OnPaint(e);
        }

        public void Disabilita()
        {
            this.MouseMove -= new System.Windows.Forms.MouseEventHandler(Vertice_MouseMove);
            this.MouseDown -= new System.Windows.Forms.MouseEventHandler(Vertice_MouseDown);
            this.MouseUp -= new System.Windows.Forms.MouseEventHandler(Vertice_MouseUp);
           // this.Click += new EventHandler(Vertice_Click);
        }
        public void Abilita()
        {
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Vertice_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(Vertice_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(Vertice_MouseUp);
         //   this.Click += new EventHandler(Vertice_Click);
        }

        public void Vertice_MouseClick(object sender, MouseEventArgs e)
        {

        }


    }
}
