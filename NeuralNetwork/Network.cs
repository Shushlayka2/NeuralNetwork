using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Network
    {
		List<Layer> Layers = new List<Layer>();

		public double[] NetworkResult { get; set; }

		public Network(int hiddenLayersCount, int[] neuronsCountInHiddenLayers, int neuronsCountInOutputLayer)
		{
			for (int i = 0; i < hiddenLayersCount; i++)
				Layers.Add(new HiddenLayer(neuronsCountInHiddenLayers[i]));
			Layers.Add(new OutputLayer(neuronsCountInOutputLayer));
		}
    }
}
