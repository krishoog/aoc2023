// Advent of Code 2023 - Day 10 - Kris Hoogendoorn
using Day10;

var lines = File.ReadLines("input.txt");

var maze = new Maze(lines);
maze.FindLoop();
var answer = maze.CountEnclosed();

Console.WriteLine("Answer: {0}", answer);
