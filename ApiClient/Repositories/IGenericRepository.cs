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
        /// <summary>
        /// Lekérdez egy elemet azonosító alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string id);
        /// <summary>
        /// Létezik-e az elem, azonosító alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsByIdAsync(string id);
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
        Task UpdateAsync(string id, T entity);
        /// <summary>
        /// Törli a megadott elemet azonosító alapján
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
