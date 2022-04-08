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

namespace AutoRepuestos_Comestibles.Vistas.Clientes
{
    /// <summary>
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        /// <summary>
        /// Instranci de clase
        /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudClientes ventana = new CrudClientes();
        ClSeleccion cli = new ClSeleccion();
        String valorID;
        string Estado;

        public Clientes()
        {
            InitializeComponent();
            CargarDG();
        }
         /// <summary>
         /// cargar datos almacenados en la base de datos datagridview
         /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("ClientesVista", GridDatos);

        }
        /// <summary>
        /// Abrir CrudClients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {

            FrameCliente.Content = ventana;
            ventana.Operacion = "Insert";
        }
        /// <summary>
        /// Realiza búsqueda de datos en el datagrid
        /// </summary>
        /// <param name="texto"></param>
        void Buscar(string texto)
        {
            obj.Busqueda("ClientesVista", GridDatos, texto, "Identidad", "[Nombre del Cliente]", "Correo");

        }

        /// <summary>
        /// Realizar busqueda de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> texto ingresado</param>
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }

        /// <summary>
        /// LLena campos de la ventana CrudClientes
        /// </summary>
        /// <param name="identidad">Identidad del cliente que desea modificar</param>
        void llenarcampos(string identidad)
        {
            cli.seleccionar(identidad);

            ventana.TxtIdCliente.Text = cli.Id;
            ventana.TxtNombre.Text = cli.Nombre;
            ventana.TxtTelefono.Text = cli.Telefono;
            ventana.TxtCorreo.Text = cli.Correo;
            ventana.TxtFechNac.Text = cli.FechaNac;
            ventana.TxtNombre.Text = cli.Nombre;

            if (Estado == "False")
            {
                ventana.rbtnInActivo.IsChecked = true;
            }


        }

        /// <summary>
        /// Abre la ventana de CrudClientes con los campos llenados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click_1(object sender, RoutedEventArgs e)
        {
            llenarcampos(valorID);
            FrameCliente.Content = ventana;
            ventana.Operacion = "Update";
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
                Estado = view.Row.ItemArray[5].ToString();
            }
            else
            {
                BtnModificar.IsEnabled = false;
                BtnEliminar.IsEnabled = false;
            }
            
        }
        /// <summary>
        /// Se elimina el registro de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = {"@ID"};
            dynamic[] controlnames = {valorID};

            obj.Insertar("Del_Clientes", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Clientes();
        }
    }
}
