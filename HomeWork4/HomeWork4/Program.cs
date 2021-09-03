using System;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Enter size of the array:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out size))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again...");
                }
            }

            int[] nums = GetRandomArray(size, 1, 26);

            int[] evenNums, oddNums;

            DivideEvenAndOddNumbers(nums, out evenNums, out oddNums);

            char[] evenChars = ReplaceNumsToChars(evenNums);
            char[] oddChars = ReplaceNumsToChars(oddNums);

            char[] specific = { 'a', 'e', 'i', 'd', 'h', 'j' };
            evenChars = SpecificCharsToUpper(evenChars, specific);
            oddChars = SpecificCharsToUpper(oddChars, specific);

            int evenCounter = CountUppercases(evenChars);
            int oddCounter = CountUppercases(oddChars);

            if (evenCounter > oddCounter)
            {
                Console.WriteLine("Even chars have more uppercases!");
            }
            else if (oddCounter > evenCounter)
            {
                Console.WriteLine("Odd chars have more uppercases!");
            }
            else
            {
                Console.WriteLine("Each array have the same count of uppercases!");
            }

            Console.Write("Even chars: ");
            DisplayArray(evenChars);
            Console.Write("Odd chars: ");
            DisplayArray(oddChars);
        }

        static int[] GetRandomArray(int size, int min, int max)
        {
            int[] nums = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                nums[i] = random.Next(min, max);
            }

            return nums;
        }

        static void DivideEvenAndOddNumbers(int[] nums, out int[] evenNums, out int[] oddNums)
        {
            int evenCounter = 0;

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    evenCounter++;
                }
            }

            evenNums = new int[evenCounter];
            oddNums = new int[nums.Length - evenCounter];

            int evenStep = 0;
            int oddStep = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    evenNums[i - evenStep] = nums[i];
                    oddStep++;
                }
                else
                {
                    oddNums[i - oddStep] = nums[i];
                    evenStep++;
                }
            }
        }

        static char[] ReplaceNumsToChars(int[] nums)
        {
            char[] chars = new char[nums.Length];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(nums[i] + 97);
            }

            return chars;
        }

        static char[] SpecificCharsToUpper(char[] chars, params char[] specific)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < specific.Length; j++)
                {
                    if (chars[i] == specific[j])
                    {
                        chars[i] = specific[j].ToString().ToUpper().ToCharArray()[0];
                    }
                }
            }

            return chars;
        }

        static int CountUppercases(char[] chars)
        {
            int counter = 0;

            foreach (char c in chars)
            {
                if (c.ToString() == c.ToString().ToUpper())
                {
                    counter++;
                }
            }

            return counter;
        }

        static void DisplayArray(char[] chars)
        {
            foreach (char c in chars)
            {
                Console.Write($"{c} ");
            }

            Console.WriteLine();
        }
    }
}
