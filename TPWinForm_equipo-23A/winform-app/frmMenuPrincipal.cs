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
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarVentanas();

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmArticulos))
                {
                    return;
                }
            }

            frmArticulos ventana = new frmArticulos();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarVentanas();

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmMarcas))
                {
                    return;
                }
            }

            frmMarcas ventana = new frmMarcas();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarVentanas();

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmCategorias))
                {
                    return;
                }
            }

            frmCategorias ventana = new frmCategorias();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void cerrarVentanas()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }
    }
}
