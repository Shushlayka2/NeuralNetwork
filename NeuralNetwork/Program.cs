using System;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
			Network network = new Network(1, new int[] { 4 }, 1);
			Trainer trainer = new Trainer();
			trainer.Train(network);
        }
    }
}
