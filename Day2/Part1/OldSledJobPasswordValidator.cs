using Day2.Interfaces;
using Day2.Models;
using System.Linq;

namespace Day2.Part1
{
    public class OldSledJobPasswordValidator : IPasswordPolicyValidator
    {
        public bool Validate(Password password)
        {
            var occurrences = password.Range.Split("-");
            var minOccurences = int.Parse(occurrences[0]);
            var maxOccurences = int.Parse(occurrences[1]);

            var characterCount = password.Value.Count(x => x == password.Character);

            return characterCount >= minOccurences && characterCount <= maxOccurences;
        }
    }
}
