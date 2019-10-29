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
        }

        private void HuffmanView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HuffmanViewModel();
            inputBox.Clear();
            outputBlock.Text = "";
            inputBox.MaxLength = 30;
        }

        private void ArithmeticView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ArithmeticViewModel();
            inputBox.Clear();
            outputBlock.Text = "";
            inputBox.CharacterCasing = System.Windows.Controls.CharacterCasing.Upper;
            inputBox.MaxLength = 7;
        }

        private void Proceed_Clicked(object sender, RoutedEventArgs e)
        {
          
        }

        private void TextBox_InputValidation(object sender, TextCompositionEventArgs e)
        {
                Regex regex = new Regex(@"^[a-zA-Z\s]+$");
                e.Handled = !regex.IsMatch(e.Text);
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
