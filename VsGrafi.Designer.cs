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
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrafo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisualizza
            // 
            this.btnVisualizza.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVisualizza.Location = new System.Drawing.Point(12, 184);
            this.btnVisualizza.Name = "btnVisualizza";
            this.btnVisualizza.Size = new System.Drawing.Size(98, 39);
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
            this.dataGrafo.Location = new System.Drawing.Point(12, 12);
            this.dataGrafo.Name = "dataGrafo";
            this.dataGrafo.Size = new System.Drawing.Size(243, 166);
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
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Dijkstra.Form1);
            // 
            // VsGrafi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 232);
            this.Controls.Add(this.dataGrafo);
            this.Controls.Add(this.btnVisualizza);
            this.Name = "VsGrafi";
            this.Text = "Percorsi minimi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrafo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.BindingSource form1BindingSource;
        public System.Windows.Forms.DataGridView dataGrafo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}