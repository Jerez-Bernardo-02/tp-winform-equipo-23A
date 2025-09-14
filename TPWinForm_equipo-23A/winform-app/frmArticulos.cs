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
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulos;
        private int indice;

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();

            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog();

            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminar el registro de forma permanente?", "Eliminar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x =>
                    x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Codigo.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Descripcion.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                return;
            }

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            indice = 0;

            mostrarImagen();
        }

        private void cargarImagen(string imagenUrl)
        {
            try
            {
                pbxArticulo.Load(imagenUrl);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void mostrarImagen()
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            if (seleccionado == null || seleccionado.listaImagenes == null || seleccionado.listaImagenes.Count == 0)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                return;
            }

            cargarImagen(seleccionado.listaImagenes[indice].ImagenUrl);

            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;

            int tam;

            tam = seleccionado.listaImagenes.Count - 1;

            if(indice < tam)
            {
                btnSiguiente.Enabled = true;
            }
            
            if(indice > 0)
            {
                btnAnterior.Enabled = true;
            }

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indice++;
            mostrarImagen();   
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            indice--;
            mostrarImagen();
        }
    }
}
