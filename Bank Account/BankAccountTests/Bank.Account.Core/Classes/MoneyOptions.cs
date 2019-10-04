namespace Bank.Account.Core.Classes
{
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;

    public class MoneyOptions : IMoneyOptions
    {
        private decimal moneyOption;

        public decimal CollectPositiveValues(int position)
        {
            switch (position)
            {
                case 0: this.moneyOption = DigitConstants.FIRST_POSITIVE; break;
                case 1: this.moneyOption = DigitConstants.AVERAGE_POSITIVE; break;
                case 2: this.moneyOption = DigitConstants.FINAL_POSITIVE; break;
                case 3: this.moneyOption = DigitConstants.THOUSAND; break;
            }

            return this.moneyOption;
        }

        public decimal CollectNegativeOrZeroValues(int position)
        {
            switch (position)
            {
                case 0: this.moneyOption = DigitConstants.NEGATIVE; break;
                case 1: this.moneyOption = DigitConstants.ZERO; break;
            }

            return this.moneyOption;
        }
    }
}
