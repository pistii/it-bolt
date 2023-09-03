using ApiClient.Entities;
using ItBolt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string? Felhasznalonev { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Felhasznalo felhasznalo, string token)
        {
            Id = felhasznalo.id;
            Felhasznalonev = felhasznalo.nev;
            Token = token;
            
        }

    }
}
