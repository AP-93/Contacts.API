using System.Collections.Generic;

namespace Contacts.API.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public ICollection<ContactEmail> emails { get; set; }
        public ICollection<ContactPhoneNum> phoneNumbers { get; set; }
    }
}
