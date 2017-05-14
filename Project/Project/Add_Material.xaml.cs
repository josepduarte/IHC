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

namespace Project
{
    /// <summary>
    /// Interaction logic for Add_Material.xaml
    /// </summary>
    public partial class Add_Material : Page
    {
        public Add_Material()
        {
            InitializeComponent();
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Homepage PaginaInicial = new Homepage();
            this.NavigationService.Navigate(PaginaInicial);
        }

        /* Botão "Ok" */
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Material PaginaMaterial = new Material();
            this.NavigationService.Navigate(PaginaMaterial);
        }

        /* Botão "Cancelar" */
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Material PaginaMaterial = new Material();
            this.NavigationService.Navigate(PaginaMaterial);
        }
    }
}
