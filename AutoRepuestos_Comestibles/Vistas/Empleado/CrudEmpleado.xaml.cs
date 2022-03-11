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
using System.Data.SqlClient;
using System.Data;
using AutoRepuestos_Comestibles.Clases;
namespace AutoRepuestos_Comestibles.Vistas.Empleado
{
    /// <summary>
    /// Interaction logic for frmControlUsuarios.xaml
    /// </summary>
    public partial class CrudEmpleado : Page
    {
        ClCmb cmb = new ClCmb();
        ClInsercion obj = new ClInsercion();
        private String operacion;

        public String Operacion { get => operacion; set => operacion = value; }
        public CrudEmpleado()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbPuesto, "Puestos", 1);

        }

        int estado;

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Empleados();

        }

        int puesto=0;

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnInActivo.IsChecked == true)
            {
                estado = 0;
            }
            if (CmbPuesto.SelectedIndex == 0)
            {
                puesto = 1;
            }
            else
            {
                puesto = 2;
            }
            dynamic[] parametros = { "@ID", "@NOMBRE", "@TELEFONO", "@CORREO", "@FECHA_NAC","ID_PUESTO" ,"@ID_ESTADO" };
            dynamic[] controlnames = { TxtIdentidad.Text, TxtNombre.Text, TxtTelefono.Text, TxtCorreo.Text, TxtFechNac.Text,puesto, estado.ToString() };
            String st;

            if (operacion == "Insert")
            {
                st = "Ins_Empleados";
                obj.Insertar(st, parametros, controlnames);
            }
            else
            {
                st = "Upd_Empleados";
                obj.Insertar(st, parametros, controlnames);
                Content = new Empleados();
            }


        }
    }
}
