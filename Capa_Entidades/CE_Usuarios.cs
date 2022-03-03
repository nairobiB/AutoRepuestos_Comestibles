using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class CE_Usuarios
    {
        private int _Id_Usuario;
        private string _Usuario_Nombre;
        private string _Pass;
        private string _Id_Empleado;
        private bool _estado;
        private string _Puesto;

        public int Id_Usuario { get => _Id_Usuario; set => _Id_Usuario = value; }
        public string Usuario_Nombre { get => _Usuario_Nombre; set => _Usuario_Nombre = value; }
        public string Pass { get => _Pass; set => _Pass = value; }
        public string Id_Empleado { get => _Id_Empleado; set => _Id_Empleado = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string Puesto { get => _Puesto; set => _Puesto = value; }
    }
}
