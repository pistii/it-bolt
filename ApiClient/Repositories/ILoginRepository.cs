using ItBolt.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Repositories
{
    public interface ILoginRepository<T> : IGenericRepository<T>
    {
        Task<LoginDTO<T>> GetAllAsync(
            string? nev = null,
            string? jelszo = null);
    }
}
