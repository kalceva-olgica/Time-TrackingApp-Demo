using System.Security.Cryptography.X509Certificates;

namespace TimeTracking.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateStringInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
        public static int ValidateNumberInput(string number, int range)
        {
            bool isNumber = int.TryParse(number, out int num);
            if (!isNumber || num <= 0 || num > range)
            {
                return -1;
            }
            return num;
        }
        public static bool ValidInputLength(string input, int length)
        {
            if (input.Length < length)
            {
                ExtendedConsole.PrintError($"The input must be {length} characters long");
                return false;
            }
            return true;
        }
        public static bool ValidateUsername(string username)
        {
            return username.Length >= 5;
        }
        public static bool ValidatePassword(string password)
        {
            if (password.Length < 6)
                return false;

            bool hasUpperLetter = false;
            bool hasDigit = false;

            foreach (char character in password)
            {
                if (char.IsDigit(character))
                {
                    hasDigit = true;
                }
                if (char.IsUpper(character))
                {
                    hasUpperLetter = true;
                }
                if (hasUpperLetter && hasDigit)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ValidateFirstNameOnly(string firstName)
        {

            if (firstName.Length < 2)
            {
                return false;
            }
            foreach (char letter in firstName)
            {
                if (char.IsDigit(letter))
                {
                    return false;

                }
            }
            return true;

        }
        public static bool ValidateLastNameOnly(string lastName)
        {

            if (lastName.Length < 2)
            {
                return false;
            }
            foreach (char letter in lastName)
            {
                if (char.IsDigit(letter))
                {
                    return false;
                }
            }
            return true;

        }
        public static bool ValidFirstAndLastName(string firstName, string lastName)
        {
            bool noDigitInFirstName = true;
            bool noDigitInLastName = true;
            if (firstName.Length < 2 || lastName.Length < 2)
            {
                return false;
            }

            foreach (char letter in firstName)
            {
                if (char.IsDigit(letter))
                {
                    noDigitInFirstName = false;
                    break;
                }
            }
            foreach (char letter in lastName)
            {
                if (char.IsDigit(letter))
                {
                    noDigitInLastName = false;
                    break;
                }
            }
            return noDigitInFirstName && noDigitInLastName;
        }

        public static bool AgeValidation(int age, int underLimit, int overLimit)
        {
            return age < underLimit || age > overLimit ? false : true;
        }


    }
}
