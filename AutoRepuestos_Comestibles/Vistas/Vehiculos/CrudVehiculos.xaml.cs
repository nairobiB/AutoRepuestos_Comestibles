﻿using System;
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
namespace AutoRepuestos_Comestibles.Vistas.Vehiculos
{
    /// <summary>
    /// Interaction logic for CrudVehiculos.xaml
    /// </summary>
    public partial class CrudVehiculos : Page
    {
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

        public CrudVehiculos()
        {
            InitializeComponent();
            cmb.fill_cmb(CmbColor, "Colores", 1);
            //cmb.fill_cmb(CmbInvisibleColor, "Colores", 0);

            cmb.fill_cmb(CmbMarca, "Marcas", 1);
            //cmb.fill_cmb(CmbInvisibleMarca, "Marcas", 0);

            cmb.fill_cmb(CmbModelo, "Modelos", 1);
          //  cmb.fill_cmb(CmbInvisibleModelo, "Modelos", 0);

            cmb.fill_cmb(CmbEstado, "Estado_Vehiculo", 1);
          //  cmb.fill_cmb(CmbEstado, "Estado_Vehiculo", 0);

        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Vehiculos();
        }
        
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

                        }
                        else
                        {
                            dynamic[] parametros = { "@ID", "@ID_Marca", "@ID_Color", "@ID_Modelo", "@Precio_Venta", "@Precio_Renta", "@ID_Estado" };
                            dynamic[] controlnames = { TxtIdVehiculo.Text, indiceMarcas, indiceColor, indiceModelo, TxtVenta.Text, TxtRenta.Text, indiceEstado };
                            st = "Upd_Vehiculos";
                            obj.Insertar(st, parametros, controlnames);
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
                val.mensajeError("El ID del vehículo debe debe ser mayor de 14 caracteres y no debe tener espacios en blanco");
            }
        }

        private void BtnAddMarca_Click(object sender, RoutedEventArgs e)
        {
            string marca = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la Marca: ", "Marcas");
            obj.Insertar("Add_Marca", new string[] { "@Marca" }, new string[] { marca });
            CmbMarca.Items.Clear();
            cmb.fill_cmb(CmbMarca, "Marcas", 1);
            CmbMarca.Text = marca;
        }

        private void BtnAddModelo_Click(object sender, RoutedEventArgs e)
        {
            string modelo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Modelo: ", "Modelos");
            obj.Insertar("Add_Modelo", new string[] { "@Modelo" }, new string[] { modelo });
            CmbModelo.Items.Clear();
            cmb.fill_cmb(CmbModelo, "Modelos", 1);
            CmbModelo.Text = modelo;
        }

        private void BtnAddcolor_Click(object sender, RoutedEventArgs e)
        {
            string color = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Color: ", "Colores");
            obj.Insertar("Add_Color", new string[] { "@Color" }, new string[] { color });
            CmbColor.Items.Clear();
            cmb.fill_cmb(CmbColor, "Colores", 1);
            CmbColor.Text = color;
        }

        private void TxtVenta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }

        private void TxtIdVehiculo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumeros_letras(e);
        }

        private void TxtRenta_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            val.validarNumerosDecimales(e);
        }
    }
}
