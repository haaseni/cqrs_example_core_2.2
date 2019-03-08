using cqrs_example.dapper.Interfaces;
using cqrs_example.dapper.QueryModels;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace cqrs_example.dapper
{
    public class PostQueryRepository : IQueryRepository<Post>
    {
        private readonly string _connectionString;

        public PostQueryRepository()
        {
            string relative = @"..\..\..\App_Data\Blog.mdf";
            string absolute = Path.GetFullPath(relative);

            _connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={absolute};Integrated Security=True;Connect Timeout=30";
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<Post> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Post>("SELECT * FROM Posts");
            }
        }

        public Post GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Posts WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Post>(sQuery, param: new { Id = id }).FirstOrDefault();
            }
        }
    }
}
