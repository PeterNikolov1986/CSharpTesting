namespace TGG.Tests
{
    using System;
    using NUnit.Framework;
    using TGG.Core.Classes;
    using TGG.Core.Interfaces;
    using TGG.Core.Shared.Types;

    [TestFixture]
    public class AttackFieldTests
    {
        private readonly IOperationSuccessCalculator calculator;

        public AttackFieldTests()
        {
            this.calculator = new OperationSuccessCalculator();
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)ValidBoundaryTypes.Y)]
        public void AttackFieldAttempt_ShouldBeSucccessful(int x, int y)
        {
            bool successfulAttack = this.calculator.IsAttackSuccesful(x, y);

            Assert.AreEqual(successfulAttack, (x + y - 5) % 2 == 0);
            Assert.True(successfulAttack);
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidBoundaryTypes.Y)]
        public void AttackFieldAttempt_WithValidValues_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidBoundaryTypes.Y)]
        public void UnsuccessfulAttackFieldAttempt_WithValidValues_ShouldHave_AppropriateErrorMessage(int x, int y)
        {
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));

            Assert.AreEqual(expression.Message, "The attack field's command is not successful.");
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)ValidBoundaryTypes.X, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidBoundaryTypes.X, (int)InvalidBoundaryTypes.Y)]
        public void EvenAttackFieldAttempt_WithInvalidValuesOfY_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)ValidBoundaryTypes.X, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidBoundaryTypes.X, (int)InvalidBoundaryTypes.Y)]
        public void EvenAttackFieldAttempt_WithInvalidValuesOfY_ShouldHave_AppropriateErrorMessage(int x, int y)
        {
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));

            Assert.AreEqual(expression.Message, "Invalid value of the Y coordinate.");
        }

        [TestCase((int)ValidAverageTypes.FirstX, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)InvalidBoundaryTypes.Y)]
        public void OddAttackFieldAttempt_WithInvalidValuesOfY_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));
        }

        [TestCase((int)ValidAverageTypes.FirstX, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)InvalidBoundaryTypes.Y)]
        public void OddAttackFieldAttempt_WithInvalidValuesOfY_ShouldHave_AppropriateErrorMessage(int x, int y)
        {
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));

            Assert.AreEqual(expression.Message, "Invalid value of the Y coordinate.");
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidBoundaryTypes.Y)]
        public void EvenAttackFieldAttempt_WithInvalidValuesOfX_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidBoundaryTypes.Y)]
        public void EvenAttackFieldAttempt_WithInvalidValuesOfX_ShouldHave_AppropriateErrorMessage(int x, int y)
        {
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));

            Assert.AreEqual(expression.Message, "Invalid value of the X coordinate.");
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidAverageTypes.SecondY)]
        public void OddAttackFieldAttempt_WithInvalidValuesOfX_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidAverageTypes.SecondY)]
        public void OddAttackFieldAttempt_WithInvalidValuesOfX_ShouldHave_AppropriateErrorMessage(int x, int y)
        {
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));

            Assert.AreEqual(expression.Message, "Invalid value of the X coordinate.");
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)InvalidBoundaryTypes.Y)]
        public void AttackFieldAttempt_WithInvalidValues_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)InvalidBoundaryTypes.Y)]
        public void AttackFieldAttempt_WithInvalidValues_ShouldHave_AppropriateErrorMessage(int x, int y)
        {
            ArgumentException expression = Assert.Throws<ArgumentException>(() => this.calculator.IsAttackSuccesful(x, y));

            Assert.AreEqual(expression.Message, "Invalid value of the X coordinate.");
            Assert.AreNotEqual(expression.Message, "Invalid value of the Y coordinate.");
            Assert.AreNotEqual(expression.Message, "The attack field's command is not successful.");
        }
    }
}
