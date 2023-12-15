// Advent of Code 2023 - Day 09 - Kris Hoogendoorn
using Day09;

var lines = File.ReadLines("input.txt");

var extrapolator = new Extrapolator();
var answer = 0;
foreach (var line in lines)
{
    answer += extrapolator.ExtrapolateBack(line);
}

Console.WriteLine("Answer: {0}", answer);
