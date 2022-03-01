using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Datos
{
    public class CD_Conexion
    {
        private readonly SqlConnection Conn = new SqlConnection("Data Source= RAMOS_C; initial catalog= BoddenRentals; integrated security=true");
    }
}


