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
namespace AutoRepuestos_Comestibles.Vistas.Rentas
{
    /// <summary>
    /// Lógica de interacción para CrudRentas.xaml
    /// </summary>
    public partial class CrudRentas : Page
    {

        ClCmb cmb = new ClCmb();
        public CrudRentas()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbCliente,"Clientes", 1);
            cmb.fill_cmb(CmbVehiculo, "Vehiculos", 0);
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Rentas();
        }
    }
}
