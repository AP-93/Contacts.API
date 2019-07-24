using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.API.Data;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Contacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ContactsController(DataContext dataContext)
        {
            _dataContext = dataContext;
            DbTestDataInitializer.Initialize(_dataContext);
        }

        // GET api/contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var Contacts = await _dataContext.Contacts.ToListAsync();
            return Ok(Contacts);
        }
        // GET api/Contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var Contact = await _dataContext.Contacts.Include(e => e.emails)
                                                     .Include(n => n.phoneNumbers)
                                                     .AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
            return Ok(Contact);
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] object value)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(value.ToString());
            var newContact = new Contact
            {
                firstName = contact.firstName,
                lastName = contact.lastName,
                emails = new List<ContactEmail>(),
                phoneNumbers = new List<ContactPhoneNum>()
            };
            foreach (var e in contact.emails)
            {
                if (e.email.Length > 0)
                    newContact.emails.Add(new ContactEmail { email = e.email });
            }
            foreach (var n in contact.phoneNumbers)
            {
                newContact.phoneNumbers.Add(new ContactPhoneNum { phoneNum = n.phoneNum });
            }
            _dataContext.Contacts.Add(newContact);
            _dataContext.SaveChanges();
            return Ok(contact);
        }
        // PUT api/contacts/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] object value)
        {
            var existingContact = await _dataContext.Contacts.Include(e => e.emails)
                                                     .Include(n => n.phoneNumbers)
                                                   .FirstOrDefaultAsync(x => x.id == id);
            var updatedContact = JsonConvert.DeserializeObject<Contact>(value.ToString());
            if (existingContact != null)
            {
                // Update Contact data
                _dataContext.Entry(existingContact).CurrentValues.SetValues(updatedContact);

                // Delete Emails
                foreach (var existingEmail in existingContact.emails.ToList())
                {
                    if (!updatedContact.emails.Any(c => c.id == existingEmail.id)) //check all incoming emails if they match with one in database
                        _dataContext.ContactEmails.Remove(existingEmail); //delete email from database if no id match
                }

                // Update and Insert Emails
                foreach (var updatedEmail in updatedContact.emails.ToList())
                {
                    var existingEmail = existingContact.emails   //get email from database that matches email from update
                        .Where(c => c.id == updatedEmail.id)
                        .SingleOrDefault();

                    if (existingEmail != null && existingEmail.id > 0)
                        // Update existing Email
                        _dataContext.Entry(existingEmail).CurrentValues.SetValues(updatedEmail);
                    else if (updatedEmail.email.Length > 0)
                    {
                        // Insert new email
                        var newEmail = new ContactEmail
                        {
                            email = updatedEmail.email,
                        };
                        existingContact.emails.Add(newEmail);
                    }
                }

                // Delete Phone Numbers
                foreach (var existingPhoneNum in existingContact.phoneNumbers.ToList())
                {
                    if (!updatedContact.phoneNumbers.Any(c => c.id == existingPhoneNum.id))
                        _dataContext.ContactPhoneNums.Remove(existingPhoneNum);
                }
                // Update and Insert phone numbers
                foreach (var updatedPhoneNum in updatedContact.phoneNumbers)
                {
                    var existingPhoneNum = existingContact.phoneNumbers
                        .Where(c => c.id == updatedPhoneNum.id)
                        .SingleOrDefault();

                    if (existingPhoneNum != null && existingPhoneNum.id > 0)
                        // Update phone number
                        _dataContext.Entry(existingPhoneNum).CurrentValues.SetValues(updatedPhoneNum);
                    else
                    {
                        // Insert phone number
                        var newPhoneNum = new ContactPhoneNum
                        {
                            phoneNum = updatedPhoneNum.phoneNum
                        };
                        existingContact.phoneNumbers.Add(newPhoneNum);
                    }
                }
                _dataContext.SaveChanges();
            }
        }

        // DELETE api/contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _dataContext.Contacts.FirstOrDefaultAsync(x => x.id == id);
            _dataContext.Remove(contact);
            _dataContext.SaveChanges();
            return Ok(contact);
        }
    }
}
