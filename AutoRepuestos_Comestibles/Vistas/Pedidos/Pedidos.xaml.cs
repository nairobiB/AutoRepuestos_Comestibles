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
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
        public Pedidos()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("PedidosVista", GridDatos);

        }
        private void BtnAgregarPedido_Click(object sender, RoutedEventArgs e)
        {
            CrudPedidos ventana = new CrudPedidos();
            FramePedidos.Content = ventana;
        }
        void Buscar(string texto)
        {
            obj.Busqueda("PedidosVista", GridDatos, texto, "Proveedor", "[Fecha del Pedido]", "[Encargado del Pedido]");

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
        }
    }
}
