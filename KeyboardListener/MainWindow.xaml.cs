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

            ComboBox comboBox = new ComboBox
            {
                Width = 100              
                
            };
            comboBox.Items.Add("VolumeUp");
            comboBox.Items.Add("VolumeDown");


            
            Button button = new Button
            {
                Height = 75,
                Width = 75,
                //HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(comboBox.Width, 0, 0, 0),
                Style = this.FindResource("RemoveButton") as Style
                
            };
            
          

            Canvas canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Azure),
                Height = button.Height
            };

            canvas.Children.Add(comboBox);
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
