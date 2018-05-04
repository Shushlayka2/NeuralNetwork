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

		public int LayerNum { get; }
		protected int Numofneurons;
		public List<Neuron> Neurons { get; set; }

		public Layer(int numofneurons)
		{
			Neuron.RestartCounter();
			LayerNum = counter++;
			Numofneurons = numofneurons;
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
			}
			return result;
		}

		abstract public void SendOutput(Network currentNetwork, Layer nextLayer);

    }
}
