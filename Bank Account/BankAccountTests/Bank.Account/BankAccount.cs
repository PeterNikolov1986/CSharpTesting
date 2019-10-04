namespace Bank.Account
{
    using System;
    using Bank.Account.Core.Classes;
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;

    public class BankAccount
    {
        private readonly ITransferFee fee;
        private decimal accountAmount;

        public BankAccount()
        {
            this.fee = new TransferFee();
        }

        public decimal AccountAmount
        {
            get { return this.accountAmount; }
            set { this.accountAmount = value; }
        }

        public decimal InitializeEmptyBankAccount()
        {
            if (this.AccountAmount < DigitConstants.ZERO)
            {
                throw new ArgumentException(ExceptionConstants.INIT_FIRST);
            }
            else if (this.AccountAmount > DigitConstants.ZERO)
            {
                throw new ArgumentException(ExceptionConstants.INIT_SECOND);
            }

            return this.AccountAmount;
        }

        public decimal DepositSum(decimal depositedSum)
        {
            if (depositedSum <= DigitConstants.ZERO)
            {
                throw new ArgumentException(ExceptionConstants.DEPOSIT);
            }
            else if (this.AccountAmount < DigitConstants.ZERO)
            {
                throw new ArgumentException(ExceptionConstants.ACCOUNT_DEPOSIT);
            }

            return depositedSum;
        }

        public decimal WithdrawSum(decimal chosenSumForWithdrawal)
        {
            decimal transferFee = this.fee.DefineCorrectTransferFee(chosenSumForWithdrawal);
            decimal withdrawnSum = chosenSumForWithdrawal + transferFee;

            if (this.AccountAmount < withdrawnSum)
            {
                throw new ArgumentException(ExceptionConstants.ACCOUNT_WITHDRAWAL);
            }

            return withdrawnSum;
        }
    }
}
