using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string contactName { get; set; }

        public string contactEmail { get; set; }

        public string contactPhoneNum { get; set; }
    }
}
