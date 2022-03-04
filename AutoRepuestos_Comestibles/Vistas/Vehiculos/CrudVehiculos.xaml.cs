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
namespace AutoRepuestos_Comestibles.Vistas.Vehiculos
{
    /// <summary>
    /// Interaction logic for CrudVehiculos.xaml
    /// </summary>
    public partial class CrudVehiculos : Page
    {
        ClCmb cmb = new ClCmb();
        public CrudVehiculos()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbColor, "Colores", 1);
            cmb.fill_cmb(CmbMarca, "Marcas", 1);
            cmb.fill_cmb(CmbModelo, "Modelos", 1);
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Vehiculos();
        }
    }
}
