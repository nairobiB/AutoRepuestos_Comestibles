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
        private String operacion;

        public String Operacion { get => operacion; set => operacion = value; }

        public CrudClientes()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Clientes();

        }

        int estado = 1;

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {

            if (rbtnInActivo.IsChecked == true)
            {
                estado = 0;
            }

            dynamic[] parametros = { "@ID", "@NOMBRE", "@TELEFONO", "@CORREO", "@FECHA_NAC", "@ID_Estado" };
            dynamic[] controlnames = { TxtIdCliente.Text, TxtNombre.Text, TxtTelefono.Text, TxtCorreo.Text, TxtFechNac.Text, estado.ToString() };
            String st;
            if (operacion == "Insert")
            {
                st = "Ins_Clientes";
                obj.Insertar(st, parametros, controlnames);
            }
            else
            {
                st = "Upd_Clientes";
                obj.Insertar(st, parametros, controlnames);
                Content = new Clientes();
            }

            
        }
    }
}
