using System;
using System.Collections;
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

        private IntPtr currentNodePtr;
        private IntPtr previousNodePtr;
        private string code;
        private Graph graph;
        private List<Tuple<string, string>> sourceDestination;
        private Dictionary<string, string> codedSigns;

        public ManagedHuffmanObj(string inputStream)
        {
            native_huffmanOccurencesCounter = CsharpWrapper.new_OccurencesCounter(inputStream);
            native_pqQueue = CsharpWrapper.GetPqSignContainer(native_huffmanOccurencesCounter);
            native_huffmanTree = CsharpWrapper.new_HuffmanTree(native_pqQueue);
            native_apex = CsharpWrapper.GetApex(native_huffmanTree);

            sourceDestination = new List<Tuple<string, string>>();
            codedSigns = new Dictionary<string, string>();
            graph = new Graph("graph");
        }

        public void delete()
        {
            CsharpWrapper.delete_HuffmanTree(native_huffmanTree);
            CsharpWrapper.delete_OccurencesCounter(native_huffmanOccurencesCounter);
        }

        public IntPtr GetApex()
        {
            return native_apex;
        }

        private struct NodesToBuildTree
        {
            public Node SourceNode { get; set; }
            public Node RightNode { get; set; }
            public Node LeftNode { get; set; }
        }

        public Graph HuffmanTreeTraverse(IntPtr apex)
        {

            Console.WriteLine("----------------------------------------------");

            currentNodePtr = apex;

            while (!(CsharpWrapper.GetLeftNode(apex) == IntPtr.Zero && CsharpWrapper.GetRightNode(apex) == IntPtr.Zero))
            {

                if (CsharpWrapper.GetRightNode(currentNodePtr) != IntPtr.Zero)
                {
                    previousNodePtr = currentNodePtr;
                    currentNodePtr = CsharpWrapper.GetRightNode(currentNodePtr);

                    if (CsharpWrapper.GetSignChar(previousNodePtr).ToString() == "#" &&
                        CsharpWrapper.GetSignChar(currentNodePtr).ToString() == "#")
                    {

                        if (!(sourceDestination.Any(x => x.Item1 == CsharpWrapper.GetId(previousNodePtr).ToString() && x.Item2 == CsharpWrapper.GetId(currentNodePtr).ToString()))) {

                            Edge currentEdge = graph.AddEdge(CsharpWrapper.GetId(previousNodePtr).ToString(), CsharpWrapper.GetId(currentNodePtr).ToString());

                            sourceDestination.Add(new Tuple<string, string>(CsharpWrapper.GetId(previousNodePtr).ToString(), CsharpWrapper.GetId(currentNodePtr).ToString()));

                            currentEdge.LabelText = "1";

                            graph.FindNode(CsharpWrapper.GetId(previousNodePtr).ToString()).LabelText = CsharpWrapper.GetNumOfOccurrences(previousNodePtr).ToString();
                            graph.FindNode(CsharpWrapper.GetId(currentNodePtr).ToString()).LabelText = CsharpWrapper.GetNumOfOccurrences(currentNodePtr).ToString();

                        }

                    }
                    else if (CsharpWrapper.GetSignChar(previousNodePtr).ToString() == "#" &&
                      CsharpWrapper.GetSignChar(currentNodePtr).ToString() != "#")
                    {
                        Edge currentEdge = graph.AddEdge(CsharpWrapper.GetId(previousNodePtr).ToString(), CsharpWrapper.GetSignChar(currentNodePtr).ToString());
                        currentEdge.LabelText = "1";
                        graph.FindNode(CsharpWrapper.GetId(previousNodePtr).ToString()).LabelText = CsharpWrapper.GetNumOfOccurrences(previousNodePtr).ToString();

                    }

                    code += '1';

                }
                else if (CsharpWrapper.GetLeftNode(currentNodePtr) != IntPtr.Zero)
                {
                    previousNodePtr = currentNodePtr;
                    currentNodePtr = CsharpWrapper.GetLeftNode(currentNodePtr);

                    if (CsharpWrapper.GetSignChar(previousNodePtr).ToString() == "#" &&
                       CsharpWrapper.GetSignChar(currentNodePtr).ToString() == "#")
                    {

                        if (!(sourceDestination.Any(x => x.Item1 == CsharpWrapper.GetId(previousNodePtr).ToString() && x.Item2 == CsharpWrapper.GetId(currentNodePtr).ToString())))
                        {

                            Edge currentEdge = graph.AddEdge(CsharpWrapper.GetId(previousNodePtr).ToString(), CsharpWrapper.GetId(currentNodePtr).ToString());

                            sourceDestination.Add(new Tuple<string, string>(CsharpWrapper.GetId(previousNodePtr).ToString(), CsharpWrapper.GetId(currentNodePtr).ToString()));

                            currentEdge.LabelText = "0";

                            graph.FindNode(CsharpWrapper.GetId(previousNodePtr).ToString()).LabelText = CsharpWrapper.GetNumOfOccurrences(previousNodePtr).ToString();
                            graph.FindNode(CsharpWrapper.GetId(currentNodePtr).ToString()).LabelText = CsharpWrapper.GetNumOfOccurrences(currentNodePtr).ToString();

                        }


                    }
                    else if (CsharpWrapper.GetSignChar(previousNodePtr).ToString() == "#" &&
                      CsharpWrapper.GetSignChar(currentNodePtr).ToString() != "#")
                    {
                        Edge currentEdge = graph.AddEdge(CsharpWrapper.GetId(previousNodePtr).ToString(), CsharpWrapper.GetSignChar(currentNodePtr).ToString());
                        currentEdge.LabelText = "0";
                        graph.FindNode(CsharpWrapper.GetId(previousNodePtr).ToString()).LabelText = CsharpWrapper.GetNumOfOccurrences(previousNodePtr).ToString();

                    }

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
                        codedSigns.Add(CsharpWrapper.GetSignChar(currentNodePtr).ToString(), code);
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

        public Dictionary<string, string> GetCodedSigns()
        {
            return codedSigns;
        }
    }

}
