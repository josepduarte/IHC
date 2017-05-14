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
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
        }

        /* Botão "Propriedades" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Propriedades PaginaPropriedades = new Propriedades();
            this.NavigationService.Navigate(PaginaPropriedades);

            for (int i = 0; i < GlobalVars.numItem; i++)
            {
                Button btn = new Button();
                btn.Content = GlobalVars.items[i];
                btn.Height = 100;
                btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                //propPage.listBox.Items.Add(btn);
                PaginaPropriedades.buttonContainer.Children.Add(btn);
            }
                //PaginaPropriedades.listBox.Items.Add(GlobalVars.items[i]);
        }

        /* Botão "Negócios" */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Negocios PaginaNegocios = new Negocios();
            this.NavigationService.Navigate(PaginaNegocios);
        }

        /* Botão "Encomendas" */
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Encomendas PaginaEncomendas = new Encomendas();
            this.NavigationService.Navigate(PaginaEncomendas);
        }

        /* Botão "Material" */
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Material PaginaMaterial = new Material();
            this.NavigationService.Navigate(PaginaMaterial);
        }

        /* Botão "Histórico" */
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Historico PaginaHistorico = new Historico();
            this.NavigationService.Navigate(PaginaHistorico);
        }

        /* Botão "Stock" */
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Stock PaginaStock = new Stock();
            this.NavigationService.Navigate(PaginaStock);
        }
    }
}
