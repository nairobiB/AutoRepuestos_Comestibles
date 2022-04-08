using AutoRepuestos_Comestibles.Clases;
using System.Windows;
using System.Windows.Controls;
using System.Data;
namespace AutoRepuestos_Comestibles.Vistas.Ventas
{
    /// <summary>
    /// Interaction logic for Ventas.xaml
    /// </summary>
    public partial class Ventas : UserControl
    {
        /// <summary>
        /// Instansia de clase y definicion de variable.
        /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
       /// <summary>
       /// Inicia el formulario y carga los datos del datagrid.
       /// </summary>
        public Ventas()
        {
            InitializeComponent();
            CargarDG();
        }
        /// <summary>
        /// Funcion para cargar datos del grid
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("VentasVista where Estado = 1", GridDatos);

        }
        /// <summary>
        /// Funcion para hacer busqueda de registros por medio del nombre del cliente, empleado o tipo de pago.
        /// </summary>
        /// <param name="texto"></param>
        void Buscar(string texto)
        {
            obj.Busqueda("VentasVista", GridDatos, texto, "Cliente", "Empleado", "[Tipo de pago]");

        }

        /// <summary>
        /// Agrega los detalles de la venta al datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarVenta_Click(object sender, RoutedEventArgs e)
        {
            CrudVentas ventana = new CrudVentas();
            FrameVentas.Content = ventana;
        }
        /// <summary>
        /// Llama a la funcion buscar y la ejecuta. Busca los datos por medio de parametros establecidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            Buscar(TxtBuscar.Text);
         
        }
        /// <summary>
        /// Activa los botones seleccionando el registro. Si no no se activan los botones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            if(view != null)
            {
                BtnModificar.IsEnabled = true;
                BtnEliminar.IsEnabled = true;
                valorID = view.Row.ItemArray[0].ToString();
            }
            else
            {
                BtnModificar.IsEnabled = false;
                BtnEliminar.IsEnabled = false;

            }
            
        }
        /// <summary>
        /// Cambia el estado de la venta para que no aparzeca en la lista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Facturas", parametros, controlnames);
            valorID = "";
            CargarDG();
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Ventas();
        }
        /// <summary>
        /// Permite generar la factura abriendo una pestaña de report builder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            ReporteVentas repVen = new ReporteVentas();
            repVen.Factura = valorID;
            repVen.Show();
        }
    }
}
