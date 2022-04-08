using System;
using System.Windows;
using System.Windows.Controls;
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Pedidos
{
    /// <summary>
    /// Lógica de interacción para CrudPedidos.xaml
    /// </summary>
    public partial class CrudPedidos : Page
    {
        /// <summary>
        /// Intancia de clases
        /// </summary>
        ClSeleccionVehiculo sel = new ClSeleccionVehiculo();
        ClInsercion obj = new ClInsercion();
        ClCmb cmb = new ClCmb();
        ClValidaciones val = new ClValidaciones();

        /// <summary>
        /// Evento Load
        /// </summary>
        public CrudPedidos()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbProveedor, "Proveedores", 3);

            cmb.fill_cmbVehiculo(CmbVehiculo, 0);
            DpFechPedido.SelectedDate = DateTime.Now;
        }

        /// <summary>
        /// clase Item que se usaran para guardar en el datagridview
        /// </summary>
        public class Item
        {
            public string vehiculo { get; set; }
            public string descripcion { get; set; }
            public double precio { get; set; }
        }
        Item view = new Item();

        int numPedido;

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Pedidos();
        }


        /// <summary>
        /// Evento Click en agregar realizara una addicion de un objeto de tipo item a el datagridviwe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            sel.vehiculoVenta(CmbVehiculo.Text);

            CmbVehiculo.Items.Remove(CmbVehiculo.SelectedItem);

            GridDatos.Items.Add(new Item() { vehiculo = sel.Id_vehiculo, descripcion = sel.Descripcion, precio = sel.PrecioVenta });

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
        /// <summary>
        /// Elimina el objeto de tipo que esta seleccionado item del datagrid
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
        /// Seleccionar un objeto de tipo item del datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            view = (Item)GridDatos.SelectedItem;
            BtnEliminar.IsEnabled = true;
        }
        /// <summary>
        /// se usa la clase de ClInsercion para enviar valores y parametros a un procedimiento almacenado llamado Ins_PedidosDetalles
        /// </summary>
        /// <param name="vehiculo">Se recibe del objeto de tipo ITEM </param>
        /// <param name="precio"> Se recibe del objeto de tipo ITEM </param>
        void insertarDetalles(string vehiculo, double precio)
        {
            dynamic[] parametros1 = { "@ID_Factura", "@ID_Vehiculo", "@Precio"};
            dynamic[] controlnames1 = { numPedido, vehiculo, precio, 1 };
            obj.Insertar("Ins_PedidosDetalles", parametros1, controlnames1);
        }
        /// <summary>
        /// Realiza las acciones agregar registro a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            obj.num_pedido();
            numPedido = obj.Pedido + 1;
            int forma_pago;
            string formacompra;

            if (rbtnCash.IsChecked == true)
            {
                forma_pago = 1;
            }
            else if (rbtnTarjeta.IsChecked == true)
            {
                forma_pago = 2;
            }
            else
            {
                forma_pago = 3;
            }

            if (rbtnCredito.IsChecked == true)
            {
                formacompra = "Credito";
            }
            else
            {
                formacompra = "Contado";
            }


            int indice = CmbProveedor.SelectedIndex + 1;

            if (GridDatos.Items.Count < 1)
            {
                val.mensajeError("Añada al menos un vehiculo a Rentar");
                CmbVehiculo.Focus();
            }
            else
            {
                 dynamic[] parametros = { "@ID_Factura", "@ID_Proveedor", "@ID_Empleado", "@ID_TipoPago", "@TipoCompra" };
                 dynamic[] controlnames = { numPedido, indice, "123",forma_pago, formacompra };
                 obj.Insertar("Ins_Pedidos", parametros, controlnames);
            
                for (int i = 0; i < GridDatos.Items.Count; i++)
                {
                    GridDatos.SelectedIndex = i;
                    view = (Item)GridDatos.SelectedItem;
                    insertarDetalles(view.vehiculo, view.precio);
                }
                System.Windows.MessageBox.Show("Pedido guardado exitosamente");
                Content = new Pedidos();
            }
            


        }

    }
}
