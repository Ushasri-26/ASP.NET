using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task<Contact> GetByIdAsync(long id);
        Task DeleteAsync(long id);
    }
}
