using System;

namespace BubbleSort
{
    class Program
    {
        // Complete the countSwaps function below.
        static void countSwaps(int[] a) {
            var swaps = 0;
            for (int i = 0; i < a.Length; i++) {
                
                for (int j = 0; j < a.Length - 1; j++) {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1]) {
                        //swap(a[j], a[j + 1]);
                        var value = a[j];
                        var valueAndOne = a[j + 1];
                        a[j] = valueAndOne;
                        a[j + 1] = value;
                        swaps++;
                    }
                }
                
            }
            Console.WriteLine($"Array is sorted in {swaps} swaps");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[a.Length - 1]}");
        }

        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            countSwaps(a);
        }
    }
}
