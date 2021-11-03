using System;
using System.Globalization;

namespace assignment2
{
  class Program
  {
    static void Main(string[] args)
    {
      // Declaring variables and date format
      string dateInput, format;
      DateTime result;
      format = "yyyy/MM/dd";
      CultureInfo provider = CultureInfo.InvariantCulture;

      // Try/catch to verify input value is not empty
      try
      {
        dateInput = GetInput();
        // Try/catch to verify that the input value is a date of a valid format
        try
        {
          result = DateTime.ParseExact(dateInput, format, provider);

          // TODO: Ask teacher what algorithm is used for this line? Is there 
          // a limitation compared to Zeller?
          // Console.WriteLine("You were born on a {0}", result.DayOfWeek); 
          
          
          Zeller(result.Day, result.Month, result.Year);
        }
        catch (FormatException)
        {
          Console.WriteLine("{0} is not in the correct format.", dateInput);
        }

      }
      catch (ArgumentException e)
      {
        Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
      }

    }

    // Function to get the input from the user
    public static string GetInput()
    {
      Console.WriteLine("Please enter birthdate in the following format: (yyyy/mm/dd)");
      string inputDate = Console.ReadLine();
      if (string.IsNullOrEmpty(inputDate))
      {
        throw new ArgumentException("Invalid input.");
      }
      return inputDate;
    }

    // Function with the algorithm to find out what day a specific date is
    public static void Zeller(int day, int month, int year)
    {
      Console.WriteLine("Day: {0}, Month: {1}, Year: {2}", day, month, year);
      if (month < 3)
      {
        month = month + 12;
        year = year - 1;
      }

      int yearOfCentury = year / 100;
      int yearOfDecade = year % 100;
      int dayOfWeek = (day + ((13 * (month + 1)) / 5) + yearOfDecade + (yearOfDecade / 4) + (yearOfCentury / 4) + 5 * yearOfCentury) % 7;

      // Example with floor:
      // int dayOfWeek = (day + (int)(Math.Floor((double)((13 * (month + 1) / 5))) + yearOfDecade + Math.Floor((double)(yearOfDecade / 4)) + Math.Floor((double)(yearOfCentury / 4)) + 5 * yearOfCentury)) % 7;

      string prefix = "You were born on a";
  

      // Switch case to change the number of the day to text instead
      switch (dayOfWeek)
      {
        case 0:
          Console.WriteLine("{0} Saturday", prefix);
          break;

        case 1:
          Console.WriteLine("{0} Sunday", prefix);
          break;

        case 2:
          Console.WriteLine("{0} Monday", prefix);
          break;

        case 3:
          Console.WriteLine("{0} Tuesday", prefix);
          break;

        case 4:
          Console.WriteLine("{0} Wednesday", prefix);
          break;

        case 5:
          Console.WriteLine("{0} Thursday", prefix);
          break;

        case 6:
          Console.WriteLine("{0} Friday", prefix);
          break;
      }
    }
  }
}
