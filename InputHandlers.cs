using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class InputHandlers
    {
		public static bool Continue(string prompt)
		{
			bool goOn = true;

			while (goOn)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();
				input = input.ToLower();

				if (input == "n")
				{
					goOn = false;
				}
				else if (input == "y")
				{
					return true;
				}
				else
				{
					Console.WriteLine("Sorry, I did not understand that... (y/n)");
				}
			}

			return goOn;
		}

		public static string GetString(string prompt)
		{
			bool valid = false;
			string value = string.Empty;

			while (!valid)
			{
				try
				{
					Console.Write(prompt);
					value = Console.ReadLine();

					valid = true;
				}
				catch
				{
					Console.WriteLine("\nSay what? Try again.");
				}
			}

			return value;
		}
	}
}