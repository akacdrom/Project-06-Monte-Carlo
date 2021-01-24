using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 1;
            string userInput;
            Monte monte = new Monte();

            Console.WriteLine("Enter tasks in the following format: c1,c2,... \nWhere cx is cost \nType END to finish entering tasks.");

            while (true)
            { 
                Console.Write($"Task #{id}: ");
                userInput = Console.ReadLine();
                if (userInput == "END" || userInput == "end")
                {
                    break;
                }
                else
                {
                    monte.addLine(userInput);
                    id++;
                }
            }
            int[] estimatedValue = monte.read();
            Bucket bucket = monte.Simulate();
            Console.WriteLine("\nAfter probing 10000 random plans, The result are:");
            System.Console.WriteLine("Minimum: "+estimatedValue[0]+" days");
            System.Console.WriteLine("Maximum: "+estimatedValue[2]+" days");
            System.Console.WriteLine("Average: "+monte.getAverage()+" days");
            System.Console.WriteLine("Probability of finishing the plan in:");
            System.Console.WriteLine("\n"+bucket);  
            Console.ReadLine();
            bucket.AccumulatedProbabilites();
            Console.WriteLine("Accumulated Probability of finishing the plan in or before:\n" + bucket);
            
        }
    }
}