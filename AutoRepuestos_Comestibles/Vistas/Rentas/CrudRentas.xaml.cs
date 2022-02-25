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
    /// Lógica de interacción para CrudRentas.xaml
    /// </summary>
    public partial class CrudRentas : Page
    {
        public CrudRentas()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Rentas();
        }
    }
}
