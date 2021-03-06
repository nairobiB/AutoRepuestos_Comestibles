using System.Data;
using System.Windows;
using System.Windows.Controls;
using AutoRepuestos_Comestibles.Clases;
using System;
namespace AutoRepuestos_Comestibles.Vistas.Empleado
{
    /// <summary>
    /// Interaction logic for Empleados.xaml
    /// </summary>
    public partial class Empleados : UserControl
    {
        /// <summary>
        /// Instancias de clases
        /// </summary>
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudEmpleado ventana = new CrudEmpleado();
        ClSeleccionEmpleado emp = new ClSeleccionEmpleado();
        /// <summary>
        /// Declaracion de variables
        /// </summary>
        String valorID;
        string Estado;
        string Puesto;
        public Empleados()
        {
            InitializeComponent();
            CargarDG();
        }
        /// <summary>
        /// cargar datos almacenados en la base de datos datagridview
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("EmpleadosVista where Estado = 1", GridDatos);

        }
        /// <summary>
        /// Realiza búsqueda de datos en el datagrid
        /// </summary>
        /// <param name="texto"></param>
        void Buscar(string texto)
        {
            obj.Busqueda("EmpleadosVista", GridDatos, texto, "Identidad", "[Nombre del empleado]", "Puesto");

        }
        /// <summary>
        /// Abre ventana de CrudEmpleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Insert";

        }
        /// <summary>
        /// LLena campos de la ventana CrudEmpleados
        /// </summary>
        /// <param name="identidad">Identidad del cliente que desea modificar</param>

        void llenarcampos(string identidad)
        {
            emp.seleccionar(identidad);

            ventana.TxtIdentidad.Text = emp.Id;
            ventana.TxtNombre.Text = emp.Nombre;
            ventana.TxtTelefono.Text = emp.Telefono;
            ventana.TxtCorreo.Text = emp.Correo;
            ventana.TxtFechNac.Text = emp.FechaNac;
            ventana.TxtIdentidad.IsEnabled = false;


            if (Puesto == "Administrador")
            {
                ventana.CmbPuesto.SelectedIndex = 0;
            }
            else
            {
                ventana.CmbPuesto.SelectedIndex = 1;
            }

            if (Estado == "False")
            {
                ventana.rbtnInActivo.IsChecked = true;
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
                Estado = view.Row.ItemArray[6].ToString();
                Puesto = view.Row.ItemArray[5].ToString();
            }
            else
            {
                BtnModificar.IsEnabled = false;
                BtnEliminar.IsEnabled = false;
            }
            
        }
        /// <summary>
        /// Abre la ventana de CrudEmpleados con los campos llenados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            llenarcampos(valorID);
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Update";
        }
        /// <summary>
        /// Se elimina el registro de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Empleados", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Empleados();
        }
    }
}
