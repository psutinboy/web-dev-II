public interface IAnimal
{
    void MakeSound();
}

public interface IWalkable
{
    void Walk();
}

public class Dog : IAnimal, IWalkable
{
    public void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }

    public void Walk()
    {
        Console.WriteLine("Dog walks");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Dog myDog = new Dog();
        myDog.MakeSound();
        myDog.Walk();
    }
}
