using Contacts.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            new Contact{FirstName="kontakt1",LastName="adaadadad"},
            new Contact{FirstName="adwdadadaw",LastName="22222"},
            new Contact{FirstName="bbbbbbbbbb",LastName="bbbbbbbbbbb"},
            new Contact{FirstName="cccccccccc",LastName="ccccc"},
            new Contact{FirstName="ddd",LastName="ddddddd"},
            new Contact{FirstName="eeeeeee",LastName="eeeeeeeee"},
            new Contact{FirstName="gffffffffff",LastName="fffffffffn"},
            new Contact{FirstName="hhhhhh",LastName="hhhhhhh"}
            };
            foreach (Contact c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

            var emails = new ContactEmail[]
            {
            new ContactEmail{ContactID=1,Email="cad1emajl"},
            new ContactEmail{ContactID=1,Email="opet1"},
            new ContactEmail{ContactID=1,Email="adasda,dla11"},
            new ContactEmail{ContactID=1,Email="cad1emajl"},
            new ContactEmail{ContactID=1,Email="opet1"},
            new ContactEmail{ContactID=1,Email="adasda,dla11"},
            new ContactEmail{ContactID=2,Email="dfasdasd2222"},
            new ContactEmail{ContactID=2,Email="asdadasd2222"},
            new ContactEmail{ContactID=2,Email="fasdasdasdas2222"},
            new ContactEmail{ContactID=3,Email="fasdasdasdas33333"},
            new ContactEmail{ContactID=4,Email="fasdasdasdas44444"},
            new ContactEmail{ContactID=4,Email="fasdasdasdas4444444"},
            new ContactEmail{ContactID=5,Email="fasdasdasdas555"},
            new ContactEmail{ContactID=6,Email="fasdasdasdas6666666"},
            new ContactEmail{ContactID=7,Email="fasdasdasdas77777777"},
            };
            foreach (ContactEmail e in emails)
            {
                context.ContactEmails.Add(e);
            }
            context.SaveChanges();


            var phoneNums = new ContactPhoneNum[]
            {
            new ContactPhoneNum{ContactID=1,PhoneNum="11111111"},
            new ContactPhoneNum{ContactID=1,PhoneNum="o1111111111"},
            new ContactPhoneNum{ContactID=1,PhoneNum="11111111111111111"},
            new ContactPhoneNum{ContactID=2,PhoneNum="2222222222222222"},
            new ContactPhoneNum{ContactID=2,PhoneNum="222222222222222222"},
            new ContactPhoneNum{ContactID=2,PhoneNum="22222222222222222"},
            new ContactPhoneNum{ContactID=3,PhoneNum="333333333333333333333"},
            new ContactPhoneNum{ContactID=4,PhoneNum="44444444444444444"},
            new ContactPhoneNum{ContactID=4,PhoneNum="44444444444444444444"},
            new ContactPhoneNum{ContactID=5,PhoneNum="555555555555555"},
            new ContactPhoneNum{ContactID=6,PhoneNum="6666666"},
            new ContactPhoneNum{ContactID=7,PhoneNum="77777777"},
            }; 
            foreach (ContactPhoneNum n in phoneNums)
            {
                context.ContactPhoneNums.Add(n);
            }
            context.SaveChanges();
        }
    }
}
   
