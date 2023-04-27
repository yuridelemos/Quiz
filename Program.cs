using Quiz.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Quiz
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Quiz;User ID=sa;Password=Sh@rk250535; TrustServerCertificate=True";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Database.Connection.Close();
        }

        public static void CreateQuestion()
        {
            var question = new Question()
            {
                CategoryId = 1,
                Body = "Padrões de Projeto têm sido utilizados com grande sucesso em programação de software. Os padrões de projeto GoF são classificados como:"
            };


            var insertSql = @"INSERT INTO 
                [Question]
                (
                    [CategoryId],
                    [Body]
                )
                VALUES (
                    @CategoryId,
                    @Body
                )";

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Execute(insertSql, new
                {
                    question.CategoryId,
                    question.Body
                });

                Console.WriteLine("Cadastro realizado com sucesso");
            }
        }

        public static void UpdateQuestion()
        {
            // var Question = new Question()
            // {
            //     Id = 3003,
            //     Bio = "Teste testaru",
            //     Email = "teste@example.com",
            //     Image = "http://",
            //     Name = "Teste",
            //     PasswordHash = "Sh@rk250535",
            //     Slug = "teste"
            // };
            // using (var connection = new SqlConnection(CONNECTION_STRING))
            // {
            //     connection.Update<Question>(Question);
            //     Console.WriteLine("Atualização realizado com sucesso");
            // }
        }

        public static void DeleteQuestion()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var Question = connection.Get<Question>(3003);
                connection.Delete<Question>(Question);
                Console.WriteLine("Exclusão realizado com sucesso");
            }
        }

    }
}