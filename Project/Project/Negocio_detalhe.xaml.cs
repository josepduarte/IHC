using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for Negocio_detalhe.xaml
    /// </summary>
    public partial class Negocio_detalhe : Page
    {
        public Negocio_detalhe()
        {
            InitializeComponent();
        }
        public Negocio_detalhe(object data) : this()
        {
            this.DataContext = data;
        }

        private void Apagar_negocio(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.DataContext);
            //ListaNegocios.getLista().Remove(this.DataContext);

            String cliente = Convert.ToString(TypeDescriptor.GetProperties(this.DataContext)["cliente"].GetValue(this.DataContext));
            /**
            String morada = Convert.ToString(TypeDescriptor.GetProperties(this.DataContext)["morada"].GetValue(this.DataContext));
            int contacto = Convert.ToInt32(TypeDescriptor.GetProperties(this.DataContext)["cliente"].GetValue(this.DataContext));
            DateTime inicio = Convert.ToDateTime(TypeDescriptor.GetProperties(this.DataContext)["cliente"].GetValue(this.DataContext));
            DateTime fim = Convert.ToDateTime(TypeDescriptor.GetProperties(this.DataContext)["cliente"].GetValue(this.DataContext));
            String descricao = Convert.ToString(TypeDescriptor.GetProperties(this.DataContext)["descricao"].GetValue(this.DataContext));
            **/
            Negocio toRemove = ListaNegocios.getLista().Single(r => r.cliente == cliente); // && r.contacto == contacto && r.morada == morada && (r.inicio.CompareTo(inicio) == 0) && (r.fim.CompareTo(fim) == 0) && r.descricao == descricao);
            ListaNegocios.getLista().Remove(toRemove);
            MessageBox.Show("Negócio Apagado. ");
            //this.NavigationService.Navigate(new Negocios());
        }
    }
}
