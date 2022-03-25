﻿using System.Windows.Controls;
using System.Windows;
using AutoRepuestos_Comestibles.Clases;
using System.Data;
using System;
namespace AutoRepuestos_Comestibles.Vistas.Proveedores
{
    /// <summary>
    /// Interaction logic for Proveedores.xaml
    /// </summary>
    public partial class Proveedores : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        CrudProveedores ventana = new CrudProveedores();
        ClSeleccionProveeedor prov = new ClSeleccionProveeedor();
        String valorID;
        string Estado;
       
        public Proveedores()
        {
            InitializeComponent();
            CargarDG();

        }
        void CargarDG()
        {
            obj.LlenarDG("ProveedoresVista where Estado = 1", GridDatos);

        }

        void Buscar(string texto)
        {
            obj.Busqueda("ProveedoresVista", GridDatos, texto, "RTN", "Nombre", "Identidad");

        }
        void llenarcampos(string identidad)
        {
            prov.seleccionar(identidad);
                       
            ventana.TxtRTN.Text = prov.Rtn;
            ventana.TxtIdentidad.Text = prov.Identidad;
            ventana.TxtNombre.Text = prov.Nombre;
            ventana.TxtEncargado.Text = prov.Encargado;
            ventana.TxtTelefono.Text = prov.Telefono;
            ventana.TxtCorreo.Text = prov.Correo;
            ventana.TxtDireccion.Text = prov.Direccion;

            if (Estado == "False")
            {
                ventana.rbtnInActivo.IsChecked = true;
            }


        }
        private void BtnAgregarProveedor_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CrudProveedores ventana = new CrudProveedores();
            FrameProveedor.Content = ventana;
            ventana.Operacion = "Insert";
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(TxtBuscar.Text);
        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnModificar.IsEnabled = true;
            BtnEliminar.IsEnabled = true;

            DataRowView view = (DataRowView)GridDatos.SelectedItem;
            valorID = view.Row.ItemArray[0].ToString();
            Estado = view.Row.ItemArray[8].ToString();
        }

        private void BtnModificar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ventana.Id =Convert.ToInt32(valorID);
            llenarcampos(valorID);
            FrameProveedor.Content = ventana;
            ventana.Operacion = "Update";
            prov.seleccionar(valorID);
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Proveedores", parametros, controlnames);
            valorID = "";

            //CargarDG();
            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
        }
    }
}
