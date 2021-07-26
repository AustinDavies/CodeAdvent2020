using Day2.Interfaces;
using System.Text.RegularExpressions;

namespace Day2.Models
{
    public class Password
    {
        public string Range { get; set; }
        public char Character { get; set; }
        public string Value { get; set; }

        public static Password ParseRowInput(string rowInput)
        {
            var match = Regex.Match(rowInput, @"^([0-9]+-[0-9]+)\s([a-zA-z]{1})\:\s([a-zA-Z]+)$");

            return new Password
            {
                Range = match.Groups[1].Value,
                Character = match.Groups[2].Value.ToCharArray()[0],
                Value = match.Groups[3].Value
            };
        }

        public bool Validate(IPasswordPolicyValidator policy)
        {
            return policy.Validate(this);
        }
    }
}
