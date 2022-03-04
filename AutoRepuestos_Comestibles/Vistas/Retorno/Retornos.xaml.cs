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

namespace AutoRepuestos_Comestibles.Vistas.Retorno
{
    /// <summary>
    /// Interaction logic for Retornos.xaml
    /// </summary>
    public partial class Retornos : UserControl
    {
        ClVistasDataGrid obj = new ClVistasDataGrid();
        ClCmb cmb = new ClCmb();
        public Retornos()
        {
            InitializeComponent();
            CargarDG();
            cmb.fill_cmb(CmbRetorno, "Retorno_VehiculoVista", 2);
        }
        void CargarDG()
        {
            obj.LlenarDG("Retorno_VehiculoVista", GridDatos);
        }
        void Buscar(string texto)
        {
            obj.Busqueda("Retorno_VehiculoVista", GridDatos, texto, "Cliente", "Vehiculo", "[Tipo de Pago]");

        }

        private void Txtbuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Buscar(Txtbuscar.Text);
        }
    }
}
