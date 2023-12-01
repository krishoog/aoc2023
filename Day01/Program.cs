// Advent of Code 2023 - Day 01 - Kris Hoogendoorn
using Day01;

var lines = File.ReadLines("input.txt");
var x = new CalibrationValueExtractor();
int answer = 0;
foreach (var line in lines)
{
    answer += x.ParseLine(line);
}

Console.WriteLine("Answer: {0}", answer);
