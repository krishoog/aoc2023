// Advent of Code 2023 - Day 02 - Kris Hoogendoorn
using Day02;

var lines = File.ReadLines("input.txt");

int answer = 0;
foreach (var line in lines)
{
    var x = new CubeGame(line);
    answer += x.MinimumSet().Power;
}

Console.WriteLine("Answer: {0}", answer);
