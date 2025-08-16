namespace Assignment3.FinanceManagement.Accounts
{
  public class Account
  {
    public string AccountNumber { get; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
      AccountNumber = accountNumber;
      Balance = initialBalance;
    }

    public virtual void ApplyTransaction(Transaction transaction)
    {
      // default behaviour: deduct amount
      Balance -= transaction.Amount;
    }
  }
}