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
using Microsoft.Msagl.Drawing;

namespace WPFInterop
{
    class ManagedHuffmanObj
    {

        private IntPtr native_huffmanOccurencesCounter;
        private IntPtr native_huffmanTree;
        private IntPtr native_pqQueue;
        private IntPtr native_apex;
        private IntPtr native_huffmanTraverse;

        private IntPtr currentNodePtr;
        private IntPtr previousNodePtr;
        private string code;
        private Graph graph;

        public ManagedHuffmanObj(string inputStream)
        {
            native_huffmanOccurencesCounter = CsharpWrapper.new_OccurencesCounter(inputStream);
            native_pqQueue = CsharpWrapper.GetPqSignContainer(native_huffmanOccurencesCounter);
            native_huffmanTree = CsharpWrapper.new_HuffmanTree(native_pqQueue);
            native_apex = CsharpWrapper.GetApex(native_huffmanTree);
            //native_huffmanTraverse = CsharpWrapper.new_HuffmanTreeTraverse(native_apex);

            graph = new Graph("graph");
        }

        public void delete()
        {
            CsharpWrapper.delete_HuffmanTree(native_huffmanTree);
            CsharpWrapper.delete_OccurencesCounter(native_huffmanOccurencesCounter);
            //CsharpWrapper.delete_HuffmanTreeTraverse(native_huffmanTraverse);
        }

        public IntPtr GetApex()
        {
            return native_apex;
        }

        public Graph HuffmanTreeTraverse(IntPtr apex)
        {

            Console.WriteLine("----------------------------------------------");

            currentNodePtr = apex;
            graph.AddNode(CsharpWrapper.GetSignChar(currentNodePtr).ToString());

            while (!(CsharpWrapper.GetLeftNode(apex) == IntPtr.Zero && CsharpWrapper.GetRightNode(apex) == IntPtr.Zero))
            {

                if (CsharpWrapper.GetRightNode(currentNodePtr) != IntPtr.Zero)
                {
                    previousNodePtr = currentNodePtr;
                    currentNodePtr = CsharpWrapper.GetRightNode(currentNodePtr);
                    graph.AddEdge(CsharpWrapper.GetSignChar(previousNodePtr).ToString(), CsharpWrapper.GetSignChar(currentNodePtr).ToString());
                    code += '1';

                }
                else if (CsharpWrapper.GetLeftNode(currentNodePtr) != IntPtr.Zero)
                {
                    previousNodePtr = currentNodePtr;
                    currentNodePtr = CsharpWrapper.GetLeftNode(currentNodePtr);
                    graph.AddEdge(CsharpWrapper.GetSignChar(previousNodePtr).ToString(), CsharpWrapper.GetSignChar(currentNodePtr).ToString());
                    code += '0';
                }
                else
                {

                    if (CsharpWrapper.GetSignChar(currentNodePtr) != '#')
                    {
                        
                        if (code[code.Length - 1] == '1')
                        {
                            CsharpWrapper.SetRightNodeNull(previousNodePtr);
                        }
                        else if (code[code.Length - 1] == '0')
                        {
                            CsharpWrapper.SetLeftNodeNull(previousNodePtr);
                        }
                        CsharpWrapper.SetSignCode(currentNodePtr, code);
                        Console.WriteLine(CsharpWrapper.GetSignChar(currentNodePtr) + " :: " + code);
                        code = "";
                    }
                    else if (CsharpWrapper.GetSignChar(currentNodePtr) == '#')
                    {
                        if (code[code.Length - 1] == '1')
                        {
                            CsharpWrapper.SetRightNodeNull(previousNodePtr);
                        }
                        else if (code[code.Length - 1] == '0')
                        {
                            CsharpWrapper.SetLeftNodeNull(previousNodePtr);
                        }
                        code = "";
                    }

                    currentNodePtr = apex;

                }

            }

            return graph;

        }

    }
}
