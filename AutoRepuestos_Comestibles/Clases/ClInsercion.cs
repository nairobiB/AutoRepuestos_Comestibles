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
                //System.Windows.MessageBox.Show("Exitoso");
            }
            catch (SqlException x)
            {
                System.Windows.MessageBox.Show("Ocurrió un error al realizar la accion" + x.Message);
            }

            conexion.cerrar();
        }

        private int _factura;
        private int _Pedido;
        private int _usuario;

        public int Factura { get => _factura; set => _factura = value; }
        public int Pedido { get => _Pedido; set => _Pedido = value; }
        public int Usuario { get => _usuario; set => _usuario = value; }

        public void num_factura()
        {
            
            conexion.abrir();
            SqlCommand com = new SqlCommand("select COUNT(ID_Factura) as IdFac from Facturas", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Factura = Convert.ToInt32(rdr["IdFac"]);
            conexion.cerrar();

        }

        public void num_pedido()
        {

            conexion.abrir();
            SqlCommand com = new SqlCommand("select COUNT(ID_Pedido) as IdFac from Pedidos", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Pedido = Convert.ToInt32(rdr["IdFac"]);

            conexion.cerrar();

        }
        public void num_usuario()
        {

            conexion.abrir();
            SqlCommand com = new SqlCommand("select count(ID_Usuario) as num from Usuarios", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Usuario = Convert.ToInt32(rdr["num"]);

            conexion.cerrar();
        }


    }
}
