using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace Lab6PigLatin
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Pig Latin translator!");

			bool again = true;

			while (again)
			{
				string input = InputHandlers.GetString("Enter the text to be translated: ");

				Console.WriteLine(ToPigLatin(input));

				Console.WriteLine();

				again = InputHandlers.Continue("Translate another line? (y/n): ");

				Console.Clear();
			}
			
			Console.WriteLine();

			Console.WriteLine("Goodbye!");

			Console.ReadLine();

		}

		static string ToPigLatin(string sentence)
		{
			// convert sentence to lower case.
			sentence = sentence.ToLower();

			// vowel string as constant.
			const string vowels = "aeiou";

			// create a string list, and add all words to list at one time. 
			List<string> words = new List<string>();
			words.AddRange(sentence.Split(' '));

			// create a string list, to hold new words.
			List<string> newWords = new List<string>();

			// loop through all words in our list.
			foreach (string word in words)
			{
				// set our high value, so we can tell we need to swap indexes of vowel.
				int index = int.MaxValue; // 2,147,483,647
				
				// current letter to cut at, after finding vowel.
				//int currentLetter = -1;

				// loops us through the word, a character at a time...
				for (int x = 0; x < word.Length; x++)
				{
					// loops us through the vowels, a character at a time.
					for (int y = 0; y < vowels.Length; y++)
					{
						// index of each vowel in order, as listed 'aeiou'
						int i = word.IndexOf(vowels[y]);
						// if index is less than highest index, and greater than -1.
						// -1 means vowel was not in word...
						if (i > -1)
						{
							// check to see if we have a vowel at a lower index value,
							// within the word.
							if (i < index)
							{
								// make swap happen.
								index = i;
							}
						}
					}
				}

				// if index equals 0, then we have a starting vowel.
				if (index == 0)
				{
					// use starting vowel rule.
					newWords.Add(word + "way");
				}
				else
				{
					// try to convert to a number, if it works just add it to new list.
					try
					{
						decimal numCheck = Convert.ToDecimal(word);
						newWords.Add(word);
					}
					// if it gets caught, it is a word, handle it here.
					catch
					{
						// non starting vowel rule, move all consonants to end of word.
						if (index != int.MaxValue) // having fun here with MaxValue.
						{
							// slpit word into front and back halves,
							// at vowel index location.
							string firstHalf = word.Substring(0, index);
							string backHalf = word.Substring(index, word.Length - index);

							// add word up and add 'ay'.
							newWords.Add(backHalf + firstHalf + "ay");
						}
						else
						{
							// handles exceptions.
							return "Does not compute! Please try again.";
						}
					}
				}
			}

			// uppercase the first character, of the first word.
			string temp = newWords[0].Substring(1, newWords[0].Length - 1);
			newWords[0] = newWords[0].Substring(0,1).ToUpper() + temp;

			return string.Join(" ", newWords);
		}
	}
}
