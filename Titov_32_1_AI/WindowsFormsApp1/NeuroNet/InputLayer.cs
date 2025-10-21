using System;
using System.IO;
using Titov_32_1_AI.NeuroNet;

namespace WindowsFormsApp1.NeuroNet
{
    internal class InputLayer
    {
        private double[,] trainset;
        private double[,] testset;

        public double[,] Trainset { get => trainset; }
        public double[,] Testset { get => testset; }

        public InputLayer(NetworkMode nm)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string[] tmpArrStr;
            string[] tmpStr;

            switch(nm)
            {
                case NetworkMode.Train:
                    tmpArrStr = File.ReadAllLines(path + "train.txt");
                    trainset = new double[tmpArrStr.Length, 16];

                    for(int i = 0; i < tmpArrStr.Length;i++)
                    {
                        tmpStr = tmpArrStr[i].Split(' ');

                        for(int j = 0; j < 16; j++)
                        {
                            trainset[i, j] = double.Parse(tmpStr[j]);
                        }
                    }
                    Shuffling_Array_Rows(trainset);
                    break;
                case NetworkMode.Test:
                    tmpArrStr = File.ReadAllLines(path + "test.txt");
                    testset = new double[tmpArrStr.Length, 16];

                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split(' ');

                        for (int j = 0; j < 16; j++)
                        {
                            trainset[i, j] = double.Parse(tmpStr[j]);
                        }
                    }
                    Shuffling_Array_Rows(testset);
                    break;
            }
        }
        public void Shuffling_Array_Rows(double[,] arr)
        {

        }
    }
}
