namespace PatikaExample1.IServices
{
    public interface IInterestService
    {
        object CalculateInterest(double? interestRate, int? totalAmount, int? period);
    }
}
