using AutoRepuestos_Comestibles.Vistas.Empleado;
using System.Windows;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Vistas.Proveedores;
using AutoRepuestos_Comestibles.Vistas.Usuario;
using AutoRepuestos_Comestibles.Vistas.Vehiculos;
using AutoRepuestos_Comestibles.Vistas.Clientes;
using AutoRepuestos_Comestibles.Vistas.Ventas;
using AutoRepuestos_Comestibles.Vistas.Rentas;
using AutoRepuestos_Comestibles.Vistas.Pedidos;
using AutoRepuestos_Comestibles.Vistas.Retorno;
using AutoRepuestos_Comestibles.Clases;
using System.Windows.Controls;

namespace AutoRepuestos_Comestibles
{
    /// <summary>
    /// Interaction logic for MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        ClConexion conexion = new ClConexion();
        public MenuAdmin(string nombre)
        {
            InitializeComponent();
            Nombre.Text = nombre;
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
            Application.Current.Shutdown();
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

        private void btnVenta_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Ventas();
        }

        private void btnRenta_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Rentas();
        }

        private void btnPedidos_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Pedidos();
        }

        private void btnRetorno_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Retornos();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conexion.abrir();
        }
    }
}
