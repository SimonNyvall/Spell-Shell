using System.Text.Json;
using SpellShell.SpellDistance;

if (args.Length != 1)
{
    Console.WriteLine("Please provide a word to spell check");
    return;
}

var word = args[0];

var json = await File.ReadAllTextAsync("programming-terms.json");
var programmingTerms = JsonSerializer.Deserialize<ProgrammingTerms>(json);

var scoredWords = new List<(string, int)>();

foreach (var term in programmingTerms!.Terms!)
{
    var distance = SpellDistance.GetDistance(word, term);
    scoredWords.Add((term, distance));
}

scoredWords.Sort((a, b) => a.Item2.CompareTo(b.Item2));

var results = scoredWords
    .Take(5)
    .Select(x => x.Item1);

foreach (var result in results)
{
    Console.WriteLine(result);
}


class ProgrammingTerms
{
    public List<string>? Terms { get; set; }
}
