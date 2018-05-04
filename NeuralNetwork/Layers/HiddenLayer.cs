using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
	public class HiddenLayer : Layer
	{
		public HiddenLayer(int numofneurons) : base(numofneurons) { }

		public override void SendOutput(Network network, Layer nextLayer)
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
