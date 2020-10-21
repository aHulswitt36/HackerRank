using System;
using System.Collections.Generic;
using System.IO;

namespace SalesByMatch
{
    class Program
    {// Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar) {
            var sockDictionary = new Dictionary<int, int>();
            for(int i = 0; i < n; i++){
                if(sockDictionary.ContainsKey(ar[i])){
                    var count = sockDictionary[ar[i]];
                    sockDictionary.Remove(ar[i]);
                    sockDictionary.Add(ar[i], count + 1);
                }else{
                    sockDictionary.Add(ar[i], 1);
                }
            }

            var pairs = 0;
            foreach(var color in sockDictionary){
                var count = color.Value;
                int colorPairs = count / 2;
                pairs += colorPairs;
            }
            return pairs;
        }

        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = sockMerchant(n, ar);

            Console.WriteLine(result);
        }
    }
}
