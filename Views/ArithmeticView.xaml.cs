using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                    parentWindow.probRow_1.LostFocus += TextBoxLostFocus;
                    parentWindow.probRow_2.LostFocus += TextBoxLostFocus;
                    parentWindow.probRow_3.LostFocus += TextBoxLostFocus;
                    parentWindow.probRow_4.LostFocus += TextBoxLostFocus;
                    parentWindow.probRow_5.LostFocus += TextBoxLostFocus;
                    parentWindow.probRow_6.LostFocus += TextBoxLostFocus;
                    parentWindow.probRow_7.LostFocus += TextBoxLostFocus;

                    parentWindow.probRow_1.GotFocus += TextBoxGotFocus;
                    parentWindow.probRow_2.GotFocus += TextBoxGotFocus;
                    parentWindow.probRow_3.GotFocus += TextBoxGotFocus;
                    parentWindow.probRow_4.GotFocus += TextBoxGotFocus;
                    parentWindow.probRow_5.GotFocus += TextBoxGotFocus;
                    parentWindow.probRow_6.GotFocus += TextBoxGotFocus;
                    parentWindow.probRow_7.GotFocus += TextBoxGotFocus;

                    parentWindow.probRow_1.KeyDown += EnterPressed;
                    parentWindow.probRow_2.KeyDown += EnterPressed;
                    parentWindow.probRow_3.KeyDown += EnterPressed;
                    parentWindow.probRow_4.KeyDown += EnterPressed;
                    parentWindow.probRow_5.KeyDown += EnterPressed;
                    parentWindow.probRow_6.KeyDown += EnterPressed;
                    parentWindow.probRow_7.KeyDown += EnterPressed;

                    parentWindow.probRow_1.IsVisibleChanged += ValidationToProcessCaller;
                    parentWindow.probRow_2.IsVisibleChanged += ValidationToProcessCaller;
                    parentWindow.probRow_3.IsVisibleChanged += ValidationToProcessCaller;
                    parentWindow.probRow_4.IsVisibleChanged += ValidationToProcessCaller;
                    parentWindow.probRow_5.IsVisibleChanged += ValidationToProcessCaller;
                    parentWindow.probRow_6.IsVisibleChanged += ValidationToProcessCaller;
                    parentWindow.probRow_7.IsVisibleChanged += ValidationToProcessCaller;

                    parentWindow.probRow_1.PreviewTextInput += TextBoxProbValidation;
                    parentWindow.probRow_2.PreviewTextInput += TextBoxProbValidation;
                    parentWindow.probRow_3.PreviewTextInput += TextBoxProbValidation;
                    parentWindow.probRow_4.PreviewTextInput += TextBoxProbValidation;
                    parentWindow.probRow_5.PreviewTextInput += TextBoxProbValidation;
                    parentWindow.probRow_6.PreviewTextInput += TextBoxProbValidation;
                    parentWindow.probRow_7.PreviewTextInput += TextBoxProbValidation;

                    parentWindow.inputBox.GotFocus += ClearTheInputBox;

                    parentWindow.mainWindowGrid.MouseDown += LoseFocus;
                    visualizationWindow.MouseDown += LoseFocus;

                    parentWindow.proceedButton.IsEnabled = false;
                }
            };

        }

        private void LoseFocus(object sender, MouseButtonEventArgs e)
        {
            visualizationWindow.Focus();
        }

        private void ClearTheInputBox(object sender, RoutedEventArgs e)
        {
            parentWindow.inputBox.Clear();
            parentWindow.probRow_1.Clear();
            parentWindow.probRow_2.Clear();
            parentWindow.probRow_3.Clear();
            parentWindow.probRow_4.Clear();
            parentWindow.probRow_5.Clear();
            parentWindow.probRow_6.Clear();
            parentWindow.probRow_7.Clear();

        }

        private void ValidationToProcessCaller(object sender, DependencyPropertyChangedEventArgs e)
        {
            ValidationToProcess(sender);
        }

        private void ValidationToProcess(object sender)
        {
            parentWindow.proceedButton.IsEnabled = false;

            double sum = 0.0;

            foreach (TextBox tb in parentWindow.arithmeticPanelGrid.Children.OfType<TextBox>())
            {
                if (tb.IsVisible)
                {
                    if (tb.Text == "")
                        break;

                    sum += double.Parse(tb.Text, System.Globalization.CultureInfo.InvariantCulture);

                }
            }

            parentWindow.sumRow.Text = sum.ToString();
            sum = double.Parse(parentWindow.sumRow.Text, System.Globalization.CultureInfo.InvariantCulture);

            if (sum == 1 && parentWindow.inputBox.Text.Length >= 2)
            {
                parentWindow.proceedButton.IsEnabled = true;
                parentWindow.sumRow.Background = Brushes.ForestGreen;
            } else
            {
                parentWindow.sumRow.Background = Brushes.IndianRed;
            }
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tb = (TextBox)sender;
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            visualizationWindow.Focus();
        }

        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 1)
                tb.Text = "0." + tb.Text + "0";
            else if (tb.Text.Length == 2)
                tb.Text = "0." + tb.Text;

            if (tb.Text == "0.00")
                tb.Text = "0.05";

            if (double.Parse(tb.Text, System.Globalization.CultureInfo.InvariantCulture) < 0.05)
                tb.Text = "0.05";

            ValidationToProcess(sender);
        }

        private void TextBoxProbValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void ProceedButtonClicked(object sender, RoutedEventArgs e)
        {
            if (parentWindow.DataContext.GetType() == typeof(ArithmeticViewModel) && parentWindow.inputBox.Text != "")
            {
                visualizationWindow.Children.Clear();
                double[] probabilities = new double[parentWindow.inputBox.Text.Length];
                int i = 0;
                int j = 0;
                foreach (TextBox tb in parentWindow.arithmeticPanelGrid.Children.OfType<TextBox>())
                {
                    if (tb.IsVisible)
                    {
                        double it = double.Parse(tb.Text, System.Globalization.CultureInfo.InvariantCulture); 
                        probabilities[i] = double.Parse(tb.Text, System.Globalization.CultureInfo.InvariantCulture);
                        i++;
                    }
                }

                arithmeticObj = new ManagedArithmeticObj(parentWindow.inputBox.Text, probabilities);
                DrawInitialLines(parentWindow.inputBox.Text.Length);
                DrawHorizontalLines(parentWindow.inputBox.Text.Length);

                foreach (TextBox tb in parentWindow.arithmeticPanelGrid.Children.OfType<TextBox>())
                {
                    if (tb.IsVisible)
                    {
                        TextBlock tblock = (TextBlock)parentWindow.arithmeticPanelGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("output"))
                            .Cast<UIElement>().First(a => Grid.GetRow(a) == Grid.GetRow(tb) && Grid.GetColumn(a) == 2);
                        tblock.Text = "[" + arithmeticObj.GetEncodedStart(j) + " : " + arithmeticObj.GetEncodedEnd(j) + "]";
                        j++;
                    }
                }

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
                           TextBlock tblock = (TextBlock)parentWindow.arithmeticPanelGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("output"))
                                              .Cast<UIElement>().First(a => Grid.GetRow(a) == Grid.GetRow(tbox) && Grid.GetColumn(a) == 2);
                           tblock.Text = "";
                    }
                            
                    }
                
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
            };

                visualizationWindow.Children.Add(newLine);
            }

    }

        private void DrawHorizontalLines(int howManySigns)
        {
            int pointOfReference = 450;
            int visualEqualizer = 50;
            int gotY = 0;
            int spacing = 100;
            int x1 = 35;
            int x2 = 10;
            int y1 = 500;
            int y2 = 500;
            int signPosX = 0;

            for (int j = 0; j <= howManySigns; j++)
            {
                x1 += spacing;
                x2 += spacing;

                for (int i = 0; i < howManySigns; i++)
                {
     
                    if (i + 1 != howManySigns)
                    gotY = (int)Math.Floor((pointOfReference * arithmeticObj.GetStartRange(i + 1))) + visualEqualizer;

                    Line newLine = new Line
                    {
                        X1 = x1,
                        X2 = x2,
                        Y1 = gotY,
                        Y2 = gotY,
                        Stroke = Brushes.Black,
                        StrokeThickness = 3
                    };

                    visualizationWindow.Children.Add(newLine);

                }

                signPosX += spacing;

                Line startLine = new Line
                {
                    X1 = x1,
                    X2 = x2,
                    Y1 = 500,
                    Y2 = 500,
                    Stroke = Brushes.Black,
                    StrokeThickness = 3
                };

                visualizationWindow.Children.Add(startLine);

                Line endLine = new Line
                {
                    X1 = x1,
                    X2 = x2,
                    Y1 = 50,
                    Y2 = 50,
                    Stroke = Brushes.Black,
                    StrokeThickness = 3
                };

                visualizationWindow.Children.Add(endLine);

                if (j != howManySigns)
                DrawDottedLine(x1, x2, ((int)Math.Floor((pointOfReference * arithmeticObj.GetStartRange(j))) + visualEqualizer),
                                  ((int)Math.Floor((pointOfReference * arithmeticObj.GetEndRange(j))) + visualEqualizer));

            }
        }

        private void DrawDottedLine(int x1, int x2, int y1, int y2)
        {

            Line initialLineStart = new Line
            {
                StrokeDashArray = new DoubleCollection() { 2, 4 },
                X1 = x1,
                X2 = x1 + 18,
                Y1 = y1,
                Y2 = y1,
                Stroke = Brushes.Black
            };

            Line theLineStart = new Line
            {
                StrokeDashArray = new DoubleCollection() { 2, 4 },
                X1 = x1 + 18,
                X2 = x2 + 100,
                Y1 = y1,
                Y2 = 50,
                Stroke = Brushes.Black
            };

            visualizationWindow.Children.Add(initialLineStart);
            visualizationWindow.Children.Add(theLineStart);

            Line initialLineEnd = new Line
            {
                StrokeDashArray = new DoubleCollection() { 2, 4 },
                X1 = x1,
                X2 = x1 + 18,
                Y1 = y2,
                Y2 = y2,
                Stroke = Brushes.Black
            };

            Line theLineEnd = new Line
            {
                StrokeDashArray = new DoubleCollection() { 2, 4 },
                X1 = x1 + 18,
                X2 = x2 + 100,
                Y1 = y2,
                Y2 = 500,
                Stroke = Brushes.Black
            };

            visualizationWindow.Children.Add(initialLineEnd);
            visualizationWindow.Children.Add(theLineEnd);

            

        }

    }
}
