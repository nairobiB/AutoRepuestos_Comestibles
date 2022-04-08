using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoRepuestos_Comestibles.Clases;
namespace AutoRepuestos_Comestibles.Vistas.Vehiculos
{
    /// <summary>
    /// Interaction logic for CrudVehiculos.xaml
    /// </summary>
    public partial class CrudVehiculos : Page
    {
        /// <summary>
        /// Definicion de atributos y instancias de clase
        /// </summary>
        ClInsercion obj = new ClInsercion();
        ClCmb cmb = new ClCmb();
        ClValidaciones val = new ClValidaciones();
        private String operacion;
        private int color;
        private int modelo;
        private int marca;
        private int estado;

        public string Operacion { get => operacion; set => operacion = value; }
        public int Color { get => color; set => color = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public int Marca { get => marca; set => marca = value; }
        public int Estado { get => estado; set => estado = value; }

        /// <summary>
        /// Metodo para llenar combobox
        /// </summary>
        public CrudVehiculos()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbColor, "Colores", 1);

            cmb.fill_cmb(CmbMarca, "Marcas", 1);

            cmb.fill_cmb(CmbModelo, "Modelos", 1);

            cmb.fill_cmb(CmbEstado, "Estado_Vehiculo", 1);
        

        }
        /// <summary>
        /// Regresa al formulario de vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Vehiculos();
        }
        /// <summary>
        /// Validaciones. Se rellena combobox con primera opcion para evitar que quede vacio.
        /// Decision Si es Insersion o actualizacion.
        /// Se guarda la informacion o se actualiza, regresando tambien al 
        /// formulario de vehiculos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdVehiculo.Text.Length > 6 && val.ValidarEspaciosEnBlancos(TxtIdVehiculo.Text))
            {
                if(TxtVenta.Text.Length > 4 && val.ValidarEspaciosEnBlancos(TxtVenta.Text))
                {
                    if (TxtRenta.Text.Length > 2 && val.ValidarEspaciosEnBlancos(TxtRenta.Text))
                    {
                        #region BTNCONFIRMAR
                        int indiceColor = CmbColor.SelectedIndex + 1;


                        int indiceMarcas = CmbMarca.SelectedIndex + 1;


                        int indiceModelo = CmbModelo.SelectedIndex + 1;


                        int indiceEstado = CmbEstado.SelectedIndex + 1;


                        String st;

                        if (operacion == "Insert")
                        {
                            dynamic[] parametros = { "@ID", "@Marca", "@color", "@Modelo", "@Precio_Venta", "@Precio_Renta", "@ID_Estado" };
                            dynamic[] controlnames = { TxtIdVehiculo.Text, indiceMarcas, indiceColor, indiceModelo, TxtVenta.Text, TxtRenta.Text, indiceEstado };
                            st = "Ins_Vehiculos";
                            obj.Insertar(st, parametros, controlnames);
                            System.Windows.MessageBox.Show("Vehiculo agregado exitosamente");
                        }
                        else
                        {
                            dynamic[] parametros = { "@ID", "@ID_Marca", "@ID_Color", "@ID_Modelo", "@Precio_Venta", "@Precio_Renta", "@ID_Estado" };
                            dynamic[] controlnames = { TxtIdVehiculo.Text, indiceMarcas, indiceColor, indiceModelo, TxtVenta.Text, TxtRenta.Text, indiceEstado };
                            st = "Upd_Vehiculos";
                            obj.Insertar(st, parametros, controlnames);
                            System.Windows.MessageBox.Show("Vehiculo modificado exitosamente");
                        }
                        #endregion
                        Content = new Vehiculos();
                    }
                    else
                    {
                        val.mensajeError("El precio de renta no puede ser menos que L. 100.00");
                    }
                }
                else
                {
                    val.mensajeError("El precio de venta no puede ser menos que L. 1,000.00");
                }
            }
            else
            {
                val.mensajeError("El ID del vehículo debe contener 7 caracteres y no debe tener espacios en blanco");
            }
        }
        /// <summary>
        /// Boton para agregar marca por medio de procedimiento almacenado. 
        /// Si esta vacio no se guarda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddMarca_Click(object sender, RoutedEventArgs e)
        {

            string marca = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la Marca: ", "Marcas");
            if(val.marcaModelo(marca))
            {
            
                obj.Insertar("Add_Marca", new string[] { "@Marca" }, new string[] { marca });
                CmbMarca.Items.Clear();
                cmb.fill_cmb(CmbMarca, "Marcas", 1);
                CmbMarca.Text = marca;
            }
           else
            {
                val.mensajeError("Error, no se pueden introducir valores nulos");
            }
        }
        /// <summary>
        /// Boton para agregar marca por medio de procedimiento almacenado. 
        /// Si esta vacio no se guarda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddModelo_Click(object sender, RoutedEventArgs e)
        {

            string modelo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Modelo: ", "Modelos");
            if (val.marcaModelo(modelo))
            {
                obj.Insertar("Add_Modelo", new string[] { "@Modelo" }, new string[] { modelo });
            CmbModelo.Items.Clear();
            cmb.fill_cmb(CmbModelo, "Modelos", 1);
            CmbModelo.Text = modelo;
            }
            else
            {
                val.mensajeError("Error, no se pueden introducir valores nulos");
            }
        }
        /// <summary>
        /// Boton para agregar marca por medio de procedimiento almacenado. 
        /// Si esta vacio no se guarda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddcolor_Click(object sender, RoutedEventArgs e)
        {
            string color = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Color: ", "Colores");
            if (val.colores(color))
            {
                obj.Insertar("Add_Color", new string[] { "@Color" }, new string[] { color });
            CmbColor.Items.Clear();
            cmb.fill_cmb(CmbColor, "Colores", 1);
            CmbColor.Text = color;
            }
            else
            {
                val.mensajeError("Error, no se pueden introducir valores nulos");
            }
        }
        /// <summary>
        /// Impide que escriba caracteres no permitidos en el textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVenta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }
        /// <summary>
        /// Impide que escriba caracteres no permitidos en el textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtIdVehiculo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros_letras(e);
        }
        /// <summary>
        /// Impide que escriba caracteres no permitidos en el textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtRenta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }
    }
}
