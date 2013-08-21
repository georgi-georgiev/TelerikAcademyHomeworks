using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherAlgorithms
{
    class Program
    {
        static int? GreedyChange(int[] coins, int targetTotal)
        {
            if (coins.Length == 0)
            {
                if (targetTotal == 0)
                    return 0;
                return null;
            }

            var total = 0;
            var count = 0;
            var maxCoin = coins[0];

            while (targetTotal - total >= maxCoin)
            {
                total += maxCoin;
                count += 1;
            }

            if (total == targetTotal)
                return count;


            var remaining = coins.Skip(1).ToArray();

            if (remaining.Length == 0)
                return null;

            for (int toDrop = 0; toDrop <= count; ++toDrop)
            {
                var maybe = GreedyChange(remaining,
                    targetTotal - total + toDrop * maxCoin);

                if (maybe == null)
                    continue;

                return maybe.Value + count - toDrop;
            }

            return null;

        }

        static int? RandomChange(
            int[] coins, int targetTotal, int totalIterations)
        {
            var counts = new Dictionary<int, int>();

            foreach (var coin in coins)
            {
                counts[coin] = 0;
            }

            var random = new Random(0);
            var countSoFar = 0;
            var totalSoFar = 0;
            int? bestSoFar = null;

            while (totalIterations > 0)
            {
                totalIterations -= 1;
                if (targetTotal > totalSoFar)
                {
                    int coin;
                    do
                    {
                        coin = coins[random.Next(0, coins.Length)];
                    } while (coin > (targetTotal - totalSoFar));

                    countSoFar += 1;
                    totalSoFar += coin;
                    counts[coin] += 1;
                }
                else
                {
                    var toDrop = random.Next(1, countSoFar + 1);
                    for (int ii = 0; ii < toDrop; ++ii)
                    {
                        int coin;
                        do
                        {
                            coin = coins[random.Next(0, coins.Length)];
                        } while (counts[coin] == 0);

                        countSoFar -= 1;
                        totalSoFar -= coin;
                        counts[coin] -= 1;
                    }
                }

                if (totalSoFar == targetTotal)
                {
                    if (bestSoFar == null || bestSoFar > countSoFar)
                    {
                        bestSoFar = countSoFar;
                    }
                }

            }

            return bestSoFar;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GreedyChange(new[] { 5, 2, 1 }, 33));
        }
    }
}
