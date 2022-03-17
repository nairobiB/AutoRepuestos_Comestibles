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
using AutoRepuestos_Comestibles.Vistas.Usuario;
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for CrudUsuarios.xaml
    /// </summary>
    public partial class CrudUsuarios : Page
    {
        ClCmb cmb = new ClCmb();
        ClInsercion obj = new ClInsercion();
        private String operacion;

        public String Operacion { get => operacion; set => operacion = value; }

        public CrudUsuarios()
        {
            InitializeComponent();
            //cmb.fill_cmb(CmbEmpleado, "Empleados", 1);
            //cmb.fill_cmb(CmbInvisible, "Empleados", 0);
            Llenar_cmb();

        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();

        }
        int estado = 1;

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnInActivo.IsChecked == true)
            {
                estado = 0;
            }

            int indice = CmbEmpleado.SelectedIndex;
            CmbInvisible.SelectedIndex = indice;

            string empleado = CmbInvisible.Text;

            /*dynamic[] parametros = { "@ID", "@Nombre", "@Password", "@ID_Empleado","@Estado" };
            dynamic[] controlnames = { TxtIdentidad.Text, TxtNombre.Text, TxtPass.Password.ToString(), empleado, estado.ToString() };
            String st;*/

            if (operacion == "Insert")
            {
                dynamic[] parametros = { "@ID", "@Nombre", "@Password", "@ID_Empleado", "@Estado" };
                dynamic[] controlnames = { TxtNombre.Text, TxtPass.Password.ToString(), empleado, estado.ToString() };
                String st;
                st = "Ins_Usuarios";
                obj.Insertar(st, parametros, controlnames);
            }
            else
            {
                dynamic[] parametros = { "@ID", "@Nombre", "@Password", "@Estado" };
                dynamic[] controlnames = {  TxtNombre.Text, TxtPass.Password.ToString(), estado.ToString() };
                String st;
                st = "Upd_Usuarios";
                obj.Insertar(st, parametros, controlnames);
                Content = new Usuarios();
            }
        }

        public void Llenar_cmb() 
        {
            cmb.fill_cmb(CmbEmpleado, "Empleados", 1);
            cmb.fill_cmb(CmbInvisible, "Empleados", 0);
        }

        public void Rellenar_cmb(string empleado) 
        {
            for (int i = 0; i < CmbEmpleado.Items.Count; i++)
            {
                CmbInvisible.SelectedIndex = i;
                if (CmbInvisible.SelectedItem == empleado) 
                {
                    CmbEmpleado.SelectedIndex = CmbInvisible.SelectedIndex;
                
                }

            }

        }
    }
}
