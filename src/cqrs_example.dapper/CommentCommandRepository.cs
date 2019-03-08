using cqrs_example.dapper.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace cqrs_example.dapper
{
    public class CommentCommandRepository : ICommandRepository
    {
        private readonly string _connectionString;

        public CommentCommandRepository()
        {
            string relative = @"..\..\..\App_Data\Blog.mdf";
            string absolute = Path.GetFullPath(relative);

            _connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={absolute};Integrated Security=True;Connect Timeout=30";
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public void Add(ICommand command)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Comments (PostId, Text) VALUES(@PostId, @Text)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, command);
            }
        }
        
        public void Delete(ICommand command)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Comments WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = command.Id });
            }
        }

        public void DeleteAllForPost(ICommand command)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Comments WHERE PostId = @PostId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, command);
            }
        }
    }
}
