using System;
using System.Collections.Generic;
using System.Text;

namespace WPFInterop
{
    class ManagedArithmeticObj
    {

        private IntPtr native_arithmetic_instance;

        public ManagedArithmeticObj(string inputStream, double[] probabilities)
        {
            native_arithmetic_instance = CsharpWrapper.new_ProcessInput(inputStream, probabilities);
        }

        public void delete()
        {
            CsharpWrapper.delete_ProcessInput(native_arithmetic_instance);
        }

        public char GetChar(int positionNumber)
        {
            return CsharpWrapper.new_GetSign(native_arithmetic_instance, positionNumber);
        }

        public int GetProbability(int positionNumber)
        {
            return CsharpWrapper.new_GetProbability(native_arithmetic_instance, positionNumber);
        }

        public double GetStartRange(int positionNumber)
        {
            return CsharpWrapper.new_GetStartRange(native_arithmetic_instance, positionNumber);
        }

        public double GetEndRange(int positionNumber)
        {
            return CsharpWrapper.new_GetEndRange(native_arithmetic_instance, positionNumber);
        }

        public double GetEncodedStart(int positionNumber)
        {
            return CsharpWrapper.new_GetEncodedStart(native_arithmetic_instance, positionNumber);
        }

        public double GetEncodedEnd(int positionNumber)
        {
            return CsharpWrapper.new_GetEncodedEnd(native_arithmetic_instance, positionNumber);
        }

        public double GetEncode()
        {
            return CsharpWrapper.new_GetEncode(native_arithmetic_instance);
        }

    }
}
