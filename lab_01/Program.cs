using System;
using System.Text.RegularExpressions;

namespace lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string way;
            string finalVerdict;

            do {
                int passwordQuality = 0;
                finalVerdict = string.Empty;

                Console.WriteLine("\nPlease, input password: ");

                var password = Console.ReadLine();

                passwordQuality += CheckNumbers(password, ref finalVerdict);

                passwordQuality += CheckPasswordLength(password, ref finalVerdict);

                passwordQuality += CheckSpecialSymbols(password, ref finalVerdict);

                passwordQuality += CheckLowAndUpperCase(password, ref finalVerdict);

                WritePasswordReport(passwordQuality, password.Length, finalVerdict);

                Console.WriteLine("Do you want to close programm? (no - 0/yes - any key)");
                way = Console.ReadLine();

            } while (way == "0");
        }

        private static void WritePasswordReport(int passwordQuality, int passwordLength, string finalVerdict)
        {
            Console.WriteLine($"\nPassword quality: {passwordQuality}/100\n");

            if (finalVerdict != string.Empty) {
                Console.WriteLine($"Recommendations:\n{finalVerdict}");
            }

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
            var regExSpecSymb = new Regex("(?=.*[!@#$%^&_;:,.-=+`~/\\|])");

            if (regExSpecSymb.IsMatch(password))
            {
                passwordQuality += 20;
            }
            else
            {
                passwordQuality -= 20;
                finalVerdict += "-add special characters(!@#$%^&_;:,.-=+`~/\\|)\n";
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
            }
            else
            {
                passwordQuality -= 10;
                finalVerdict += "-add numbers\n";
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
            }
            else
            {
                passwordQuality -= 10;
                finalVerdict += "-add chars in lowercase\n";
            }

            if (regExUp.IsMatch(password))
            {
                passwordQuality += 10;
            }
            else
            {
                passwordQuality -= 10;
                finalVerdict += "-add chars in uppercase\n";
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
                finalVerdict += "-too short(optimal length - 8 characters)\n";
            }

            if (passwordLength >= 6 && passwordLength <= 8)
            {
                passwordQuality = (passwordLength * 5) + 10;
            }

            if (passwordLength > 8)
            {
                passwordQuality = 50 + (8 - passwordLength) * 2;
                finalVerdict += "-too long(optimal length - 8 characters)\n";
            }

            return passwordQuality;
        }
    }
}
