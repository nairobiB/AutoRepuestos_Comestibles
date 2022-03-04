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
namespace AutoRepuestos_Comestibles.Vistas.Ventas
{
    /// <summary>
    /// Interaction logic for CrudVentas.xaml
    /// </summary>
    public partial class CrudVentas : Page
    {
        ClCmb cmb = new ClCmb();
        public CrudVentas()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbCliente, "Clientes", 1);
            cmb.fill_cmb(CmbVehiculo, "Vehiculos", 0);
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Ventas();
        }
    }
}
