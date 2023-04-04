using System.Security;

namespace ApiClient.Repositories
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Lekérdezi az összes elemet
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Lekérdez egy elemet név és jelszó alapján
        /// </summary>
        /// <returns></returns>
        Task<bool> ExistsByNameAndPw(string nev, string pw);
        Task<bool> ExistsByNameAndPw(string nev, SecureString pw);

        /// <summary>
        /// Lekérdez egy elemet azonosító alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Létezik-e az elem, azonosító alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsByIdAsync(int id);
        /// <summary>
        /// Létezik-e az elem, név alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsByNameAsync(string id);
        /// <summary>
        /// Beilleszt egy új elemet
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(T entity);
        /// <summary>
        /// Módosít egy meglévő elemet azonosító alapján
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(int id, T entity);
        /// <summary>
        /// Módosít egy meglévő elemet név alapján
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateByNameAsync(string name, T entity);
        /// <summary>
        /// Törli a megadott elemet azonosító alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
