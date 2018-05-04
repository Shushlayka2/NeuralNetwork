using System;
using System.Collections.Generic;
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
    }
}
