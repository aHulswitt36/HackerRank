using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Test
{
    class Result
    {

        /*
        * Complete the 'fiveStarReviews' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts following parameters:
        *  1. 2D_INTEGER_ARRAY productRatings
        *  2. INTEGER ratingThreshold
        */

        public static int fiveStarReviews(List<List<int>> productRatings, int ratingThreshold)
        {
            var reviewsAdded = 0;
            double currentRating = 0;
            var productRatingsList = productRatings
                .Select(productRating => new ProductRating
                    {FiveStarRatings = productRating[0], TotalRatings = productRating[1]})
                .ToList();
            productRatingsList.Sort();

            currentRating = productRatingsList.Sum(s => s.CurrentRating) / productRatings.Count;

            while (currentRating < ratingThreshold)
            {
                reviewsAdded++;
                //"Pop" first product rating off the queue
                var rating = productRatingsList.First();
                productRatingsList.RemoveAt(0);
                var newProductRating = new ProductRating
                    {FiveStarRatings = rating.FiveStarRatings + 1, TotalRatings = rating.TotalRatings + 1};
                productRatingsList.Add(newProductRating);
                currentRating = Math.Round(productRatingsList.Sum(s => s.CurrentRating) / productRatings.Count, 2);
                productRatingsList.Sort();
            }

            return reviewsAdded;
        }



    }

    class ProductRating : IComparable<ProductRating>
    {
        public int TotalRatings { get; set; }
        public int FiveStarRatings { get; set; }

        public double CurrentRating => ((double)FiveStarRatings / TotalRatings) * 100;


        public int CompareTo(ProductRating other)
        {
            return other.GetDifference() - this.GetDifference();
        }
        
        private int GetDifference()
        {
            var currentRating = CurrentRating;
            var newRating = (((double)FiveStarRatings + 1) / (TotalRatings + 1)) * 100;
            return (int) ((int) newRating - currentRating);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            
            int productRatingsRows = Convert.ToInt32(Console.ReadLine().Trim());
            int productRatingsColumns = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> productRatings = new List<List<int>>();

            for (int i = 0; i < productRatingsRows; i++)
            {
                productRatings.Add(Console.ReadLine().TrimEnd().Split(' ').ToList()
                    .Select(productRatingsTemp => Convert.ToInt32(productRatingsTemp)).ToList());
            }

            int ratingThreshold = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.fiveStarReviews(productRatings, ratingThreshold);

            Console.WriteLine(result);
        }
    }
}
