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
    /// Interaction logic for ReportePedidos.xaml
    /// </summary>
    public partial class ReportePedidos : Window
    {
        public ReportePedidos()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ReportePedidos_Loaded);
        }
        private string _factura;

        public string Factura { get => _factura; set => _factura = value; }

        private void ReportePedidos_Loaded(object sender, RoutedEventArgs e)
        {


            /*this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Busqueda_FacturaRenta.rdl");
            this.ReportViewer.RefreshReport();   */
            this.ReportViewer.ReportLoaded += (sen, arg) =>
            {
                List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                BoldReports.Windows.ReportParameter parameter = new BoldReports.Windows.ReportParameter();
                parameter.Name = "ID";
                parameter.Values = new List<string>() { Factura };
                parameters.Add(parameter);
                this.ReportViewer.SetParameters(parameters);
            };

            this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\ReportePedidos.rdl");
            this.ReportViewer.RefreshReport();

        }
    }
}
