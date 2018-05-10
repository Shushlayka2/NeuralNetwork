using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
	public class HiddenLayer : Layer
	{
		internal HiddenLayer(int numofneurons, int numofprevneurons) : base(numofneurons, numofprevneurons) { }

		internal override void CorrectWeights(Network network, double[] rightOutput, double alpha)
		{
			//Gradients sums
			double[] grSum = new double[Numofprevneurons];
			for (int i = 0; i < Numofprevneurons; i++)
			{
				double sum = 0;
				for (int j = 0; j < Numofneurons; j++)
					sum += Neurons[j].Weights[i] * network.GrSum[j] * Neurons[j].Derivativator();
				sum *= 2;
				grSum[i] = sum;
			}

			for (int i = 0; i < Numofneurons; i++)
			{
				Neuron currentNeuron = Neurons[i];
				for (int j = 0; j < currentNeuron.Weights.Length; j++)
					if (j != currentNeuron.Weights.Length - 1)
						currentNeuron.Weights[j] += alpha * currentNeuron.Inputs[j] * network.GrSum[i] * currentNeuron.Derivativator();
					else
						currentNeuron.Weights[j] += alpha * network.GrSum[i] * currentNeuron.Derivativator();
			}

			network.GrSum = grSum;
		}

		internal override void SendOutput(Network network, Layer nextLayer)
		{
			for (int i = 0; i < nextLayer.Neurons.Count; i++)
			{
				nextLayer.Neurons[i].Inputs = new double[Neurons.Count];
				for (int j = 0; j < Neurons.Count; j++)
					nextLayer.Neurons[i].Inputs[j] = Neurons[j].Output;
			}
		}
	}
}
