using System;

namespace ContactManager.UI
{
    /// <summary>
    /// Handles console menu display and formatting.
    /// </summary>
    public static class MenuDisplay
    {
        /// <summary>
        /// Displays the application header.
        /// </summary>
        public static void DisplayHeader()
        {
            Console.WriteLine("╔═══════════════════════════╗");
            Console.WriteLine("║    CONTACT MANAGER        ║");
            Console.WriteLine("╚═══════════════════════════╝\n");
        }

        /// <summary>
        /// Displays the main menu options.
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("┌─────────────────────────┐");
            Console.WriteLine("│  MAIN MENU              │");
            Console.WriteLine("├─────────────────────────┤");
            Console.WriteLine("│  1. Add Contact         │");
            Console.WriteLine("│  2. View All Contacts   │");
            Console.WriteLine("│  3. Search Contact      │");
            Console.WriteLine("│  4. Edit Contact        │");
            Console.WriteLine("│  5. Delete Contact      │");
            Console.WriteLine("│  6. Exit                │");
            Console.WriteLine("└─────────────────────────┘\n");
        }
    }
}
