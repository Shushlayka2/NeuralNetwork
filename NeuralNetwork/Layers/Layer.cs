using NeuralNetwork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeuralNetwork
{
    public abstract class Layer
    {
		private static int counter = 0;
		private Random rnd = new Random(1);

		internal int LayerNum { get; }
		protected int Numofneurons;
		protected int Numofprevneurons;
		internal List<Neuron> Neurons { get; set; }

		internal Layer(int numofneurons, int numofprevneurons)
		{
			Neuron.RestartCounter();
			LayerNum = counter++;
			Numofneurons = numofneurons;
			Numofprevneurons = numofprevneurons;
			Neurons = new List<Neuron>();

			for (int i = 0; i < Numofneurons; i++)
			{
				Neuron neuron = new Neuron();
				neuron.Weights = GetWeights(LayerNum, neuron.NeuronNum);
				Neurons.Add(neuron);
			}
		}

		private double[] GetWeights(int layerNum, int neuronNum)
		{
			double[] result = null;
			using (WeightsDBContext db = new WeightsDBContext())
			{
				result = (from weight in db.Weights
						  where weight.LayerNum == layerNum && weight.NeuronNum == neuronNum
						  select weight.Value).ToArray();
				if (result.Length == 0)
				{
					for (int i = 0; i < Numofprevneurons + 1; i++)
						db.Weights.Add(new Weight(0.1, layerNum, neuronNum));
					db.SaveChanges();
					return GetWeights(layerNum, neuronNum);
				}
					
			}
			return result;
		}

		abstract internal void SendOutput(Network network, Layer nextLayer);

		abstract internal void CorrectWeights(Network network, double[] rightOutput, double alpha);
    }
}
