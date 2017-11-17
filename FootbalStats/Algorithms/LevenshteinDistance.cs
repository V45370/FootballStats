using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbalStats.Algorithms
{
    public static class LevenshteinDistance
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
       public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        //public static double CalculateSimilarity(string source, string target)
        //{
        //    if ((source == null) || (target == null)) return 0.0;
        //    if ((source.Length == 0) || (target.Length == 0)) return 0.0;
        //    if (source == target) return 1.0;

        //    int stepsToSame = ComputeV2(source, target);
        //    return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        //}

        //public static int ComputeV2(string source, string target)
        //{
        //    // degenerate cases
        //    if (source == target) return 0;
        //    if (source.Length == 0) return target.Length;
        //    if (target.Length == 0) return source.Length;

        //    // create two work vectors of integer distances
        //    int[] v0 = new int[target.Length + 1];
        //    int[] v1 = new int[target.Length + 1];

        //    // initialize v0 (the previous row of distances)
        //    // this row is A[0][i]: edit distance for an empty s
        //    // the distance is just the number of characters to delete from t
        //    for (int i = 0; i < v0.Length; i++)
        //        v0[i] = i;

        //    for (int i = 0; i < source.Length; i++)
        //    {
        //        // calculate v1 (current row distances) from the previous row v0

        //        // first element of v1 is A[i+1][0]
        //        //   edit distance is delete (i+1) chars from s to match empty t
        //        v1[0] = i + 1;

        //        // use formula to fill in the rest of the row
        //        for (int j = 0; j < target.Length; j++)
        //        {
        //            var cost = (source[i] == target[j]) ? 0 : 1;
        //            v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
        //        }

        //        // copy v1 (current row) to v0 (previous row) for next iteration
        //        for (int j = 0; j < v0.Length; j++)
        //            v0[j] = v1[j];
        //    }

        //    return v1[target.Length];
        //}
    }
}
