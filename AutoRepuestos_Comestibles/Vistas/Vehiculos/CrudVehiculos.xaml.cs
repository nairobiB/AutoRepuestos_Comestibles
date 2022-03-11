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
            int indiceColor = CmbColor.SelectedIndex + 1;


            int indiceMarcas = CmbMarca.SelectedIndex + 1;


            int indiceModelo = CmbModelo.SelectedIndex + 1;


            int indiceEstado = CmbEstado.SelectedIndex + 1;
           

            dynamic[] parametros = { "@ID", "@Marca", "@color", "@Modelo", "@Precio_Venta", "@Precio_Renta", "@ID_Estado" };
            dynamic[] controlnames = { TxtIdVehiculo.Text, indiceMarcas, indiceColor, indiceModelo, TxtVenta.Text, TxtRenta.Text, indiceEstado };
            String st;

            st = "Ins_Vehiculos";
            obj.Insertar(st, parametros, controlnames);


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
    }
}
