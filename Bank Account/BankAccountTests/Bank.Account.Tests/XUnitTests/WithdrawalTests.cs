namespace Bank.Account.Tests.XUnitTests
{
    using System;
    using Bank.Account.Core.Classes;
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;
    using Xunit;

    public class WithdrawalTests
    {
        private readonly BankAccount account;
        private readonly IMoneyOptions options;
        private decimal chosenSumForWithdrawal;
        private decimal withdrawal;
        private decimal accountAmountAfterWithdrawal;

        public WithdrawalTests()
        {
            this.account = new BankAccount();
            this.options = new MoneyOptions();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void BankAccountAmount_ShouldBeEnoughFor_Withdrawal(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);

            if (this.chosenSumForWithdrawal < DigitConstants.THOUSAND)
            {
                this.account.AccountAmount = 1049.9895m;
            }
            else 
            {
                this.account.AccountAmount = 1020m;
            }

            this.withdrawal = this.account.WithdrawSum(this.chosenSumForWithdrawal);
            this.accountAmountAfterWithdrawal = this.account.AccountAmount - this.withdrawal;

            Assert.True(this.account.AccountAmount >= this.withdrawal);
            Assert.True(this.accountAmountAfterWithdrawal >= DigitConstants.ZERO);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void BankAccountAmount_ShouldBeEnoughFor_DoubleWithdrawal(int position)
        {
            switch (position)
            {
                case 0: this.account.AccountAmount = 1545m; break;
                case 1: this.account.AccountAmount = 2000m; break;
            }

            decimal firstWithdrawnSum = this.account.WithdrawSum(DigitConstants.AVERAGE_POSITIVE);
            decimal secondWithdrawnSum = this.account.WithdrawSum(DigitConstants.THOUSAND);
            this.withdrawal = firstWithdrawnSum + secondWithdrawnSum;
            this.accountAmountAfterWithdrawal = this.account.AccountAmount - this.withdrawal;

            Assert.True(this.account.AccountAmount >= this.withdrawal);
            Assert.True(this.accountAmountAfterWithdrawal >= DigitConstants.ZERO);
        }

        [Fact]
        public void BankAccountAmount_ShouldBeNotEnoughFor_DoubleWithdrawal()
        {
            this.account.AccountAmount = 1049.9895m;
            decimal firstWithdrawnSum = this.account.WithdrawSum(DigitConstants.AVERAGE_POSITIVE);
            decimal secondWithdrawnSum = this.account.WithdrawSum(DigitConstants.FINAL_POSITIVE);
            this.withdrawal = firstWithdrawnSum + secondWithdrawnSum;
            this.accountAmountAfterWithdrawal = this.account.AccountAmount - this.withdrawal;

            Assert.True(this.account.AccountAmount < this.withdrawal);
            Assert.True(this.accountAmountAfterWithdrawal < DigitConstants.ZERO);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void NotEnough_BankAccountAmount_ForWithdrawal_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;

            Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ErrorMessageOf_NotEnough_BankAccountAmount_ForWithdrawal_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;
            ArgumentException expression = 
                Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));

            Assert.Equal(expression.Message, ExceptionConstants.ACCOUNT_WITHDRAWAL);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Withdrawal_FromEmptyBankAcount_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.account.AccountAmount = DigitConstants.ZERO;

            Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ErrorMessageOf_Withdrawal_FromEmptyBankAcount_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.account.AccountAmount = DigitConstants.ZERO;
            ArgumentException expression =
                Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));

            Assert.Equal(expression.Message, ExceptionConstants.ACCOUNT_WITHDRAWAL);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Withdrawal_FromInitializedBankAcount_WithNegativeSum_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.account.AccountAmount = DigitConstants.NEGATIVE;

            Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ErrorMessageOf_Withdrawal_FromInitializedBankAcount_WithNegativeSum_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            ArgumentException expression =
                Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));

            Assert.Equal(expression.Message, ExceptionConstants.ACCOUNT_WITHDRAWAL);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Withdrawal_WithNegativeSumOrZero_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;

            Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ErrorMessageOf_Withdrawal_WithNegativeSumOrZero_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;
            ArgumentException expression =
                Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));

            Assert.Equal(expression.Message, ExceptionConstants.WITHDRAWAL);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Withdrawal_WithNegativeSumOrZero_FromEmptyBankAccount_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            this.account.AccountAmount = DigitConstants.ZERO;

            Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ErrorMessageOf_Withdrawal_WithNegativeSumOrZero_FromEmptyBankAccount_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            this.account.AccountAmount = DigitConstants.ZERO;
            ArgumentException expression =
                Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));

            Assert.Equal(expression.Message, ExceptionConstants.WITHDRAWAL);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Withdrawal_WithNegativeSumOrZero_FromInitializedBankAcount_WithNegativeSum_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            this.account.AccountAmount = DigitConstants.NEGATIVE;

            Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ErrorMessageOf_Withdrawal_WithNegativeSumOrZero_FromInitializedBankAcount_WithNegativeSum_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            ArgumentException expression =
                Assert.Throws<ArgumentException>(() => this.account.WithdrawSum(this.chosenSumForWithdrawal));

            Assert.Equal(expression.Message, ExceptionConstants.WITHDRAWAL);
        }
    }
}
