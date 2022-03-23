using AutoRepuestos_Comestibles.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace AutoRepuestos_Comestibles.Vistas.Retorno
{
    /// <summary>
    /// Interaction logic for Retornos.xaml
    /// </summary>
    public partial class Retornos : UserControl
    {
        ClValidaciones val = new ClValidaciones();
        ClVistasDataGrid obj = new ClVistasDataGrid();
        ClCmb cmb = new ClCmb();
        ClInsercion objeto = new ClInsercion();
        string idVehiculo;
        string hora;

        public Retornos()
        {
            InitializeComponent();
            CargarDG();
            cmb.fill_cmb(CmbVehiculo, "RetornosVista", 2);
        }
        void CargarDG()
        {
            obj.LlenarDG("RetornosVista", GridDatos);
        }
        void Buscar(string texto)
        {
            obj.Busqueda("RetornosVista", GridDatos, texto, "Cliente", "Vehiculo", "[Placa de Vehiculo]");

        }

        private void Txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtIdFactura.Clear();
            CmbVehiculo.Items.Clear();
            BtnAgregarRetorno.IsEnabled = false;
            
            Buscar(Txtbuscar.Text);
            
        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (GridDatos.Items.Count > 0)
            {
                BtnAgregarRetorno.IsEnabled = true;
                DataRowView view = (DataRowView)GridDatos.SelectedItem;

                TxtIdFactura.Text = view.Row.ItemArray[0].ToString();
                CmbVehiculo.Text = view.Row.ItemArray[2].ToString();
                idVehiculo = view.Row.ItemArray[1].ToString();
                DpFechRetorno.SelectedDate = DateTime.Now;
                hora = DateTime.Now.ToString();
            }
        }

        DateTime fecha_actual = DateTime.Now;

        private void BtnAgregarRetorno_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DpFechRetorno.SelectedDate.Value;

            if(val.ValidarEspaciosEnBlancos(TxtCombustible.Text))
            {
                if(fecha > fecha_actual)
                {
                    if (val.ValidarEspaciosEnBlancos(TxtDanos.Text))
                    {
                        if (val.ValidarEspaciosEnBlancos(TxtMora.Text))
                        {
                            dynamic[] parametros = { "@ID_Factura", "@ID_Vehiculo", "@Mora", "@Combustible", "@Daños", "@Fecha_Devolucion" };
                            dynamic[] controlnames = { TxtIdFactura.Text, idVehiculo, TxtMora.Text, TxtCombustible.Text, TxtDanos.Text, hora };
                            objeto.Insertar("Ins_Retorno", parametros, controlnames);
                            //CargarDG();
                            TxtIdFactura.Clear();
                            CmbVehiculo.Items.Clear();
                            BtnAgregarRetorno.IsEnabled = false;
                        }
                        else
                        {
                            val.mensajeError("Total de mora escrito con espacios");
                        }
                        
                    }
                    else
                    {
                        val.mensajeError("Total de da;os escrito con espacios");
                    }
                }
                else
                {
                    val.mensajeError("Fecha ingresada incorrectamente");
                }
                
            }
            else
            {
                val.mensajeError("Total de combustible escrito con espacios");
            }

        }

        private void TxtCombustible_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }

        private void TxtMora_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }

        private void TxtDanos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros(e);
        }
    }
}
