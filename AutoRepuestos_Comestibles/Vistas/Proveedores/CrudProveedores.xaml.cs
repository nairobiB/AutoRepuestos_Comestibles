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
            if (rbtnInActivo.IsChecked == true)
            {
                estado = 0;
            }


            dynamic[] parametros = { "@ID", "@RTN", "@Identidad", "@Nombre", "@Encargado", "@Telefono", "@Correo", "@Direccion", "@ID_Estado" };
            dynamic[] controlnames = { TxtIdproveedor.Text, TxtRTN.Text, TxtIdentidad.Text, TxtNombre.Text, TxtEncargado.Text, TxtTelefono.Text, TxtCorreo.Text, TxtDireccion.Text, estado.ToString() };
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
                Content = new Proveedores();
            }
        }
    }
}
