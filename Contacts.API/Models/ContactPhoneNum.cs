namespace Contacts.API.Models
{
    public class ContactPhoneNum
    {
        public int Id { get; set; }
        public string PhoneNum { get; set; }
        public Contact contact { get; set; }
        public int ContactID { get; set; }
    }
}
