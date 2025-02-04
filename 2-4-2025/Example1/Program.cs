public class BankAccount
{
  private decimal _balance;
  public string AccountHolder;

  public BankAccount(string accountHolder, decimal initialBalance)
  {
    AccountHolder = accountHolder;
    _balance = initialBalance;
  }

  public decimal Balance
  {
    get { return _balance; }
  }

  public void Deposit(decimal amount)
  {
    if (amount > 0)
    {
      _balance += amount;
    }
    else
    {
      Console.WriteLine("Deposit amount must be positive");
    }
  }

  public void Withdraw(decimal amount)
  {
    if (amount > 0 && amount <= _balance)
    {
      _balance -= amount;
    }
    else
    {
      Console.WriteLine("Insufficient funds");
    }
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    BankAccount account = new BankAccount("John Doe", 500);
    account.Deposit(200);
    account.Withdraw(100);
    Console.WriteLine($"Balance: {account.Balance}");
  }
}