using CleanArch.Domain.Abstraction;
using CleanArch.Domain.Entities;
using Dapper;
using System.Data;

namespace CleanArch.Infrastructure.Repositories
{
    public class MemberDapperRepository : IMemberDapperRepository
    {
        private readonly IDbConnection _connection;
        public MemberDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            string query = "SELECT * FROM Members";
            return await _connection.QueryAsync<Member>(query);
        }

        public async Task<Member> GetById(int id)
        {
            string query = "SELECT * FROM Members WHERE Id = @id";
            return await _connection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
        }
    }
}
