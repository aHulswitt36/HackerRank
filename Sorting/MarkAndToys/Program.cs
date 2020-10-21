using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkAndToys
{
    class Program
    {
        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k) {
            var dict = new List<int>();//<int, int>();
            int sum = 0, toyCount = 0;
            prices = prices.Where(p => p <= k).OrderBy(n => n).ToArray();
            for(var i = 0; i < prices.Length; i++){
                if(sum + prices[i] > k) break;
                sum += prices[i];
                toyCount++;
            }
            return toyCount;
            
        }

        static void Main(string[] args) {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp))
            ;
            int result = maximumToys(prices, k);
            Console.WriteLine(result);
        }
    }
}
