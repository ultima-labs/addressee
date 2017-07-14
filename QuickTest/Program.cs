using System;
using System.Globalization;
using Addressee;
using Addressee.AU;

namespace QuickTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var lang = SupportedLanguage.PickLanguage(new CultureInfo("ru"));

            var postcode = new AustralianPostcode(4000);

            Console.WriteLine($"{postcode:G}");
        }
    }
}