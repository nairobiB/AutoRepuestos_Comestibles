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
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudEmpleado ventana = new CrudEmpleado();
        ClSeleccionEmpleado emp = new ClSeleccionEmpleado();
        String valorID;
        string Estado;
        string Puesto;
        public Empleados()
        {
            InitializeComponent();
            CargarDG();
        }

        void CargarDG()
        {
            obj.LlenarDG("EmpleadosVista", GridDatos);

        }

        void Buscar(string texto)
        {
            obj.Busqueda("EmpleadosVista", GridDatos, texto, "Identidad", "[Nombre del empleado]", "Puesto");

        }
        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Insert";

        }

        void llenarcampos(string identidad)
        {
            emp.seleccionar(identidad);

            ventana.TxtIdentidad.Text = emp.Id;
            ventana.TxtNombre.Text = emp.Nombre;
            ventana.TxtTelefono.Text = emp.Telefono;
            ventana.TxtCorreo.Text = emp.Correo;
            ventana.TxtFechNac.Text = emp.FechaNac;
            DataRowView view = (DataRowView)GridDatos.SelectedItem;

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

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();
            Estado = view.Row.ItemArray[6].ToString();
            Puesto = view.Row.ItemArray[5].ToString();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            llenarcampos(valorID);
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Update";
        }
    }
}
