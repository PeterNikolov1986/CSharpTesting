namespace Bank.Account.Tests.NUnitTests
{
    using System;
    using Bank.Account.Core.Shared.Constants;
    using NUnit.Framework;

    [TestFixture]
    public class InitializationTests
    {
        private readonly BankAccount account;

        public InitializationTests()
        {
            this.account = new BankAccount();
        }

        [Test]
        public void InitializationOf_EmptyBankAccount_ShouldBeSuccessful()
        {
            this.account.AccountAmount = DigitConstants.ZERO;

            Assert.AreEqual(this.account.AccountAmount, this.account.InitializeEmptyBankAccount());
            Assert.AreNotEqual(this.account.AccountAmount, DigitConstants.NEGATIVE);
            Assert.AreNotEqual(this.account.AccountAmount, DigitConstants.FIRST_POSITIVE);
        }

        [Test]
        public void InitializationOf_EmptyBankAccount_WithNegativeSum_ShouldThrow_ArgumentException()
        {
            this.account.AccountAmount = DigitConstants.NEGATIVE;

            Assert.Throws<ArgumentException>(() => this.account.InitializeEmptyBankAccount());
        }

        [Test]
        public void ErrorMessageOf_EmptyBankAccountInitialization_WithNegativeSum_ShouldBe_TheSameAsExpected()
        {
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.account.InitializeEmptyBankAccount());

            Assert.That(expression.Message == ExceptionConstants.INIT_FIRST);
            Assert.AreNotEqual(expression.Message, ExceptionConstants.INIT_SECOND);
        }

        [Test]
        public void InitializationOf_EmptyBankAccount_WithPositiveSum_ShouldThrow_ArgumentException()
        {
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;

            Assert.Throws<ArgumentException>(() => this.account.InitializeEmptyBankAccount());
        }

        [Test]
        public void ErrorMessageOf_EmptyBankAccountInitialization_WithPositiveSum_ShouldBe_TheSameAsExpected()
        {
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.account.InitializeEmptyBankAccount());

            Assert.That(expression.Message == ExceptionConstants.INIT_SECOND);
            Assert.AreNotEqual(expression.Message, ExceptionConstants.INIT_FIRST);
        }
    }
}
