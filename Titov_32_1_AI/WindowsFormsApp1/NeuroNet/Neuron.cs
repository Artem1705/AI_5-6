using System;
using static System.Math;

namespace Titov_32_1_AI.NeuroNet
{
    class Neuron
    {
        // поля
        private NeuronType type; //тип нейрона
        private double[] weights; //его веса
        private double[] inputs; //его входы
        private double output;
        private double derivative;

        //константы для функц активации
        private double a = 0.01d;

        //свойства
        public double[] Weights { get => weights; set => weights = value; }
        public double[] Inputs { get => inputs; set => inputs = value; }
        public double Output { get => output; }
        public double Derivative { get => derivative; }

        //конструктор
        public Neuron(double[] memoryWeights, NeuronType typeNeuron)
        {
            type = typeNeuron;
            weights = memoryWeights;
        }
        public static double Tanh(double x)
        {
            return Math.Tanh(x);
        }
        public static double TanhDerivative(double x)
        {
            double tanh = Math.Tanh(x);
            return 1 - tanh * tanh;
        }
        public void Activator(double[] i)
        {
            inputs = i;
            double sum = weights[0];
            for (int j = 0; j < inputs.Length; j++)
            {
                sum += inputs[j] * weights[j + 1];
            }

            switch (type)
            {
                case NeuronType.Hidden:
                    output = Tanh(sum);
                    derivative = TanhDerivative(sum);
                    break;
                case NeuronType.Output:
                    output = Exp(sum);
                    break;
            }
        }
    }

}
