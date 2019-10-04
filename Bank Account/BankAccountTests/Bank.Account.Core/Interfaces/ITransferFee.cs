namespace Bank.Account.Core.Interfaces
{
    public interface ITransferFee
    {
        decimal DefineCorrectTransferFee(decimal chosenSumForWithdrawal);
    }
}
