namespace Calculator
{
	internal class Program
	{
		private static double valueA = -1;
		private static double valueB = -1;

		private static string stringOperator = "";
		private static string[] operationSymbolArray;
		private static bool enableSymbolLoop = true;

		static void Main(string[] args)
		{
			Console.WriteLine("Number A:");
			double.TryParse(Console.ReadLine(), out valueA);

			while (enableSymbolLoop)
			{
				Console.WriteLine("Operation: ( + - * / )");
				stringOperator = Console.ReadLine();

				operationSymbolArray = stringOperator.Split(" ");
			}
			
			Console.WriteLine("Number B:");
			double.TryParse(Console.ReadLine(), out valueB);

			switch (operationSymbolArray[0])
			{
				case "+": // add
					Console.WriteLine(SimpleAdd(valueA, valueB));
					break;

				case "-": // subtract
					Console.WriteLine(SimpleSubtract(valueA, valueB));
					break;

				case "*": // multiply
					Console.WriteLine(SimpleMultiply(valueA, valueB));
					break;

				case "x": // multiply
					Console.WriteLine(SimpleMultiply(valueA, valueB));
					break;

				case "X": // multiply
					Console.WriteLine(SimpleMultiply(valueA, valueB));
					break;

				case "/": // divide
					Console.WriteLine(SimpleDivide(valueA, valueB));
					break;

				case "÷": // divide
					Console.WriteLine(SimpleDivide(valueA, valueB));
					break;

				default:
					Console.WriteLine("Please enter a valid operation symbol");
					break;
			}
		}

		#region Operations
		public static double SimpleAdd(double a, double b)
		{
			return a + b;
		}

		public static double SimpleSubtract(double a, double b)
		{
			return a - b;
		}

		public static double SimpleMultiply(double a, double b)
		{
			return a * b;
		}

		public static double SimpleDivide(double a, double b)
		{
			// divide by 0 safe-guard
			if (a == 0 || b == 0)
			{
				return 0;
			}

			return a / b;
		}
		#endregion

	}
}