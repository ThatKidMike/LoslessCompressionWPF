﻿using System;
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
        private double sum = 0.0;

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

            sum = 0.0;

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
            parentWindow.outputRow_1.Text = "";
            parentWindow.outputRow_2.Text = "";
            parentWindow.outputRow_3.Text = "";
            parentWindow.outputRow_4.Text = "";
            parentWindow.outputRow_5.Text = "";
            parentWindow.outputRow_6.Text = "";
            parentWindow.outputRow_7.Text = "";

            foreach (TextBlock tblock in parentWindow.arithmeticPanelGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("sign")).ToList())
            {
                tblock.Text = "";
                tblock.Visibility = Visibility.Hidden;
                TextBox tbox = (TextBox)parentWindow.arithmeticPanelGrid.Children
                                           .Cast<UIElement>()
                                           .First(element => Grid.GetRow(element) == Grid.GetRow(tblock) && Grid.GetColumn(element) == 1);
                tbox.Visibility = Visibility.Hidden;
            }

            foreach (TextBlock tblock in parentWindow.arithmeticPanelGrid.Children.OfType<TextBlock>().Where(x => x.Name.Contains("sign")).ToList())
            {
                tblock.Visibility = Visibility.Visible;
            }

        }

        private void ValidationToProcessCaller(object sender, DependencyPropertyChangedEventArgs e)
        {
            ValidationToProcess(sender);
        }

        private void ValidationToProcess(object sender)
        {

            sum = 0.0;
            bool someEmpty = false;

            parentWindow.proceedButton.IsEnabled = false;

            foreach (TextBox tb in parentWindow.arithmeticPanelGrid.Children.OfType<TextBox>())
            {
                if (tb.IsVisible)
                {
                    if (tb.Text != "")
                        sum += double.Parse(tb.Text, System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            parentWindow.sumRow.Text = sum.ToString();
            sum = double.Parse(parentWindow.sumRow.Text, System.Globalization.CultureInfo.InvariantCulture);

            foreach (TextBox tb in parentWindow.arithmeticPanelGrid.Children.OfType<TextBox>())
            {
                if (tb.IsVisible)
                {
                    if (tb.Text == "")
                        someEmpty = true;
                }
            }

            if (sum == 1 && parentWindow.inputBox.Text.Length >= 2 && !someEmpty)
            {
                parentWindow.proceedButton.IsEnabled = true;
                parentWindow.sumRow.Background = Brushes.ForestGreen;
            }
            else
            {
                parentWindow.proceedButton.IsEnabled = false;
                parentWindow.sumRow.Background = Brushes.IndianRed;
            }
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tb = (TextBox)sender;
                tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ValidationToProcess(sender);
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

            if (tb.Text.Length != 0)
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
                    }
                    else
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

                ValidationToProcess(sender);

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
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(newLine, 0);
                Canvas.SetTop(newLine, 0);
                visualizationWindow.Children.Add(newLine);

            }
        }

        private int CalculateSignY(int signPos)
        {
            int pointOfReference = 450;
            int visualEqualizer = 50;
            int calculatedValue = (((int)Math.Floor((pointOfReference * arithmeticObj.GetEndRange(signPos))) -
                    (int)Math.Floor((pointOfReference * arithmeticObj.GetStartRange(signPos)))) / 2
                + visualEqualizer) + (int)Math.Floor((pointOfReference * arithmeticObj.GetStartRange(signPos)));
            return calculatedValue;
        }

        private double CalculateCurrentProb(int pos, double probStart, double probEnd)
        {
            return arithmeticObj.GetProbability(pos) * (probEnd - probStart);
        }



        private void DrawHorizontalLines(int howManySigns)
        {
            int pointOfReference = 450;
            int visualEqualizer = 50;
            int gotY = 0;
            int spacing = 100;
            int x1 = 35;
            int x2 = 10;
            int signPosX = 0;
            int signX = -5;

            for (int j = 0; j <= howManySigns; j++)
            {
                x1 += spacing;
                x2 += spacing;
                signX += spacing;

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

                    Canvas.SetLeft(newLine, 0);
                    Canvas.SetTop(newLine, 0);
                    visualizationWindow.Children.Add(newLine);

                    for (int k = 0; k < howManySigns; k++)
                    {
                        if (j != howManySigns)
                        {
                            TextBlock signChar = new TextBlock()
                            {
                                Text = arithmeticObj.GetChar(k).ToString()
                            };

                            if (k == j)
                                signChar.FontWeight = FontWeights.ExtraBold;

                            Canvas.SetLeft(signChar, signX);
                            Canvas.SetTop(signChar, CalculateSignY(k));
                            visualizationWindow.Children.Add(signChar);
                        }
                    }

                }



                if (j != howManySigns)
                {

                    double startingProb = arithmeticObj.GetEncodedStart(j);
                    double endingProb = arithmeticObj.GetEncodedEnd(j);

                    TextBlock probStart = new TextBlock()
                    {
                        Text = startingProb.ToString()
                    };

                    Canvas.SetLeft(probStart, signX + 120);
                    Canvas.SetTop(probStart, 50);
                    visualizationWindow.Children.Add(probStart);

                    double calculatedCumulative = startingProb;

                    for (int k = 0; k < howManySigns; k++)
                    {
                        calculatedCumulative += CalculateCurrentProb(k, startingProb, endingProb);

                        TextBlock prob = new TextBlock()
                        {
                            Text = calculatedCumulative.ToString()
                        };

                        Canvas.SetLeft(prob, signX + 120);
                        Canvas.SetTop(prob, (int)Math.Floor((pointOfReference * arithmeticObj.GetEndRange(k))) + visualEqualizer);
                        visualizationWindow.Children.Add(prob);

                    }

                }

                if (j == 0)
                {
                    TextBlock probStart = new TextBlock()
                    {
                        Text = 0.ToString()
                    };

                    Canvas.SetLeft(probStart, signX + 20);
                    Canvas.SetTop(probStart, 50);
                    visualizationWindow.Children.Add(probStart);

                    TextBlock probEnd = new TextBlock()
                    {
                        Text = 1.ToString()
                    };

                    Canvas.SetLeft(probEnd, signX + 20);
                    Canvas.SetTop(probEnd, 500);
                    visualizationWindow.Children.Add(probEnd);

                    for (int i = 0; i < howManySigns; i++)
                    {

                        if (i != howManySigns - 1)
                        {

                            TextBlock initialProb = new TextBlock()
                            {
                                Text = arithmeticObj.GetEndRange(i).ToString()
                            };

                            Canvas.SetLeft(initialProb, signX + 20);
                            Canvas.SetTop(initialProb, (int)Math.Floor((pointOfReference * arithmeticObj.GetEndRange(i))) + visualEqualizer);
                            visualizationWindow.Children.Add(initialProb);

                        }

                    }
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

                Canvas.SetLeft(startLine, 0);
                Canvas.SetTop(startLine, 0);
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

                Canvas.SetLeft(endLine, 0);
                Canvas.SetTop(endLine, 0);
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

            Canvas.SetLeft(initialLineStart, 0);
            Canvas.SetTop(initialLineStart, 0);
            Canvas.SetLeft(theLineStart, 0);
            Canvas.SetTop(theLineStart, 0);
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

            Canvas.SetLeft(initialLineEnd, 0);
            Canvas.SetTop(initialLineEnd, 0);
            Canvas.SetLeft(theLineEnd, 0);
            Canvas.SetTop(theLineEnd, 0);
            visualizationWindow.Children.Add(initialLineEnd);
            visualizationWindow.Children.Add(theLineEnd);

        }

    }
}
