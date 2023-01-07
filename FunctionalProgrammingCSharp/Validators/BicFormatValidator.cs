using System.Text.RegularExpressions;

namespace FunctionalProgrammingCSharp.Validators;

public class BicFormatValidator: IValidator<MakeTransfer>
{
    private readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
    public bool IsValid(MakeTransfer transfer) => regex.IsMatch(transfer.Bic);
}