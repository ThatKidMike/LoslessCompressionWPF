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
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using System.Collections.ObjectModel;
using WPFInterop.ViewModels;
using System.Text.RegularExpressions;

namespace WPFInterop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            arithmeticPanel.Visibility = Visibility.Hidden;
            huffmanPanel.Visibility = Visibility.Hidden;
            crcPanel.Visibility = Visibility.Hidden;
        }

        private void HuffmanView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HuffmanViewModel();
            crcPanel.Visibility = Visibility.Collapsed;
            arithmeticPanel.Visibility = Visibility.Collapsed;
            huffmanPanel.Visibility = Visibility.Visible;
            huffmanButton.IsEnabled = false;
            arithmeticButton.IsEnabled = true;
            CRCButton.IsEnabled = true;
            inputBox.Clear();
            inputBox.CharacterCasing = System.Windows.Controls.CharacterCasing.Normal;
            inputBox.MaxLength = 50;
            huffmanOccurrencesSpace.Text = "";
            huffmanSignSpace.Text = "";
            huffmanCodedSpace.Text = "";
            codedTextBox.Text = "";
        }

        private void ArithmeticView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ArithmeticViewModel();
            crcPanel.Visibility = Visibility.Collapsed;
            huffmanPanel.Visibility = Visibility.Collapsed;
            arithmeticPanel.Visibility = Visibility.Visible;
            huffmanButton.IsEnabled = true;
            arithmeticButton.IsEnabled = false;
            CRCButton.IsEnabled = true;
            inputBox.Clear();
            inputBox.CharacterCasing = System.Windows.Controls.CharacterCasing.Upper;
            inputBox.MaxLength = 7;
        }

        private void CRCView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new CRCViewModel();
            huffmanPanel.Visibility = Visibility.Collapsed;
            arithmeticPanel.Visibility = Visibility.Collapsed;
            crcPanel.Visibility = Visibility.Visible;
            huffmanButton.IsEnabled = true;
            arithmeticButton.IsEnabled = true;
            CRCButton.IsEnabled = false;
            inputBox.Clear();
            inputBox.CharacterCasing = System.Windows.Controls.CharacterCasing.Normal;
            inputBox.MaxLength = 50;
        }

        private void Proceed_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_InputValidation(object sender, TextCompositionEventArgs e)
        {
            if (DataContext.GetType() == typeof(CRCViewModel))
            {
                Regex regex = new Regex(@"^[01]+$");
                e.Handled = !regex.IsMatch(e.Text);
            }
            else
            {
                Regex regex = new Regex(@"^[a-zA-Z\s]+$");
                e.Handled = !regex.IsMatch(e.Text);
            }
        }

        private void TextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
