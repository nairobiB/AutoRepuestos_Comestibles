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
        String valorID;
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

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Vehiculos", parametros, controlnames);
            valorID = "";

            CargarDG();
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();
            //view.Row.Delete();
        }
    }
}
