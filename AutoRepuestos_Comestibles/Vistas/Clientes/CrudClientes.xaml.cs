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
    /// Interaction logic for CrudClientes.xaml
    /// </summary>
    public partial class CrudClientes : Page
    {
        ClInsercion obj = new ClInsercion();

        public CrudClientes()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Clientes();
        }


        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            List<string> parametros = new List<string>() { "@ID", "@Nombre" ,"@Telefono", "@Correo", "@FechaNac", "@IDEstado"};
            List<string> controlnames = new List<string>() { TxtIdCliente.Text, TxtNombre.Text, TxtTelefono.Text, TxtCorreo.Text, TxtFechNac.Text, "1" };
            obj.Insertar("Ins_Clientes", parametros, controlnames);
            
        }
    }
}
