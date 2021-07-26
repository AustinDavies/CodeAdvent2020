using Day2.Interfaces;
using Day2.Models;

namespace Day2.Part2
{
    public class TobogganPasswordValidator : IPasswordPolicyValidator
    {
        public bool Validate(Password password)
        {
            if (password == null)
                return false;

            var rangeNumbers = password.Range.Split("-");
            var pos1 = int.Parse(rangeNumbers[0]);
            var pos2 = int.Parse(rangeNumbers[1]);

            var passwordValueCharacters = password.Value.ToCharArray();
            
            var valueCharAtPos1 = passwordValueCharacters[pos1 - 1];
            var valueCharAtPos2 = passwordValueCharacters[pos2 - 1];

            return 
                (valueCharAtPos1 == password.Character && valueCharAtPos2 != password.Character) ||
                (valueCharAtPos1 != password.Character && valueCharAtPos2 == password.Character);
        }
    }
}
