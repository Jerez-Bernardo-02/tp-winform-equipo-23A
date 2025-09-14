using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            while(espaciosVacios() == false)
            {
                return;
            }

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                Imagen imagen = new Imagen();
                imagen.ImagenUrl = txtImagenUrl.Text;
                articulo.listaImagenes.Add(imagen);

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("¡Articulo modificado con exito!");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("¡Articulo agregado con exito!");
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

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
               
                if (articulo != null)
                { 
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    txtPrecio.Text = articulo.Precio.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool espaciosVacios()
        {
            int cont = 0;

            if (txtCodigo.Text == "")
            {
                txtCodigo.BackColor = Color.Red;
                cont++;
            }
            else
            {
                txtCodigo.BackColor = System.Drawing.SystemColors.Control;
            }

            if (txtNombre.Text == "")
            {
                txtNombre.BackColor = Color.Red;
                cont++;
            }
            else
            {
                txtNombre.BackColor = System.Drawing.SystemColors.Control;
            }

            if (txtDescripcion.Text == "")
            {
                txtDescripcion.BackColor = Color.Red;
                cont++;
            }
            else
            {
                txtDescripcion.BackColor = System.Drawing.SystemColors.Control;
            }

            if (txtPrecio.Text == "")
            {
                txtPrecio.BackColor = Color.Red;
                cont++;
            }
            else
            {
                txtPrecio.BackColor = System.Drawing.SystemColors.Control;
            }

            if (txtImagenUrl.Text == "")
            {
                txtImagenUrl.BackColor = Color.Red;
                cont++;
            }
            else
            {
                txtImagenUrl.BackColor = System.Drawing.SystemColors.Control;
            }

            if(cont == 0)
            {
                return true;
            }

            return false;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }

        private void cargarImagen(string imagenUrl)
        {
            try
            {
                pbxAltaArticulo.Load(imagenUrl);
            }
            catch (Exception ex)
            {
                pbxAltaArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
    }
}
