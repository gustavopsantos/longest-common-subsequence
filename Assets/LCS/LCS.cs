using System;
using System.Linq;
using System.Collections.Generic;

public static class LCS
{
    private static int[,] GenerateScoreMatrix2(string a, string b)
    {
        var width = a.Length + 1;
        var height = b.Length + 1;
        var matrix = new int[width, height];

        for (int row = 1; row < height; row++)
        {
            for (int column = 1; column < width; column++)
            {
                matrix[column, row] = CalculateCellScore(a, b, column, row, matrix);
            }
        }

        return matrix;
    }

    private static int CalculateCellScore(string a, string b, int column, int row, int[,] matrix)
    {
        var rowChar = b[row - 1];
        var columnChar = a[column - 1];

        if (rowChar == columnChar)
        {
            var northWestScore = matrix[column - 1, row - 1];
            return northWestScore + 1;
        }

        var westScore = matrix[column - 1, row];
        var northScore = matrix[column, row - 1];
        return Math.Max(westScore, northScore);
    }

    private static string TracebackPathWithHighestScore(string a, int[,] scoreMatrix)
    {
        var result = new LinkedList<char>();
        var row = scoreMatrix.GetLength(0) - 1;
        var column = scoreMatrix.GetLength(1) - 1;

        while (scoreMatrix[row, column] != 0)
        {
            if (scoreMatrix[row, column - 1] == scoreMatrix[row, column])
            {
                column -= 1;
            }
            else if (scoreMatrix[row - 1, column] == scoreMatrix[row, column])
            {
                row -= 1;
            }
            else
            {
                result.AddFirst(a[row - 1]);
                row -= 1;
                column -= 1;
            }
        }

        return new string(result.ToArray());
    }

    public static string Find(string a, string b)
    {
        var scoreMatrix = GenerateScoreMatrix2(a, b);
        return TracebackPathWithHighestScore(a, scoreMatrix);
        ;
    }
}