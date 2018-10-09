using System;

namespace MonthAndYearFromSpanishRegistration
{
    class Program
    {
        static void Main()
        {
            var strRegNumber = "4252JNZ"; 
            // JNZ should be 2016 / May
            var age = SpanishRegistrationAge.NearestMonth(strRegNumber);
            Console.WriteLine(age.year + "/" + age.month);
        }
    }
}
