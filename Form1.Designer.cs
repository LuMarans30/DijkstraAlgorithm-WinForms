namespace Dijkstra
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoArcoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.percorsoMinimoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sorgenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grafoToolStripMenuItem,
            this.percorsoMinimoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1186, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // grafoToolStripMenuItem
            // 
            this.grafoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoArcoToolStripMenuItem});
            this.grafoToolStripMenuItem.Name = "grafoToolStripMenuItem";
            this.grafoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.grafoToolStripMenuItem.Text = "Grafo";
            // 
            // nuovoArcoToolStripMenuItem
            // 
            this.nuovoArcoToolStripMenuItem.Name = "nuovoArcoToolStripMenuItem";
            this.nuovoArcoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.nuovoArcoToolStripMenuItem.Text = "Nuovo Arco";
            this.nuovoArcoToolStripMenuItem.Click += new System.EventHandler(this.nuovoArcoToolStripMenuItem_Click);
            // 
            // percorsoMinimoToolStripMenuItem
            // 
            this.percorsoMinimoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sorgenteToolStripMenuItem});
            this.percorsoMinimoToolStripMenuItem.Name = "percorsoMinimoToolStripMenuItem";
            this.percorsoMinimoToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.percorsoMinimoToolStripMenuItem.Text = "Percorso Minimo";
            // 
            // sorgenteToolStripMenuItem
            // 
            this.sorgenteToolStripMenuItem.Name = "sorgenteToolStripMenuItem";
            this.sorgenteToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.sorgenteToolStripMenuItem.Text = "Imposta Sorgente e Destinazione";
            this.sorgenteToolStripMenuItem.Click += new System.EventHandler(this.sorgenteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.Location = new System.Drawing.Point(13, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(45, 45);
            this.panel1.TabIndex = 2;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 217);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(119, 186);
            this.listBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Percorso Minimo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1186, 591);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Algoritmo di Dijkstra";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem grafoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem nuovoArcoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem percorsoMinimoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sorgenteToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

