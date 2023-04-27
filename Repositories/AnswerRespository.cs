using Quiz.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Quiz.Repositories
{
    public class AnswerRespository
    {
        private readonly SqlConnection _connection;

        public AnswerRespository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<Answer> Get()
           => _connection.GetAll<Answer>();

        public Answer Get(int id)
           => _connection.Get<Answer>(id);

        public void Insert(Answer answer)
           => _connection.Insert<Answer>(answer);
    }
}