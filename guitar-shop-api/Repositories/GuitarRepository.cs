using Dapper;
using guitar_shop_api.Data;
using guitar_shop_api.Models;
using Microsoft.Data.SqlClient;

namespace guitar_shop_api.Repositories
{
    public class GuitarRepository
    {
        private readonly DataContext _dataContext;

        public GuitarRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Create(GuitarModel guitarModel)
        {
            using (var connection = new SqlConnection(_dataContext.GetConnectionString()))
            {
                var query = @"INSERT INTO TbGuitar VALUES (@Name)";
                var result = await connection.ExecuteAsync(query, guitarModel);
                return result > 0;
            }
        }

        public async Task<IEnumerable<GuitarModel>> Get()
        {
            using (var connection = new SqlConnection(_dataContext.GetConnectionString()))
            {
                var query = @"SELECT * FROM TbGuitar";
                var result = await connection.QueryAsync<GuitarModel>(query);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<GuitarModel>> GetById(long id)
        {
            using (var connection = new SqlConnection(_dataContext.GetConnectionString()))
            {
                var query = @"SELECT * FROM TbGuitar WHERE Id = @id";
                var result = await connection.QueryAsync<GuitarModel>(query, new {id});
                return result.ToList();
            }
        }

        public async Task<bool> Update(GuitarModel guitarModel)
        {
            using (var connection = new SqlConnection(_dataContext.GetConnectionString()))
            {
                var query = @"UPDATE TbGuitar SET Name = @Name WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, guitarModel);
                return result > 0;
            }
        }

        public async Task<bool> Delete(long id)
        {
            using (var connection = new SqlConnection(_dataContext.GetConnectionString()))
            {
                var query = @"DELETE TbGuitar WHERE Id = @Id";
                var result = await connection.ExecuteAsync(query, new {id});
                return result > 0;
            }
        }
    }
}
