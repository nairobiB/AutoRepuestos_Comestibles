using AutoRepuestos_Comestibles.Clases;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoRepuestos_Comestibles.Vistas.Retorno
{
    /// <summary>
    /// Interaction logic for Retornos.xaml
    /// </summary>
    public partial class Retornos : UserControl
    {
        /// <summary>
        /// Instancia de clases
        /// </summary>
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
            DpFechRetorno.SelectedDate = DateTime.Now;
        }
        /// <summary>
        /// hace referencia a la clase vistas datagrid view, enviando texto y un objeto tipo datagrid
        /// </summary>
        void CargarDG()
        {
            obj.LlenarDG("RetornosVista", GridDatos);
        }
        /// <summary>
        /// Hace referencia a la clase VistaDatagrid usando el metodo busqueda usando Clientes, vehiculo, placa
        /// </summary>
        void Buscar(string texto)
        {
            obj.Busqueda("RetornosVista", GridDatos, texto, "Cliente", "Vehiculo", "[Placa de Vehiculo]");

        }
        /// <summary>
        /// para realizar busqueda de autos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtIdFactura.Clear();
            CmbVehiculo.Items.Clear();
            BtnAgregarRetorno.IsEnabled = false;
            Buscar(Txtbuscar.Text);
            
        }
        /// <summary>
        /// Permite selecionar una fila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (GridDatos.Items.Count > 0)
            {
                
                DataRowView view = (DataRowView)GridDatos.SelectedItem;
                if(view != null)
                {
                    BtnAgregarRetorno.IsEnabled =true;
                    TxtIdFactura.Text = view.Row.ItemArray[0].ToString();
                    CmbVehiculo.Text = view.Row.ItemArray[2].ToString();
                    idVehiculo = view.Row.ItemArray[1].ToString();
                    DpFechRetorno.SelectedDate = DateTime.Now;
                }
                else
                {
                    BtnAgregarRetorno.IsEnabled = false;
                }
               
            }
        }
        /// <summary>
        /// Crea una variable tipodate time para actualizar la fecha actual
        /// </summary>

        DateTime fecha_actual = DateTime.Now;
        /// <summary>
        /// se usa para agregar valores a la base de datos usando un procedimiento almacenado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarRetorno_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DpFechRetorno.SelectedDate.Value;
            
            if(val.ValidarEspaciosEnBlancos(TxtCombustible.Text) && TxtCombustible.Text != String.Empty)
            {
                if(fecha > fecha_actual)
                {
                    if (val.ValidarEspaciosEnBlancos(TxtDanos.Text) && TxtDanos.Text != String.Empty)
                    {
                        if (val.ValidarEspaciosEnBlancos(TxtMora.Text) && TxtMora.Text != String.Empty)
                        {
                            dynamic[] parametros = { "@ID_Factura", "@ID_Vehiculo", "@Mora", "@Combustible", "@Daños", "@Fecha_Devolucion" };
                            dynamic[] controlnames = { TxtIdFactura.Text, idVehiculo, TxtMora.Text, TxtCombustible.Text, TxtDanos.Text, DateTime.Now };
                            objeto.Insertar("Ins_Retorno", parametros, controlnames);
                            CargarDG();
                            TxtIdFactura.Clear();
                            CmbVehiculo.Items.Clear();
                            BtnAgregarRetorno.IsEnabled = false;
                            System.Windows.MessageBox.Show("Recargo actualizado exitosamente");
                            Content = new Retornos();
                        }
                        else
                        {
                            val.mensajeError("Total de mora escrito con espacios");
                        }
                        
                    }
                    else
                    {
                        val.mensajeError("Total de daños escrito con espacios");
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

        /// <summary>
        /// Valida la entrada de numeros y tambien ingresar "."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCombustible_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }
        /// <summary>
        /// Valida la entrada de numeros y tambien ingresar "."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMora_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }
        /// <summary>
        /// Valida la entrada de numeros y tambien ingresar "."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDanos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }
    }
}
