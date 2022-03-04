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

        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudEmpleado ventana = new CrudEmpleado();
            FrameEmpleado.Content = ventana;

        }
    }
}
