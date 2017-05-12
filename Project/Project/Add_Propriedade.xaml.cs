﻿using System;
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
    /// Interaction logic for Add_Propriedade.xaml
    /// </summary>
    public partial class Add_Propriedade : Page
    {
        public string rua { get; set; }
        public string freguesia { get; set; }
        public string concelho { get; set; }

        public Add_Propriedade()
        {
            InitializeComponent();
            DataContext = this;
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));
        }

        /* Botão "Confirmar" */
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
