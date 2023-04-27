using Quiz.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Quiz.Repositories
{
    public class QuestionRespository : Repository<Question>
    {
        public void Insert()
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

            Database.Connection.Execute(insertSql, new
            {
                question.CategoryId,
                question.Body
            });

            Console.WriteLine("Cadastro realizado com sucesso");
        }
    }
}