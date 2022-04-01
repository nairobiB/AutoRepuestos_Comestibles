using AutoRepuestos_Comestibles.Clases;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System;

namespace AutoRepuestos_Comestibles.Vistas.Rentas
{
    /// <summary>
    /// Lógica de interacción para Rentas.xaml
    /// </summary>
    public partial class Rentas : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        string valorID;
        public Rentas()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("RentasVista where Estado = 1", GridDatos);

        }

        private void BtnAgregarRenta_Click(object sender, RoutedEventArgs e)
        {
            CrudRentas ventana = new CrudRentas();
            FrameRentas.Content = ventana;
        }

        void Buscar(string texto)
        {
            obj.Busqueda("RentasVista", GridDatos, texto, "Cliente", "Empleado", "Fecha");

        }
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Buscar(TxtBuscar.Text);
        }

        private void GridDatos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            

       
                DataRowView view = (DataRowView)GridDatos.SelectedItem;
                if(view!= null)
                {
                    BtnModificar.IsEnabled = true;
                    BtnEliminar.IsEnabled = true;
                    valorID = view.Row.ItemArray[0].ToString();
                }
                else
                {
                    BtnModificar.IsEnabled = false;
                    BtnEliminar.IsEnabled = false;
                }
                
         

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClInsercion obj = new ClInsercion();
            dynamic[] parametros = { "@ID" };
            dynamic[] controlnames = { valorID };

            obj.Insertar("Del_Facturas", parametros, controlnames);
            valorID = "";

            BtnModificar.IsEnabled = false;
            BtnEliminar.IsEnabled = false;
            Content = new Rentas();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            ReporteRentas repRen = new ReporteRentas();
            repRen.Factura = valorID;
            repRen.Show();
        }
    }
}
