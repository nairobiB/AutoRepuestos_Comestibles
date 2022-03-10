using AutoRepuestos_Comestibles.Clases;
using System.Windows;
using System.Windows.Controls;
using System.Data;
namespace AutoRepuestos_Comestibles.Vistas.Rentas
{
    /// <summary>
    /// Lógica de interacción para Rentas.xaml
    /// </summary>
    public partial class Rentas : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
        public Rentas()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("RentasVista", GridDatos);

        }

        private void BtnAgregarRenta_Click(object sender, RoutedEventArgs e)
        {
            CrudRentas ventana = new CrudRentas();
            FrameRentas.Content = ventana;
        }

        void Buscar(string texto)
        {
            obj.Busqueda("RentasVista", GridDatos, texto, "Cliente", "Empleado", "Fecha");

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
