using System;
using System.Linq;

namespace FraudulentActivity
{
    class Program
    {
        // Complete the activityNotifications function below.
        static int activityNotifications(int[] expenditure, int d) {
            var notifications = 0;
            var countSort = new int[201];
            for(var i = 0; i < d; i++){
                countSort[expenditure[i]]++;
            }
            for(var i = d; i < expenditure.Length; i++){
                var median = GetMedian(d, countSort);
                if(expenditure[i] >= median * 2){
                    notifications++;
                }

                countSort[expenditure[i]]++;
                countSort[expenditure[i - d]]--;
            }
            return notifications;
        }

        static double GetMedian(int days, int[] countSort)
        {
            double median = 0;
            var count = 0;
            if(days % 2 == 0){
                int m1 = 0;
                int m2 = 0;
                for(int j = 0; j < countSort.Length; j++){
                    count += countSort[j];
                    if(m1 == 0 && count >= days/2){
                        m1 = j;
                    }
                    if( m2 == 0 && count >= days/2 + 1){
                        m2 = j;
                        break;
                    }
                }
                median = (m1 + m2) / 2.0;
            }else{
                for(int j = 0; j < countSort.Length; j++){
                    count += countSort[j];
                    if(count > days/2){
                        median = j;
                        break;
                    }
                }
            }

            return median;
        }
        static void Main(string[] args) {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
            ;
            int result = activityNotifications(expenditure, d);

            Console.WriteLine(result);
        }
    }
}