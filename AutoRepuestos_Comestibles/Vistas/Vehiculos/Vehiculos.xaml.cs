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

namespace AutoRepuestos_Comestibles.Vistas.Vehiculos
{
    /// <summary>
    /// Interaction logic for Vehiculos.xaml
    /// </summary>
    public partial class Vehiculos : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        public Vehiculos()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("VehiculosVista", GridDatos);

        }
        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudVehiculos ventana = new CrudVehiculos();
            FrameEmpleado.Content = ventana;
        }

        void Buscar(string texto)
        {
            obj.Busqueda("VehiculosVista", GridDatos, texto, "Marca", "COlor", "Modelo");

        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }
    }
}
