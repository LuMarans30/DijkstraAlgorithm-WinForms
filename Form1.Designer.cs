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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.percorsoMinimoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sorgenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaGrafiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.percorsoMinimoToolStripMenuItem,
            this.visualizzaGrafiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 20);
            this.menuStrip1.Size = new System.Drawing.Size(1186, 41);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.sorgenteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sorgenteToolStripMenuItem.Text = "Imposta Sorgente";
            this.sorgenteToolStripMenuItem.Click += new System.EventHandler(this.sorgenteToolStripMenuItem_Click);
            // 
            // visualizzaGrafiToolStripMenuItem
            // 
            this.visualizzaGrafiToolStripMenuItem.Name = "visualizzaGrafiToolStripMenuItem";
            this.visualizzaGrafiToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.visualizzaGrafiToolStripMenuItem.Text = "Visualizza grafi";
            this.visualizzaGrafiToolStripMenuItem.Click += new System.EventHandler(this.visualizzaGrafiToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(13, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 60);
            this.panel1.TabIndex = 2;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1186, 591);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Algoritmo di Dijkstra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem percorsoMinimoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sorgenteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem visualizzaGrafiToolStripMenuItem;
    }
}

