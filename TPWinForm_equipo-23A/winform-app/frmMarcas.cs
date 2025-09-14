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
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarcas;

        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                listaMarcas = negocio.listar();
                dgvMarcas.DataSource = null;
                dgvMarcas.DataSource = listaMarcas;
                dgvMarcas.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmAltaMarca alta = new frmAltaMarca();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null) return;

            Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            frmAltaMarca modificar = new frmAltaMarca(seleccionada);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null) return;

            MarcaNegocio negocio = new MarcaNegocio();
            Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar la marca?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                negocio.eliminarMarca(seleccionada.Id);
                cargar();
            }
        }
    }
}
