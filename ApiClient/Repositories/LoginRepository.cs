using ItBolt.Model.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Repositories
{
    public class LoginRepository<T> : GenericAPIRepository<T>, ILoginRepository<T>
    {
        public LoginRepository(string path, string? baseUrl = null, DelegatingHandler? handler = null) : base(path, baseUrl, handler)
        {
        }

        public async Task<LoginDTO<T>> GetAllAsync(string? nev = null, string? jelszo = null)
        {
            var queryParameters = new Dictionary<string, string>();
            if (nev is not null && jelszo is not null)
            {
                queryParameters.Add("nev", nev);
                queryParameters.Add("jelszo", jelszo);
            }
                // Összefűzi a paramétereket URL kódolásban
                var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
                var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

            try 
            {
                return await client.GetFromJsonAsync<LoginDTO<T>>($"(_path)?{queryString}");
            }
            catch (HttpRequestException)
            {
                throw;
            }

        }
    }
}
