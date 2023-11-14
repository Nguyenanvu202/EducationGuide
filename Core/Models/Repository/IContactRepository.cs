using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
	public interface IContactRepository
	{
		public Task<List<Contact>> GetAllAsync();
		public Task<Contact> GetContactAsync(int Id);
		public Task<Contact> UpdateContactAsync(int Id, Contact contact);
		public Task<Contact> CreateContactAsync(Contact contact);
		public Task<Contact> DeleteContactInfoAsync(int Id);

	}
}
