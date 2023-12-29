// Advent of Code 2023 - Day 12 - Kris Hoogendoorn
using Day12;

var lines = File.ReadLines("input.txt");
var calculator = new ArrangementCalculator(5);

var answer = lines.Sum(calculator.CalculateArrangements);
Console.WriteLine("Answer: {0}", answer);
