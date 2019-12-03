namespace TGG.Core.Classes
{
    using System;
    using TGG.Core.Interfaces;

    public class OperationSuccessCalculator : IOperationSuccessCalculator
    {
        private readonly IGameBoard board;

        public OperationSuccessCalculator()
        {
            this.board = new GameBoard();
        }

        public bool IsAttackSuccesful(int x, int y)
        {
            x = this.board.GetXCoordinate(x);
            y = this.board.GetYCoordinate(y);

            if ((x + y - 5) % 2 != 0 )
            {
                throw new ArgumentException("The attack field's command is not successful.");
            }

            return (x + y - 5) % 2 == 0;
        }

        public bool IsDefenceSuccesful(int x, int y)
        {
            x = this.board.GetXCoordinate(x);
            y = this.board.GetYCoordinate(y);

            if ((x * y - 5) % 2 != 0)
            {
                throw new ArgumentException("The defend field's command is not successful.");
            }

            return (x * y - 5) % 2 == 0;
        }
    }
}
