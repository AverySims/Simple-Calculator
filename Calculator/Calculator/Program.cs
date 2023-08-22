namespace Calculator
{
	internal class Program
	{
		private static double valueA = 0;
		private static double valueB = 0;

		private static readonly string[] operationTypes = { "+", "-", "*", "/" };
		private static string userOperationValue = "";

		private static bool loopMain = true;
		private static bool loopOperationSelector = true;

		static void Main(string[] args)
		{
			while (loopMain)
			{
				SelectNumberA();
				SelectOperator(); // selecting +, -, *, or /
				SelectNumberB();

				SimpleConsoleFunctions.PrintBlank(); // empty line before
				PrintEquation(userOperationValue);
				SimpleConsoleFunctions.PrintBlank(); // empty line after

				SimpleConsoleFunctions.SelectEndingAction(out loopMain);
			}
		}

		#region Formatting
		public static string FormatEquation(double a, double b, string operation, double result)
		{
			return $"{a} {operation} {b} = {result}";
		}

		private static void PrintEquation(string val)
		{
			switch (val)
			{
				case "+": // add
					Console.WriteLine($"{FormatEquation(valueA, valueB, val, SimpleAdd(valueA, valueB))}");
					break;

				case "-": // subtract
					Console.WriteLine($"{FormatEquation(valueA, valueB, val, SimpleSubtract(valueA, valueB))}");
					break;

				case "*": // multiply
					Console.WriteLine($"{FormatEquation(valueA, valueB, val, SimpleMultiply(valueA, valueB))}");
					break;

				case "/": // divide
					Console.WriteLine($"{FormatEquation(valueA, valueB, val, SimpleDivide(valueA, valueB))}");
					break;

				default: // invalid symbols
					SimpleConsoleFunctions.PrintInvalidSelection();
					break;
			}
		}
		#endregion

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
#if true
			// divide by 0 safe-guard
			// returns 0 when divided by 0
			if (a == 0 || b == 0)
				return 0;
			else
				return a / b;
#else
			// returns infinity when divided by 0
			return a / b;
#endif
		}
		#endregion

		private static void SelectNumberA()
		{
			bool tempLoop = true;

			Console.WriteLine("Number A:");
			while (tempLoop)
			{
				if (SimpleConsoleFunctions.ParseDoubleEC(out valueA))
				{
					tempLoop = false;
				}
				else
				{
					Console.WriteLine("Please enter a valid number");
				}
			}
		}

		private static void SelectNumberB()
		{
			bool tempLoop = true;

			Console.WriteLine("Number B:");
			while (tempLoop)
			{
				if (SimpleConsoleFunctions.ParseDoubleEC(out valueB))
				{
					tempLoop = false;
				}
				else
				{
					Console.WriteLine("Please enter a valid number");
				}
			}
		}

		private static void SelectOperator()
		{
			loopOperationSelector = true;

			Console.WriteLine("Operation: + - * /");
			while (loopOperationSelector)
			{
				bool operatorSymbolValid = false;
				// getting the first index in the split string from the console line,
				// entries are determined by seperation via spaces
				userOperationValue = Console.ReadLine().Split(" ")[0];
				foreach (string op in operationTypes)
				{
					if (userOperationValue == op)
					{
						operatorSymbolValid = true;
						loopOperationSelector = false;
						// breaking out of the loop if we have a matching operator
						break;
					}
				}

				if (operatorSymbolValid) // == true
				{
					break;
				}
				else
				{
					SimpleConsoleFunctions.PrintInvalidSelection();
				}

			}

		}

	}

}