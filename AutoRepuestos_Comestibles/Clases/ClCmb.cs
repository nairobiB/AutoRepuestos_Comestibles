using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
namespace AutoRepuestos_Comestibles.Clases
{
    public class ClCmb
    {
        ClConexion conexion = new ClConexion();

        public void fill_cmb(ComboBox cmb, string tabla, int row)
        {


            try
            {
                conexion.abrir();
                string query = "Select * from " + tabla;
                SqlCommand command = new SqlCommand(query, conexion.Sc);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(row).ToString();
                    cmb.Items.Add(name);
                }
                conexion.Sc.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
