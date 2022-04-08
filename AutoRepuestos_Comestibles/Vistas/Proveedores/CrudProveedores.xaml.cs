using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Proveedores
{
    /// <summary>
    /// Interaction logic for CrudProveedores.xaml
    /// </summary>
    public partial class CrudProveedores : Page
    {

        /// <summary>
        /// Instancia de clases
        /// </summary>
        ClInsercion obj = new ClInsercion();
        ClValidaciones val = new ClValidaciones();
        int estado = 1;
        private String operacion;
        private int id;

        public String Operacion { get => operacion; set => operacion = value; }
        public int Id { get => id; set => id = value; }

        public CrudProveedores()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Regresa el usuario a la pantalla pricnipal de proveedores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Proveedores();
        }
        /// <summary>
        /// Realiza la operación de modificar o agregar un nuevo proveedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {

                if ((TxtIdentidad.Text.Length > 12 && val.ValidarEspaciosEnBlancos(TxtIdentidad.Text)) || TxtIdentidad.Text.Length < 1 || TxtIdentidad.Text!="0000000000000")
                {
                    if (TxtNombre.Text.Length >= 4 && !val.ValidarEspaciosEnBlancos(TxtNombre.Text))
                    {
                        if (val.email(TxtCorreo.Text) && TxtCorreo.Text.Length > 17)
                        {
                            if (TxtRTN.Text.Length >= 14 && val.ValidarEspaciosEnBlancos(TxtRTN.Text) || TxtRTN.Text != "00000000000000" || TxtRTN.Text != "000000000000000")
                            {
                                if (TxtEncargado.Text.Length > 5 && !val.ValidarEspaciosEnBlancos(TxtEncargado.Text))
                                {
                                    if (rbtnInActivo.IsChecked == true)
                                    {
                                        estado = 0;
                                    }

                                    String st;
                                    if (operacion == "Insert")
                                    {
                                    dynamic[] parametros = {"@RTN", "@Identidad", "@Nombre", "@Encargado", "@Telefono", "@Correo", "@Direccion", "@ID_Estado" };
                                    dynamic[] controlnames = { TxtRTN.Text, TxtIdentidad.Text, TxtNombre.Text, TxtEncargado.Text, TxtTelefono.Text, TxtCorreo.Text, TxtDireccion.Text, estado.ToString() };
                                    st = "Ins_Proveedores";
                                    obj.Insertar(st, parametros, controlnames);
                                    System.Windows.MessageBox.Show("Proveedor modificado exitosamente");
                                    }
                                    else
                                    {
                                    dynamic[] parametros = {"@ID","@RTN", "@Identidad", "@Nombre", "@Encargado", "@Telefono", "@Correo", "@Direccion", "@ID_Estado" };
                                    dynamic[] controlnames = { Id,TxtRTN.Text, TxtIdentidad.Text, TxtNombre.Text, TxtEncargado.Text, TxtTelefono.Text, TxtCorreo.Text, TxtDireccion.Text, estado.ToString() };
                                    st = "Upd_Proveedores";
                                    obj.Insertar(st, parametros, controlnames);
                                    System.Windows.MessageBox.Show("Proveedor modificado exitosamente");
                                    }
                                    Content = new Proveedores();
                                }
                                else
                                {
                                    val.mensajeError("El encargado ingresado no cumple con los requisitos");
                                }
                            }
                            else
                            {
                                val.mensajeError("El RTN es invalido, no debe contener espacios");
                            }
                        }
                        else
                        {
                            val.mensajeError("Su correo es invalido. Debe contener 8 caracteres antes del @");
                        }
                    }
                    else
                    {
                        val.mensajeError("El nombre ingresado no cumple los requisitos");
                    }
                }

                else
                {
                    val.mensajeError("La identidad ingresada es invalida (asegurese que no contiene espacios)");
                }              
        }
        /// <summary>
        /// Validacion para no ingresar letras al textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtIdentidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }
        /// <summary>
        /// Validacion para no ingresar numeros al textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarLetras(e);
        }

        private void TxtCorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //val.email(e);
        }
        /// <summary>
        /// Validacion para no ingresar numeros al textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtRTN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }
        /// <summary>
        /// Validacion para no ingresar letras al textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtEncargado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarLetras(e);
        }
        /// <summary>
        /// Validacion para numeros de telefonos, permite agregar el simbolo "+" al inicio y numeros al final
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TxtTelefono.Text.Length == 0)
            {
                val.validarTelefonos(e);
            }
            else
            {
                val.validarNumeros(e);
            }

        }
    }
}
