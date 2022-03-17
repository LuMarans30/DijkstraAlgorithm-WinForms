namespace Dijkstra
{
    partial class VsGrafi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.dataGrafo = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rBtnDijkstra = new System.Windows.Forms.RadioButton();
            this.rBtnBellmanFord = new System.Windows.Forms.RadioButton();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrafo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisualizza
            // 
            this.btnVisualizza.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVisualizza.Location = new System.Drawing.Point(12, 279);
            this.btnVisualizza.Name = "btnVisualizza";
            this.btnVisualizza.Size = new System.Drawing.Size(243, 39);
            this.btnVisualizza.TabIndex = 13;
            this.btnVisualizza.Text = "OK";
            this.btnVisualizza.UseVisualStyleBackColor = true;
            // 
            // dataGrafo
            // 
            this.dataGrafo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrafo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrafo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1});
            this.dataGrafo.Location = new System.Drawing.Point(12, 73);
            this.dataGrafo.Name = "dataGrafo";
            this.dataGrafo.Size = new System.Drawing.Size(243, 181);
            this.dataGrafo.TabIndex = 16;
            // 
            // Column0
            // 
            this.Column0.DataPropertyName = "Text";
            this.Column0.HeaderText = "Etichetta";
            this.Column0.Name = "Column0";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Text";
            this.Column1.HeaderText = "Peso";
            this.Column1.Name = "Column1";
            // 
            // rBtnDijkstra
            // 
            this.rBtnDijkstra.AutoSize = true;
            this.rBtnDijkstra.Location = new System.Drawing.Point(12, 31);
            this.rBtnDijkstra.Name = "rBtnDijkstra";
            this.rBtnDijkstra.Size = new System.Drawing.Size(60, 17);
            this.rBtnDijkstra.TabIndex = 17;
            this.rBtnDijkstra.Text = "Dijkstra";
            this.rBtnDijkstra.UseVisualStyleBackColor = true;
            this.rBtnDijkstra.CheckedChanged += new System.EventHandler(this.rBtnDijkstra_CheckedChanged);
            // 
            // rBtnBellmanFord
            // 
            this.rBtnBellmanFord.AutoSize = true;
            this.rBtnBellmanFord.Location = new System.Drawing.Point(78, 31);
            this.rBtnBellmanFord.Name = "rBtnBellmanFord";
            this.rBtnBellmanFord.Size = new System.Drawing.Size(86, 17);
            this.rBtnBellmanFord.TabIndex = 18;
            this.rBtnBellmanFord.Text = "Bellman Ford";
            this.rBtnBellmanFord.UseVisualStyleBackColor = false;
            this.rBtnBellmanFord.CheckedChanged += new System.EventHandler(this.rBtnDijkstra_CheckedChanged);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Dijkstra.Form1);
            // 
            // VsGrafi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 330);
            this.Controls.Add(this.rBtnBellmanFord);
            this.Controls.Add(this.rBtnDijkstra);
            this.Controls.Add(this.dataGrafo);
            this.Controls.Add(this.btnVisualizza);
            this.Name = "VsGrafi";
            this.Text = "Percorsi minimi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrafo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.BindingSource form1BindingSource;
        public System.Windows.Forms.DataGridView dataGrafo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.RadioButton rBtnDijkstra;
        public System.Windows.Forms.RadioButton rBtnBellmanFord;
    }
}