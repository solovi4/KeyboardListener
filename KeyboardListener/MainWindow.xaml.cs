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

        private Canvas GetOneKeyBindCanvas(string deviceId, string key, string action)
        {

            MyTextbox textBox = new MyTextbox
            {
                Width = 400,
                IsReadOnly = true                
            };           

            textBox.KeyUp += TextBox_KeyUp;

            ComboBox comboBox = new ComboBox
            {
                Width = 100,
                Margin = new Thickness(textBox.Width, 0, 0, 0)
                
            };
            comboBox.Items.Add("VolumeUp");
            comboBox.Items.Add("VolumeDown");

            if (deviceId != null && key != null && action != null)
            {
                textBox.SetDeviceAndKey(deviceId, key);
                comboBox.SelectedItem = action;
            }

            Button button = new Button
            {
                Height = 75,
                Width = 75,
                //HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(comboBox.Width + textBox.Width, 0, 0, 0),
                Style = this.FindResource("RemoveButton") as Style
                
            };
            button.Click += Button_Click1;
          

            Canvas canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.Azure),
                Height = button.Height
            };

            canvas.Children.Add(textBox);
            canvas.Children.Add(comboBox);
            canvas.Children.Add(button);
            
            return canvas;
            
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Canvas canvas = (Canvas)button.Parent;
            KeysBindingStackPanel.Children.Remove(canvas);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            MyTextbox textBox = (MyTextbox)sender;
            textBox.SetDeviceAndKey(e.KeyboardDevice.ToString(), e.Key.ToString());            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas oneKeyBindCanvas = GetOneKeyBindCanvas(null, null, null);
            KeysBindingStackPanel.Children.Add(oneKeyBindCanvas);
            KeysBindingStackPanel.Height += oneKeyBindCanvas.Height;
           
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            List<ConfigUnit> configUnits = new List<ConfigUnit>();

            foreach (var child in KeysBindingStackPanel.Children)
            {
                Canvas canvas = (Canvas)child;
                MyTextbox textBox = (MyTextbox)canvas.Children[0];
                ComboBox comboBox = (ComboBox)canvas.Children[1];
                if (textBox.Text == null || comboBox.SelectedIndex == -1) continue;
                configUnits.Add(new ConfigUnit(textBox.DeviceID, textBox.Key, comboBox.SelectedItem.ToString()));
            }

            ConfigManager.Save(configUnits.ToArray());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KeysBindingStackPanel.Children.Clear();
            ConfigUnit[] configUnits = ConfigManager.Load();
            foreach (var configUnit in configUnits)
            {
                KeysBindingStackPanel.Children.Add(GetOneKeyBindCanvas(configUnit.DeviceID, configUnit.Key, configUnit.Action));
            }
        }
    }
}
