using AutoRepuestos_Comestibles.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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
        CrudVehiculos ventana = new CrudVehiculos();
        ClSeleccionVehiculo vehiculo = new ClSeleccionVehiculo();
        String valorID;
        string Estado;
        string Color;
        string marca;
        string modelo;
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
            ventana.Operacion = "Insert";

        }

        void llenarCampos(string idvehiculo)
        {
            vehiculo.seleccionar(idvehiculo);

            ventana.TxtIdVehiculo.Text = vehiculo.Id_vehiculo;
            ventana.TxtVenta.Text = vehiculo.PrecioVenta.ToString();
            ventana.TxtRenta.Text = vehiculo.Preciorenta.ToString();

            ventana.CmbColor.SelectedIndex = vehiculo.Color - 1;
            ventana.CmbMarca.SelectedIndex = vehiculo.Marca - 1;
            ventana.CmbModelo.SelectedIndex = vehiculo.Modelo - 1;
            ventana.CmbEstado.SelectedIndex = 0;
            
        }

        void Buscar(string texto)
        {
            obj.Busqueda("VehiculosVista", GridDatos, texto, "Marca", "Color", "Modelo");

        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;


            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();

            vehiculo.seleccionar(valorID);

            
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            llenarCampos(valorID);
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Update";            
        }
    }
}
