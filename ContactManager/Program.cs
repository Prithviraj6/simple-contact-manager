using System;
using System.Collections.Generic;
using ContactManager.Constants;
using ContactManager.Models;
using ContactManager.Services;
using ContactManager.UI;

namespace ContactManager
{
    /// <summary>
    /// Main application entry point and orchestration.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ContactService contactService = new ContactService();
            int choice;

            MenuDisplay.DisplayHeader();

            do
            {
                MenuDisplay.DisplayMenu();
                choice = InputHandler.GetValidChoice(AppConstants.ADD_CONTACT, AppConstants.EXIT);

                switch (choice)
                {
                    case AppConstants.ADD_CONTACT:
                        AddContactFlow(contactService);
                        break;

                    case AppConstants.VIEW_ALL:
                        ViewAllFlow(contactService);
                        break;

                    case AppConstants.SEARCH_CONTACT:
                        SearchContactFlow(contactService);
                        break;

                    case AppConstants.EDIT_CONTACT:
                        EditContactFlow(contactService);
                        break;

                    case AppConstants.DELETE_CONTACT:
                        DeleteContactFlow(contactService);
                        break;

                    case AppConstants.EXIT:
                        Console.WriteLine("\n✓ Thank you for using Contact Manager! Goodbye! 👋");
                        break;
                }

                if (choice != AppConstants.EXIT)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuDisplay.DisplayHeader();
                }

            } while (choice != AppConstants.EXIT);
        }

        /// <summary>
        /// Handles the flow for adding a new contact.
        /// </summary>
        static void AddContactFlow(ContactService contactService)
        {
            Console.WriteLine("\n┌─ ADD NEW CONTACT ─────┐\n");

            string name = InputHandler.GetNonEmptyInput("Name: ");

            // Check for duplicate names
            if (contactService.ContactExists(name))
            {
                Console.Write($"\n⚠ Contact '{name}' already exists. Add anyway? (y/n): ");
                if (Console.ReadLine()?.ToLower() != "y")
                {
                    Console.WriteLine("✗ Contact not added.");
                    return;
                }
            }

            string phone = InputHandler.GetValidPhone();
            string email = InputHandler.GetNonEmptyInput("Email: ");

            if (contactService.AddContact(name, phone, email))
            {
                Console.WriteLine("\n✓ Contact added successfully!");
            }
            else
            {
                Console.WriteLine("\n✗ Failed to add contact.");
            }
        }

        /// <summary>
        /// Handles the flow for viewing all contacts.
        /// </summary>
        static void ViewAllFlow(ContactService contactService)
        {
            Console.WriteLine("\n┌─ ALL CONTACTS ────────┐\n");

            List<Contact> contacts = contactService.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("✗ No contacts found.");
                return;
            }

            Console.WriteLine($"Total Contacts: {contacts.Count}\n");

            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]");
                contacts[i].Display();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Handles the flow for searching contacts by name.
        /// </summary>
        static void SearchContactFlow(ContactService contactService)
        {
            Console.WriteLine("\n┌─ SEARCH CONTACT ──────┐\n");

            string searchTerm = InputHandler.GetNonEmptyInput("Enter name to search: ");
            List<Contact> results = contactService.SearchByName(searchTerm);

            if (results.Count == 0)
            {
                Console.WriteLine($"\n✗ No contacts found matching '{searchTerm}'");
                return;
            }

            Console.WriteLine($"\n✓ Found {results.Count} contact(s):\n");

            foreach (var contact in results)
            {
                contact.Display();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Handles the flow for editing an existing contact.
        /// </summary>
        static void EditContactFlow(ContactService contactService)
        {
            Console.WriteLine("\n┌─ EDIT CONTACT ────────┐\n");

            string name = InputHandler.GetNonEmptyInput("Enter name of contact to edit: ");
            Contact? contact = contactService.FindExactContact(name);

            if (contact == null)
            {
                Console.WriteLine($"\n✗ No contact found with name '{name}'");
                return;
            }

            Console.WriteLine("\nCurrent details:");
            contact.Display();

            Console.WriteLine("\nEnter new details (press Enter to keep current):\n");

            Console.Write($"Name [{contact.Name}]: ");
            string newName = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(newName))
                contact.Name = newName;

            Console.Write($"Phone [{contact.Phone}]: ");
            string newPhone = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(newPhone))
                contact.Phone = newPhone;

            Console.Write($"Email [{contact.Email}]: ");
            string newEmail = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(newEmail))
                contact.Email = newEmail;

            Console.WriteLine("\n✓ Contact updated successfully!");
        }

        /// <summary>
        /// Handles the flow for deleting a contact.
        /// </summary>
        static void DeleteContactFlow(ContactService contactService)
        {
            Console.WriteLine("\n┌─ DELETE CONTACT ──────┐\n");

            string name = InputHandler.GetNonEmptyInput("Enter name of contact to delete: ");
            Contact? contact = contactService.FindExactContact(name);

            if (contact == null)
            {
                Console.WriteLine($"\n✗ No contact found with name '{name}'");
                return;
            }

            Console.WriteLine("\nContact to delete:");
            contact.Display();

            Console.Write("\n⚠ Are you sure? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                if (contactService.DeleteContact(name))
                {
                    Console.WriteLine($"\n✓ Contact '{name}' deleted successfully.");
                }
                else
                {
                    Console.WriteLine("\n✗ Failed to delete contact.");
                }
            }
            else
            {
                Console.WriteLine("\n✗ Deletion cancelled.");
            }
        }
    }
}