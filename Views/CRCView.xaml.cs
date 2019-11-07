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
    /// Logika interakcji dla klasy CRCView.xaml
    /// </summary>
    public partial class CRCView : UserControl
    {

        private ManagedCRCObj crcOBJ;
        private MainWindow parentWindow;
        private string chosenCRC;
        private bool handle = true;

        public CRCView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    parentWindow.proceedButton.IsEnabled = false;
                    parentWindow.inputBox.TextChanged += CheckIfReadyToGo;
                    parentWindow.proceedButton.Click += ProceedButtonClicked;
                    parentWindow.crcBox.SelectionChanged += SelectionChanged;
                    parentWindow.crcBox.DropDownClosed += DropDownClosed;
                    parentWindow.crcBox.DropDownClosed += MainCheckReady;

                    parentWindow.polynomialBinaryForm.Text = "";
                    parentWindow.polynomialTrueForm.Text = "";
                    parentWindow.crcBox.SelectedIndex = -1;
                }
            };

        }

        private void MainCheckReady(object sender, EventArgs e)
        {
            CheckIfReadyToGo(null, null);
        }

        private void DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void Handle()
        {
            if (parentWindow.crcBox.SelectedItem != null)
            {
                switch (parentWindow.crcBox.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
                {
                    case "CRC-4-ITU":
                        UnicodeSuperScript("CRC-4-ITU");
                        break;
                    case "CRC-5-ITU":
                        UnicodeSuperScript("CRC-5-ITU");
                        break;
                    case "CRC-5-USB":
                        UnicodeSuperScript("CRC-5-USB");
                        break;
                    case "CRC-6-ITU":
                        UnicodeSuperScript("CRC-6-ITU");
                        break;
                    case "CRC-7":
                        UnicodeSuperScript("CRC-7");
                        break;
                    case "CRC-8-ATM":
                        UnicodeSuperScript("CRC-8-ATM");
                        break;
                    case "CRC-8-CCITT":
                        UnicodeSuperScript("CRC-8-CCITT");
                        break;
                }
            }
            else
            {
                parentWindow.polynomialTrueForm.Text = "";
                parentWindow.polynomialBinaryForm.Text = "";
            }
        }

        private void UnicodeSuperScript(string input)
        {

            switch (input)
            {
                case "CRC-4-ITU":
                    parentWindow.polynomialTrueForm.Text = "x\x2074 + x + 1";
                    parentWindow.polynomialBinaryForm.Text = "10011";
                    chosenCRC = "10011";
                    break;
                case "CRC-5-ITU":
                    parentWindow.polynomialTrueForm.Text = "x\x2075 + x\x2074 + x\x00B2 + 1";
                    parentWindow.polynomialBinaryForm.Text = "110101";
                    chosenCRC = "110101";
                    break;
                case "CRC-5-USB":
                    parentWindow.polynomialTrueForm.Text = "x\x2075 + x\x00B2 + 1";
                    parentWindow.polynomialBinaryForm.Text = "100101";
                    chosenCRC = "100101";
                    break;
                case "CRC-6-ITU":
                    parentWindow.polynomialTrueForm.Text = "x\x2076 + x + 1";
                    parentWindow.polynomialBinaryForm.Text = "1000011";
                    chosenCRC = "1000011";
                    break;
                case "CRC-7":
                    parentWindow.polynomialTrueForm.Text = "x\x2077 + x\x00B3 + 1";
                    parentWindow.polynomialBinaryForm.Text = "10001001";
                    chosenCRC = "10001001";
                    break;
                case "CRC-8-ATM":
                    parentWindow.polynomialTrueForm.Text = "x\x2078 + x\x00B2 + x + 1";
                    parentWindow.polynomialBinaryForm.Text = "100000111";
                    chosenCRC = "100000111";
                    break;
                case "CRC-8-CCITT":
                    parentWindow.polynomialTrueForm.Text = "x\x2078 + x\x2077 + x\x00B3 + x\x00B2 + 1";
                    parentWindow.polynomialBinaryForm.Text = "110001101";
                    chosenCRC = "110001101"; ;
                    break;
            }

        }

        private void CheckIfReadyToGo(object sender, TextChangedEventArgs e)
        {
            if (parentWindow.inputBox.Text != "" && parentWindow.crcBox.SelectedItem != null)
            {
                parentWindow.proceedButton.IsEnabled = true;

            }
            else
            {
                parentWindow.proceedButton.IsEnabled = false;
            }
        }

        private void ProceedButtonClicked(object sender, RoutedEventArgs e)
        {
            string previousXor;
            string currentXor;
            string spaceEqualizer = "  ";
            string spaceCRCEqualizer = "    ";

            if (parentWindow.DataContext.GetType() == typeof(CRCViewModel) && parentWindow.inputBox.Text != "" && parentWindow.crcBox.SelectedItem != null)
            {
                crcOBJ = new ManagedCRCObj(parentWindow.inputBox.Text, chosenCRC);
                int xorListLength = crcOBJ.GetXORListLength();
                testingText.FontSize = 15;
                for (int i = 0; i < xorListLength; i++)
                {
                    if (i == 0)
                    {
                        testingText.Text += System.Runtime.InteropServices.Marshal.PtrToStringAnsi(crcOBJ.GetXORResult(i)) + "\n";
                        currentXor = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(crcOBJ.GetXORResult(i));
                        testingText.Text += chosenCRC + "\n";

                        for (int j = 0; j < currentXor.Length; j++)
                        {
                            testingText.Text += "-";
                        }

                        testingText.Text += "\n";
                    }
                    else if (i > 0 && i < xorListLength - 1)
                    {
                        testingText.Text += spaceEqualizer + "0" + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(crcOBJ.GetXORResult(i)) + "\n";
                        currentXor = spaceEqualizer + "0" + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(crcOBJ.GetXORResult(i)); 

                        if (i == 1)
                            testingText.Text += spaceEqualizer + spaceEqualizer + chosenCRC + "\n";
                        else
                            testingText.Text += spaceCRCEqualizer + chosenCRC + "\n";

                        for (int j = 0; j < currentXor.Length; j++)
                        {
                            if (currentXor.ElementAt(j) == ' ')
                                testingText.Text += " ";
                            else
                                testingText.Text += "-";
                        }

                        testingText.Text += "\n";

                        spaceEqualizer += "  ";
                        spaceCRCEqualizer += "  ";

                    }
                    else if (i == xorListLength - 1)
                    {
                        testingText.Text += spaceEqualizer + "0" + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(crcOBJ.GetXORResult(i)) + "\n";
                        spaceEqualizer += "  ";
                    }

                }
                crcOBJ.delete();
            }
        }
    }

}

