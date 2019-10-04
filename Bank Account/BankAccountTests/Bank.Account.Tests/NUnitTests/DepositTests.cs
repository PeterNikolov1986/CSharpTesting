﻿namespace Bank.Account.Tests.NUnitTests
{
    using Bank.Account.Core.Classes;
    using Bank.Account.Core.Interfaces;
    using Bank.Account.Core.Shared.Constants;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DepositTests
    {
        private readonly BankAccount account;
        private readonly IMoneyOptions options;
        private decimal deposit;
        private decimal accountAmountAfterDeposit;

        private static readonly int[] fourPositions = new int[] { 0, 1, 2, 3 };
        private static readonly int[] twoPositions = new int[] { 0, 1 };

        public DepositTests()
        {
            this.account = new BankAccount();
            this.options = new MoneyOptions();
        }

        [TestCaseSource(nameof(fourPositions))]
        public void Deposit_WithPositiveSum_ShouldBeSuccessful(int position)
        {
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;
            this.deposit = this.options.CollectPositiveValues(position);
            this.accountAmountAfterDeposit = this.account.AccountAmount + this.deposit;

            Assert.Greater(this.accountAmountAfterDeposit, this.account.AccountAmount);
            Assert.Greater(this.accountAmountAfterDeposit, this.deposit);
            Assert.Greater(this.accountAmountAfterDeposit, DigitConstants.ZERO);
            Assert.Greater(this.deposit, DigitConstants.ZERO);
        }

        [TestCaseSource(nameof(fourPositions))]
        public void Deposit_WithPositiveSum_InEmptyBankAccount_ShouldBeSuccessful(int position)
        {
            this.account.AccountAmount = DigitConstants.ZERO;
            this.deposit = this.options.CollectPositiveValues(position);
            this.accountAmountAfterDeposit = this.account.AccountAmount + this.deposit;

            Assert.AreEqual(this.accountAmountAfterDeposit, this.deposit);
            Assert.Greater(this.accountAmountAfterDeposit, this.account.AccountAmount);
            Assert.Greater(this.accountAmountAfterDeposit, DigitConstants.ZERO);
            Assert.Greater(this.deposit, DigitConstants.ZERO);
        }

        [TestCaseSource(nameof(twoPositions))]
        public void Deposit_WithNegativeSumOrZero_ShouldThrow_ArgumentException(int position)
        {
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;
            this.deposit = this.options.CollectNegativeOrZeroValues(position);

            Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));
        }

        [TestCaseSource(nameof(twoPositions))]
        public void ErrorMessageOf_Deposit_WithNegativeSumOrZero_ShouldBe_TheSameAsExpected(int position)
        {
            this.account.AccountAmount = DigitConstants.FIRST_POSITIVE;
            this.deposit = this.options.CollectNegativeOrZeroValues(position);
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));

            Assert.That(expression.Message == ExceptionConstants.DEPOSIT);
        }

        [TestCaseSource(nameof(fourPositions))]
        public void Deposit_WithPositiveSum_InInitializedBankAccount_WithNegativeSum_ShouldThrow_ArgumentException(int position)
        {
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            this.deposit = this.options.CollectPositiveValues(position);

            Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));
        }

        [TestCaseSource(nameof(fourPositions))]
        public void ErrorMessageOf_Deposit_WithPositiveSum_InInitializedBankAccount_WithNegativeSum_ShouldBe_TheSameAsExpected(int position)
        {
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            this.deposit = this.options.CollectPositiveValues(position);
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));

            Assert.That(expression.Message == ExceptionConstants.ACCOUNT_DEPOSIT);
        }

        [TestCaseSource(nameof(twoPositions))]
        public void Deposit_WithNegativeSumOrZero_InInitializedBankAccount_WithNegativeSum_ShouldThrow_ArgumentException(int position)
        {
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            this.deposit = this.options.CollectNegativeOrZeroValues(position);

            Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));
        }

        [TestCaseSource(nameof(twoPositions))]
        public void ErrorMessageOf_Deposit_WithNegativeSumOrZero_InInitializedBankAccount_WithNegativeSum_ShouldBe_TheSameAsExpected(int position)
        {
            this.account.AccountAmount = DigitConstants.NEGATIVE;
            this.deposit = this.options.CollectNegativeOrZeroValues(position);
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));

            Assert.That(expression.Message == ExceptionConstants.DEPOSIT);
            Assert.AreNotEqual(expression.Message, ExceptionConstants.ACCOUNT_DEPOSIT);
        }

        [TestCaseSource(nameof(twoPositions))]
        public void Deposit_WithNegativeSumOrZero_InEmptyBankAccount_ShouldThrow_ArgumentException(int position)
        {
            this.account.AccountAmount = DigitConstants.ZERO;
            this.deposit = this.options.CollectNegativeOrZeroValues(position);

            Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));
        }

        [TestCaseSource(nameof(twoPositions))]
        public void ErrorMessageOf_Deposit_WithNegativeSumOrZero_InEmptyBankAccount_ShouldBe_TheSameAsExpected(int position)
        {
            this.account.AccountAmount = DigitConstants.ZERO;
            this.deposit = this.options.CollectNegativeOrZeroValues(position);
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.account.DepositSum(this.deposit));

            Assert.That(expression.Message == ExceptionConstants.DEPOSIT);
        }
    }
}