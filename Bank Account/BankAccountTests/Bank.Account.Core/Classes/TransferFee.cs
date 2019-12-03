namespace Bank.Account.Core.Classes
{
    using System;
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;

    public class TransferFee : ITransferFee
    {
        private decimal fee;
        
        public decimal DefineCorrectTransferFee(decimal chosenSumForWithdrawal)
        {
            if (chosenSumForWithdrawal <= DigitConstants.ZERO)
            {
                throw new ArgumentException("The withdrawn sum can not be negative or equal to zero.");
            }
            else
            {
                if (chosenSumForWithdrawal < DigitConstants.THOUSAND)
                {
                    this.fee = chosenSumForWithdrawal * 0.05m;
                }
                else
                {
                    this.fee = chosenSumForWithdrawal * 0.02m;
                }
            }

            return this.fee;
        }
    }
}
