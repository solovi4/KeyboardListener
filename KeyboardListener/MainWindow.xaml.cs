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

namespace KeyboardListener
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

        private Canvas GetOneKeyBindCanvas()
        {
            int heightButton = 75;
            Button button = new Button
            {
                Height = heightButton,
                Width = 75,
                //HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 0, 0)
            };

            Canvas canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Azure),
                Height = button.Height
            };
            canvas.Children.Add(new TextBox
            {
                Height = 80,
                Width = 80
            }); 
            canvas.Children.Add(button);
            
            return canvas;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas oneKeyBindCanvas = GetOneKeyBindCanvas();
            KeysBindingStackPanel.Children.Add(oneKeyBindCanvas);
            KeysBindingStackPanel.Height += oneKeyBindCanvas.Height;
           
        }
    }
}
