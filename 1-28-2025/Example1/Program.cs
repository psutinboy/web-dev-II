public class BankAccount
{
  public decimal Balance;
  private string _owner;

  public string Owner
  {
    get { return _owner; }
    set { _owner = value.ToUpper(); }
  }
  public event EventHandler lowBalance;

  public void Deposit(decimal amount)
  {
    if (amount > 0)
    {
      Balance += amount;
      Console.WriteLine($"Deposited {amount}. Current balance: {Balance}");
    }
    else
    {
      Console.WriteLine("Invalid deposit amount.");
    }
  }

  public void Withdraw(decimal amount)
  {
    if (Balance >= amount)
    {
      Balance -= amount;
      Console.WriteLine($"Withdrew {amount}. Current balance: {Balance}");
      if (Balance < 50 && lowBalance != null)
      {
        lowBalance(this, EventArgs.Empty);
      }
    }
    else
    {
      Console.WriteLine("Insufficient funds.");
    }
  }

}

public class Program
{
  public static void Main(string[] args)
  {
    BankAccount account = new BankAccount();

    account.lowBalance += (sender, e) =>
    {
      Console.WriteLine("Warning: low balance");
    };

    account.Owner = "John Doe";
    Console.WriteLine($"Account owner: {account.Owner}");

    account.Deposit(100);
    account.Withdraw(60);
  }
}

