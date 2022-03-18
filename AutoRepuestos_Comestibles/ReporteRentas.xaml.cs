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
using System.Windows.Shapes;

namespace AutoRepuestos_Comestibles
{
    /// <summary>
    /// Interaction logic for ReporteRentas.xaml
    /// </summary>
    public partial class ReporteRentas : Window
    {
        public ReporteRentas()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ReporteRentas_Loaded);
        }

        private void ReporteRentas_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Busqueda_FacturaRenta.rdl");
            this.ReportViewer.RefreshReport();           
        }
    }
}
