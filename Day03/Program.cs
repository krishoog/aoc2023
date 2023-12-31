﻿// Advent of Code 2023 - Day 03 - Kris Hoogendoorn
using Day03;

var lines = File.ReadLines("input.txt");

var schematic = new Schematic(140, 140);
foreach (var line in lines)
{
    schematic.LoadRow(line);
}

schematic.LinkSymbolNeighbors();
schematic.LinkSymbolNumberNeighbors();
int answer = schematic.Gears.Sum(x => x.GearRatio);

Console.WriteLine("Answer: {0}", answer);
