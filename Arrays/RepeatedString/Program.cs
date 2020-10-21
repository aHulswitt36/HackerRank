using System;
using System.Linq;
using System.Text;

namespace RepeatedString
{
    class Program
    {// Complete the repeatedString function below.
        static long repeatedString(string s, long n) {
            if(s.Length < 1 || s.Length > 100)
                return 0;
            if(n < 1 || n > Math.Pow(10, 12))
                return 0;

            long count = 0;
            foreach(char c in s.ToCharArray()){
                if(c == 'a')
                    count++;
            }
            long factor = (n/s.Length);
            var rem = (n%s.Length);
            count = factor * count;
            for(int i = 0; i< rem; i++){
                if(s[i] == 'a')
                    count++;
            }
            return count;


        }

        static void Main(string[] args) {
            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            long result = repeatedString(s, n);
            Console.WriteLine(result);
        }
    }
}