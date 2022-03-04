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
        public CrudEmpleado()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbPuesto, "Puestos", 1);
        }


        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Empleados();

        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
