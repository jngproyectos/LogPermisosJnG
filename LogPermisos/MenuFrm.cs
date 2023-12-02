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
    public partial class MenuFrm : Form
    {
        public MenuFrm()
        {
            InitializeComponent();
        }
        public MenuFrm(int pIdRol)
        {
            InitializeComponent();
            IdRol = pIdRol;
        }
        int IdRol;
        CDatos datos = new CDatos();
        private void ConsultarRol(ToolStripMenuItem pTool)
        {
            var LstOp = datos.SelectOpcion(IdRol);
            foreach(ToolStripMenuItem tool in pTool.DropDownItems)
            {
                foreach(var opc in LstOp)
                {
                    if (opc.OpcionId == Convert.ToInt32(tool.Tag))
                    {
                        if (!opc.Permitido)
                            tool.Enabled = false;
                    }
                }
            }
        }
        private void rolDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolUsuarioFrm rol = new RolUsuarioFrm();
            rol.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioFrm us = new UsuarioFrm();
            us.ShowDialog();
        }

        private void MenuFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MenuFrm_Load(object sender, EventArgs e)
        {
            ConsultarRol(administracionTS);
            ConsultarRol(serviciosTs);
            ConsultarRol(mantenimientoTS);
            ConsultarRol(clientesTS);
        }
    }
}
