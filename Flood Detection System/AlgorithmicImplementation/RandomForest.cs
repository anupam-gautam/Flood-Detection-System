//namespace Flood_Detection_System.AlgorithmicImplementation
//{
//    public class RandomForest
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomForestExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a dataset of examples
            List<Example> examples = new List<Example>();
            examples.Add(new Example { Rainfall = 0.5, SoilMoisture = 0.7, FloodRisk = false });
            examples.Add(new Example { Rainfall = 0.9, SoilMoisture = 0.8, FloodRisk = true });
            examples.Add(new Example { Rainfall = 0.2, SoilMoisture = 0.5, FloodRisk = false });
            examples.Add(new Example { Rainfall = 0.7, SoilMoisture = 0.9, FloodRisk = true });
            examples.Add(new Example { Rainfall = 0.1, SoilMoisture = 0.3, FloodRisk = false });

            // Create a random forest with 10 trees
            RandomForest forest = new RandomForest(10);

            // Train the random forest on the dataset
            forest.Train(examples);

            // Test the random forest on a new example
            Example testExample = new Example { Rainfall = 0.6, SoilMoisture = 0.7 };
            bool prediction = forest.Predict(testExample);
            Console.WriteLine("Prediction: " + prediction);
        }
    }

    class Example
    {
        public double Rainfall { get; set; }
        public double SoilMoisture { get; set; }
        public bool FloodRisk { get; set; }
    }

    class DecisionTree
    {
        public DecisionTree Left { get; set; }
        public DecisionTree Right { get; set; }
        public int Feature { get; set; }
        public double Threshold { get; set; }
        public bool Result { get; set; }

        public bool Predict(Example example)
        {
            if (Left == null && Right == null)
            {
                return Result;
            }

            if (example.GetType().GetProperty(Feature).GetValue(example) < Threshold)
            {
                return Left.Predict(example);
            }
            else
            {
                return Right.Predict(example);
            }
        }
    }

    class RandomForest
    {
        private List<DecisionTree> trees;

        public RandomForest(int treeCount)
        {
            trees = new List<DecisionTree>();
            for (int i = 0; i < treeCount; i++)
            {
                trees.Add(new DecisionTree());
            }
        }

        public void Train(List<Example> examples)
        {
            // Train each decision tree in the random forest
            foreach (DecisionTree tree in trees)
            {
                // Select a random subset of the examples to train on
                List<Example> subset = examples.OrderBy(x => Guid.NewGuid()).Take(examples.Count / 2).ToList();

                // Train the decision tree on the subset
                tree.Train(subset);
            }

