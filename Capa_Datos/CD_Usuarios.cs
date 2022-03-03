using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Datos
{
    public class CD_Usuarios
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private CE_Usuarios CE = new CE_Usuarios();

        #region CRUD

        #region Insertar
        public void Insertar(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "Ins_Usuarios",
                CommandType = CommandType.StoredProcedure,

            };
            com.Parameters.AddWithValue("@ID", Usuarios.Id_Usuario);
            com.Parameters.AddWithValue("@Nombre", Usuarios.Usuario_Nombre);
            com.Parameters.AddWithValue("@Password", Usuarios.Pass);
            com.Parameters.AddWithValue("@ID_Empleado", Usuarios.Id_Empleado);
            com.Parameters.AddWithValue("@Estado", Usuarios.Usuario_Nombre);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();


        }

        #endregion

        #region Consulta
        public CE_Usuarios Consultar(int IdUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter("Consultar_Usuario", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id_usuario", SqlDbType.Int).Value = IdUsuario;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            CE.Id_Usuario = Convert.ToInt32(row[0]);
            CE.Usuario_Nombre = Convert.ToString(row[1]);
            CE.Pass = Convert.ToString(row[2]);
            CE.Id_Empleado = Convert.ToString(row[3]);
            CE.Estado = Convert.ToBoolean(row[4]);


            return CE;

        }
        #endregion

        #region Modificar
        public void Modificar(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "Upd_Usuarios",
                CommandType = CommandType.StoredProcedure,

            };

            com.Parameters.AddWithValue("@ID", Usuarios.Id_Usuario);
            com.Parameters.AddWithValue("@Nombre", Usuarios.Usuario_Nombre);
            com.Parameters.AddWithValue("@Contraseña", Usuarios.Pass);
            com.Parameters.AddWithValue("@Estado", Usuarios.Estado);

            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();

        }
        #endregion

        #region Cargar Usuarios

        public void cargar()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "CMB_CargarUsuarios",
                CommandType = CommandType.StoredProcedure

            };

            con.CerrarConexion();
        }



        #endregion




        #endregion

    }
}
