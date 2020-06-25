namespace NeuralNetwork
{
    public class OutputLayer : Layer
    {
        internal OutputLayer(int numofneurons, int numofprevneurons) : base(numofneurons, numofprevneurons) { }

        internal override void CorrectWeights(Network network, double[] rightOutput, double alpha)
        {
            //Gradients sum counting
            network.GrSum = new double[Numofprevneurons];
            for (int i = 0; i < Numofprevneurons; i++)
            {
                double sum = 0;
                for (int j = 0; j < Numofneurons; j++)
                    sum += Neurons[j].Weights[i] * (rightOutput[j] - network.NetworkResult[j]) * Neurons[j].Derivativator();
                sum *= 2;
                network.GrSum[i] = sum;
            }

            for (int i = 0; i < Numofneurons; i++)
            {
                Neuron currentNeuron = Neurons[i];
                for (int j = 0; j < currentNeuron.Weights.Length; j++)
                    if (j != currentNeuron.Weights.Length - 1)
                        currentNeuron.Weights[j] += alpha * 2 * currentNeuron.Inputs[j] * (rightOutput[i] - network.NetworkResult[i]) * currentNeuron.Derivativator();
                    else
                        currentNeuron.Weights[j] += alpha * 2 * (rightOutput[i] - network.NetworkResult[i]) * currentNeuron.Derivativator();
            }
        }

        internal override void SendOutput(Network network, Layer nextLayer)
        {
            network.NetworkResult = new double[Numofneurons];
            for (int i = 0; i < Numofneurons; i++)
                network.NetworkResult[i] = Neurons[i].Output;
        }
    }
}
