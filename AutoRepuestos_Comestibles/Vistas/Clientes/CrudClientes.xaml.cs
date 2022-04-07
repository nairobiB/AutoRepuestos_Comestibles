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
        ClValidaciones val = new ClValidaciones();
        ClInsercion obj = new ClInsercion();
        private String operacion;

        public String Operacion { get => operacion; set => operacion = value; }

        public CrudClientes()
        {
            InitializeComponent();
            TxtFechNac.SelectedDate = DateTime.Now.AddYears(-25);
        }


        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Clientes();

        }

        int estado = 1;


        DateTime fecha_actual = DateTime.Now;
        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            
            DateTime fecha = TxtFechNac.SelectedDate.Value;

            if (TxtIdCliente.Text.Length > 12 && val.ValidarEspaciosEnBlancos(TxtIdCliente.Text))
            {
                if(TxtNombre.Text.Length > 5 && !val.ValidarEspaciosEnBlancos(TxtNombre.Text))
                {
                    if (fecha.Year > (fecha_actual.AddYears(-69).Year) && fecha.Year < (fecha_actual.AddYears(-18).Year))
                    {
                        if (TxtTelefono.Text.Length > 7)
                        {
                            if(val.email(TxtCorreo.Text) && TxtCorreo.Text.Length > 17)
                            {                            
                                if (rbtnInActivo.IsChecked == true)
                                {
                                    estado = 0;
                                }                                
                                dynamic[] parametros = { "@ID", "@NOMBRE", "@TELEFONO", "@CORREO", "@FECHA_NAC", "@ID_Estado" };
                                dynamic[] controlnames = { TxtIdCliente.Text, TxtNombre.Text, TxtTelefono.Text, TxtCorreo.Text, TxtFechNac.SelectedDate, estado.ToString() };
                                String st;
                                if (operacion == "Insert")
                                {
                                    st = "Ins_Clientes";
                                    obj.Insertar(st, parametros, controlnames);
                                    System.Windows.MessageBox.Show("Cliente agregado exitosamente");
                                }
                                else
                                {
                                    st = "Upd_Clientes";
                                    obj.Insertar(st, parametros, controlnames);
                                    System.Windows.MessageBox.Show("Cliente modificado exitosamente");
                                }
                                Content = new Clientes();
                            }
                            else
                            {
                                val.mensajeError("Su correo es invalido. Debe contener 8 caracteres antes del @");
                            }
                        }
                        else
                        {
                            val.mensajeError("Ingrese un numero de telefono valido");
                        }

                    }
                    else
                    {
                        val.mensajeError("La persona no cumple los requisitos de edad");
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


        private void TxtIdCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);

        }

        private void TxtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarLetras(e);
        }

        private void TxtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }

        private void TxtCorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //val.email(e);
        }
    }



  }

