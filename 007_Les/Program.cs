internal class Program
{
	private static void Main(string[] _)
	{
		// Task1
		{
			string? email = "somemail@gmail.com";
			string? password = "12345678";
			double usd = 100;

			Console.WriteLine($"Email {email} is {(Task1.IsEmailValid(email)? "valid" : "Invalid")}");
			Console.WriteLine($"Password {password} is {(Task1.IsPasswordValid(password) ? "valid" : "Invalid")}");
			Console.WriteLine($"{usd} USD is {Task1.UsdToEu(usd)} EU");
		}

		Console.WriteLine();

		// Task2
		{
			string firstName = "John";
			string lastName = "Doe";
			double radius = 10;
			double height = 20;
			double width = 30;
			int number = 10;

			Console.WriteLine($"Full name: {Task2.GetFullName(firstName, lastName)}");
			Console.WriteLine($"Cylinder volume: {Task2.CalculateCylinderVolume(radius, height):0.00}");
			Console.WriteLine($"Number {number} is {(Task2.IsEven(number) ? "even" : "odd")}");
			Console.WriteLine($"Rectangle area: {Task2.CalculateRectangleArea(width, height):0.00}");
		}

        Console.WriteLine();

		// Task3
		{
			int number = 10;
			Console.WriteLine($"Factorial of {number} is {Task3.Factorial(number)}");
			Console.WriteLine($"Fibonacci of {number} is {Task3.Fibonacci(number)}");
		}
    }
}