using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
	public class Trainer
	{
		private List<SystemData> Samples { get; set; }
		public double[] Input { get; set; }
		public double[] Output { get; set; }

		public Trainer()
		{
			Samples = new List<SystemData>
			{
				new SystemData("Windows", 4),
				new SystemData("Windows", 1),
				new SystemData("Windows", 16),
				new SystemData("Ubuntu", 1),
				new SystemData("IOS", 16),
				new SystemData("IOS", 4)
			};
			Output = new double[] { 0.25, 0.5, 0, 0.5, 0, 0 };
			Input = (from sample in Samples
					 select CodeStrings(sample.OS)).ToArray();
		}

		private double CodeStrings(string str)
		{
			int[] lettersCount = new int[26];
			str = str.ToLower();
			return BitConverter.ToDouble(Encoding.ASCII.GetBytes(str), 0);
		}

		public void Train(Network network)
		{

		}
    }
}
