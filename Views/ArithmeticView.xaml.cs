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
using WPFInterop.ViewModels;

namespace WPFInterop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ArithmeticView.xaml
    /// </summary>
    public partial class ArithmeticView : UserControl
    {
        private MainWindow parentWindow;
        private ManagedArithmeticObj arithmeticObj;

        public ArithmeticView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    parentWindow.proceedButton.Click += ProceedButtonClicked;
                }
            };

        }

        private void ProceedButtonClicked(object sender, RoutedEventArgs e)
        {
            if (parentWindow.DataContext.GetType() == typeof(ArithmeticViewModel) && parentWindow.inputBox.Text != "")
            {
                visualizationWindow.Children.Clear();
                arithmeticObj = new ManagedArithmeticObj(parentWindow.inputBox.Text);
                DrawInitialLines(parentWindow.inputBox.Text.Length);
                arithmeticObj.delete();
            }
        }

        private void DrawInitialLines(int howManySigns)
        {
            int x1 = 10;
            int x2 = 10;
            int y1 = 50;
            int y2 = 500;
            int spacing = 100;

            for (int i = 0; i <= howManySigns; i++)
            {
                x1 = x1 + spacing;
                x2 = x2 + spacing;

                Line newLine = new Line
                {
                    X1 = x1,
                    X2 = x2,
                    Y1 = y1,
                    Y2 = y2,
                    Stroke = Brushes.Black,
                    StrokeThickness = 4
                };

                visualizationWindow.Children.Add(newLine);
            }


        }
    }
}
