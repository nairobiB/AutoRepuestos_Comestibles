using AutoRepuestos_Comestibles.Vistas.Empleado;
using System.Windows;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Vistas.Proveedores;
using AutoRepuestos_Comestibles.Vistas.Usuario;
using AutoRepuestos_Comestibles.Vistas.Vehiculos;
using AutoRepuestos_Comestibles.Vistas.Clientes;

namespace AutoRepuestos_Comestibles
{
    /// <summary>
    /// Interaction logic for MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void TBShow(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 0.5;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;
        }

        private void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BtnShowHide.IsChecked = false;
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Empleados();
        }

        private void btnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Vehiculos();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Usuarios();
        }

        private void btnProveedores_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Proveedores();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Clientes();
        }
    }
}
