using AutoRepuestos_Comestibles.Clases;
using System.Data;
using System.Windows;
using System.Windows.Controls;
namespace AutoRepuestos_Comestibles.Vistas.Pedidos
{
    /// <summary>
    /// Lógica de interacción para Pedidos.xaml
    /// </summary>
    public partial class Pedidos : UserControl
    {/// <summary>
    /// instancia de clases
    /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
        public Pedidos()
        {
            InitializeComponent();
            CargarDG();
        }
        /// <summary>
        /// hace referencia a la clase vistas datagrid view, enviando texto y un objeto tipo datagrid
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("PedidosVista where Estado = 1", GridDatos);

        }
        /// <summary>
        /// Abre el formulario CrudPedidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarPedido_Click(object sender, RoutedEventArgs e)
        {
            CrudPedidos ventana = new CrudPedidos();
            FramePedidos.Content = ventana;
        }
        /// <summary>
        /// Hace referencia a la clase VistaDatagrid usando el metodo busqueda usando nombre, Fecha del Pedido, Encargado del Pedido
        /// </summary>
        /// <param name="texto">texto ingresado en la textbox de busqueda</param>
        void Buscar(string texto)
        {
            obj.Busqueda("PedidosVista", GridDatos, texto, "Proveedor", "[Fecha del Pedido]", "[Encargado del Pedido]");

        }
        /// <summary>
        /// llama la funcion buscar cada vez que ingresa una letra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }
        /// <summary>
        /// Permite seleccionar un objeto del datagrid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            if (view != null)
            {

                BtnEliminar.IsEnabled = true;
                valorID = view.Row.ItemArray[0].ToString();
            }
            else
            {

                BtnEliminar.IsEnabled = false;
            }
        }
        /// <summary>
        /// Se usa para eliminar una registro mediante un procedimiento almacenado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Pedidos", parametros, controlnames);
            valorID = "";


            BtnEliminar.IsEnabled = false;
            Content = new Pedidos();
        }


    }
}
