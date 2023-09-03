using ApiClient.Entities;
using ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Services
{
    public interface IFelhasznaloService
    {
        AuthenticateResponse? Authenticate(AuthenticateRequest model);
        IEnumerable<Felhasznalo> GetAll();
        Felhasznalo? GetById(int id);
        bool ExistsUser(string name, string password);
    }
}
