using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.Client.Services
{
    public static class ModbusFloatConverter
    {
        public static float ToFloatCDAB(ushort reg1, ushort reg2)
        {
           // System.Diagnostics.Debug.WriteLine(reg1);
          //  System.Diagnostics.Debug.WriteLine(reg2);


            byte[] bytes =
            {
                (byte)(reg1 & 0xFF),  (byte)(reg1 >> 8),
                (byte)(reg2 & 0xFF), (byte)(reg2 >> 8)
            };

            float value = BitConverter.ToSingle(bytes, 0);
        
            return (float)Math.Round(value, 2); // limit to 2 decimals
        }
     

    }
}

