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
    class ClInsercion
    {
        ClConexion conexion = new ClConexion();

        public void Insertar(string Sp, List<string> parametros, List<string> controlsNames)
        {
            

            conexion.abrir();
            SqlCommand cmd = new SqlCommand(Sp, conexion.Sc);
            cmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < parametros.Count; i++)
            {
                cmd.Parameters.AddWithValue(parametros[i], controlsNames[i]);

            }

            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.MessageBox.Show("Registro Agregado Correctamente");
            }
            catch (SqlException x)
            {
                System.Windows.MessageBox.Show("Ocurrió un error al insertar el registro" + x.Message);
            }

            conexion.cerrar();
        }
    }
}
