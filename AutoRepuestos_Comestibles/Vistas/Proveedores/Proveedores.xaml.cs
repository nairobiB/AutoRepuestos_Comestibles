using System.Windows.Controls;
using AutoRepuestos_Comestibles.Clases;
using System.Data;
namespace AutoRepuestos_Comestibles.Vistas.Proveedores
{
    /// <summary>
    /// Interaction logic for Proveedores.xaml
    /// </summary>
    public partial class Proveedores : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
        public Proveedores()
        {
            InitializeComponent();
            CargarDG();

        }
        void CargarDG()
        {
            obj.LlenarDG("ProveedoresVista", GridDatos);

        }

        void Buscar(string texto)
        {
            obj.Busqueda("ProveedoresVista", GridDatos, texto, "RTN", "Nombre", "Identidad");

        }

        private void BtnAgregarProveedor_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CrudProveedores ventana = new CrudProveedores();
            FrameProveedor.Content = ventana;
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
