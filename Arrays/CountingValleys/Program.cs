using System;

namespace CountingValleys
{
    class Program
    {
        public static void Main(string[] args)
        {
            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            int result = Result.countingValleys(steps, path);

            Console.WriteLine(result);
        }
    }
    class Result
    {

        /*
        * Complete the 'countingValleys' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts following parameters:
        *  1. INTEGER steps
        *  2. STRING path
        */

        public static int countingValleys(int steps, string path)
        {
            var valleys = 0;
            var seaLevel = 0;
            var startValley = false;
            for(int i = 0; i < steps; i++){
                if(path[i] == 'U'){
                    seaLevel = seaLevel + 1;
                }else{
                    seaLevel = seaLevel - 1;
                }
                if(seaLevel == -1 && !startValley)
                    startValley = true;
                else if(seaLevel == 0 && startValley)
                {
                    valleys = valleys + 1; 
                    startValley = false;
                }               
            }
            return valleys;
        }

    }

}
