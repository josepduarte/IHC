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
using System.Windows.Media.Animation;

namespace Exemplo1_IHC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Olá Mundo");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Window had been activated. ");
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
          // Console.WriteLine("I'm a rat and I'm moving like there is no tomorrow. ");
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine("Omg Im getting fatter. ");
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("You dont need to click twice!! I understood the first time! ");
            Point p = e.GetPosition(this);
            double xPos = p.X;
            double yPos = p.Y;
            Console.WriteLine("The X Position is " + xPos + " The Y Position is " + yPos);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("I'm going dowwwwwwwnnnnn");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Dont shut me down like that!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Loaded...whatever does that mean. ");
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drag enter. ");
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Droppppiing");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Olá Mundo");
            SolidColorBrush init_color = new SolidColorBrush(Colors.Pink);
            this.Background = init_color;
            ColorAnimation colorAnim = new ColorAnimation();
            colorAnim.Duration = new Duration(TimeSpan.FromMilliseconds(10000));
            colorAnim.To = Colors.LightBlue;
            init_color.BeginAnimation(SolidColorBrush.ColorProperty, colorAnim);            //this.Background = init_color;
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
          //  Console.WriteLine("Moving on button. ");
            if (e.RightButton == MouseButtonState.Pressed)
                Console.WriteLine("Botão Direito");
        }
    }
}
