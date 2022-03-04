using System;
using System.Collections.Generic;
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
            CrudClientes ventana = new CrudClientes();
            FrameCliente.Content = ventana;
        }

        void Buscar(string texto)
        {
            obj.Busqueda("ClientesVista", GridDatos, texto, "Identidad", "[Nombre del Cliente]", "Correo");

        }
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }
    }
}
