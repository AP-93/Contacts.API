using Contacts.API.Models;
using System.Linq;

namespace Contacts.API.Data
{
    public class DbTestDataInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
            {
                return;
            }

            var contacts = new Contact[]
            {
            new Contact{firstName="kontakt1",lastName="adaadadad"},
            new Contact{firstName="adwdadadaw",lastName="22222"},
            new Contact{firstName="bbbbbbbbbb",lastName="bbbbbbbbbbb"},
            new Contact{firstName="cccccccccc",lastName="ccccc"},
            new Contact{firstName="ddd",lastName="ddddddd"},
            new Contact{firstName="eeeeeee",lastName="eeeeeeeee"},
            new Contact{firstName="gffffffffff",lastName="fffffffffn"},
            new Contact{firstName="hhhhhh",lastName="hhhhhhh"}
            };
            foreach (Contact c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

            var emails = new ContactEmail[]
            {
            new ContactEmail{contactID=1,email="kon1majl@gmail.com"},
            new ContactEmail{contactID=1,email="cad1kon1emajl@gmail.com"},
            new ContactEmail{contactID=1,email="cadawdajl@gmail.com"},
            new ContactEmail{contactID=1,email="awdawd1emajl@gmail.com"},
            new ContactEmail{contactID=1,email="cwdadmajl@gmail.com"},
            new ContactEmail{contactID=1,email="cadrfsasefajl@gmail.com"},
            new ContactEmail{contactID=2,email="cwadajl@gmail.com"},
            new ContactEmail{contactID=2,email="awdaw1emajl@gmail.com"},
            new ContactEmail{contactID=2,email="bsefemajl@gmail.com"},
            new ContactEmail{contactID=3,email="dawdmajl@gmail.com"},
            new ContactEmail{contactID=4,email="awdawmajl@gmail.com"},
            new ContactEmail{contactID=4,email="daajl@gmail.com"},
            new ContactEmail{contactID=5,email="hdawdjl@gmail.com"},
            new ContactEmail{contactID=6,email="tdhtrtgdrl@gmail.com"},
            new ContactEmail{contactID=7,email="efsefcysdcjl@gmail.com"},
            };
            foreach (ContactEmail e in emails)
            {
                context.ContactEmails.Add(e);
            }
            context.SaveChanges();

            var phoneNums = new ContactPhoneNum[]
            {                               
            new ContactPhoneNum{contactID=1,phoneNum="11111111"},
            new ContactPhoneNum{contactID=1,phoneNum="1111111111"},
            new ContactPhoneNum{contactID=1,phoneNum="11111111111111111"},
            new ContactPhoneNum{contactID=2,phoneNum="2222222222222222"},
            new ContactPhoneNum{contactID=2,phoneNum="222222222222222222"},
            new ContactPhoneNum{contactID=2,phoneNum="22222222222222222"},
            new ContactPhoneNum{contactID=3,phoneNum="333333333333333333333"},
            new ContactPhoneNum{contactID=4,phoneNum="44444444444444444"},
            new ContactPhoneNum{contactID=4,phoneNum="44444444444444444444"},
            new ContactPhoneNum{contactID=5,phoneNum="555555555555555"},
            new ContactPhoneNum{contactID=6,phoneNum="6666666"},
            new ContactPhoneNum{contactID=7,phoneNum="77777777"},
            new ContactPhoneNum{contactID=7,phoneNum="888888888"},
            }; 
            foreach (ContactPhoneNum n in phoneNums)
            {
                context.ContactPhoneNums.Add(n);
            }
            context.SaveChanges();
        }
    }
}
   
