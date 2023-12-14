// Advent of Code 2023 - Day 08 - Kris Hoogendoorn
using Day08;

var lines = File.ReadLines("input.txt");

var map = new Map();
map.AddDirections(lines.First());

foreach (var line in lines.Skip(2))
{
    map.AddNode(line);
}

var answer = map.MultipathTraverse();
Console.WriteLine("Answer: {0}", answer);
