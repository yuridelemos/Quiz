using Quiz.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Quiz.Repositories
{
    public class QuestionRepository
    {

        private readonly SqlConnection _connection;

        public QuestionRepository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<Question> Get()
           => _connection.GetAll<Question>();

        public Question Get(int id)
           => _connection.Get<Question>(id);

        public void Insert(Question question)
        {
            question.Id = 0; //Força o ID ser 0 para que não seja possível colocar o ID, visto que o BD já está usando Identity(1,1)
            _connection.Insert<Question>(question);
        }
    }
}