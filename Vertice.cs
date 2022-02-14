using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dijkstra
{
    class Vertice : FlowLayoutPanel 
    {

        public Label lblEtichetta = new Label();
        public Label lblPeso = new Label();
        public event MouseEventHandler MouseGiu;
        public event MouseEventHandler MouseSu;
        public event MouseEventHandler MouseMuovi;
        public event EventHandler MouseClicca;

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
            listaAdiacenti = new List<Arco>();
            BackColor = System.Drawing.Color.White;
            BackgroundImage = global::Dijkstra.Properties.Resources.aquamarine_circle;
            this.BackColor = System.Drawing.Color.Transparent;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            Margin = new System.Windows.Forms.Padding(0);
            Size = new System.Drawing.Size(60, 60);

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
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new System.Drawing.Point(40, 0);
            this.lblPeso.Margin = new System.Windows.Forms.Padding(0);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(20, 20);
            this.lblPeso.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
        }

        public void Abilita()
        {
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Vertice_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(Vertice_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(Vertice_MouseUp);
        }


        


    }
}
