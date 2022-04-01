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
        ClValidaciones val = new ClValidaciones();
        ClCmb cmb = new ClCmb();
        ClInsercion obj = new ClInsercion();
        private String operacion;

        public String Operacion { get => operacion; set => operacion = value; }
        public CrudEmpleado()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbPuesto, "Puestos", 1);
            TxtFechNac.SelectedDate = DateTime.Now.AddYears(-25);
        }

        int estado = 1;

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Empleados();

        }

        int puesto=0;

        DateTime fecha_actual = DateTime.Now;

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = TxtFechNac.SelectedDate.Value;

            if (TxtIdentidad.Text.Length>12 && val.ValidarEspaciosEnBlancos(TxtIdentidad.Text))
            {
                if(TxtNombre.Text.Length > 5 && !val.ValidarEspaciosEnBlancos(TxtNombre.Text))
                {
                    if(TxtTelefono.Text.Length > 7)
                    {
                        if(val.email(TxtCorreo.Text) && TxtCorreo.Text.Length > 17)
                        {
                            if(fecha.Year > (fecha_actual.AddYears(-69).Year) && fecha.Year < (fecha_actual.AddYears(-18).Year))
                            {
                                #region Boton confirmar

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
                                dynamic[] parametros = { "@ID", "@NOMBRE", "@TELEFONO", "@CORREO", "@FECHA_NAC", "ID_PUESTO", "@ID_ESTADO" };
                                dynamic[] controlnames = { TxtIdentidad.Text, TxtNombre.Text, TxtTelefono.Text, TxtCorreo.Text, TxtFechNac.SelectedDate, puesto, estado.ToString() };
                                String st;

                                if (operacion == "Insert")
                                {
                                    st = "Ins_Empleados";
                                    obj.Insertar(st, parametros, controlnames);
                                    System.Windows.MessageBox.Show("Empleado actualizado exitosamente");
                                }
                                else
                                {
                                    st = "Upd_Empleados";
                                    obj.Insertar(st, parametros, controlnames);
                                    System.Windows.MessageBox.Show("Empleado actualizado exitosamente");
                                }
                                Content = new Empleados();
                                #endregion
                            }
                            else
                            {
                                val.mensajeError("La persona no cumple los requisitos de edad");
                                TxtFechNac.Focus();
                            }
                        }
                        else
                        {
                            val.mensajeError("Su correo es invalido. Debe contener 8 caracteres antes del @");
                            TxtTelefono.Clear();
                            TxtTelefono.Focus();
                        }

                    }
                    else
                    {
                        val.mensajeError("El numero de telefono es invalido");
                        TxtTelefono.Clear();
                        TxtTelefono.Focus();
                    }

                }
                else
                {
                    val.mensajeError("El nombre ingresado es no cumple con los requisitos");
                    TxtNombre.Clear();
                    TxtNombre.Focus();
                }

            }
            else
            {
                val.mensajeError("La identidad ingresada es invalida, no debe tener espacios");
                TxtIdentidad.Focus();
            }



        }

        private void TxtIdentidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }
    }
}
