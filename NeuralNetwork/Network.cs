using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Network
    {
		internal List<Layer> Layers = new List<Layer>();

		internal double[] NetworkResult { get; set; }

		internal double[] GrSum { get; set; }

		public Network(int[] neuronsCountInLayers)
		{
			int hiddenLayersCount = neuronsCountInLayers.Length - 2;
			for (int i = 0; i < hiddenLayersCount; i++)
				Layers.Add(new HiddenLayer(neuronsCountInLayers[i + 1], neuronsCountInLayers[i]));
			Layers.Add(new OutputLayer(neuronsCountInLayers[neuronsCountInLayers.Length - 1], neuronsCountInLayers[neuronsCountInLayers.Length - 2]));
		}

		public double[] Run(double[] inputData)
		{
			foreach (Neuron neuron in Layers[0].Neurons)
				neuron.Inputs = inputData;
			for (int i = 1; i < Layers.Count; i++)
				Layers[i - 1].SendOutput(this, Layers[i]);
			Layers[Layers.Count - 1].SendOutput(this, null);
			return NetworkResult;
		}
    }
}
