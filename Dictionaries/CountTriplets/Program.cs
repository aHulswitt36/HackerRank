using System;
using System.Collections.Generic;
using System.Linq;

namespace CountTriplets
{
    class Program
    {
        // Complete the countTriplets function below.
        static long countTriplets(List<long> arr, long r) {
            var count = 0;
            var dict = new Dictionary<long, int>();
            var dictPairs = new Dictionary<long, int>();

            foreach(var i in arr.Reverse<long>())
            {
                if(dictPairs.ContainsKey(i * r))
                {
                    count += dictPairs[i*r];
                }
                if(dict.ContainsKey(i * r))
                {
                    int value;
                    dictPairs.TryGetValue(i, out value);
                    dictPairs[i] = value + dict[i*r];
                }
                int dictValue;
                dict.TryGetValue(i, out dictValue);
                dict[i] = dictValue + 1;
            }
            string pairs = string.Join(',', dictPairs.Select(d => d.Key));
            Console.WriteLine(pairs);
            return count;
        }

        static void Main(string[] args) {
            string[] nr = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nr[0]);

            long r = Convert.ToInt64(nr[1]);

            List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            long ans = countTriplets(arr, r);
            Console.WriteLine(ans);
        }
    }
}

// long tripletCount = 0;
//             var indices = new List<long>();
//             var copy = arr.Select(i => i).ToList();
//             var dict = new Dictionary<string, int>();
//             for(int i = 0; i < arr.Count; i++){
//                 var index = arr[i];
//                 indices.Add(i);
//                 var secondIndex = arr.First(a => a == index * r);
//                 if(secondIndex == 0) continue;
//                 indices.Add(arr.IndexOf(secondIndex));
//                 for(var j = arr.IndexOf(secondIndex) + 1; j < arr.Count; j++){
//                     if(secondIndex * r == arr[j]){
//                         tripletCount++;
//                         indices.Add(j);
//                         dict.Add(string.Join(',', indices), 1);
//                         indices.Clear();
                        
//                     }
//                 }

//                 for(int j = i + 1; j < copy.Count; j++){
//                     if(index * r == copy[j]){
//                         indices.Add(j);
//                         index = copy[j];
//                     }
//                     if(indices.Count == 3)
//                     {
//                         tripletCount++;
//                         dict.Add(string.Join(',', indices), 1);
//                         indices.Clear();
//                         index = arr[i];
//                         indices.Add(i);
//                         copy.RemoveAt(i + 1);
//                         j = i;
//                     }

//                 }
//             }
//             foreach(var h in dict){
//                 Console.WriteLine(h.Key);
//             }
//             return tripletCount; 