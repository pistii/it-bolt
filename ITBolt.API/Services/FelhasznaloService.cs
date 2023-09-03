using ApiClient.Authorization;
using ApiClient.Entities;
using ApiClient.Models;
using BCrypt.Net;
using ItBolt.Model.Entities;
using ITBolt.API.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Services
{
    
    public class FelhasznaloService : IFelhasznaloService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly ITBoltContext _context;

        public FelhasznaloService(IJwtUtils jwtUtils, ITBoltContext context)
        {
            _jwtUtils = jwtUtils;
            _context = context;
        }


        public AuthenticateResponse? Authenticate(AuthenticateRequest model)
        {
                var userExists = _context.felhasznalo.SingleOrDefault(x => x.nev == model.nev);
            if (userExists != null)
            {
                var pw = BCrypt.Net.BCrypt.Verify(model.Jelszo, userExists.jelszo, false, HashType.SHA256);

                var felhasznalo = _context.felhasznalo.SingleOrDefault(x => x.nev == model.nev && pw);

                // null if felhasznalo not found

                //Successful auth, token generation
                if (felhasznalo != null)
                {
                    var token = _jwtUtils.GenerateJwtToken(felhasznalo);

                    return new AuthenticateResponse(felhasznalo, token);
                }
                return null;
            }
            else return null;


        }

        public bool ExistsUser(string name, string password)
        {
            var exists = _context.felhasznalo.FirstOrDefault(x => x.nev == name && x.jelszo == password);
            if (exists != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Felhasznalo> GetAll()
        {
            return _context.felhasznalo;
        }

        public Felhasznalo? GetById(int id)
        {
            return _context.felhasznalo.FirstOrDefault(x => x.id == id);
        }
    }
}
