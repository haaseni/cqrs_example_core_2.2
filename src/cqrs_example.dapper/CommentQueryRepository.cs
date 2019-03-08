using cqrs_example.dapper.QueryModels;
using System.IO;
using cqrs_example.dapper.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace cqrs_example.dapper
{
    public class CommentQueryRepository : IQueryRepository<Comment>
    {
        private readonly string _connectionString;

        public CommentQueryRepository()
        {
            string relative = @"..\..\..\App_Data\Blog.mdf";
            string absolute = Path.GetFullPath(relative);

            _connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={absolute};Integrated Security=True;Connect Timeout=30";
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<Comment> GetAll(int postId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Comment>("SELECT * FROM Comments WHERE PostId = @Id", new { Id = postId });
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Comment>("SELECT * FROM Comments");
            }
        }

        public Comment GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Comments WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Comment>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
    }
}
