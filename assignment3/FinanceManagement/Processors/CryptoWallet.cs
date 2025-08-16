using System;

namespace Assignment3.FinanceManagement.Processors
{
  public class CryptoWalletProcessor : ITransactionProcessor
  {
    public void Process(Transaction transaction)
    {
      Console.WriteLine($"[Crypto Wallet] Processed {transaction.Amount:C} for {transaction.Category} (Id: {transaction.Id})");
    }
  }
}