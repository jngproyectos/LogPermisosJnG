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
    public partial class RolUsuarioFrm : Form
    {
        public RolUsuarioFrm()
        {
            InitializeComponent();
        }
        RolUsuarioEn rolEntidad = new RolUsuarioEn();
        PermisoEn permisoEntidad = new PermisoEn();
        CDatos datos = new CDatos();
        int IdRol;
        private void GuardarRol()
        {
            rolEntidad.RolNombre = txtUsuario.Text.ToUpper().Trim();
            IdRol = datos.GuardarRolUsuario(rolEntidad);
        }
        private void GuardarPermiso()
        {
            foreach(Control chk in panel1.Controls)
            {
                permisoEntidad.RolUsuarioId = IdRol;
                if(chk is CheckBox)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        permisoEntidad.OpcionId = Convert.ToInt32(chk.Tag);
                        permisoEntidad.Permitido = true;
                        datos.GuardarPermiso(permisoEntidad);
                    }
                    else
                    {
                        permisoEntidad.OpcionId = Convert.ToInt32(chk.Tag);
                        permisoEntidad.Permitido = false;
                        datos.GuardarPermiso(permisoEntidad);
                    }
                }
            }
        }
        private void Limpiar()
        {
            txtUsuario.Text = string.Empty;
            txtUsuario.Focus();
            foreach(Control chk in panel1.Controls)
            {
                if(chk is CheckBox)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        ((CheckBox)chk).Checked = false;
                    }
                }
            }
            MessageBox.Show("Permiso guardado");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRol();
            GuardarPermiso();
            Limpiar();
        }
    }
}
