using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepuestos_Comestibles.Clases
{
    class ClSeleccionVehiculo
    {
        ClConexion conexion = new ClConexion(); 

        private string _id_vehiculo;
        private int _marca;
        private int _color;
        private int _modelo;
        private double _precioVenta;
        private double _preciorenta;
        private string _Descripcion;
        private int _estado;

        public string Id_vehiculo { get => _id_vehiculo; set => _id_vehiculo = value; }
        public int Marca { get => _marca; set => _marca = value; }
        public int Color { get => _color; set => _color = value; }
        public int Modelo { get => _modelo; set => _modelo = value; }
        public double PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
        public double Preciorenta { get => _preciorenta; set => _preciorenta = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Estado { get => _estado; set => _estado = value; }

        public void vehiculoVenta(string vehiculo)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select ID,(Marca+' '+Modelo+' ' +Color) as Vehiculo, [Precio de Venta] as venta from VehiculosVista where ID ='" + vehiculo + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id_vehiculo = rdr["ID"].ToString();
            PrecioVenta = Convert.ToDouble(rdr["venta"]);
            Descripcion = rdr["Vehiculo"].ToString();
            conexion.cerrar();
        }

        public void vehiculoRenta(string vehiculo)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select ID,(Marca+' '+Modelo+' ' +Color) as Vehiculo, [Precio de Renta] as renta from VehiculosVista where ID ='" + vehiculo + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id_vehiculo = rdr["ID"].ToString();
            Preciorenta = Convert.ToDouble(rdr["renta"]);
            Descripcion = rdr["Vehiculo"].ToString();
            conexion.cerrar();
        }

        public void seleccionar(string vehiculo)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select * from Vehiculos where ID_Vehiculo ='" + vehiculo + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id_vehiculo = rdr["ID_Vehiculo"].ToString();
            Marca = Convert.ToInt32(rdr["FK_ID_Marca"]);
            Color = Convert.ToInt32(rdr["FK_ID_Color"]);
            Modelo = Convert.ToInt32(rdr["FK_ID_Modelo"]);
            PrecioVenta = Convert.ToDouble(rdr["Vehiculo_PrecioVenta"]);
            Preciorenta = Convert.ToDouble(rdr["Vehiculo_PrecioRenta"]);
            Estado = Convert.ToInt32(rdr["FK_ID_Estado"]);
            conexion.cerrar();

        }


    }
}
