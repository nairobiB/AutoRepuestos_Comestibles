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
            obj.LlenarDG("PedidosVista where Estado = 1", GridDatos);

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
            

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            if (view != null)
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

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Pedidos", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Pedidos();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            ReportePedidos repPed = new ReportePedidos();
            repPed.Factura = valorID;
            repPed.Show();
        }
    }
}
