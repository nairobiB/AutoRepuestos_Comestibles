using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepuestos_Comestibles.Clases
{
    class ClCrudVehiculo
    {
        ClConexion conexion = new ClConexion();

        private string _id_vehiculo;
        private double _precioVenta;

        public string Id_vehiculo { get => _id_vehiculo; set => _id_vehiculo = value; }
        public double PrecioVenta { get => _precioVenta; set => _precioVenta = value; }

        public void vehiculoVenta(string vehiculo)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select ID_Vehiculo, Vehiculo_PrecioVenta from Vehiculos where ID_Vehiculo = '" + vehiculo + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id_vehiculo = rdr["ID_Vehiculo"].ToString();
            PrecioVenta = Convert.ToDouble(rdr["Vehiculo_PrecioVenta"]);
            conexion.cerrar();

        }
    }
}
