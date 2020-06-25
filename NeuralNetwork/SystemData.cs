using System;
using System.Text;

namespace NeuralNetwork
{
    public class SystemData
    {
        public string OS { get; set; }
        public int RAM { get; set; }

        public SystemData(string os, int ram)
        {
            OS = os;
            RAM = ram;
        }

        public static double CodeStrings(string str)
        {
            //if (str == "Windows")
            //	return 10;
            //if (str == "Ubuntu")
            //	return 20;
            //if (str == "IOS")
            //	return 30;
            //return 0;
            str = str.ToLower();
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            byte[] extendedBytes = new byte[128];
            Array.Copy(bytes, extendedBytes, bytes.Length);
            double result = BitConverter.ToDouble(extendedBytes, 0);
            for (int i = 0; i < 307; i++)
                result *= 10;
            return result;
        }
    }
}
