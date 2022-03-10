using System.Windows;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Vistas.Vehiculos;
using AutoRepuestos_Comestibles.Vistas.Clientes;
using AutoRepuestos_Comestibles.Vistas.Ventas;
using AutoRepuestos_Comestibles.Vistas.Rentas;
using AutoRepuestos_Comestibles.Vistas.Retorno;
using System.Windows.Controls;

namespace AutoRepuestos_Comestibles
{
    /// <summary>
    /// Interaction logic for MenuAgente.xaml
    /// </summary>
    public partial class MenuAgente : Window
    {
        public MenuAgente(string nombre)
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

        private void btnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            Vehiculos vehiculo = new Vehiculos();
            vehiculo.GridDatos.IsEnabled = false;
            DataContext = vehiculo;
            
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

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnRetorno_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Retornos();
        }
    }
}
