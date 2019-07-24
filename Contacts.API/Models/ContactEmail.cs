namespace Contacts.API.Models
{
    public class ContactEmail
    {
        public int id { get; set; }
        public string email { get; set; }
        public Contact contact { get; set; }
        public int contactID { get; set; }
    }
}
