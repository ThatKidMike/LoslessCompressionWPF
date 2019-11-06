using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFInterop
{
    class ManagedCRCObj
    {
        private IntPtr native_CRC;

        public ManagedCRCObj(string msg, string chosenCRC)
        {
            native_CRC = CsharpWrapper.new_CRC(msg, chosenCRC);
        }

        public void delete()
        {
            CsharpWrapper.delete_CRC(native_CRC);
        }

        public int GetXORListLength()
        {
            return CsharpWrapper.GetXORListLength(native_CRC);
        }

        public string GetXORResult(int wichOne)
        {
            return CsharpWrapper.GetXORResult(native_CRC, wichOne);
        }
    }
}
