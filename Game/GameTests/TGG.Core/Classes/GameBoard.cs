namespace TGG.Core.Classes
{
    using System;
    using TGG.Core.Constants;
    using TGG.Core.Interfaces;
    using TGG.Core.Shared.Types;

    public class GameBoard : IGameBoard
    {
        private int x;
        private int y;

        public int X
        {
            get { return this.x; }
            set 
            {
                if (this.x >= (int)ValidBoundaryTypes.Zero && this.x <= (int)ValidBoundaryTypes.X)
                {
                    this.x = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionConstants.X);
                }
            }   
        }

        public int Y 
        {
            get { return this.y; }
            set 
            {
                if (this.y >= (int)ValidBoundaryTypes.Zero && this.y <= (int)ValidBoundaryTypes.Y)
                {
                    this.y = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionConstants.Y);
                }
            }
        }
    }
}
