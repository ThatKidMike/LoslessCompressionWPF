using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WPFInterop
{
    class CsharpWrapper
    {
        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr new_ProcessInput(string str);

        [DllImport("ArithmeticCodingLibrary.dll")]
        public static extern void delete_ProcessInput(IntPtr instance);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char new_GetSign(IntPtr instance, int positionNumber);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int new_GetProbability(IntPtr instance, int positionNumber);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double new_GetStartRange(IntPtr instance, int positionNumber);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double new_GetEndRange(IntPtr instance, int positionNumber);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double new_GetEncodedStart(IntPtr instance, int positionNumber);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double new_GetEncodedEnd(IntPtr instance, int positionNumber);

        [DllImport("ArithmeticCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double new_GetEncode(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr new_OccurencesCounter(string str);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_OccurencesCounter(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr new_HuffmanTree(IntPtr pqQueueInstance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_HuffmanTree(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetPqSignContainer(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr new_HuffmanTreeTraverse(IntPtr huffmanTreeTraverse);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_HuffmanTreeTraverse(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetApex(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char GetSignChar(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumOfOccurrences(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSignCode(IntPtr instance, string code);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetSignCoded(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetLeftNode(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRightNode(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLeftNodeNull(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRightNodeNull(IntPtr instance);

        [DllImport("HuffmanCodingLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetId(IntPtr instance);
    }
}
