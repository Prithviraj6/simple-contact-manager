using System;

namespace ContactManager.Models
{
    /// <summary>
    /// Represents a contact with personal information.
    /// </summary>
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Displays the contact details to the console.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"  Name:  {Name}");
            Console.WriteLine($"  Phone: {Phone}");
            Console.WriteLine($"  Email: {Email}");
        }

        public override string ToString()
        {
            return $"{Name} | {Phone} | {Email}";
        }
    }
}
