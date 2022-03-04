using AutoRepuestos_Comestibles.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoRepuestos_Comestibles.Vistas.Ventas
{
    /// <summary>
    /// Interaction logic for Ventas.xaml
    /// </summary>
    public partial class Ventas : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        public Ventas()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("VentasVista", GridDatos);

        }

        void Buscar(string texto)
        {
            obj.Busqueda("VentasVista", GridDatos, texto, "Cliente", "Empleado", "[Tipo de pago]");

        }


        private void BtnAgregarVenta_Click(object sender, RoutedEventArgs e)
        {
            CrudVentas ventana = new CrudVentas();
            FrameVentas.Content = ventana;
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }
    }
}
