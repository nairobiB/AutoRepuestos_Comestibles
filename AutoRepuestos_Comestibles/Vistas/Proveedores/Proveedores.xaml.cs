using System.Windows.Controls;
using AutoRepuestos_Comestibles.Clases;
using AutoRepuestos_Comestibles.Vistas.Proveedores;

namespace AutoRepuestos_Comestibles.Vistas.Proveedores
{
    /// <summary>
    /// Interaction logic for Proveedores.xaml
    /// </summary>
    public partial class Proveedores : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();

        public Proveedores()
        {
            InitializeComponent();
            CargarDG();

        }
        void CargarDG()
        {
            obj.LlenarDG("ProveedoresVista", GridDatos);

        }

        private void BtnAgregarProveedor_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CrudProveedores ventana = new CrudProveedores();
            FrameProveedor.Content = ventana;
        }
    }
}
