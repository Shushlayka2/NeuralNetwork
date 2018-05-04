using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
	public class Neuron
	{
		private static int counter = 0;
		public static void RestartCounter() => counter = 0;

		public int NeuronNum { get; }
		public double[] Weights { get; set; }
		public double[] Inputs { get; set; }
		public double Output { get => Activator(Inputs, Weights); }

		public Neuron()
		{
			NeuronNum = counter++;
		}

		private double Activator(double[] i, double[] w)
		{
			double sum = 0;
			for (int l = 0; l < i.Length; l++)
				sum += i[l] * w[l];
			return Math.Pow(1 + Math.Exp(-sum), -1);
		}

		public double Derivativator(double outsignal) => outsignal * (1 - outsignal);

	}
}
