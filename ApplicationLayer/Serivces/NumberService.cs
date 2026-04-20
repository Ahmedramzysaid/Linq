using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Serivces
{
    public static class NumberService
    {

        public static bool CheckNumber9inList()
        {
            int[] ids = { 3, 9, 13, 18 };


            var result = ids
                            .Any(x => x == 9);

            return result;
        }


        public static List<int> ExpcetLists()
        {
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var result = setA
                              .Except(setB)
                              .ToList();

            return result;

        }

        public static List<string> ExceptContries()
        {
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var result = list1
                                    .Except(list2, StringComparer.OrdinalIgnoreCase)
                                    .ToList();

            return result;
        }
        public static List<string> MultiplicationTableRowFor7()
        {
            var result = Enumerable
                                    .Range(1, 12)
                                    .Select(i => $"7 x {i} = {7 * i}")
                                    .ToList();
            return result;
        }
       
        public static List<int> GenerateEvenNumbers()
        {
            var result = Enumerable
                                    .Range(1, 30)
                                    .Where(n => n % 2 == 0)
                                    .ToList();
            return result;
        }
       
    }
}
