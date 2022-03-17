using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dijkstra
{
    public class Vertice : FlowLayoutPanel, IComparable<Vertice>
    {

        public Label lblEtichetta = new Label();
        public Label lblPeso = new Label();
        public event MouseEventHandler MouseGiu;
        public event MouseEventHandler MouseSu;
        public event MouseEventHandler MouseMuovi;
        public event EventHandler MouseClicca;
        public List<Arco> listaAdiacenti;
        public static string INFINITY = "∞";

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
        public Vertice Predecessore { get; set; }

        public Vertice(string nome)
        {
            Predecessore = null;
            this.Peso = int.MaxValue-100000;
            this.nome = nome;
            this.Visitato = false;
            listaAdiacenti = new List<Arco>();
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.aquamarine_circle;
            this.BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            Margin = new Padding(0);
            Size = new Size(60, 60);

            this.Click += OnClick;
            this.MouseGiu += Vertice_MouseDown;
            this.MouseSu += Vertice_MouseUp;
            this.MouseMuovi += Vertice_MouseMove;
            
            // 
            // lblEtichetta
            // 
            //this.lblEtichetta.BackColor = System.Drawing.Color.Transparent;
            this.lblEtichetta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtichetta.Location = new System.Drawing.Point(0, 0);
            this.lblEtichetta.Text = nome;
            this.lblEtichetta.Margin = new System.Windows.Forms.Padding(0);
            this.lblEtichetta.Name = "lblEtichetta";
            this.lblEtichetta.Size = new System.Drawing.Size(40, 55);
            this.lblEtichetta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEtichetta.MouseDown += lblMouseDown;
            this.lblEtichetta.MouseUp += lblMouseUp;
            this.lblEtichetta.MouseMove += lblMouseMove;
            this.lblEtichetta.Click += lblClick;
            // 
            // lblPeso
            // 
            //this.lblPeso.BackColor = System.Drawing.Color.Transparent;
            this.lblPeso.Font = new Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new Point(40, 0);
            this.lblPeso.Margin = new Padding(0);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new Size(20, 20);
            this.lblPeso.TextAlign = ContentAlignment.BottomLeft;
            this.lblPeso.MouseDown += lblMouseDown;
            this.lblPeso.MouseUp += lblMouseUp;
            this.lblPeso.MouseMove += lblMouseMove;
            this.lblPeso.Click += lblClick;

            Abilita();
            Controls.Add(this.lblEtichetta);
            Controls.Add(this.lblPeso);

        }

        private void OnClick(object sender, EventArgs e)
        {
            MouseClicca?.Invoke(this, e);
        }

        protected virtual void OnMouseGiu(MouseEventArgs e)
        {
            MouseGiu?.Invoke(this, e);
        }

        protected virtual void OnMouseSu(MouseEventArgs e)
        {
            MouseSu?.Invoke(this, e);
        }

        protected virtual void OnMouseMuovi(MouseEventArgs e)
        {
            MouseMuovi?.Invoke(this, e);
        }

        public void lblMouseDown(object sender, MouseEventArgs e)
        {
            OnMouseGiu(e);
        }
        public void lblMouseUp(object sender, MouseEventArgs e)
        {
            OnMouseSu(e);
        }

        public void lblMouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMuovi(e);
        }

        public void lblClick(object sender, EventArgs e)
        {
            OnClick(e);
        }

        /*public void Aggiungi(Arco arco)
        {
            Console.WriteLine("AGGIUNGI");
            int i = 0;
            for (; i < listaAdiacenti.Count && arco.Peso >= listaAdiacenti[i].Peso; i++);
            listaAdiacenti.Insert(i, arco);
            Arco arco2 = new Arco(this, this.Peso);
            for (i=0; i < arco2.Destinazione.listaAdiacenti.Count && arco2.Peso >= arco2.Destinazione.listaAdiacenti[i].Peso; i++) ;
            arco2.Destinazione.listaAdiacenti.Insert(i, arco2);
        }*/

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
            //Brush b1 = Brushes.White;
            //g.FillRectangle(b1, 0, 0, 45, 45);
            Brush b = Brushes.Transparent;
            g.FillEllipse(b,0, 0, 45, 45);
            base.OnPaint(e);
        }

        public void Disabilita()
        {
            this.MouseMove -= new System.Windows.Forms.MouseEventHandler(Vertice_MouseMove);
            this.MouseDown -= new System.Windows.Forms.MouseEventHandler(Vertice_MouseDown);
            this.MouseUp -= new System.Windows.Forms.MouseEventHandler(Vertice_MouseUp);
        }

        public void Abilita()
        {
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Vertice_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(Vertice_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(Vertice_MouseUp);
        }

        public int CompareTo(Vertice v)
        {
            if (v.Peso == this.Peso)
                return 0;

            if (v.Peso > this.Peso)
                return -1;

            return 1;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
