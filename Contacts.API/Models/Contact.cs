

using System.Collections.Generic;

namespace Contacts.API.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ContactEmail> Emails { get; set; }
        public ICollection<ContactPhoneNum> PhoneNumbers { get; set; }
    }
}
