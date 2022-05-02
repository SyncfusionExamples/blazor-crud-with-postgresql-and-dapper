    using Dapper;
    using Npgsql;
    using System.Data;
    using System.Diagnostics;

    namespace BlazorCRUD.Services
    {
    public class DbService  : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration config)
        {
            _db = new NpgsqlConnection(config.GetConnectionString("Employeedb"));
        }
        
        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<T> Insert<T>(string command, object parms)
        {
            T result;
            
            result = _db.Query<T>(command, parms).FirstOrDefault();

            return result;
        }

        public async Task<T> Update<T>(string command, object parms)
        {
            T result;
            
            result = _db.Query<T>(command, parms).FirstOrDefault();
           
            return result;
        }

        public async Task<T> Delete<T>(string command, object parms)
        {
            T result;

            result = _db.Query<T>(command, parms).FirstOrDefault();

            return result;
        }
    }
}

