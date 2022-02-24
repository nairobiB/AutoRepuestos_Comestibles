using System;
using System.Collections.Generic;
using System.Data;
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

namespace AutoRepuestos_Comestibles.Vistas.Empleado
{
    /// <summary>
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : UserControl
    {
        public Empleados()
        {
            InitializeComponent();
            cargar_datos();
        }

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        void cargar_datos()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[EmpleadosVista]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new DataTable();
            da.Fill(dt);
            GridDatos.ItemsSource = dt.DefaultView;
            con.Close();

        }
        private void BtnAddEmpleado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            CrudEmpleado ventana = new CrudEmpleado();
            FrameEmpleado.Content = ventana;
        }
    }
}
