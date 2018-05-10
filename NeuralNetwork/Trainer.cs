using NeuralNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
	public class Trainer
	{
		private double Alpha = 0.1;

		public void SetAlpha(double alpha)
		{
			Alpha = alpha;
		}

		public void Train(Network network, double[] input, double[] output)
		{
			for (int i = 0; i < 3; i++)
			{
				network.Run(input);
				for (int j = network.Layers.Count - 1; j >= 0; j--)
				{
					network.Layers[j].CorrectWeights(network, output, Alpha);
				}
			}
		}

		internal void SaveWeights(Network network)
		{
			for (int i = 0; i < network.Layers.Count; i++)
				for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
					for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
						using (WeightsDBContext db = new WeightsDBContext())
						{
							Weight weight = (from w in db.Weights
											where w.LayerNum == i && w.NeuronNum == j
											select w).First();
							weight.Value = network.Layers[i].Neurons[j].Weights[k];
							db.Weights.Update(weight);
							db.SaveChanges();
						}
		}
	}
}
