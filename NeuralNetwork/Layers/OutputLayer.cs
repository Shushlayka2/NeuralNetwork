using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
	public class OutputLayer : Layer
	{
		public OutputLayer(int numofneurons) : base(numofneurons) { }

		public override void SendOutput(Network currentNetwork, Layer nextLayer)
		{
			currentNetwork.NetworkResult = new double[Neurons.Count];
			for (int i = 0; i < Neurons.Count; i++)
				currentNetwork.NetworkResult[i] = Neurons[i].Output;
		}
	}
}
