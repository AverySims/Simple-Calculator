namespace Calculator
{
	internal class Program
	{
		private static double valueA = -1;
		private static double valueB = -1;

		private static string[] validOperators = { "+", "-", "*", "/" };
		//private static string[] splitOperator;
		private static string selectedOperator = "";
		private static bool loopOperaterSelector = true;

		static void Main(string[] args)
		{
			Console.WriteLine("Number A:");
			double.TryParse(Console.ReadLine(), out valueA);

			Console.WriteLine("Operation: ( + - * / )");

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
					PrintInvalidOperator();

			}

			Console.WriteLine("Number B:");
			double.TryParse(Console.ReadLine(), out valueB);

			PrintEquation(selectedOperator);
		}

		private static void PrintEquation(string val)
		{
			switch (val)
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

				case "/": // divide
					Console.WriteLine(SimpleDivide(valueA, valueB));
					break;

				default: // invalid symbols
					PrintInvalidOperator();
					break;
				/*
				case "x": // multiply
					Console.WriteLine(SimpleMultiply(valueA, valueB));
					break;

				case "X": // multiply
					Console.WriteLine(SimpleMultiply(valueA, valueB));
					break;

				case "÷": // divide
					Console.WriteLine(SimpleDivide(valueA, valueB));
					break;
				*/
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
				return 0;
			else
				return a / b;
		}
		#endregion

		public static void PrintInvalidOperator()
		{
			Console.WriteLine("Please select a valid operation symbol");
		}

	}
}



