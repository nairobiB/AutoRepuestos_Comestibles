using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AutoRepuestos_Comestibles.Clases
{
    class ClSeleccionEmpleado
    {
        ClConexion conexion = new ClConexion();

        private string _id;
        private string _nombre;
        private string _Telefono;
        private string _Correo;
        private string _FechaNac;
        private string _IDPuesto;
        private string _IDEstado;

        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string IDPuesto { get => _IDPuesto; set => _IDPuesto = value; }
        public string IDEstado { get => _IDEstado; set => _IDEstado = value; }

        public void seleccionar(string idEmpleado)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select * from Empleados where ID_Empleado =  '" + idEmpleado + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id = rdr["ID_Empleado"].ToString();
            Nombre = rdr["Empleado_Nombre"].ToString();
            Telefono = rdr["Empleado_Telefono"].ToString();
            Correo = rdr["Empleado_Correo"].ToString();
            FechaNac = rdr["Empleado_FechaNac"].ToString();
            IDPuesto = rdr["FK_ID_Puestos"].ToString();
            IDEstado = rdr["ID_Estado"].ToString();
            conexion.cerrar();

        }
    }
}
