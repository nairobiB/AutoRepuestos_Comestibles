using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Conexion
    {
        private readonly SqlConnection con = new SqlConnection("Data Source=Ele; initial catalog= BoddenRentals; integrated security=true");


        public SqlConnection AbrirConexion()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            return con;

        }


        public SqlConnection CerrarConexion()
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            return con;

        }
    }
}
