using System;
using System.Linq;

namespace TwoStrings
{
    class Program
    {
// Complete the twoStrings function below.
        static string twoStrings(string s1, string s2) {
            var s1Dict = s1.ToLookup(x => x, x => 1);
            foreach(char i in s2){
                if(s1Dict.Contains(i)){
                    return "YES";
                }
            }
            
            return "NO";
        }

        static void Main(string[] args) {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++) {
                string s1 = Console.ReadLine();

                string s2 = Console.ReadLine();

                string result = twoStrings(s1, s2);

                Console.WriteLine(result);
            }
        }
    }
}
