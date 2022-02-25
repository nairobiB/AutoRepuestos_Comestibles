using System.Windows;
using System.Windows.Controls;

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
        }

        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudEmpleado ventana = new CrudEmpleado();
            FrameEmpleado.Content = ventana;

        }
    }
}
