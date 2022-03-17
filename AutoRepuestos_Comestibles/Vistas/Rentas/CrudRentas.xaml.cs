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
using AutoRepuestos_Comestibles.Clases;
namespace AutoRepuestos_Comestibles.Vistas.Rentas
{
    /// <summary>
    /// Lógica de interacción para CrudRentas.xaml
    /// </summary>
    public partial class CrudRentas : Page
    {

        ClCmb cmb = new ClCmb();
        ClSeleccionVehiculo sel = new ClSeleccionVehiculo();

        ClInsercion obj = new ClInsercion();
        int numFac;

        public CrudRentas()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbCliente, "Clientes", 1);
            cmb.fill_cmb(CmbInvisible, "Clientes", 0);
            cmb.fill_cmbVehiculo(CmbVehiculo, 0);
            DpFechFac.SelectedDate = DateTime.Now;
            TxtTotal.Text = "0";
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Rentas();
        }

        public class Item
        {
            public string vehiculo { get; set; }
            public string descripcion { get; set; }
            public double precio { get; set; }
        }

        Item view = new Item();

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            sel.vehiculoRenta(CmbVehiculo.Text);

            CmbVehiculo.Items.Remove(CmbVehiculo.SelectedItem);

            GridDatos.Items.Add(new Item() { vehiculo = sel.Id_vehiculo, descripcion = sel.Descripcion, precio = sel.Preciorenta });
            CmbVehiculo.SelectedIndex = 0;
            double total = 0;
            for (int i = 0; i < GridDatos.Items.Count; i++)
            {
                GridDatos.SelectedIndex = i;
                view = (Item)GridDatos.SelectedItem;
                total += view.precio;

            }

            TxtTotal.Text = total.ToString();

        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            view = (Item)GridDatos.SelectedItem;
            BtnEliminar.IsEnabled = true;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BtnEliminar.IsEnabled = false;
            CmbVehiculo.Items.Add(view.vehiculo);
            GridDatos.Items.Remove(view);
            double total = 0;
            for (int i = 0; i < GridDatos.Items.Count; i++)
            {
                GridDatos.SelectedIndex = i;
                view = (Item)GridDatos.SelectedItem;
                total += view.precio;
            }

            TxtTotal.Text = total.ToString();

        }

        void insertarDetalles(string vehiculo, double precio)
        {
            dynamic[] parametros1 = { "@ID_Factura", "@ID_Vehiculo", "@Precio_Historico", "@Operacion" };
            dynamic[] controlnames1 = { numFac, vehiculo, precio, 2 };
            obj.Insertar("Ins_DetallesRentas", parametros1, controlnames1);
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            int pago = 1;
            string deposito = "Identidad";
            obj.num_factura();
            numFac = obj.Factura + 1;


            if (rbtnCash.IsChecked == true)
            {
                pago = 1;
            }
            else if (rbtnTarjera.IsChecked == true)
            {
                pago = 2;
            }
            else
            {
                pago = 3;
            }


            if (rbtnTarjera.IsChecked == true)
            {
                deposito = "Tarjeta";
            }
            else if (rbtnTranferencia.IsChecked == true)
            {
                deposito = "Transferencia";
            }

            int indice = CmbCliente.SelectedIndex;
            CmbInvisible.SelectedIndex = indice;

            dynamic[] parametros = { "@ID_Factura", "@ID_Cliente", "@ID_Empleado","@ID_TipoPago", "@horas", "@Comprobante" };
            dynamic[] controlnames = { numFac, CmbInvisible.Text, "123", pago, TxtTiempo.Text, deposito};
            obj.Insertar("Ins_FacturasRentas", parametros, controlnames);


            for (int i = 0; i < GridDatos.Items.Count; i++)
            {
                GridDatos.SelectedIndex = i;
                view = (Item)GridDatos.SelectedItem;
                insertarDetalles(view.vehiculo, view.precio);

            }
        }
    }
}
