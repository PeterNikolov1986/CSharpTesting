namespace Bank.Account.Core.Shared.Constants
{
    public class ExceptionConstants
    {
        public const string INIT_FIRST = "A bank account's initialization with negative sum is impossible.";
        public const string INIT_SECOND = "A bank account's initialization doesn't need deposit of money.";
        public const string DEPOSIT = "The deposited sum can not be negative or equal to zero.";
        public const string ACCOUNT_DEPOSIT = "The initial sum in a bank account can not be negative.";
        public const string WITHDRAWAL = "The withdrawn sum can not be negative or equal to zero.";
        public const string ACCOUNT_WITHDRAWAL = "The initial sum in a bank account can not be less than the withdrawn one.";
    }
}
