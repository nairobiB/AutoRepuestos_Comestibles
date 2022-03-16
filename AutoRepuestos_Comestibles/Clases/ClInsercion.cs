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

        public void Insertar(string Sp, dynamic[] parametros, dynamic[] controlsNames)
        {
            

            conexion.abrir();
            SqlCommand cmd = new SqlCommand(Sp, conexion.Sc);
            cmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < parametros.Length; i++)
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

        private int _factura;

        public int Factura { get => _factura; set => _factura = value; }

        public void num_factura()
        {
            
            conexion.abrir();
            SqlCommand com = new SqlCommand("select COUNT(ID_Factura) as IdFac from Facturas", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Factura = Convert.ToInt32(rdr["IdFac"]);
            conexion.cerrar();

        }
    }
}
