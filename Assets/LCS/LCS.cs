using System;
using System.Linq;
using System.Collections.Generic;

public static class LCS
{
    private static int[,] GenerateScoreMatrix(string a, string b)
    {
        var table = new int[a.Length + 1, b.Length + 1];

        for (int r = 1; r < table.GetLength(0); r++)
        {
            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[r, c] = a[r - 1] == b[c - 1]
                    ? table[r - 1, c - 1] + 1
                    : Math.Max(table[r - 1, c], table[r, c - 1]);
            }
        }

        return table;
    }
    
    private static string TracebackPathWithHighestScore(string a, int[,] scoreMatrix)
    {
        var result = new LinkedList<char>();
        var rr = scoreMatrix.GetLength(0) - 1;
        var cc = scoreMatrix.GetLength(1) - 1;

        while (scoreMatrix[rr, cc] != 0)
        {
            if (scoreMatrix[rr, cc - 1] == scoreMatrix[rr, cc])
            {
                cc -= 1;
            }
            else if (scoreMatrix[rr - 1, cc] == scoreMatrix[rr, cc])
            {
                rr -= 1;
            }
            else
            {
                result.AddFirst(a[rr - 1]);
                rr -= 1;
                cc -= 1;
            }
        }

        return new string(result.ToArray());
    }

    public static string Find(string a, string b)
    {
        var scoreMatrix = GenerateScoreMatrix(a, b);
        return TracebackPathWithHighestScore(a, scoreMatrix);;
    }
}