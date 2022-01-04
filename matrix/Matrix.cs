using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    public string matrix { get; init; }

    public Matrix(string input)
    {
        matrix = input;
    }

    public int[] Row(int row) => matrix
        .Split('\n')[row - 1]
        .Split(" ")
        .Select(digit => int.Parse(digit))
        .ToArray();

    public int[] Column(int col)
    {
        int[][] rows = matrix.Split('\n').Select((row, index) => Row(index + 1)).ToArray();
        int rowLength = rows[0].Length;
        List<int[]> columns = new List<int[]>();
        for (int i = 0; i < rowLength; i++)
        {
            List<int> column = new List<int>();
            for (int j = 0; j < rows.Length; j++)
            {
                column.Add(rows[j][i]);
            }
            columns.Add(column.ToArray());
        }
        return columns[col - 1];
    }
}