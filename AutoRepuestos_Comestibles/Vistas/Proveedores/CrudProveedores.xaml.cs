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

        public String Operacion { get => operacion; set => operacion = value; }
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

            if(TxtIdentidad.Text.Length > 12  && val.ValidarEspaciosEnBlancos(TxtIdentidad.Text))
            {
                if(TxtNombre.Text.Length > 5 && !val.ValidarEspaciosEnBlancos(TxtNombre.Text))
                {
                    if(TxtCorreo.Text.Length > 17 && val.email(TxtCorreo.Text))
                    {
                        if(TxtRTN.Text.Length > 14 && val.ValidarEspaciosEnBlancos(TxtRTN.Text))
                        {
                            if(TxtEncargado.Text.Length > 5 && !val.ValidarEspaciosEnBlancos(TxtEncargado.Text))
                            {
                                if(TxtTelefono.Text.Length > 7)
                                {
                                    if(TxtDireccion.Text.Length > 8)
                                    {
                                        if (rbtnInActivo.IsChecked == true)
                                        {
                                            estado = 0;
                                        }


                                        dynamic[] parametros = { "@RTN", "@Identidad", "@Nombre", "@Encargado", "@Telefono", "@Correo", "@Direccion", "@ID_Estado" };
                                        dynamic[] controlnames = { TxtRTN.Text, TxtIdentidad.Text, TxtNombre.Text, TxtEncargado.Text, TxtTelefono.Text, TxtCorreo.Text, TxtDireccion.Text, estado.ToString() };
                                        String st;
                                        if (operacion == "Insert")
                                        {
                                            st = "Ins_Proveedores";
                                            obj.Insertar(st, parametros, controlnames);
                                        }
                                        else
                                        {
                                            st = "Upd_Proveedores";
                                            obj.Insertar(st, parametros, controlnames);
                                        }
                                        Content = new Proveedores();
                                    }
                                    else
                                    {
                                            val.mensajeError("La direccion ingresada es invalida");
                                    }
                                }
                                else
                                {
                                    val.mensajeError("Ingrese un numero de telefono valido");
                                }
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
                val.mensajeError("La identidad ingresada es invalida, no debe tener espacios");
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
