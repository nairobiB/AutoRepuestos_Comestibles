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
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Pedidos
{
    /// <summary>
    /// Lógica de interacción para CrudPedidos.xaml
    /// </summary>
    public partial class CrudPedidos : Page
    {
        ClCmb cmb = new ClCmb();
        public CrudPedidos()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbProveedor, "Proveedores", 3);
            cmb.fill_cmb(CmbVehiculo, "Vehiculos", 0);
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Pedidos();
        }
    }
}
