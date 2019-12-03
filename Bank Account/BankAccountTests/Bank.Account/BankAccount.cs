namespace Bank.Account
{
    using System;
    using Bank.Account.Core.Classes;
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;

    public class BankAccount
    {
        private readonly ITransferFee fee;

        public BankAccount()
        {
            this.fee = new TransferFee();
        }

        public decimal AccountAmount { get; set; }

        public decimal InitializeEmptyBankAccount()
        {
            if (this.AccountAmount < DigitConstants.ZERO)
            {
                throw new ArgumentException("A bank account's initialization with negative sum is impossible.");
            }
            else if (this.AccountAmount > DigitConstants.ZERO)
            {
                throw new ArgumentException("A bank account's initialization doesn't need deposit of money.");
            }

            return this.AccountAmount;
        }

        public decimal DepositSum(decimal depositedSum)
        {
            if (depositedSum <= DigitConstants.ZERO)
            {
                throw new ArgumentException("The deposited sum can not be negative or equal to zero.");
            }
            else if (this.AccountAmount < DigitConstants.ZERO)
            {
                throw new ArgumentException("The initial sum in a bank account can not be negative.");
            }

            return depositedSum;
        }

        public decimal WithdrawSum(decimal chosenSumForWithdrawal)
        {
            decimal transferFee = this.fee.DefineCorrectTransferFee(chosenSumForWithdrawal);
            decimal withdrawnSum = chosenSumForWithdrawal + transferFee;

            if (this.AccountAmount < withdrawnSum)
            {
                throw new ArgumentException("The initial sum in a bank account can not be less than the withdrawn one.");
            }

            return withdrawnSum;
        }
    }
}
