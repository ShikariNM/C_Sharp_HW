// Напишите программу, которая принимает на вход трёхзначное число и
// на выходе показывает вторую цифру этого числа.

// 456 -> 5
// 782 -> 8 
// 918 -> 1

Console.Clear ();
Console.Write ("Enter the number: ");
int num = int.Parse (Console.ReadLine ());
Console.WriteLine($"{(num % 100 - num % 10) / 10}");