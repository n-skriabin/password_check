using System;
using System.Text.RegularExpressions;

namespace lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string way = string.Empty;
            string finalVerdict = string.Empty;

            do {
                int passwordQuality = 0;

                Console.WriteLine("\n" +
                    "Please, input password: ");

                var password = Console.ReadLine();

                passwordQuality += CheckNumbers(password, ref finalVerdict);

                passwordQuality += CheckPasswordLength(password, ref finalVerdict);

                passwordQuality += CheckSpecialSymbols(password, ref finalVerdict);

                passwordQuality += CheckLowAndUpperCase(password, ref finalVerdict);

                WritePasswordReport(passwordQuality, password.Length, finalVerdict);

                Console.WriteLine("Do you want to close programm? (no - 0/yes - any key)");
                way = Console.ReadLine();

            } while (way == "0");

            Console.ReadKey();
        }

        private static void WritePasswordReport(int passwordQuality, int passwordLength, string finalVerdict)
        {
            Console.WriteLine($"Password quality: {passwordQuality}\n");
            Console.WriteLine($"{finalVerdict}");

            if (passwordQuality < 30)
            {
                Console.WriteLine("Your password is generally bad.\n");
            }

            if (passwordQuality >= 30 && passwordQuality <= 80)
            {
                Console.WriteLine("Your password is normal.\n");
            }

            if (passwordQuality > 80)
            {
                Console.WriteLine("Your password is beautiful.\n");
            }
        }

        private static int CheckSpecialSymbols(string password, ref string finalVerdict)
        {
            int passwordQuality = 0;
            var regExSpecSymb = new Regex("(?=.*[!@#$%^&_,.-=+`~/\\|])");

            if (regExSpecSymb.IsMatch(password))
            {
                passwordQuality += 20;
                finalVerdict += "have special symbols(!@#$%^&_,.-=+`~/\\|), "; 
            }
            else
            {
                passwordQuality -= 20;
                finalVerdict += "havn't got special symbols(!@#$%^&_,.-=+`~/\\|), ";
            }

            return passwordQuality;
        }

        private static int CheckNumbers(string password, ref string finalVerdict)
        {
            int passwordQuality = 0;
            var regExNumb = new Regex("(?=.*\\d)");

            if (regExNumb.IsMatch(password))
            {
                passwordQuality += 10;
                finalVerdict += "Your password have numbers, ";
            }
            else
            {
                passwordQuality -= 10;
                finalVerdict += "Your password havn't got numbers, ";
            }

            return passwordQuality;
        }

        static public int CheckLowAndUpperCase(string password, ref string finalVerdict)
        {
            int passwordQuality = 0;
            var regExUp = new Regex("(?=.*[A-Z])");
            var regExLow = new Regex("(?=.*[a-z])");

            if (regExLow.IsMatch(password))
            {
                passwordQuality += 10;
                finalVerdict += "have chars in low case ";
            }
            else
            {
                passwordQuality -= 10;
                finalVerdict += "havn't got chars in low case ";
            }

            if (regExUp.IsMatch(password))
            {
                passwordQuality += 10;
                finalVerdict += "and have chars in upper case.";
            }
            else
            {
                passwordQuality -= 10;
                finalVerdict += "and have chars in upper case.";
            }

            return passwordQuality;
        }

        static public int CheckPasswordLength(string password, ref string finalVerdict)
        {
            int passwordQuality = 0;
            var passwordLength = password.Length;
            
            if (passwordLength < 6)
            {
                passwordQuality = (passwordLength - 6) * 10;
                finalVerdict += "too short, ";
            }

            if (passwordLength >= 6 && passwordLength <= 8)
            {
                passwordQuality = (passwordLength * 5) + 10;
                finalVerdict += "normal length, ";
            }

            if (passwordLength > 8)
            {
                passwordQuality = 50 + (8 - passwordLength) * 2;
                finalVerdict += "too long, ";
            }

            return passwordQuality;
        }
    }
}
