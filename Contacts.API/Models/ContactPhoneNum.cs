namespace Contacts.API.Models
{
    public class ContactPhoneNum
    {
        public int id { get; set; }
        public string phoneNum { get; set; }
        public Contact contact { get; set; }
        public int contactID { get; set; }
    }
}
