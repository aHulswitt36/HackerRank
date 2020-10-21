using System;
using System.Linq;

namespace LeftRotation
{
    class Program
    {
        static int[] rotLeft(int[] a, int d) {
            for(int i = 0; i < d; i++){
                var first = a[0];
                Array.Copy(a, 1, a, 0, a.Length - 1);
                a[a.Length - 1] = first;                
            }
            return a;
        }

        static void Main(string[] args) {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
            ;
            int[] result = rotLeft(a, d);
            foreach(var item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
