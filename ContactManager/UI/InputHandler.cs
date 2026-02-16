using System;
using ContactManager.Utilities;

namespace ContactManager.UI
{
    /// <summary>
    /// Handles user input with validation.
    /// </summary>
    public static class InputHandler
    {
        /// <summary>
        /// Gets a validated integer choice within a specified range.
        /// </summary>
        /// <param name="min">Minimum valid value</param>
        /// <param name="max">Maximum valid value</param>
        /// <returns>The validated user choice</returns>
        public static int GetValidChoice(int min, int max)
        {
            int input;
            bool isValid;

            do
            {
                Console.Write($"Enter choice ({min}-{max}): ");
                isValid = int.TryParse(Console.ReadLine(), out input) &&
                         input >= min && input <= max;

                if (!isValid)
                {
                    Console.WriteLine($"✗ Please enter a number between {min} and {max}\n");
                }

            } while (!isValid);

            return input;
        }

        /// <summary>
        /// Gets a validated phone number from the user.
        /// </summary>
        /// <returns>The validated phone number</returns>
        public static string GetValidPhone()
        {
            string phone;
            bool isValid;

            do
            {
                Console.Write("Phone: ");
                phone = Console.ReadLine()?.Trim() ?? string.Empty;

                isValid = ContactValidator.ValidatePhoneNumber(phone);

                if (!isValid)
                {
                    Console.WriteLine("✗ Please enter a valid phone number (at least 10 digits)\n");
                }

            } while (!isValid);

            return phone;
        }

        /// <summary>
        /// Gets non-empty input from the user with a custom prompt.
        /// </summary>
        /// <param name="prompt">The prompt to display</param>
        /// <returns>The validated non-empty input</returns>
        public static string GetNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!ContactValidator.ValidateNonEmpty(input))
                {
                    Console.WriteLine("✗ This field cannot be empty\n");
                }

            } while (!ContactValidator.ValidateNonEmpty(input));

            return input;
        }
    }
}
