namespace Bank.Account.Tests.XUnitTests
{
    using System;
    using Bank.Account.Core.Classes;
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;
    using Xunit;

    public class TransferFeeTests
    {
        private readonly ITransferFee fee;
        private readonly IMoneyOptions options;

        private decimal chosenSumForWithdrawal;
        private decimal expectedTransferFee;
        private decimal transferFee;

        public TransferFeeTests()
        {
            this.fee = new TransferFee();
            this.options = new MoneyOptions();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TransferFee_ShouldBeCorrect(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.transferFee = this.fee.DefineCorrectTransferFee(this.chosenSumForWithdrawal);

            if (this.chosenSumForWithdrawal < DigitConstants.THOUSAND)
            {
                this.expectedTransferFee = this.chosenSumForWithdrawal * 0.05m;
            }
            else
            {
                this.expectedTransferFee = this.chosenSumForWithdrawal * 0.02m;
            }

            Assert.Equal(this.expectedTransferFee, this.transferFee);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TransferFee_ShouldBeIncorrect(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectPositiveValues(position);
            this.transferFee = this.fee.DefineCorrectTransferFee(this.chosenSumForWithdrawal);

            if (this.chosenSumForWithdrawal < DigitConstants.THOUSAND)
            {
                this.expectedTransferFee = this.chosenSumForWithdrawal * 0.02m;
            }
            else
            {
                this.expectedTransferFee = this.chosenSumForWithdrawal * 0.05m;
            }

            Assert.NotEqual(this.expectedTransferFee, this.transferFee);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void NegativeOrZeroValueOf_ChosenSumForWithdrawal_ShouldThrow_ArgumentException(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);

            Assert.Throws<ArgumentException>(() => this.fee.DefineCorrectTransferFee(this.chosenSumForWithdrawal));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ErrorMessageOf_NegativeOrZeroValueOf_ChosenSumForWithdrawal_ShouldBe_TheSameAsExpected(int position)
        {
            this.chosenSumForWithdrawal = this.options.CollectNegativeOrZeroValues(position);
            ArgumentException expression =
                Assert.Throws<ArgumentException>(() => this.fee.DefineCorrectTransferFee(this.chosenSumForWithdrawal));

            Assert.Equal("The withdrawn sum can not be negative or equal to zero.", expression.Message);
        }
    }
}
