using System;
using System.Linq;
using System.Collections.Generic;

public static class LCS
{
    public static int[,] GenerateTable(string from, string to)
    {
        var table = new int[from.Length + 1, to.Length + 1];

        for (int r = 1; r < table.GetLength(0); r++)
        {
            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[r, c] = from[r - 1] == to[c - 1]
                    ? table[r - 1, c - 1] + 1
                    : Math.Max(table[r - 1, c], table[r, c - 1]);
            }
        }

        return table;
    }

    public static string Find(string from, string to, out List<int> indexes)
    {
        // The data type here should be able to support the max length between row and col inputs
        var matchTable = new int[from.Length + 1, to.Length + 1];

        for (int r = 1; r < matchTable.GetLength(0); r++)
        {
            for (int c = 1; c < matchTable.GetLength(1); c++)
            {
                // Fill match table
                var match = from[r - 1] == to[c - 1];
                matchTable[r, c] =
                    match ? matchTable[r - 1, c - 1] + 1 : Math.Max(matchTable[r - 1, c], matchTable[r, c - 1]);
            }
        }

        // Bottom up solution seeking
        indexes = new List<int>();
        var result = new LinkedList<char>();
        var rr = matchTable.GetLength(0) - 1;
        var cc = matchTable.GetLength(1) - 1;

        while (true)
        {
            if (matchTable[rr, cc] == 0)
            {
                break;
            }

            if (matchTable[rr, cc - 1] == matchTable[rr, cc])
            {
                cc -= 1;
            }
            else if (matchTable[rr - 1, cc] == matchTable[rr, cc])
            {
                rr -= 1;
            }
            else
            {
                result.AddFirst(from[rr - 1]);
                indexes.Add(rr - 1);
                rr -= 1;
                cc -= 1;
            }
        }

        indexes.Reverse();

        return new string(result.ToArray());
    }
}