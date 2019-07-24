using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){    
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }
        public DbSet<ContactPhoneNum> ContactPhoneNums { get; set; }
    }
}
