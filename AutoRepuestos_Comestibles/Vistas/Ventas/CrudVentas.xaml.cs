using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
namespace AutoRepuestos_Comestibles.Vistas.Ventas
{
    /// <summary>
    /// Interaction logic for CrudVentas.xaml
    /// </summary>
    public partial class CrudVentas : Page
    {
        /// <summary>
        /// Instansias de clase y definicion de variable
        /// </summary>
        ClValidaciones val = new ClValidaciones();
        ClCmb cmb = new ClCmb();
        ClSeleccionVehiculo sel = new ClSeleccionVehiculo();
        ClInsercion obj = new ClInsercion();
        int tipoPago = 1;


        /// <summary>
        /// Rellenar el combobox
        /// </summary>
        public CrudVentas()
        {

            InitializeComponent();

            cmb.fill_cmb(CmbCliente, "Clientes", 1);
            cmb.fill_cmb(CmbInvisible, "Clientes", 0);
            cmb.fill_cmbVehiculo(CmbVehiculo, 0);
            DpFechFac.SelectedDate = DateTime.Now;
            TxtTotal.Text = "0";
            
           
        }
        /// <summary>
        /// Definicion de metodos
        /// </summary>
        public class Item
        {
            public string vehiculo { get; set; }
            public string descripcion { get; set; }
            public double precio { get; set; }
        }


        /// <summary>
        /// Regresa al formulario sin guardar cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Ventas();
        }

        int numFac;
        /// <summary>
        /// Boton que agrega el vehiculo con sus detalles para hacer una venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)    
        {
           sel.vehiculoVenta(CmbVehiculo.Text);

            CmbVehiculo.Items.Remove(CmbVehiculo.SelectedItem);
           
            GridDatos.Items.Add(new Item() {vehiculo= sel.Id_vehiculo, descripcion= sel.Descripcion, precio=sel.PrecioVenta});
            CmbVehiculo.SelectedIndex = 0;
            double total = 0;
            for (int i=0; i < GridDatos.Items.Count; i++)
            {
                GridDatos.SelectedIndex = i;
                view = (Item)GridDatos.SelectedItem;
                total += view.precio;

            }

            TxtTotal.Text=total.ToString();

        }
        /// <summary>
        /// Instancia de la clase
        /// </summary>
        Item view = new Item();

        /// <summary>
        /// Hacer seleccion de un registro y activa el boton para eliminar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            view = (Item)GridDatos.SelectedItem;
            BtnEliminar.IsEnabled = true;



        }

        /// <summary>
        /// Cambia el estado de una venta a falso para que ya no aparezca en la vista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Insercion de los detalles del venta por medio de procedimiento almacenado. 
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <param name="precio"></param>
        void insertarDetalles( string vehiculo, double precio)
        {
            dynamic[] parametros1 = { "@ID_Factura", "@ID_Vehiculo", "@Precio_Historico", "@Operacion"};
            dynamic[] controlnames1 = {numFac, vehiculo, precio, 4};
            obj.Insertar("Ins_DetallesVentas", parametros1, controlnames1);
        }
        /// <summary>
        /// Validaciones. Si cumple todos los requisitos se realiza la venta y guarda los detalles a la base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (GridDatos.Items.Count > 0)
            {
                #region Contenido
                int pago = 1;
                obj.num_factura();
                numFac = obj.Factura + 1;


                if (rbtnCash.IsChecked == true)
                {
                    pago = 1;
                }
                else if (rbtnTarjeta.IsChecked == true)
                {
                    pago = 2;
                }
                else
                {
                    pago = 3;
                }




                String forma_compra;

                if (rbtnContado.IsChecked == true)
                {
                    forma_compra = "Contado";
                }
                else
                {
                    forma_compra = "Credito";
                }

                int indice = CmbCliente.SelectedIndex;
                CmbInvisible.SelectedIndex = indice;

                dynamic[] parametros = { "@ID_Factura", "@ID_Cliente", "@ID_Empleado", "@ID_TipoPago", "@FormaCompra" };
                dynamic[] controlnames = { numFac, CmbInvisible.Text, "123", pago, forma_compra };
                obj.Insertar("Ins_FacturasVentas", parametros, controlnames);


                for (int i = 0; i < GridDatos.Items.Count; i++)
                {
                    GridDatos.SelectedIndex = i;
                    view = (Item)GridDatos.SelectedItem;
                    insertarDetalles(view.vehiculo, view.precio);

                }

                #endregion
                System.Windows.MessageBox.Show("Operacion Realizada exitosamente");
                Content = new Ventas();
            }
            else
            {
                val.mensajeError("Agregue vehiculo que desea vender al contenedor");
            }
        }
        /// <summary>
        /// Cambia el estado del tipo de pago si es seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnTranferencia_Checked(object sender, RoutedEventArgs e)
        {
            tipoPago = 3;
        }
        /// <summary>
        /// Cambia el estado del tipo de pago si es seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnTarjeta_Checked(object sender, RoutedEventArgs e)
        {
            tipoPago = 2;
        }
    }
}
