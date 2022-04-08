using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Usuario
{
    /// <summary>
    /// Interaction logic for CrudUsuarios.xaml
    /// </summary>
    public partial class CrudUsuarios : Page
    {
        /// <summary>
        /// Instancias de clases
        /// </summary>
        ClSeleccionUsuario user = new ClSeleccionUsuario();
        ClCmb cmb = new ClCmb();
        ClInsercion ob = new ClInsercion();
        ClValidaciones val = new ClValidaciones();
        private String operacion;
        private int id_usuario;


        /// <summary>
        /// Declaracion de variable y encapsulacion
        /// </summary>
        public String Operacion { get => operacion; set => operacion = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }

        public CrudUsuarios()
        {
            InitializeComponent();
            Llenar_cmb();

        }
        /// <summary>
        /// Regresa el usuario a la pantalla pricnipal de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();

        }
        int estado = 1;
        /// <summary>
        /// Realiza la operación de modificar o agregar un nuevo usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if(TxtNombre.Text.Length > 5 && val.ValidarEspaciosEnBlancos(TxtNombre.Text))
            {
                if(TxtPass.Password.Length > 5 )
                {
                    if(TxtPassConf.Password == TxtPass.Password)
                    {
                        #region Boton confirmar

                        if (rbtnInActivo.IsChecked == true)
                        {
                            estado = 0;
                        }

                        int indice = CmbEmpleado.SelectedIndex;
                        CmbInvisible.SelectedIndex = indice;

                        string empleado = CmbInvisible.Text;
                        ob.num_usuario();



                       /* dynamic[] parametros = { "@ID", "@Nombre", "@Password", "@ID_Empleado","@Estado" };
                        dynamic[] controlnames = { TxtIdentidad.Text, TxtNombre.Text, TxtPass.Password.ToString(), empleado, estado.ToString() };
                        String st;*/

                        if (operacion == "Insert")
                        {
                            Id_usuario = ob.Usuario + 1;
                            dynamic[] parametros = { "@ID", "@Nombre", "@Password", "@ID_Empleado", "@Estado" };
                            dynamic[] controlnames = { Id_usuario, TxtNombre.Text, TxtPass.Password.ToString(), empleado, estado.ToString() };
                            String st;
                            st = "Ins_Usuarios";
                            ob.Insertar(st, parametros, controlnames);
                            System.Windows.MessageBox.Show("Usuario creado exitosamente");
                            
                        }
                        else
                        {
                            dynamic[] parametros = { "@ID", "@Nombre", "@Password", "@ID_Empleado", "@Estado" };
                            dynamic[] controlnames = { Id_usuario, TxtNombre.Text, TxtPass.Password.ToString(), empleado, estado.ToString() };
                            String st;
                            st = "Upd_Usuarios";
                            ob.Insertar(st, parametros, controlnames);
                            System.Windows.MessageBox.Show("Usuario modificado exitosamente");
                        }

                        #endregion 
                        Content = new Usuarios();

                    }
                    else
                    {
                        val.mensajeError("Las contraseñas ingresadas no coinciden");
                        TxtPass.Clear();
                        TxtPassConf.Clear();
                        TxtPass.Focus();
                    }

                }
                else
                {
                    val.mensajeError("La contraseña es muy corta, debe contener como minimo 6 caracteres");
                    TxtPass.Clear();
                    TxtPassConf.Clear();
                    TxtPass.Focus();
                }

            }
            else
            {
                val.mensajeError("El usuario ingresado es invalido, intente ingresar uno nuevo");
                TxtNombre.Focus();
            }
            
        }
        /// <summary>
        /// Llena los combobox del formulario
        /// </summary>
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
        /// <summary>
        /// Permite letras y numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPassConf_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros_letras(e);
        }
        /// <summary>
        /// Permite letras y numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros_letras(e);
        }
        /// <summary>
        /// Permite letras y numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros_letras(e);
        }
    }
}
