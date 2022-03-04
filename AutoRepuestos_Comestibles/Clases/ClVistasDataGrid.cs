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
    class ClVistasDataGrid

    {
      ClConexion conexion = new ClConexion();


        public void LlenarDG(string vista, DataGrid Tabla)
        {
            conexion.abrir();
            SqlCommand cmd = new SqlCommand("select * from "+vista, conexion.Sc);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new DataTable();
            da.Fill(dt);
            Tabla.ItemsSource = dt.DefaultView;
            conexion.cerrar();

        }

        public void Busqueda(string vista, DataGrid Tabla, string texto, string campo1, string campo2, string campo3)
        {
            conexion.abrir();
            SqlCommand cmd = new SqlCommand("select * from " + vista + " where " + campo1 + " like '%%" + texto + "%%' or " + campo2 + " like '%%" + texto + "%%' or " + campo3 + " like '%%" + texto + "%%' ", conexion.Sc);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new DataTable();
            da.Fill(dt);
            Tabla.ItemsSource = dt.DefaultView;
            conexion.cerrar();

        }

    }
}
