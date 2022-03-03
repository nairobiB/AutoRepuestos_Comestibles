using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AutoRepuestos_Comestibles.Clases
{
    public class ClConexion
    {
        SqlDataAdapter da;
        DataTable dt;

        string conexion = "Data Source = Nairobi-Bodden\\SQLEXPRESS; Initial catalog = BoddenRentals; Integrated Security = true";

        //string conexion = "Data Source = 34.70.153.7;" + "Initial Catalog = BoddenRentals;" + "User id = sqlserver;" + "Password = vE8wcHIvMBxec47v;";

        public SqlConnection Sc = new SqlConnection();

        public ClConexion()
        {
            Sc.ConnectionString = conexion;
        }

        public void abrir()
        {
            try
            {
                Sc.Open();
                System.Windows.MessageBox.Show("Conexion abierta");
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show("Ocurrió un error al abrir BD" + x.Message);
            }
        }

        public void cerrar()
        {
            Sc.Close();
            System.Windows.MessageBox.Show("Conexion cerrada");
        }

        public void cargarDatos(DataColumn dgv, string tableName)
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM " + tableName, conexion);
                dt = new DataTable();
                da.Fill(dt);
                
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("No se pudieron cargar los datos.");
            }
        }

    }
}
