// Advent of Code 2023 - Day 11 - Kris Hoogendoorn
using Day11;

var lines = File.ReadLines("input.txt");
var universe = new UniverseMap(lines);

var answer = universe.CalculteShortesPaths().Sum(); ;
Console.WriteLine("Answer: {0}", answer);
