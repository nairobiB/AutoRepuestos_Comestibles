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
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using AutoRepuestos_Comestibles.Clases;
using System.Data.SqlClient;
using System.Data;
using AutoRepuestos_Comestibles.Vistas;

namespace AutoRepuestos_Comestibles
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        ClConexion conexion = new ClConexion();

        public bool IsDarkTheme { get; set; }

        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if(IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        public void ingresar(string usuario, string pass)
        {
            try
            {
                conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select Empleado_Nombre, Puesto_Descripcion FROM LoginVista WHERE Usuario_Nombre = @usuario AND Usuario_Contraseña = @pass",conexion.Sc);
                cmd.Parameters.AddWithValue("usuario",usuario);
                cmd.Parameters.AddWithValue("pass", pass);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        new MenuAdmin(dt.Rows[0][0].ToString()).Show();

                    }
                    else if (dt.Rows[0][1].ToString() == "Agente de Ventas")
                    {
                        new MenuAgente(dt.Rows[0][0].ToString()).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contrasena Incorrectos");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            ingresar(txtUsername.Text, txtPassword.Password);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ingresar(txtUsername.Text, txtPassword.Password);
            }
        }


    }
}
