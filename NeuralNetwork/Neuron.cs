using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
	public class Neuron
	{
		private static int counter = 0;
		internal static void RestartCounter() => counter = 0;

		internal int NeuronNum { get; }
		internal double[] Weights { get; set; }
		internal double[] Inputs { get; set; }
		internal double Output { get => Activator(Inputs, Weights); }

		internal Neuron()
		{
			NeuronNum = counter++;
		}

		private double Activator(double[] i, double[] w)
		{
			double sum = 0;
			for (int l = 0; l < i.Length; l++)
				sum += i[l] * w[l];
			sum += w[w.Length - 1];
			return Math.Pow(1 + Math.Exp(-sum), -1);
		}

		internal double Derivativator() => Output * (1 - Output);
	}
}
