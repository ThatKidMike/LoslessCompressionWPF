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
            gViewer.ToolBarIsVisible = false;
            theButton.Click += TheButton_Click;
            MouseWheel += mouseWheel;


            System.Drawing.SolidBrush solidWhite = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            gViewer.OutsideAreaBrush = solidWhite;

        }

        private void TheButton_Click(object sender, RoutedEventArgs e)
        {

            if (inputBox.Text != "")
            {
                ManagedHuffmanObj obj = new ManagedHuffmanObj(inputBox.Text);

                gViewer.Graph = obj.HuffmanTreeTraverse(obj.GetApex());

                obj.delete();

            }
        }

        private void mouseWheel(object sender, RoutedEventArgs e)
        {
            gViewer.Pan(0, 10);
        }

    }
}
