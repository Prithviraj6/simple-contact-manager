using System.Linq;
using ContactManager.Constants;

namespace ContactManager.Utilities
{
    /// <summary>
    /// Provides validation methods for contact information.
    /// </summary>
    public static class ContactValidator
    {
        /// <summary>
        /// Validates a phone number by checking if it contains at least 10 digits.
        /// </summary>
        /// <param name="phone">The phone number to validate</param>
        /// <returns>True if the phone number is valid, false otherwise</returns>
        public static bool ValidatePhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            string digitsOnly = new string(phone.Where(char.IsDigit).ToArray());
            return digitsOnly.Length >= AppConstants.MIN_PHONE_DIGITS;
        }

        /// <summary>
        /// Validates that a string is not null or empty.
        /// </summary>
        /// <param name="input">The string to validate</param>
        /// <returns>True if the string has content, false otherwise</returns>
        public static bool ValidateNonEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
