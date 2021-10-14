using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static IEnumerable<IEnumerable<int>> RecursiveCartesian(List<List<int>> numbers)
        {
            if(numbers.Count==0)
                return new List<IEnumerable<int>>();
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < numbers[0].Count; i++)
            {
                List<List<int>> rest = numbers.GetRange(1, numbers.Count - 1);
                IEnumerable<IEnumerable<int>> rc =  RecursiveCartesian(rest);
                foreach (var enumerable in rc)
                {
                    List<int> current = new List<int>();
                    current.Add(numbers[0][i]);
                    foreach (var i1 in enumerable)
                    {
                        current.Add(i1);
                    }
                    result.Add(current);
                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            // tier 1 (1,2,3,4,5,6)
            // tier 2 (7,8,9)
            // tier 3 (20,30,40)
            // tier 4 (120,130,140)

            // i = 0..5 
            // 1,7,20,120
            // 2,7,20,120
            // 3,7,20,120
            // ..
            // 6,7,20,120

            // j = 0..2
            // 1,8,20,120
            // 2,8,20,120


            int[][] tiers = {new[] {1, 2, 3, 4, 5, 6}, new[] {7, 8, 9}, new[] {20, 30, 40}, new[] {120, 130, 140}};

            int[] control = {0, 0, 0, 0};
            
            
            while(true)
            {
                // Console.Out.WriteLine(
                    // $"{tiers[0][control[0]]},{tiers[1][control[1]]},{tiers[2][control[2]]},{tiers[3][control[3]]}");
                Console.Out.WriteLine(String.Join(",", from c in control select c.ToString()));
                var overflow = false;
                int i=0;
                do
                {
                    control[i]++;
                    if (control[i] == tiers[i].Length)
                    {
                        overflow = true;
                        control[i] = 0;
                        i++;
                    }
                    else
                    {
                        overflow = false;
                    }
                } while (i<control.Length && overflow == true);

                if (overflow == true)
                    return;
                //
            }

            Console.WriteLine("Hello World!");
        }
    }
}