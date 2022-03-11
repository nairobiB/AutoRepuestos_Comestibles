using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AutoRepuestos_Comestibles.Clases
{
    class ClSeleccionUsuario
    {
        ClConexion conexion = new ClConexion();

        private string _id;
        private string _nombre;
        private string _contra;
        private string _idemp;
        private string _IDEstado;

        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Contra { get => _contra; set => _contra = value; }
        public string Idemp { get => _idemp; set => _idemp = value; }
        public string IDEstado { get => _IDEstado; set => _IDEstado = value; }

        public void seleccionar(string idUsuario)
        {
            conexion.abrir();
            SqlCommand com = new SqlCommand("select * from Usuarios where ID_Usuario =  '" + idUsuario + "' ", conexion.Sc);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            Id = rdr["ID_Usuario"].ToString();
            Nombre = rdr["Usuario_Nombre"].ToString();
            Contra = rdr["Usuario_Contraseña"].ToString();
            Idemp = rdr["FK_ID_Empleado"].ToString();
            IDEstado = rdr["Usuario_Estado"].ToString();
            conexion.cerrar();

        }
    }
}
