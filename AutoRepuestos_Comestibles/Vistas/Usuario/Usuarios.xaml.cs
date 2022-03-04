using AutoRepuestos_Comestibles.Clases;
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

namespace AutoRepuestos_Comestibles.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        public Usuarios()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("UsuariosVista", GridDatos);

        }


        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudUsuarios ventana = new CrudUsuarios();
            FrameEmpleado.Content = ventana;
        }

        void Buscar(string texto)
        {
            obj.Busqueda("UsuariosVista", GridDatos, texto, "Usuario", "[Nombre del Empleado]", "Rol");

        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }
    }
}
