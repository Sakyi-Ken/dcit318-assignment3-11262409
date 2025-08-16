using Assignment3.FinanceManagement.Accounts;
using Assignment3.FinanceManagement.Processors;

namespace Assignment3.FinanceManagement.App
{
  public class FinanceApp
  {
    public readonly List<Transaction> _transactions = new();

    public void Run()
    {
      // 1. Instantiate a SavingsAccount
      //var account = new SavingsAccount("ACC-1001", 1000m);
      SavingsAccount account = new SavingsAccount("ACC-1001", 1000m);
      Console.WriteLine($"Starting balance for account {account.AccountNumber}: {account.Balance:C}\n");

      // 2. Create three Transaction records
      var t1 = new Transaction(1, DateTime.Now, 200m, "Groceries");
      var t2 = new Transaction(2, DateTime.Now, 150m, "Utilities");
      var t3 = new Transaction(3, DateTime.Now, 50m, "Entertainment");

      // 3. Instantiate processors
      ITransactionProcessor mobileMoney = new MobileMoneyProcessor();
      ITransactionProcessor bankTransfer = new BankTransferProcessor();
      ITransactionProcessor cryptoWallet = new CryptoWalletProcessor();

      // Process and apply transaction 1
      Console.WriteLine("-- Transaction 1 --");
      mobileMoney.Process(t1);
      account.ApplyTransaction(t1);

      // Process and apply transaction 2
      Console.WriteLine("\n-- Transaction 2 --");
      bankTransfer.Process(t2);
      account.ApplyTransaction(t2);

      // Process and apply transaction 3
      Console.WriteLine("\n-- Transaction 3 --");
      cryptoWallet.Process(t3);
      account.ApplyTransaction(t3);

      // 4. Add transactions to list
      _transactions.AddRange([t1, t2, t3]);
      // _transactions.AddRange(new[] { t1, t2, t3 });


      // Summary
      Console.WriteLine($"\nFinal balance: {account.Balance:C}");
    }
  }
}