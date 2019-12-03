namespace TGG.Core.Classes
{
    using System;
    using TGG.Core.Interfaces;
    using TGG.Core.Shared.Types;

    public class GameBoard : IGameBoard
    {
        public int GetXCoordinate(int x)
        {
            if (x < (int)ValidBoundaryTypes.Zero || x > (int)ValidBoundaryTypes.X)
            {
                throw new ArgumentException("Invalid value of the X coordinate.");
            }

            return x;
        }

        public int GetYCoordinate(int y)
        {
            if (y < (int)ValidBoundaryTypes.Zero || y > (int)ValidBoundaryTypes.Y)
            {
                throw new ArgumentException("Invalid value of the Y coordinate.");
            }

            return y;
        }
    }
}
