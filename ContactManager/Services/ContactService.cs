using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager.Models;

namespace ContactManager.Services
{
    /// <summary>
    /// Manages contact operations including CRUD functionality.
    /// </summary>
    public class ContactService
    {
        private readonly List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>();
        }

        /// <summary>
        /// Adds a new contact to the collection.
        /// </summary>
        /// <param name="name">Contact name</param>
        /// <param name="phone">Contact phone number</param>
        /// <param name="email">Contact email address</param>
        /// <returns>True if the contact was added successfully, false otherwise</returns>
        public bool AddContact(string name, string phone, string email)
        {
            try
            {
                _contacts.Add(new Contact(name, phone, email));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves all contacts.
        /// </summary>
        /// <returns>A copy of the contact list</returns>
        public List<Contact> GetAllContacts()
        {
            return new List<Contact>(_contacts);
        }

        /// <summary>
        /// Searches for contacts by name using case-insensitive partial matching.
        /// </summary>
        /// <param name="searchTerm">The search term to match</param>
        /// <returns>List of matching contacts</returns>
        public List<Contact> SearchByName(string searchTerm)
        {
            return _contacts
                .Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Finds a contact with an exact name match.
        /// </summary>
        /// <param name="name">The exact name to search for</param>
        /// <returns>The matching contact, or null if not found</returns>
        public Contact? FindExactContact(string name)
        {
            return _contacts
                .FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks if a contact with the given name exists.
        /// </summary>
        /// <param name="name">The name to check</param>
        /// <returns>True if the contact exists, false otherwise</returns>
        public bool ContactExists(string name)
        {
            return FindExactContact(name) != null;
        }

        /// <summary>
        /// Deletes a contact by name.
        /// </summary>
        /// <param name="name">The name of the contact to delete</param>
        /// <returns>True if the contact was deleted, false if not found</returns>
        public bool DeleteContact(string name)
        {
            Contact? contact = FindExactContact(name);

            if (contact != null)
            {
                return _contacts.Remove(contact);
            }

            return false;
        }

        /// <summary>
        /// Gets the total number of contacts.
        /// </summary>
        /// <returns>The contact count</returns>
        public int GetContactCount()
        {
            return _contacts.Count;
        }
    }
}
