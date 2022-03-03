using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class CE_combobox
    {
        private string _IdEmpleado;
        private string _NombreEmpleado;

        public string IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public string NombreEmpleado { get => _NombreEmpleado; set => _NombreEmpleado = value; }

    }
}
