using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    
    class Monte
    {
        public List<string> inputs = new List<string>();
        public Random rand = new Random();
        public int average;
        public void addLine (string userInput)
            {
                inputs.Add(userInput);
            }

        public int[] read()
        {
            int min = 0;
            int avg= 0;
            int max = 0;
            
            foreach (string input in inputs)
            {
                var parts = input.Split(',').ToList();
                List<int> intParts = parts.ConvertAll(int.Parse);
                min += intParts.Min();
                avg += (int)intParts.Average();
                max += intParts.Max();
            }

            int[] TimeCases = new int[] { min, avg, max };
            return TimeCases;

        }
        
        public int RandomEstimationGenerator()
        {
            int sum = 0;

            foreach (string input in inputs)
            {
                var parts = input.Split(',').ToList();
                List<int> intParts = parts.ConvertAll(int.Parse);

                int occasion = rand.Next(intParts.Count());
                if (occasion == 0)
                    sum += intParts.Min();
                if (occasion == 1)
                    sum += (int)intParts.Average();;
                if (occasion == 2)
                    sum += intParts.Max();
            }
            return sum;
        }
        public Bucket Simulate ()
        {
            int totalCostOfRandomPlans = 0;
            int iterations = 10000;
            int[] Estimation = read();
            int min = Estimation[0], max = Estimation[2];
            Bucket bucket = new Bucket(10, min, max);
            for (int i = 0; i < iterations; i++)
            {
                int randomPlanCost = 0 ;
                randomPlanCost += RandomEstimationGenerator();
                bucket.AddValueToBucket(randomPlanCost);
                totalCostOfRandomPlans += randomPlanCost;
            }
            //System.Console.WriteLine(bucket);
            average = totalCostOfRandomPlans / iterations;
            return bucket;
           
        }
        public int getAverage()
        {
            return average;
        }

    }
}