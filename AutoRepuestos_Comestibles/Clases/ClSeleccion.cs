using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    

namespace AutoRepuestos_Comestibles.Clases
{
    class ClSeleccion
    {
        ClConexion conexion = new ClConexion();

        private string _id;
        private string _nombre;
        private string _Telefono;
        private string _Correo;
        private string _FechaNac;
        private string _IDEstado;

        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string IDEstado { get => _IDEstado; set => _IDEstado = value; }

        public void seleccionar(string idCliente)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select * from Clientes where ID_Cliente =  '" + idCliente + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id = rdr["ID_Cliente"].ToString();
            Nombre = rdr["Cliente_Nombre"].ToString();
            Telefono = rdr["Cliente_Telefono"].ToString();
            Correo = rdr["Cliente_Correo"].ToString();
            FechaNac = rdr["Cliente_FechaNac"].ToString();
            IDEstado = rdr["ID_Estado"].ToString();
            conexion.cerrar();

        }

        public void eliminar(string idCliente)
        {

        }

    }
}
