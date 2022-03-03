using AutoRepuestos_Comestibles.Clases;
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

namespace AutoRepuestos_Comestibles.Vistas.Rentas
{
    /// <summary>
    /// Lógica de interacción para Rentas.xaml
    /// </summary>
    public partial class Rentas : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();

        public Rentas()
        {
            InitializeComponent();
            CargarDG();
        }
        void CargarDG()
        {
            obj.LlenarDG("RentasVista", GridDatos);

        }

        private void BtnAgregarRenta_Click(object sender, RoutedEventArgs e)
        {
            CrudRentas ventana = new CrudRentas();
            FrameRentas.Content = ventana;
        }
    }
}
