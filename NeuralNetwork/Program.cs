using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    class Program
    {
		static List<SystemData> TrainSetInput { get; set; }
		static double[] TrainSetOutput { get; set; }

		static void InitializeCustomTrainSet()
		{
			TrainSetInput = new List<SystemData>
			{
				new SystemData("Windows", 4),
				new SystemData("Windows", 1),
				new SystemData("Windows", 16),
				new SystemData("Ubuntu", 1),
				new SystemData("Ubuntu", 6),
				new SystemData("IOS", 1),
				new SystemData("IOS", 16),
				new SystemData("IOS", 4)
			};
			TrainSetOutput = new double[] { 0.25, 0.5, 0, 0.5, 0, 0, 0, 0 };
		}

		static void Main(string[] args)
        {
			InitializeCustomTrainSet();
			Network network = new Network(new int[] { 2, 4, 1 });
			Trainer trainer = new Trainer();
			Console.WriteLine("Learning...");
			for (int j = 0; j < 100000; j++)
				for (int i = 0; i < TrainSetInput.Count; i++)
					trainer.Train(network, new double[] { SystemData.CodeStrings(TrainSetInput[i].OS), TrainSetInput[i].RAM }, new double[] { TrainSetOutput[i] });
			trainer.SaveWeights(network);
			Test(network);
		}

		private static void Test(Network network)
		{
			while (true)
			{
				Console.WriteLine("Enter Os: ");
				double osCode = SystemData.CodeStrings(Console.ReadLine());
				Console.WriteLine("Enter RAM: ");
				double ram = Convert.ToDouble(Console.ReadLine());
				network.Run(new double[] { osCode, ram });
				Console.WriteLine("Result: " + network.NetworkResult[0].ToString());
			}
		}
    }
}
