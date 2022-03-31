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
        ClVistasDataGrid obj = new ClVistasDataGrid();

        CrudUsuarios ventana = new CrudUsuarios();
        ClSeleccionUsuario user = new ClSeleccionUsuario();
        String valorID;
        string Estado;
        string Empleado;
        public Usuarios()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("UsuariosVista where Estado = 1", GridDatos);

        }


        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Insert";
        }

        void Buscar(string texto)
        {
            obj.Busqueda("UsuariosVista", GridDatos, texto, "Usuario", "[Nombre del Empleado]", "Rol");

        }

        int indiceEmpleado;
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

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();
            user.seleccionar(valorID);
            view.CancelEdit();


        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            llenarcampos(valorID);
            FrameEmpleado.Content = ventana;
            ventana.Operacion = "Update";
        }

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
