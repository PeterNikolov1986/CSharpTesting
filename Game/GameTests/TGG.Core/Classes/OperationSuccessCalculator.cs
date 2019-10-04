namespace TGG.Core.Classes
{
    using System;
    using TGG.Core.Constants;
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
            this.board.X = x;
            this.board.Y = y;

            if ((this.board.X + this.board.Y - 5) % 2 != 0 )
            {
                throw new ArgumentException(ExceptionConstants.ATTACK_FIELD);
            }

            return (this.board.X + this.board.Y - 5) % 2 == 0;
        }

        public bool IsDefenceSuccesful(int x, int y)
        {
            this.board.X = x;
            this.board.Y = y;

            if ((this.board.X * this.board.Y - 5) % 2 != 0)
            {
                throw new ArgumentException(ExceptionConstants.DEFEND_FIELD);
            }

            return (this.board.X * this.board.Y - 5) % 2 == 0;
        }
    }
}
