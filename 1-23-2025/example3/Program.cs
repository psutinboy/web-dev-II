using System;

public class Program
{
  public static void Main(string[] args)
  {
    int[] arr = new int[5];
    arr[0] = 10;
    arr[2] = 20;
    arr[4] = 30;

    for (int i = 0; i < arr.Length; i++)
    {
      Console.WriteLine(arr[i]);
    }
  }
}
