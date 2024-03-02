namespace SpellShell.SpellDistance;

public class SpellDistance
{
    public static int GetDistance(string source, string target)
    {
        source = " " + source;
        target = " " + target;

        var costTable = GetTableTriversalCosts(source, target);

        return TraverseTable(costTable);
    }

    private static int TraverseTable(int[,] table)
    {
        int i = table.GetLength(0) - 1;
        int j = table.GetLength(1) - 1;
        int score = 0;

        while (i > 0 && j > 0)
        {
            int current = table[i, j];
            int top = table[i - 1, j];
            int left = table[i, j - 1];
            int topLeft = table[i - 1, j - 1];

            if (current == topLeft && current <= top && current <= left)
            {
                i--;
                j--;
            }
            else if (current == top + 1 && current <= topLeft && current <= left)
            {
                i--;
                score++;
            }
            else if (current == left + 1 && current <= topLeft && current <= top)
            {
                j--;
                score++;
            }
            else if (topLeft < current)
            {
                i--;
                j--;
                score++;
            }
            else
            {
                if (top < left)
                {
                    i--;
                }
                else
                {
                    j--;
                }
                score++;
            }
        }

        score += i + j;

        return score;
    }

    private static int[,] GetTableTriversalCosts(string source, string target)
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
