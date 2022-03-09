using System;
using System.Collections.Generic;
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
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudClientes ventana = new CrudClientes();
        ClSeleccion cli = new ClSeleccion();
        //String valorID;

        public Clientes()
        {
            InitializeComponent();
            CargarDG();
        }
         
        void CargarDG()
        {
            obj.LlenarDG("ClientesVista", GridDatos);

        }

        private void BtnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {

            FrameCliente.Content = ventana;
            ventana.Operacion = "Insert";
        }

        void Buscar(string texto)
        {
            obj.Busqueda("ClientesVista", GridDatos, texto, "Identidad", "[Nombre del Cliente]", "Correo");

        }
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }

        void llenarcampos(string identidad)
        {
            cli.seleccionar(identidad);

            ventana.TxtIdCliente.Text = cli.Id;
            ventana.TxtNombre.Text = cli.Nombre;
            ventana.TxtTelefono.Text = cli.Telefono;
            ventana.TxtCorreo.Text = cli.Correo;
            ventana.TxtFechNac.Text = cli.FechaNac;
            ventana.TxtNombre.Text = cli.Nombre;

            if (cli.IDEstado != "1")
            {
                ventana.rbtnInActivo.IsChecked = true;
            }


        }


        private void BtnModificar_Click_1(object sender, RoutedEventArgs e)
        {
            FrameCliente.Content = ventana;
            string identidad = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la Identidad del Cliente: ", "Identidad");
            llenarcampos(identidad);
            ventana.Operacion = "Update";
        }
    }
}
