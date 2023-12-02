using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LogPermisos.Entidad;
using System.Windows.Forms;

namespace LogPermisos.Datos
{
    class CDatos
    {
        public int GuardarRolUsuario(RolUsuarioEn pRol)
        {
            CConexion cn = new CConexion();
            using (SqlConnection Conexion = new
                SqlConnection(cn.strinCon("dbSql")))
            {
                try
                {
                    using (SqlCommand cmd = new
                        SqlCommand("spGuardarRol", Conexion))
                    {
                        int ultimoRegistro = 0;
                        Conexion.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter IdRol = new
                            SqlParameter("@IdRol", SqlDbType.Int);
                        IdRol.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(IdRol);

                        cmd.Parameters.Add(new
                            SqlParameter("@Nom", pRol.RolNombre));
                        cmd.ExecuteNonQuery();

                        if (IdRol.Value != DBNull.Value)
                            ultimoRegistro = Convert.ToInt32(IdRol.Value);

                        return ultimoRegistro;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        public void GuardarPermiso(PermisoEn pPermiso)
        {
            CConexion cn = new CConexion();
            using (SqlConnection Conexion = new
                SqlConnection(cn.strinCon("dbSql")))
            {
                try
                {
                    using (SqlCommand cmd = new
                        SqlCommand("spGuardarPermiso", Conexion))
                    {
                        Conexion.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new
                            SqlParameter("@RolId", pPermiso.RolUsuarioId));
                        cmd.Parameters.Add(new
                            SqlParameter("@OpcionId", pPermiso.OpcionId));
                        cmd.Parameters.Add(new
                            SqlParameter("@Permitido", pPermiso.Permitido));

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public DataTable comboRol()
        {
            CConexion cn = new CConexion();
            DataTable dt = new DataTable();
            using(SqlConnection Conexion = new
                SqlConnection(cn.strinCon("dbSql")))
            {
                try
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spComboRol", Conexion))
                    {
                        Conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return dt;
            }
        }
        public void GuardarUsuario(UsuarioEn pUsuario)
        {
            CConexion cn = new CConexion();
            using (SqlConnection Conexion = new
                SqlConnection(cn.strinCon("dbSql")))
            {
                try
                {
                    using (SqlCommand cmd = new
                        SqlCommand("spGuardarUsuario", Conexion))
                    {
                        Conexion.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new
                            SqlParameter("@Usario", pUsuario.Usuario));
                        cmd.Parameters.Add(new
                            SqlParameter("@Contra", pUsuario.Contraseña));
                        cmd.Parameters.Add(new
                            SqlParameter("@RolId", pUsuario.RolId));

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public int buscaUsuario(string pUsario, string pContra)
        {
            CConexion cn = new CConexion();
            using (SqlConnection Conexion = new
                SqlConnection(cn.strinCon("dbSql")))
            {
                try
                {
                    using (SqlCommand cmd = new
                        SqlCommand("spBuscarUsuario", Conexion))
                    {
                        int Id = 0;
                        Conexion.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter IdRol = new
                            SqlParameter("@IdUsario", SqlDbType.Int);
                        IdRol.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(IdRol);

                        cmd.Parameters.Add(new
                            SqlParameter("@usario", pUsario));
                        cmd.Parameters.Add(new
                            SqlParameter("@contra", pContra));

                        cmd.ExecuteNonQuery();
                        if (IdRol.Value != DBNull.Value)
                            Id = Convert.ToInt32(IdRol.Value);

                        return Id;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        public List<PermisoEn> SelectOpcion(int pIdRol)
        {
            CConexion cn = new CConexion();
            DataTable dt = new DataTable();
            using (SqlConnection Conexion = new
                SqlConnection(cn.strinCon("dbSql")))
            {
                try
                {
                    using (SqlCommand cmd =
                        new SqlCommand("spSelectOpcion", Conexion))
                    {
                        Conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new
                            SqlParameter("@IdRol", pIdRol));
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        List<PermisoEn> Opcion =
                            (from row in dt.AsEnumerable()
                             select new PermisoEn()
                             {
                                 IdPermiso = int.Parse(row["IdPermiso"].ToString()),
                                 RolUsuarioId = int.Parse(row["RolUsuId"].ToString()),
                                 OpcionId = int.Parse(row["OpcionId"].ToString()),
                                 Permitido = bool.Parse(row["Permitido"].ToString())

                             }).ToList();

                        return Opcion;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}
