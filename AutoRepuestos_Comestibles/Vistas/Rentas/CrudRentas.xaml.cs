using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Clases;
namespace AutoRepuestos_Comestibles.Vistas.Rentas
{
    /// <summary>
    /// Lógica de interacción para CrudRentas.xaml
    /// </summary>
    public partial class CrudRentas : Page
    {
        /// <summary>
        /// Instancias de clases
        /// </summary>
        ClCmb cmb = new ClCmb();
        ClSeleccionVehiculo sel = new ClSeleccionVehiculo();
        ClValidaciones val = new ClValidaciones();
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
        /// <summary>
        /// Encapsulacion
        /// </summary>
        public class Item
        {
            public string vehiculo { get; set; }
            public string descripcion { get; set; }
            public double precio { get; set; }
        }

        Item view = new Item();
        /// <summary>
        /// Agrega vehiculo al datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (CmbVehiculo.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("No hay vehiculos disponibles");
            }
            else 
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


        }
        /// <summary>
        /// Selecciona fila en datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            view = (Item)GridDatos.SelectedItem;
            BtnEliminar.IsEnabled = true;
        }
        /// <summary>
        /// Elimina registro del datagrid
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
        /// Inserta un vehiculo al datagrid
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <param name="precio"></param>
        void insertarDetalles(string vehiculo, double precio)
        {
            dynamic[] parametros1 = { "@ID_Factura", "@ID_Vehiculo", "@Precio_Historico", "@Operacion" };
            dynamic[] controlnames1 = { numFac, vehiculo, precio, 2 };
            obj.Insertar("Ins_DetallesRentas", parametros1, controlnames1);
        }
        /// <summary>
        /// Confirma la rtenta y agrega el registro a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            


            if (TxtTiempo.Text.Length > 0 && TxtTiempo.Text != "0")
            {

                if (GridDatos.Items.Count < 1)
                {
                    val.mensajeError("Agregue al menos un vehiculo a rentar");
                }
                else
                {
                    int indice = CmbCliente.SelectedIndex;
                    CmbInvisible.SelectedIndex = indice;

                    dynamic[] parametros = { "@ID_Factura", "@ID_Cliente", "@ID_Empleado", "@ID_TipoPago", "@horas", "@Comprobante" };
                    dynamic[] controlnames = { numFac, CmbInvisible.Text, "123", pago, TxtTiempo.Text, deposito };
                    obj.Insertar("Ins_FacturasRentas", parametros, controlnames);


                    for (int i = 0; i < GridDatos.Items.Count; i++)
                    {
                        GridDatos.SelectedIndex = i;
                        view = (Item)GridDatos.SelectedItem;
                        insertarDetalles(view.vehiculo, view.precio);

                    }
                    System.Windows.MessageBox.Show("Renta guardada exitosamente");
                    Content = new Rentas();
                }
            }
            else 
            {
                val.mensajeError("Ingrese un tiempo de renta");
            }
            
               
            
        }

        private void TxtTiempo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }
    }
}
