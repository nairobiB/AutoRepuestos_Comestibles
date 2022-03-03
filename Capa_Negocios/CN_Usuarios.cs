using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios();

        #region Insertar
        public CE_Usuarios Consultar(int idUsuario)
        {
            return objDatos.Consultar(idUsuario);
        }
        #endregion


        #region Insertar
        public void Insertar(CE_Usuarios Usuarios)
        {
            objDatos.Insertar(Usuarios);
        }
        #endregion

        #region Modificar
        public void Modificar(CE_Usuarios Usuarios)
        {
            objDatos.Modificar(Usuarios);
        }
        #endregion


       public void Cargar()
        {
            objDatos.cargar();
        }
    }
}
