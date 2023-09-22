using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingProject
{
	public class AverageClass
	{
		public AverageClass()
		{

		}

		public void Average(int[] Arr)
		{
			try
			{ 

				if(Arr.Length == 0)
				{
					throw new Exception("The array passed to calculate average is empty.");
				}
                int sum = 0;
                foreach (int num in Arr)
                {
                    sum += num;
                }
                double avg = (double)sum / Arr.Length;
                Console.WriteLine($"Average of given Array Integers is : {avg}");
            }
			catch(Exception e)
			{
				Console.WriteLine($"Exception Occurred: {e.Message}");
			}
			
		}

		public void StrtoInt(string str)
		{
			try
			{
				
                int num = int.Parse(str);
				Console.WriteLine($"Converted number: {num}");
            }
			catch (FormatException e)
            {
                Console.WriteLine($"Exception Occurred: {e.Message}.");

            }

		}
		
		public void RangeInt(string[] arr3)
		{
			try
			{
                int[] arr = new int[5];
                
                for (int i = 0; i < 5; i++)
                    arr[i] = int.Parse(arr3[i]);
            }
			catch(OverflowException e)
			{
                Console.WriteLine($"Exception Occurred: {e.Message}.");
            }
			
		}

		public void Divide(int numerator, int denominator)
		{
			try
			{
                int num = numerator / denominator;
				Console.WriteLine($"Divide Answer: {num}");
            }
			catch(DivideByZeroException e)
			{
                Console.WriteLine($"Exception Occurred: {e.Message}");
            }
        }

		public void StrToDate(string str)
		{
			try
			{
                DateTime date = DateTime.Parse(str);
				Console.WriteLine($"Date: {date}");
            }
			catch(FormatException e)
			{
                Console.WriteLine($"Exception Occurred: {e.Message}");
            }
			
		}

		public void Sqrt(double n)
        {   try
			{
				if (n < 0)
				{
					throw new ArgumentOutOfRangeException("Input must be non-negative.");
				}
                double sqrt_no = Math.Sqrt(n);
                Console.WriteLine($"Square root: {sqrt_no}");
            }
			catch(ArgumentOutOfRangeException e)
			{
                Console.WriteLine($"Exception Occurred: {e.Message}");
            }
			
		}
		public void UpperCase(string str)
		{
			
            try
			{

				if (str.Length == 0)
					throw new NullReferenceException("Empty string cannot be converted to uppercase.");
				str = str.ToUpper();
				Console.WriteLine($"UpperCase : {str}");
			}
			catch(NullReferenceException e)
			{
                Console.WriteLine($"Exception Occurred: {e.Message}");
            }
		}
		public void factorial(int n)
		{
			try
			{
                int fact = 1;
                for (int i = n; i > 0; i--)
                {
					checked
					{
						fact = fact * i;
					}
                }
                Console.WriteLine($"Factorial of {n}: {fact}");
            }
			catch(OverflowException e)
			{
                Console.WriteLine($"Exception Occurred: {e.Message}");
            }

		}
			

		

		static void Main(string[] args)
		{
			int[] arr1 = { 10, 20, 30, 41, 55, 63 };
			int[] arr2 = { };
			string[] arr3 = {"3","33","3333","3333333333","333333" };
            string[] arr4 = { "3", "33", "3333", "33333333", "333333" };
            AverageClass Obj1 = new AverageClass();
			Obj1.Average(arr1);
			Obj1.Average(arr2);

			Obj1.StrtoInt("32");
            Obj1.StrtoInt("hi");

            Obj1.RangeInt(arr4);
            Obj1.RangeInt(arr3);

            Obj1.Divide(10,5);
			Obj1.Divide(8, 0);

			Obj1.StrToDate("03/06/1998");
            Obj1.StrToDate("hi");

			Obj1.Sqrt(100.0);
			Obj1.Sqrt(-100.0);

			Obj1.UpperCase("paritosh");
            Obj1.UpperCase("");

			Obj1.factorial(10);
            Obj1.factorial(100);


        }

    }
	

}

