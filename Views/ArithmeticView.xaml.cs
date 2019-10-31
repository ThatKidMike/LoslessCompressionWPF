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
                    parentWindow.inputBox.TextChanged += TextBoxChanged;
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
                DrawHorizontalLines(parentWindow.inputBox.Text.Length);
                arithmeticObj.delete();
            }
        }

        private void TextBoxChanged(object sender, TextChangedEventArgs e)
        {

            if (parentWindow.DataContext.GetType() == typeof(ArithmeticViewModel))
            {
                parentWindow.signRow_1.Text = parentWindow.inputBox.Text.ElementAtOrDefault(0).ToString();
                parentWindow.signRow_2.Text = parentWindow.inputBox.Text.ElementAtOrDefault(1).ToString();
                parentWindow.signRow_3.Text = parentWindow.inputBox.Text.ElementAtOrDefault(2).ToString();
                parentWindow.signRow_4.Text = parentWindow.inputBox.Text.ElementAtOrDefault(3).ToString();
                parentWindow.signRow_5.Text = parentWindow.inputBox.Text.ElementAtOrDefault(4).ToString();
                parentWindow.signRow_6.Text = parentWindow.inputBox.Text.ElementAtOrDefault(5).ToString();
                parentWindow.signRow_7.Text = parentWindow.inputBox.Text.ElementAtOrDefault(6).ToString();

                    foreach (TextBlock tb in parentWindow.arithmeticPanelGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("sign")).ToList())
                    {
                        if (tb.Text != "\0")
                        {
                                    int row = Grid.GetRow(tb);
                                    TextBox tbox = (TextBox)parentWindow.arithmeticPanelGrid.Children
                                         .Cast<UIElement>()
                                         .First(element => Grid.GetRow(element) == row && Grid.GetColumn(element) == 1);
                                         tbox.Visibility = Visibility.Visible;
                        } else
                        {
                        int row = Grid.GetRow(tb);
                        TextBox tbox = (TextBox)parentWindow.arithmeticPanelGrid.Children
                             .Cast<UIElement>()
                             .First(element => Grid.GetRow(element) == row && Grid.GetColumn(element) == 1);
                        tbox.Visibility = Visibility.Hidden;

                    }
                            
                    }
                
            }
        }

        /*static T ElementAtOrDefault<T>(this IList<T> list, int index, T @default)
        {
            return index >= 0 && index < list.Count ? list[index] : @default;
        }*/

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

        private void DrawHorizontalLines(int howManySigns)
        {
            int pointOfReference = 500;
            int currentYStart = 500;
            int currentYEnd = 500;
            int spacing = 100;
            int x1 = 35;
            int x2 = 10;
            int y1 = 500;
            int y2 = 500;

            for (int j = 0; j <= howManySigns; j++)
            {
                x1 += spacing;
                x2 += spacing;
                currentYStart = 500;
                currentYEnd = 500;

                for (int i = 0; i < howManySigns; i++)
                {

                    currentYStart = pointOfReference - (int)(pointOfReference * arithmeticObj.GetStartRange(i));
                    if (currentYStart < 50)
                        currentYStart += 50;

                    y1 = currentYStart;
                    y2 = currentYStart;

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

                    currentYEnd = pointOfReference - (int)(pointOfReference * arithmeticObj.GetEndRange(i));
                    if (currentYEnd < 50)
                        currentYEnd += 50;

                    y1 = currentYEnd;
                    y2 = currentYEnd;

                    Line newLineSecond = new Line
                    {
                        X1 = x1,
                        X2 = x2,
                        Y1 = y1,
                        Y2 = y2,
                        Stroke = Brushes.Black,
                        StrokeThickness = 4

                    };

                    visualizationWindow.Children.Add(newLineSecond);

                }

            }


        }
    }
}
