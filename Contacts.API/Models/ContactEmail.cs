
namespace Contacts.API.Models
{
    public class ContactEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Contact contact { get; set; }
        public int ContactID { get; set; }
    }
}
