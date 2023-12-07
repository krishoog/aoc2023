// Advent of Code 2023 - Day 04 - Kris Hoogendoorn
using Day04;

var lines = File.ReadLines("input.txt");

var pile = new Pile();
foreach (var line in lines)
{
    pile.AddCard(line);
}

pile.ScoreCards();

var answer = pile.NumCards;
Console.WriteLine("Answer: {0}", answer);
