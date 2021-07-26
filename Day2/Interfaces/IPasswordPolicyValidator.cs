using Day2.Models;

namespace Day2.Interfaces
{
    public interface IPasswordPolicyValidator
    {
        bool Validate(Password line);
    }
}
