// Advent of Code 2023 - Day 07 - Kris Hoogendoorn
using Day07;

var lines = File.ReadLines("input.txt");

var game = new CamelCards();
foreach (var line in lines)
{
    game.AddCard(line);
}

var answer = game.TotalWinnings();
Console.WriteLine("Answer: {0}", answer);

