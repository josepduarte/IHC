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
using Microsoft.Maps.MapControl.WPF;

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
            ListaNegocios bla = new ListaNegocios();
            foreach (DateTime date in Dates.dates)
            {
                Console.WriteLine(date);
                CalendarNegocios.BlackoutDates.Add(new CalendarDateRange(date, date)); 
            }
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
                PaginaPropriedades.buttonContainer.Children.Add(btn);
            }

            for (int i = 0; i < Pins.numPin; i++)
            {
                var pushpinText = string.Format("P{0}", i);
                Pushpin pin = new Pushpin();
                pin.Content = pushpinText;
                pin.Location = new Location(Pins.cx[i], Pins.cy[i]);
                PaginaPropriedades.myMap.Children.Add(pin);
            }
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

        /* Botão "Sair" */
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Tem a certeza que quer sair da Aplicação?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                Environment.Exit(1);
            else
            {
                Homepage PaginaInicial = new Homepage();
                this.NavigationService.Navigate(PaginaInicial);
            }
            
        }

        /* Botão "Administração" */
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Administracao PaginaAdmin = new Administracao();
            this.NavigationService.Navigate(PaginaAdmin);
        }

        private void CalendarNegocios_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Selected date");
        }
    }
}
