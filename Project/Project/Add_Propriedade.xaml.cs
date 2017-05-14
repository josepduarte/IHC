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
using Microsoft.Maps.MapControl.WPF;

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
        public double coordX { get; set; }
        public double coordY { get; set; }

        public Add_Propriedade()
        {
            InitializeComponent();
            DataContext = this;
        }

        /* Botão "Voltar à Página Inicial" */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Propriedades propPage = new Propriedades();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("Homepage.xaml", UriKind.Relative));

            for (int i = 0; i < GlobalVars.numItem; i++)
            {
                Button btn = new Button();
                btn.Content = GlobalVars.items[i];
                btn.Height = 100;
                btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                propPage.buttonContainer.Children.Add(btn);
            }
        }

        /* Botão "Ok" */
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Propriedades propPage = new Propriedades();
            this.NavigationService.Navigate(propPage);

            var str = string.Format("PROPRIEDADE {0}:", GlobalVars.numItem);
            GlobalVars.items[GlobalVars.numItem++] = str+"\n"+rua+", "+freguesia+", "+concelho;

            for (int i = 0; i < GlobalVars.numItem; i++)
            {
                Button btn = new Button();
                btn.Content = GlobalVars.items[i];
                btn.Height = 100;
                btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                propPage.buttonContainer.Children.Add(btn);
            }

            Pins.cx[Pins.numPin] = coordX;
            Pins.cy[Pins.numPin] = coordY;
            Pins.numPin++;

            for (int i = 0; i < Pins.numPin; i++)
            {
                var pushpinText = string.Format("P{0}", i);
                Pushpin pin = new Pushpin();
                pin.Content = pushpinText;
                pin.Location = new Location(Pins.cx[i], Pins.cy[i]);
                propPage.myMap.Children.Add(pin);
            }
        }

        /* botão "Cancelar"*/
        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Propriedades propPage = new Propriedades();
            this.NavigationService.Navigate(propPage);

            for (int i = 0; i < GlobalVars.numItem; i++)
            {
                Button btn = new Button();
                btn.Content = GlobalVars.items[i];
                btn.Height = 100;
                btn.HorizontalContentAlignment = HorizontalAlignment.Left;
                propPage.buttonContainer.Children.Add(btn);
            }

            for (int i = 0; i < Pins.numPin; i++)
            {
                var pushpinText = string.Format("P{0}", i);
                Pushpin pin = new Pushpin();
                pin.Content = pushpinText;
                pin.Location = new Location(Pins.cx[i], Pins.cy[i]);
                propPage.myMap.Children.Add(pin);
            }
        }
    }

    public static class GlobalVars
    {
        public static int numItem = 0;
        public static string[] items = new string[100];
    }

    public static class Pins
    {
        public static int numPin = 0;
        public static double[] cx = new double[100];
        public static double[] cy = new double[100];
    }

}
