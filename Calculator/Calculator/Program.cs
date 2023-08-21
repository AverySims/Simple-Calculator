namespace Calculator
{
	internal class Program
	{
		private static double valueA = -1;
		private static double valueB = -1;
		
		// program ending selection
		private static int userEndVal = -1;

		private static readonly string[] validOperators = { "+", "-", "*", "/" };
		private static string selectedOperator = "";

		private static bool loopMain = true;
		private static bool loopOperaterSelector = true;
		private static bool loopEndingSelector = true;

		static void Main(string[] args)
		{
			while (loopMain)
			{
				Console.WriteLine("Number A:");
				double.TryParse(Console.ReadLine(), out valueA);

				Console.WriteLine("Operation: + - * /");
				
				// selecting + - * /
				SelectOperator();

				Console.WriteLine("Number B:");
				double.TryParse(Console.ReadLine(), out valueB);

				PrintBlank(); // empty line before
				
				PrintEquation(selectedOperator);
				
				PrintBlank(); // empty line after

				SelectEndingPath();
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
					PrintInvalidSelection();
					break;

			}
		}

		#endregion

		#region Parsing
		// EC = Error correction
		private static bool ParseIntEC(out int val)
		{
			return int.TryParse(Console.ReadLine(), out val);
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
			// divide by 0 safe-guard
			if (a == 0 || b == 0)
				return 0;
			else
				return a / b;
		}
		#endregion

		private static void SelectOperator()
		{
			loopOperaterSelector = true;
			while (loopOperaterSelector)
			{
				bool operatorSymbolValid = false;
				// getting the first index in the split string from the console line,
				// entries are determined by seperation via spaces
				selectedOperator = Console.ReadLine().Split(" ")[0];
				foreach (string op in validOperators)
				{
					if (selectedOperator == op)
					{
						operatorSymbolValid = true;
						loopOperaterSelector = false;
						// breaking out of the loop if we have a matching operator
						break;
					}
				}

				if (operatorSymbolValid) // == true
					break;
				else
					PrintInvalidSelection();

			}
		}

		private static void SelectEndingPath()
		{
			// reset loop state before entering loop
			loopEndingSelector = true;
			Console.WriteLine("Choose what happens next:");
			PrintBlank();

			Console.WriteLine("1. Calculate new equation");
			Console.WriteLine("2. Quit program");

			while (loopEndingSelector)
			{
				ParseIntEC(out userEndVal);
				switch (userEndVal)
				{
					case 1:
						loopEndingSelector = false;
						break;

					case 2:
						loopEndingSelector = false;
						loopMain = false;
						break;

					default:
						PrintInvalidSelection();
						break;
				}
			}
			PrintBlank();
			return;
		}

		public static void PrintInvalidSelection()
		{
			Console.WriteLine("Invalid selection, please select a listed option.");
		}

		private static void PrintBlank()
		{
			Console.WriteLine("");
		}
	}
}