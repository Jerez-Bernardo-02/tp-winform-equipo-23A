using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app
{
    public partial class frmAltaCategoria : Form
    {
        private Categoria categoria = null;
        public frmAltaCategoria()
        {
            InitializeComponent();
            Text = "Agregar Categoría";
        }
        public frmAltaCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Modificar Categoría"; 
        }

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            if (categoria != null)
                txtDescripcion.Text = categoria.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            while (espaciosVacios() == false)
            {
                return;
            }

            try
            {
                if (categoria == null)
                    categoria = new Categoria();

                categoria.Descripcion = txtDescripcion.Text;

                if (categoria.Id != 0)
                {
                    negocio.modificarCategoria(categoria);
                    MessageBox.Show("¡Categoría modificada con éxito!");
                }
                else
                {
                    negocio.agregarCategoria(categoria);
                    MessageBox.Show("¡Categoría agregada con éxito!");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool espaciosVacios()
        {

            if (txtDescripcion.Text == "")
            {
                txtDescripcion.BackColor = Color.Red;
                return false;
            }
            else
            {
                txtDescripcion.BackColor = System.Drawing.SystemColors.Control;
                return true;
            }
        }
    }
}
