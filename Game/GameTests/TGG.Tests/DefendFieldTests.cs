namespace TGG.Tests
{
    using System;
    using NUnit.Framework;
    using TGG.Core.Classes;
    using TGG.Core.Interfaces;
    using TGG.Core.Shared.Types;

    [TestFixture]
    public class DefendFieldTests
    {
        private readonly IOperationSuccessCalculator calculator;

        public DefendFieldTests()
        {
            this.calculator = new OperationSuccessCalculator();
        }

        [Test]
        public void DefendFieldAttempt_ShouldBeSucccessful()
        {
            int x = (int)ValidAverageTypes.FirstX;
            int y = (int)ValidAverageTypes.SecondY;
            bool successfulDefence = this.calculator.IsDefenceSuccesful(x, y);

            Assert.AreEqual(successfulDefence, (x * y - 5) % 2 == 0);
            Assert.True(successfulDefence);
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)ValidBoundaryTypes.X, (int)ValidBoundaryTypes.Y)]
        public void DefendFieldAttempt_WithValidValues_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsDefenceSuccesful(x, y));
        }

        [TestCase((int)ValidAverageTypes.FirstX, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidAverageTypes.FirstX, (int)InvalidBoundaryTypes.Y)]
        public void EvenDefendFieldAttempt_WithInvalidValuesOfY_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsDefenceSuccesful(x, y));
        }

        [TestCase((int)ValidBoundaryTypes.Zero, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidBoundaryTypes.Zero, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidAverageTypes.SecondX, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)ValidBoundaryTypes.X, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)ValidBoundaryTypes.X, (int)InvalidBoundaryTypes.Y)]
        public void OddDefendFieldAttempt_WithInvalidValuesOfY_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsDefenceSuccesful(x, y));
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidAverageTypes.SecondY)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidAverageTypes.SecondY)]
        public void EvenDefendFieldAttempt_WithInvalidValuesOfX_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsDefenceSuccesful(x, y));
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidBoundaryTypes.Zero)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidAverageTypes.FirstY)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)ValidBoundaryTypes.Y)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)ValidBoundaryTypes.Y)]
        public void OddDefendFieldAttempt_WithInvalidValuesOfX_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsDefenceSuccesful(x, y));
        }

        [TestCase((int)InvalidBoundaryTypes.Negative, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)InvalidBoundaryTypes.Negative)]
        [TestCase((int)InvalidBoundaryTypes.Negative, (int)InvalidBoundaryTypes.Y)]
        [TestCase((int)InvalidBoundaryTypes.X, (int)InvalidBoundaryTypes.Y)]
        public void DefendFieldAttempt_WithInvalidValues_ShouldThrow_ArgumentException(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.IsDefenceSuccesful(x, y));
        }
    }
}
