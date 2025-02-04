public class Animal
{
  public virtual void makeSound()
  {
    Console.WriteLine("The animal makes a sound");
  }
}

public class Dog : Animal
{
  public override void makeSound()
  {
    Console.WriteLine("The dog barks");
  }
}

public class Program
{
  static void Main(string[] args)
  {
    Animal myAnimal = new Dog();
    myAnimal.makeSound();
  }

}
