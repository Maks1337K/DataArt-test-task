using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTest.Models;
using TaskTest.Models.DBModels;
using TaskTest.Models.RegModels;

namespace TaskTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        ApplicationContext DBContext;

        public CreateController(ApplicationContext context)
        {
            DBContext = context;
        }

        [HttpPost]
        public async Task<ActionResult> DBAdd(RegisterIncident reginc)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            Accounts account = new Accounts();
            account.Name = reginc.Name;
            account.Contact = new List<Contacts>();
            account.Contact.Add(reginc.Contact);
            Incidents incident = new Incidents();
            incident.Name = reginc.Description;
            incident.Account = new List<Accounts>();
            incident.Account.Add(account);
            await DBContext.AddAsync(incident);
            await DBContext.SaveChangesAsync();
            return Ok();
        }

        [Route("addcont")]
        [HttpPost]
        public async Task<ActionResult> AddContact(RegisterContact regcont)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!DBContext.Accounts.Any(el => el.Id == regcont.Account_Id))
            {
                return NotFound();
            }
            if (DBContext.Contacts.Any(el => el.Email == regcont.Contact.Email))
            {
                Contacts cont = new Contacts();
                cont = DBContext.Set<Contacts>().FirstOrDefault(el => el.Email.Equals(regcont.Contact.Email));
                cont.First_Name = regcont.Contact.First_Name;
                cont.Last_Name = regcont.Contact.Last_Name;
                DBContext.Update(cont);
                await DBContext.SaveChangesAsync();
                return Ok();
            }
            Accounts account = new Accounts();
            account.Id = regcont.Account_Id;
            account.Contact = new List<Contacts>();
            Accounts temp = DBContext.Set<Accounts>().FirstOrDefault(el => el.Id.Equals(regcont.Account_Id));
            temp.Contact = new List<Contacts>();
            temp.Contact.Add(new Contacts
            {
                First_Name = regcont.Contact.First_Name,
                Last_Name = regcont.Contact.Last_Name,
                Email = regcont.Contact.Email
            });
            DBContext.Update(temp);
            await DBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
