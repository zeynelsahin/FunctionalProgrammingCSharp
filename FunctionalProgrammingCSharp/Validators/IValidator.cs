namespace FunctionalProgrammingCSharp.Validators;

public interface IValidator<in T>
{
    bool IsValid(T transfer);
}