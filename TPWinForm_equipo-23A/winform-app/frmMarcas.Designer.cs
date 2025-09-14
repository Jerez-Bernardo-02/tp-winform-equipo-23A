namespace winform_app
{
    partial class frmMarcas
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
            this.btnFiltroMarca = new System.Windows.Forms.Button();
            this.txtFiltroMarca = new System.Windows.Forms.TextBox();
            this.lblFiltroMarca = new System.Windows.Forms.Label();
            this.btnEliminarMarca = new System.Windows.Forms.Button();
            this.btnModificarMarca = new System.Windows.Forms.Button();
            this.btnAgregarMarca = new System.Windows.Forms.Button();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFiltroMarca
            // 
            this.btnFiltroMarca.Location = new System.Drawing.Point(610, 411);
            this.btnFiltroMarca.Name = "btnFiltroMarca";
            this.btnFiltroMarca.Size = new System.Drawing.Size(75, 23);
            this.btnFiltroMarca.TabIndex = 22;
            this.btnFiltroMarca.Text = "Buscar";
            this.btnFiltroMarca.UseVisualStyleBackColor = true;
            // 
            // txtFiltroMarca
            // 
            this.txtFiltroMarca.Location = new System.Drawing.Point(384, 413);
            this.txtFiltroMarca.Name = "txtFiltroMarca";
            this.txtFiltroMarca.Size = new System.Drawing.Size(220, 20);
            this.txtFiltroMarca.TabIndex = 21;
            // 
            // lblFiltroMarca
            // 
            this.lblFiltroMarca.AutoSize = true;
            this.lblFiltroMarca.Location = new System.Drawing.Point(346, 416);
            this.lblFiltroMarca.Name = "lblFiltroMarca";
            this.lblFiltroMarca.Size = new System.Drawing.Size(32, 13);
            this.lblFiltroMarca.TabIndex = 20;
            this.lblFiltroMarca.Text = "Filtro:";
            // 
            // btnEliminarMarca
            // 
            this.btnEliminarMarca.Location = new System.Drawing.Point(181, 411);
            this.btnEliminarMarca.Name = "btnEliminarMarca";
            this.btnEliminarMarca.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarMarca.TabIndex = 19;
            this.btnEliminarMarca.Text = "Eliminar";
            this.btnEliminarMarca.UseVisualStyleBackColor = true;
            this.btnEliminarMarca.Click += new System.EventHandler(this.btnEliminarMarca_Click);
            // 
            // btnModificarMarca
            // 
            this.btnModificarMarca.Location = new System.Drawing.Point(101, 411);
            this.btnModificarMarca.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarMarca.Name = "btnModificarMarca";
            this.btnModificarMarca.Size = new System.Drawing.Size(75, 23);
            this.btnModificarMarca.TabIndex = 18;
            this.btnModificarMarca.Text = "Modificar";
            this.btnModificarMarca.UseVisualStyleBackColor = true;
            this.btnModificarMarca.Click += new System.EventHandler(this.btnModificarMarca_Click);
            // 
            // btnAgregarMarca
            // 
            this.btnAgregarMarca.Location = new System.Drawing.Point(21, 411);
            this.btnAgregarMarca.Name = "btnAgregarMarca";
            this.btnAgregarMarca.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarMarca.TabIndex = 17;
            this.btnAgregarMarca.Text = "Agregar";
            this.btnAgregarMarca.UseVisualStyleBackColor = true;
            this.btnAgregarMarca.Click += new System.EventHandler(this.btnAgregarMarca_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(21, 44);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.RowHeadersWidth = 62;
            this.dgvMarcas.RowTemplate.Height = 28;
            this.dgvMarcas.Size = new System.Drawing.Size(664, 338);
            this.dgvMarcas.TabIndex = 16;
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 466);
            this.ControlBox = false;
            this.Controls.Add(this.btnFiltroMarca);
            this.Controls.Add(this.txtFiltroMarca);
            this.Controls.Add(this.lblFiltroMarca);
            this.Controls.Add(this.btnEliminarMarca);
            this.Controls.Add(this.btnModificarMarca);
            this.Controls.Add(this.btnAgregarMarca);
            this.Controls.Add(this.dgvMarcas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarcas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMarcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFiltroMarca;
        private System.Windows.Forms.TextBox txtFiltroMarca;
        private System.Windows.Forms.Label lblFiltroMarca;
        private System.Windows.Forms.Button btnEliminarMarca;
        private System.Windows.Forms.Button btnModificarMarca;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.DataGridView dgvMarcas;
    }
}