using AutoRepuestos_Comestibles.Clases;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace AutoRepuestos_Comestibles.Vistas.Vehiculos
{
    /// <summary>
    /// Interaction logic for Vehiculos.xaml
    /// </summary>
    public partial class Vehiculos : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudVehiculos ventana = new CrudVehiculos();
        String valorID;
        ClSeleccionVehiculo vehiculo = new ClSeleccionVehiculo();
        public Vehiculos()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("VehiculosVista where Estado != 'Deshabilitado'", GridDatos);

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
        void llenarCampos(string idvehiculo)
        {
            vehiculo.seleccionar(idvehiculo);

            ventana.TxtIdVehiculo.Text = vehiculo.Id_vehiculo;
            ventana.TxtVenta.Text = vehiculo.PrecioVenta.ToString();
            ventana.TxtRenta.Text = vehiculo.Preciorenta.ToString();

            ventana.CmbColor.SelectedIndex = vehiculo.Color - 1;
            ventana.CmbMarca.SelectedIndex = vehiculo.Marca - 1;
            ventana.CmbModelo.SelectedIndex = vehiculo.Modelo - 1;
            ventana.CmbEstado.SelectedIndex = vehiculo.Estado - 1;

        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Vehiculos", parametros, controlnames);
            valorID = "";

            //CargarDG();
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();

            vehiculo.seleccionar(valorID);
        }

        private void Image_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

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
