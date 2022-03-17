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
using System.Data;
namespace AutoRepuestos_Comestibles.Vistas.Ventas
{
    /// <summary>
    /// Interaction logic for Ventas.xaml
    /// </summary>
    public partial class Ventas : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
       
        public Ventas()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("VentasVista where Estado = 1", GridDatos);

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

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Facturas", parametros, controlnames);
            valorID = "";

            //CargarDG();
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
        }
    }
}
