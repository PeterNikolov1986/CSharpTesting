namespace Bank.Account.Core.Interfaces
{
    public interface IMoneyOptions
    {
        decimal CollectPositiveValues(int position);

        decimal CollectNegativeOrZeroValues(int position);
    }
}
