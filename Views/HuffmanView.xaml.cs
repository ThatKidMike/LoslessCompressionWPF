﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Msagl.Drawing;
using WPFInterop.ViewModels;

namespace WPFInterop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy HuffmanView.xaml
    /// </summary>
    public partial class HuffmanView : System.Windows.Controls.UserControl
    {
        private ManagedHuffmanObj huffmanObj;
        private MainWindow parentWindow;

        public HuffmanView()
        {
            InitializeComponent();
            gViewer.ToolBarIsVisible = false;
            gViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(_ViewerKeyDown);
            KeyDown += HostWindowKeyDown;
            KeyUp += HostWindowKeyUp;
            gViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(_ViewerMouseClick);

            System.Drawing.SolidBrush solidWhite = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            gViewer.OutsideAreaBrush = solidWhite;

            Loaded += (s, e) =>
            {
                parentWindow = Window.GetWindow(this) as MainWindow;
                if (parentWindow != null)
                {
                    parentWindow.inputBox.TextChanged += CheckIfReadyToGo;
                    parentWindow.proceedButton.Click += ProceedButtonClicked;
                    parentWindow.proceedButton.IsEnabled = false;
                }
            };

        }

        private void CheckIfReadyToGo(object sender, TextChangedEventArgs e)
        {
            if (parentWindow.inputBox.Text.Length >= 3)
                parentWindow.proceedButton.IsEnabled = true;
            else
                parentWindow.proceedButton.IsEnabled = false;
        }

        private void ProceedButtonClicked(object sender, RoutedEventArgs e)
        {
            if (parentWindow.DataContext.GetType() == typeof(HuffmanViewModel) && parentWindow.inputBox.Text != "")
            {
                huffmanObj = new ManagedHuffmanObj(parentWindow.inputBox.Text);
                parentWindow.codedTextBox.Clear();
                gViewer.Graph = huffmanObj.HuffmanTreeTraverse(huffmanObj.GetApex());
                OutputCodedMessage();
                huffmanObj.delete();
            }
        }

        private void HostWindowKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftCtrl:
                    _ViewerKeyDown(null, new System.Windows.Forms.KeyEventArgs(Keys.Control));
                    break;
            }
        }

        private void HostWindowKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftCtrl:
                    _ViewerKeyUp(null, new System.Windows.Forms.KeyEventArgs(Keys.Control));
                    break;
            }

        }

        private void _ViewerKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                gViewer.PanButtonPressed = true;
                UpdateCursor(System.Windows.Forms.Cursors.Hand);
            }
        }

        private void _ViewerKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (!Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                gViewer.PanButtonPressed = false;
                UpdateCursor(System.Windows.Forms.Cursors.Default);
            }
        }

        private void UpdateCursor(System.Windows.Forms.Cursor cursor)
        {
            gViewer.Cursor = cursor;
        }

        private void _ViewerMouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (gViewer.SelectedObject.GetType() == typeof(Node) && gViewer.SelectedObject != null)
                {
                    var selectedObj = gViewer.SelectedObject;
                    Node selectedNode = (Node)selectedObj;
                    string code = huffmanObj.GetCodedSigns()[selectedNode.LabelText];
                    if (code != null)
                    {
                        parentWindow.huffmanCodedSpace.Text = code;
                        parentWindow.huffmanSignSpace.Text = selectedNode.LabelText;
                        parentWindow.huffmanOccurrencesSpace.Text = huffmanObj.GetOccurrenesSigns()[selectedNode.LabelText].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void OutputCodedMessage()
        {
            for (int i = 0; i < parentWindow.inputBox.Text.Length; i++)
            {
                parentWindow.codedTextBox.Text += huffmanObj.GetCodedSigns()[parentWindow.inputBox.Text.ElementAt(i).ToString()];
                parentWindow.codedTextBox.Text += ".";
            }
        }
    }
}
