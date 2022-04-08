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
        /// <summary>
        /// Instancia de clases y definicion de variable valorID
        /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudVehiculos ventana = new CrudVehiculos();
        String valorID;
        ClSeleccionVehiculo vehiculo = new ClSeleccionVehiculo();
        /// <summary>
        /// Abre el formulario vehiculos y ejecuta funcion para cargar datos del datagridview
        /// </summary>
        public Vehiculos()
        {
            InitializeComponent();
            CargarDG();
        }
        /// <summary>
        /// Llenar datos del datagridview con datos que tengan estado en habilitado
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("VehiculosVista where Estado != 'Deshabilitado'", GridDatos);

        }
        /// <summary>
        /// Redirige al formulario de Crudvehiculos e iguala operacion a Insert para ejecutar el procedimiento
        /// insertar posteriormente si se guarda informacin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudVehiculos ventana = new CrudVehiculos();
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Insert";
        }
        /// <summary>
        /// Funcion para buscar dentro por medio de los parametros.
        /// </summary>
        /// <param name="texto"></param>
        void Buscar(string texto)
        {
            obj.Busqueda("VehiculosVista", GridDatos, texto, "Marca", "COlor", "Modelo");

        }
        /// <summary>
        /// llama a la funcion buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idvehiculo"></param>
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
        /// <summary>
        /// Elimina los datos de la lista pero no de la base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Vehiculos", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Vehiculos();
        }
        /// <summary>
        /// Si se selecciona un registro activa los botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            if (view != null)
            {   
                BtnModificar.IsEnabled = true;
                BtnEliminar.IsEnabled = true;
                valorID = view.Row.ItemArray[0].ToString();
                vehiculo.seleccionar(valorID);
            }
            else
            {

                BtnModificar.IsEnabled = false;
                BtnEliminar.IsEnabled = false;
            }

        }

        private void Image_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
        /// <summary>
        /// Modifica los datos por medio del procedimiento almacenado dependiendo y edita
        /// el registro seleccionado en el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
