// Advent of Code 2023 - Day 13 - Kris Hoogendoorn
using Day13;

var lines = File.ReadLines("input.txt");

var answer = 0;
bool end = false;
var skip = 0;
var finder = new ReflectionFinder(1);
while (!end)
{
    var input = lines.Skip(skip).TakeWhile(x => x.Length != 0).ToArray();
    if (input.Length == 0)
    {
        end = true;
    }
    else
    {
        skip += input.Length + 1;
        answer += finder.ReflectionNumber(input);
    }    
}

Console.WriteLine("Answer: {0}", answer);
