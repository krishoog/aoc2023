// Advent of Code 2023 - Day 05 - Kris Hoogendoorn
using Day05;

var lines = File.ReadLines("input.txt");

var almanac = new Almanac(lines);

var answer = almanac.GetLowestLocation();
Console.WriteLine("Answer: {0}", answer);
