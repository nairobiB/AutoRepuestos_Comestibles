using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoRepuestos_Comestibles.Vistas.Usuario;
using Capa_Datos;
using Capa_Entidades;
using Capa_Negocios;

namespace AutoRepuestos_Comestibles.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for CrudUsuarios.xaml
    /// </summary>
    public partial class CrudUsuarios : Page
    {
        readonly CN_Usuarios Obj_CN_usuario = new CN_Usuarios();
        readonly CE_Usuarios obj_CE_Usuarios = new CE_Usuarios();
        readonly CN_Combobox Obj_CN_Combobox = new CN_Combobox();
        readonly CE_combobox Obj_CE_Combobox = new CE_combobox();

        String IdEmpleado;
        public CrudUsuarios()
            {
                InitializeComponent();
                Cargar_Combobox();           

            }

        public int IdUsuario;

        #region Cargar Combobox
        void Cargar_Combobox()
        {
            List<String> Empleados = Obj_CN_Combobox.ListarPrivilegios();
            for(int i=0; i<Empleados.Count; i++)
            {
                CmbEmpleado.Items.Add(Empleados[i]);
            }
           
       

        }
        #endregion



        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (TxtIdentidad.Text == "" || TxtNombre.Text == "")
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        #endregion







        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
    }
}
