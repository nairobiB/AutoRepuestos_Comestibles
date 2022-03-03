using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class CN_Combobox
    {
        private readonly CD_Combobox objDatos = new CD_Combobox();

        #region ID
        public void Cmb_EmpleadosId(String Nombre)
        {
            objDatos.CMB_EMPLEADOSID(Nombre);
        }

        #endregion

        #region Nombre
        public void Cmb_EmpleadosNombre(String Id)
        {
            objDatos.CMB_EMPLEADOSNOMBRE(Id);
        }

        #endregion

        #region Lista
        public List<String> ListarPrivilegios()
        {
            return objDatos.cargarEmpleados();
        }

        #endregion


    }
}
