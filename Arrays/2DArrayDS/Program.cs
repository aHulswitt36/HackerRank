using System;

namespace _2DArrayDS
{
    class Program
    {// Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr) {
            var maxSum = int.MinValue;
            for(int i = 0; i < 4; i++){
                for(int j = 0; j < 4; j++){
                    int sum = (arr[i][j] + arr[i][j+1] + arr[i][j+2] + 
                               arr[i+ 1][j + 1] + arr[i + 2][j] + arr[i+2][j+1] +
                               arr[i+2][j+2]);
                    maxSum = Math.Max(maxSum, sum);
                }
            }
            return maxSum;
        }

        static void Main(string[] args) {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++) {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);

            Console.WriteLine(result);
        }
    }
}
