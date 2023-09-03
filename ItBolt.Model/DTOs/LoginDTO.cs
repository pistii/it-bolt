using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItBolt.Model.DTOs
{
    public class LoginDTO<T>
    {
        public LoginDTO(string? nev, string? jelszo)
        {
            Nev = nev;
            Jelszo = jelszo;
        }

       
        public string? Nev { get; set; }

        public string? Jelszo { get; set; }
    }
}
