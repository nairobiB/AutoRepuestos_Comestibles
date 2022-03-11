using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AutoRepuestos_Comestibles.Clases
{
    class ClSeleccionProveeedor
    {
        ClConexion conexion = new ClConexion();

        private string _id;
        private string _rtn;
        private string _identidad;
        private string _nombre;
        private string _encargado;
        private string _Telefono;
        private string _Correo;
        private string _Direccion;
        private string _IDEstado;

        public string Id { get => _id; set => _id = value; }
        public string Rtn { get => _rtn; set => _rtn = value; }
        public string Identidad { get => _identidad; set => _identidad = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Encargado { get => _encargado; set => _encargado = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string IDEstado { get => _IDEstado; set => _IDEstado = value; }

        public void seleccionar(string idProveedor)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select * from Proveedores where ID_Proveedor =  '" + idProveedor + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id = rdr["ID_Proveedor"].ToString();
            Rtn = rdr["Proveedor_RTN"].ToString();
            Identidad = rdr["Proveedor_Identidad"].ToString();
            Nombre = rdr["Proveedor_Nombre"].ToString();
            Encargado = rdr["Proveedor_Encargado"].ToString();
            Telefono = rdr["Proveedor_Telefono"].ToString();
            Correo = rdr["Proveedor_Correo"].ToString();
            Direccion = rdr["Proveedor_Direccion"].ToString();
            IDEstado = rdr["ID_Estado"].ToString();
            conexion.cerrar();

        }
    }
}
