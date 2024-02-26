using SpellShell.SpellDistance;

var table = SpellDistance.GetDistance(" boats", " float");

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.Write(table[i, j] + " ");
    }
    Console.WriteLine();
}

