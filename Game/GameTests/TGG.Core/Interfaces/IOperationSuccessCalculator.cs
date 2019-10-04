namespace TGG.Core.Interfaces
{
    public interface IOperationSuccessCalculator
    {
        bool IsAttackSuccesful(int x, int y);

        bool IsDefenceSuccesful(int x, int y);
    }
}
