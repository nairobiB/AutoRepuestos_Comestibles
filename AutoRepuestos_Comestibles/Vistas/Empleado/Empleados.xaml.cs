using System.Data;
using System.Windows;
using System.Windows.Controls;
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Empleado
{
    /// <summary>
    /// Interaction logic for Empleados.xaml
    /// </summary>
    public partial class Empleados : UserControl
    {
        string valorID;
        public Empleados()
        {
            InitializeComponent();
            CargarDG();
        }
        ClVistasDataGrid obj = new ClVistasDataGrid();
        void CargarDG()
        {
            obj.LlenarDG("EmpleadosVista", GridDatos);

        }

        void Buscar(string texto)
        {
            obj.Busqueda("EmpleadosVista", GridDatos, texto, "Identidad", "[Nombre del empleado]", "Puesto");

        }
        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudEmpleado ventana = new CrudEmpleado();
            FrameEmpleado.Content = ventana;

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
