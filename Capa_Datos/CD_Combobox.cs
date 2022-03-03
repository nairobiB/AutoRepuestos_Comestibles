using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Combobox
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private CE_combobox CE = new CE_combobox();


        public CE_combobox CMB_EMPLEADOSID(String Nombre)
        {
            SqlDataAdapter da = new SqlDataAdapter("CMB_EmpleadoID", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.Int).Value = Nombre;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            CE.IdEmpleado = Convert.ToString(row[0]);
            return CE;

        }


        public CE_combobox CMB_EMPLEADOSNOMBRE (String Id)
        {
            SqlDataAdapter da = new SqlDataAdapter("CMB_EmpleadoNombre", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            CE.NombreEmpleado = Convert.ToString(row[0]);
            return CE;

        }


        public List<String> cargarEmpleados()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText= "CMB_CargarEMPLEADO",
                CommandType= CommandType.StoredProcedure
            };
            SqlDataReader reader = com.ExecuteReader();
            List<String> lista = new List<string>();
            while (reader.Read())
            {
                lista.Add(Convert.ToString(reader["Empleado_Nombre"]));
            }
            con.CerrarConexion();

            return lista;

        }



    }
}
