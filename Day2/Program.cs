using Day2.Interfaces;
using Day2.Models;
using Day2.Part1;
using Day2.Part2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day2
{
    class Program
    {
        private static IPasswordPolicyValidator passwordPolicyValidator;
        static void Main(string[] args)
        {
            PromptWelcome();
        }

        static void PromptWelcome()
        {
            Console.WriteLine("Pick Part1 (1) OR Part2 (2)");
            var partInput = Console.ReadLine();
            if (partInput.ToLower() == "part1" || partInput.ToLower() == "1")
                UsePart1();
            else
                UsePart2();

            var passwords = ReadPasswords().ToArray();
            var validPasswordCount = passwords.Where(x => x.Validate(passwordPolicyValidator)).Count();

            Console.WriteLine($"Valid Passwords Count: {validPasswordCount}");
        }

        static void UsePart1()
        {
            passwordPolicyValidator = new OldSledJobPasswordValidator();
        }

        static void UsePart2()
        {
            passwordPolicyValidator = new TobogganPasswordValidator();
        }

        static IEnumerable<Password> ReadPasswords()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", @"Data\PuzzleInput.raw.txt");
            var input = File.ReadLines(path);
            foreach (var line in input)
                yield return Password.ParseRowInput(line);
        }
    }
}
