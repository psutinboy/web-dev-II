public class Person
{
  private string _name;

  public string Name
  {
    get { return _name; }
    set
    {
      if (string.IsNullOrEmpty(value))
      {
        Console.WriteLine("Name cannot be empty");
      }
      else
      {
        _name = value;
      }
    }
  }
}
