namespace SpellShell.SpellDistance;

public class SpellDistance
{
    public static int[,] GetDistance(string source, string target)
    {
        return GetTableTriversalCost(source, target);
    }

    private static int TriverseTable(int[,] table, int lastCellValue, int i, int j)
    {

    }

    private static int[,] GetTableTriversalCost(string source, string target)
    {
        int[,] table = GetDefualtTable(source.Length, target.Length);

        for (int i = 1; i < source.Length; i++)
        {
            for (int j = 1; j < target.Length; j++)
            {
                var top = table[i - 1, j];
                var left = table[i, j - 1];
                var topLeft = table[i - 1, j - 1];

                if (source[i] == target[j])
                {
                    table[i, j] = GetMin(top, left, topLeft);
                    continue;
                }

                table[i, j] = GetMin(top, left, topLeft) + 1;
            }
        }

        return table;
    }

    private static int GetMin(int a, int b, int c)
    {
        return Math.Min(a, Math.Min(b, c));
    }

    private static int[,] GetDefualtTable(int rows, int columns)
    {
        int[,] table = new int[rows, columns];

        for (int i = 1; i < rows; ++i)
        {
            table[i, 0] = i;
        }

        for (int i = 1; i < columns; ++i)
        {
            table[0, i] = i;
        }

        return table;
    }


}
