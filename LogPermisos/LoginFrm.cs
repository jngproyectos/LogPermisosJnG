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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        CDatos datos = new CDatos();
        UsuarioEn usuarioEntidad = new UsuarioEn();
        int IdRol;
        private bool ValidarCampos()
        {
            IdRol = datos.buscaUsuario(txtUsuario.Text, txtPassword.Text);
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Ingrese usuario");
                txtUsuario.Focus();
                return false;
            }
            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Ingrese password");
                txtPassword.Focus();
                return false;
            }
            else if (IdRol == 0)
            {
                MessageBox.Show("Usuario no registrado");
                return false;
            }
            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MenuFrm m = new MenuFrm(IdRol);
                m.Show();
                this.Hide();
            }
        }
    }
}
