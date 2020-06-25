using System.ComponentModel.DataAnnotations;

namespace NeuralNetwork.Models
{
    public class Weight
    {
        public int Id { get; set; }

        [Required]
        public double Value { get; set; }
        [Required]
        public int LayerNum { get; set; }
        [Required]
        public int NeuronNum { get; set; }

        public Weight() { }

        public Weight(double value, int layerNum, int neuronNum)
        {
            Value = value;
            LayerNum = layerNum;
            NeuronNum = neuronNum;
        }
    }
}
