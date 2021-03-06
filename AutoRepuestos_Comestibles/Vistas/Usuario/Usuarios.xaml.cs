using AutoRepuestos_Comestibles.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace AutoRepuestos_Comestibles.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        /// <summary>
        /// Instancias de clases
        /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();

        CrudUsuarios ventana = new CrudUsuarios();
        ClSeleccionUsuario user = new ClSeleccionUsuario();
        /// <summary>
        /// Declaracion de variables
        /// </summary>
        String valorID;
        string Estado;
        string Empleado;
        public Usuarios()
        {
            InitializeComponent();
            CargarDG();
        }
        /// <summary>
        /// cargar datos almacenados en la base de datos datagridview
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("UsuariosVista where Estado = 1", GridDatos);

        }

        /// <summary>
        /// Abre ventana de CrudUsuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Insert";
        }
        /// <summary>
        /// Realiza búsqueda de datos en el datagrid
        /// </summary>
        /// <param name="texto"></param>
        void Buscar(string texto)
        {
            obj.Busqueda("UsuariosVista", GridDatos, texto, "Usuario", "[Nombre del Empleado]", "Rol");

        }

        int indiceEmpleado;
        /// <summary>
        /// LLena campos de la ventana CrudUsuarios
        /// </summary>
        /// <param name="identidad">Identidad del cliente que desea modificar</param>

        void llenarcampos(string identidad)
        {
            
            user.seleccionar(identidad);
            ventana.TxtNombre.Text = user.Nombre;
            ventana.Id_usuario = Convert.ToInt32(user.Id);

            for (int i = 0; i < ventana.CmbInvisible.Items.Count; i++)
            {
                ventana.CmbInvisible.SelectedIndex = i;
                if (ventana.CmbInvisible.Text == user.Idemp)
                {
                    ventana.CmbEmpleado.SelectedIndex = ventana.CmbInvisible.SelectedIndex;
                }
            }

        }

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
                user.seleccionar(valorID);
            }
            else
            {
                BtnModificar.IsEnabled = false;
                BtnEliminar.IsEnabled = false;
            }
            
            


        }
        /// <summary>
        /// Abre la ventana de CrudUsuarios con los campos llenados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            llenarcampos(valorID);
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Update";
        }
        /// <summary>
        /// Se elimina el registro de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Usuarios", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Usuarios();
        }
    }

}
