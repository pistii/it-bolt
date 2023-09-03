using ApiClient.Entities;
using System.Net.Http.Json;
using System.Security;

namespace ApiClient.Repositories
{
    public class GenericAPIRepository<T> : BaseAPIRepository, IGenericRepository<T>
    {
        public GenericAPIRepository(string path, string? baseUrl = null, DelegatingHandler? handler = null) : base(baseUrl, path, handler)
        {
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<List<T>>(_path);
        }

        public async Task<bool> ExistsByNameAndPw(string name, string pw)
        {
            //HttpResponseMessage responseMessage = await client.GetAsync(_path + "/?nev=" + name + "&jelszo=" + pw);
            //return responseMessage.IsSuccessStatusCode;
            var user = new Felhasznalo { nev = name, jelszo = pw };
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(_path + "/authenticate", user);
            return responseMessage.IsSuccessStatusCode;
            //return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> ExistsByNameAndPw(string name, SecureString pw)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(_path + "/?nev=" + name + "&jelszo=" + pw);
            return responseMessage.IsSuccessStatusCode;
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(_path + "/" + name);
            return responseMessage.IsSuccessStatusCode;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<T>(_path + "/" + id);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(_path + "/" + id);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task InsertAsync(T entity)
        {
            await client.PostAsJsonAsync(_path, entity);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            await client.PutAsJsonAsync(_path + "/" + id, entity);
        }

        public async Task UpdateByNameAsync(string name, T entity)
        {
            await client.PutAsJsonAsync(_path + "/" + name, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await client.DeleteAsync(_path + "/" + id);
        }
    }
}
