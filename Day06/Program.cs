// Advent of Code 2023 - Day 06 - Kris Hoogendoorn
using Day06;

var calc = new WinCalculator();

var answer = calc.WaysToWin(40, 233);
answer *= calc.WaysToWin(82, 1011);
answer *= calc.WaysToWin(84, 1110);
answer *= calc.WaysToWin(92, 1487);
Console.WriteLine("Answer: {0}", answer);
