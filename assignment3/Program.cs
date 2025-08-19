// using Assignment3.FinanceManagement.App;
// using Assignment3.App;
// using assignment3.WarehouseInventory.App;
using assignment3.SchoolGradingSys.Processing;

class Program
{
  static void Main(string[] args)
  {
    // var app = new FinanceApp();
    //FinanceApp app = new FinanceApp();

    // var app = new HealthSystemApp();
    // app.Run();

    // var app = new WareHouseManager();
    // app.Run();

    var app = new StudentResultProcessor();
    app.Run();
  }
}
