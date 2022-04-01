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
using AutoRepuestos_Comestibles.Vistas.Proveedores;
using AutoRepuestos_Comestibles.Clases;

namespace AutoRepuestos_Comestibles.Vistas.Proveedores
{
    /// <summary>
    /// Interaction logic for CrudProveedores.xaml
    /// </summary>
    public partial class CrudProveedores : Page
    {
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

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Proveedores();
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {

                if ((TxtIdentidad.Text.Length > 12 && val.ValidarEspaciosEnBlancos(TxtIdentidad.Text)) || TxtIdentidad.Text.Length < 1)
                {
                    if (TxtNombre.Text.Length > 5 && !val.ValidarEspaciosEnBlancos(TxtNombre.Text))
                    {
                        if (val.email(TxtCorreo.Text) && TxtCorreo.Text.Length > 17)
                        {
                            if (TxtRTN.Text.Length > 14 && val.ValidarEspaciosEnBlancos(TxtRTN.Text))
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

        private void TxtIdentidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }

        private void TxtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarLetras(e);
        }

        private void TxtCorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //val.email(e);
        }

        private void TxtRTN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }

        private void TxtEncargado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarLetras(e);
        }

        private void TxtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }
    }
}
