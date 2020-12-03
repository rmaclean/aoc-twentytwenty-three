using System;
using System.IO;
using System.Linq;

var count = File.ReadLines("map.txt").ToList();
var tests = new[] { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };
var results = new long[tests.Length];

var resultIndex = 0;
foreach (var test in tests)
{
    var result = CountTrees(test.Item1, test.Item2);
    Console.WriteLine($"🎄 = {result}");
    results[resultIndex++] = result;
}

Console.WriteLine($"🎄🎄🎄 {results.Aggregate(1L, (curr, result) => result *= curr)} 🎄🎄🎄");

int CountTrees(int rowModifier, int columnModifier)
{
    var column = columnModifier;
    var tree = 0;
    for (var row = rowModifier; row < count.Count; row += rowModifier, column += columnModifier)
    {
        var line = count[row];
        if (column >= line.Length)
        {
            column = column - line.Length;
        }

        tree += line[column] == '#' ? 1 : 0;
    }

    return tree;
}