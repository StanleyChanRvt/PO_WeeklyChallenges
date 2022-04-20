using System;
using System.Collections;
using System.Linq;

namespace BuildOrder
{
    class Program
    {
        public static string[] BuildOrderSolve(string[] inputProjects, Hashtable dependencies)
        {
            string[] solution = new string[inputProjects.Length];
            string order = inputProjects[0];
            int index = 0;
 

            foreach(string project in inputProjects)
            {
                if(!dependencies.ContainsValue(project))
                {
                    solution[index] = project;
                    index++;
                }
            }//find projects that are independent

            for(int ValueKeys = 0; ValueKeys < inputProjects.Length; ValueKeys++)
            {
                if(dependencies.ContainsKey(inputProjects[ValueKeys]) && dependencies.ContainsValue(inputProjects[ValueKeys]))
                {
                    solution[index] = inputProjects[ValueKeys];
                    index++;
                }
            }//find projects that are both depend on project and projects depend on them

            for(int onlyValues = 0; onlyValues < inputProjects.Length; onlyValues++)
            {
                if (!dependencies.ContainsKey(inputProjects[onlyValues]) && dependencies.ContainsValue(inputProjects[onlyValues]))
                {
                    solution[index] = inputProjects[onlyValues];
                    index++;
                }
            }//find projects that only depend on other projects


            if (index != inputProjects.Length+1)
                Console.WriteLine("valid build order not found");
            return solution;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] projects = new string[6] {"a","b", "c", "d", "e", "f" };
            var dependentPairs = new Hashtable()
            {
                {"a", "d"},
                {"f", "b"},
                {"b", "d"},
                {"f", "a"},
                {"d", "c"}
            };

            projects = BuildOrderSolve(projects, dependentPairs);
        }
    }
}
