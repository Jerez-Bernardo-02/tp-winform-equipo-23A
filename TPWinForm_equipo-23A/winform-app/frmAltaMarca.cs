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
    public partial class frmAltaMarca : Form
    {
        private Marca marca = null;
        public frmAltaMarca()
        {
            InitializeComponent();
            Text = "Agregar Marca";
        }
        public frmAltaMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            Text = "Modificar Marca";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtDescripcion.Text;

                if (marca.Id != 0)
                {
                    negocio.modificarMarca(marca);
                    MessageBox.Show("¡Marca modificada con éxito!");
                }
                else
                {
                    negocio.agregarMarca(marca);
                    MessageBox.Show("¡Marca agregada con éxito!");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            if (marca != null)
                txtDescripcion.Text = marca.Descripcion;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            while(espaciosVacios() == false)
            {
                return;
            }

            try
            {
                MarcaNegocio negocio = new MarcaNegocio();

                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtDescripcion.Text;

                if (marca.Id != 0)
                {
                    negocio.modificarMarca(marca);
                    MessageBox.Show("¡Marca modificada con éxito!");
                }
                else
                {
                    negocio.agregarMarca(marca);
                    MessageBox.Show("¡Marca agregada con éxito!");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
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
