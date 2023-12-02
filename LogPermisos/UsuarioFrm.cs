using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogPermisos.Datos;
using LogPermisos.Entidad;

namespace LogPermisos
{
    public partial class UsuarioFrm : Form
    {
        public UsuarioFrm()
        {
            InitializeComponent();
        }
        CDatos datos = new CDatos();
        UsuarioEn usarioEntidad = new UsuarioEn();
        private void CargarCombo()
        {
            DataTable Lst = datos.comboRol();
            cbRol.DataSource = Lst;
            cbRol.DisplayMember = "RolNombre";
            cbRol.ValueMember = "IdRol";
        }

        private void UsuarioFrm_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }
        private void Limpiar()
        {
            txtUsuario.Focus();
            txtUsuario.Text = string.Empty;
            txtPasword.Text = string.Empty;
            cbRol.SelectedIndex = -1;
            MessageBox.Show("Usuario guardado");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            usarioEntidad.Usuario = txtUsuario.Text;
            usarioEntidad.Contraseña = txtPasword.Text;
            usarioEntidad.RolId = (int)cbRol.SelectedValue;
            datos.GuardarUsuario(usarioEntidad);
            Limpiar();
        }
    }
}
