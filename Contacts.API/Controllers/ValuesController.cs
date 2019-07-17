using System.Linq;
using System.Threading.Tasks;
using Contacts.API.Data;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public  async Task<IActionResult> GetContact(int id)
        {
            var Contact = await _dataContext.Contacts.Include(e => e.Emails)
                                                     .Include(n =>n.PhoneNumbers)
                                                     .AsNoTracking().FirstOrDefaultAsync(x => x.Id ==id);
            return Ok(Contact);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Contact = _dataContext.Contacts.Include(e => e.Emails)
                                                    .Include(n => n.PhoneNumbers)
                                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
