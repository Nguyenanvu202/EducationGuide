using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly PageContext _pageContext;

        public ContactRepository(PageContext pageContext)
        {
            _pageContext = pageContext;
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            await _pageContext.AddAsync(contact);
            await _pageContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteContactInfoAsync(int Id)
        {
            var contactExist = await _pageContext.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
            _pageContext.Contacts.Remove(contactExist);
            await _pageContext.SaveChangesAsync();
            if (contactExist == null)
            {
                return null;
            }
            return contactExist;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var contact = await _pageContext.Contacts.ToListAsync();
            return contact;
        }

        public async Task<Contact> GetContactAsync(int Id)
        {
            var contactExist = await _pageContext.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
            return contactExist;
        }

        public async Task<Contact> UpdateContactAsync(int Id, Contact contact)
        {
            var contactExist = await _pageContext.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
            if (contactExist == null)
            {
                return null;
            }
            contactExist.UpdatedDate = DateTime.Now;
            contactExist.CreatedDate = DateTime.Now;
            contactExist.CreatedBy = contact.CreatedBy;
            contactExist.UpdatedDate = DateTime.Now;

            contactExist.Message = contact.Message;
            contactExist.Email = contact.Email;
            contactExist.Name = contact.Name;
            return contactExist;
        }
    }
}
