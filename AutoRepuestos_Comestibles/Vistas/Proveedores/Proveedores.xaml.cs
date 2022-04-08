using System.Windows.Controls;
using System.Windows;
using AutoRepuestos_Comestibles.Clases;
using System.Data;
using System;
namespace AutoRepuestos_Comestibles.Vistas.Proveedores
{
    /// <summary>
    /// Interaction logic for Proveedores.xaml
    /// </summary>
    public partial class Proveedores : UserControl
    {
        /// <summary>
        /// INstancias de clases
        /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudProveedores ventana = new CrudProveedores();
        ClSeleccionProveeedor prov = new ClSeleccionProveeedor();
        String valorID;
        string Estado;
       
        public Proveedores()
        {
            InitializeComponent();
            CargarDG();

        }
        /// <summary>
        /// cargar datos almacenados en la base de datos datagridview
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("ProveedoresVista where Estado = 1", GridDatos);

        }
        /// <summary>
        /// Realiza búsqueda de datos en el datagrid
        /// </summary>
        /// <param name="texto"></param>
        void Buscar(string texto)
        {
            obj.Busqueda("ProveedoresVista", GridDatos, texto, "RTN", "Nombre", "Identidad");

        }
        /// <summary>
        /// LLena campos de la ventana CrudClientes
        /// </summary>
        /// <param name="identidad">Identidad del cliente que desea modificar</param>

        void llenarcampos(string identidad)
        {
            prov.seleccionar(identidad);
                       
            ventana.TxtRTN.Text = prov.Rtn;
            ventana.TxtIdentidad.Text = prov.Identidad;
            ventana.TxtNombre.Text = prov.Nombre;
            ventana.TxtEncargado.Text = prov.Encargado;
            ventana.TxtTelefono.Text = prov.Telefono;
            ventana.TxtCorreo.Text = prov.Correo;
            ventana.TxtDireccion.Text = prov.Direccion;

            if (Estado == "False")
            {
                ventana.rbtnInActivo.IsChecked = true;
            }


        }
        /// <summary>
        /// Abrir Crud'Proveedores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarProveedor_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CrudProveedores ventana = new CrudProveedores();
            FrameProveedor.Content = ventana;
            ventana.Operacion = "Insert";
        }
        /// <summary>
        /// Realizar busqueda de proveedores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> texto ingresado</param>

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }

        /// <summary>
        /// cuando selesccione una fila se guarda valores de un registro de la base datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            if(view != null)
            {
                BtnModificar.IsEnabled = true;
                BtnEliminar.IsEnabled = true;
                valorID = view.Row.ItemArray[0].ToString();
                Estado = view.Row.ItemArray[8].ToString();
            }
            
        }
        /// <summary>
        /// Abre la ventana de CrudProveedores con los campos llenados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ventana.Id =Convert.ToInt32(valorID);
            llenarcampos(valorID);
            FrameProveedor.Content = ventana;
            ventana.Operacion = "Update";
            prov.seleccionar(valorID);
        }
        /// <summary>
        /// Se elimina el registro de proveedores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Proveedores", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Proveedores();
        }
    }
}
