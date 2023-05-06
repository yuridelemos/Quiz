using Dapper;
using Quiz.Models;

namespace Quiz.Repositories
{
    public class AnswerRepository : Repository<Answer>
    {
        public new void Update(Answer answer)
        {
            var sql = @"UPDATE [Answer] SET [Body] = @NewBody WHERE [QuestionId] = @QuestionId AND [AnswerOrder] = @AnswerOrder";

            Database.Connection.Execute(sql, new
            {
                NewBody = answer.Body,
                QuestionId = answer.QuestionId,
                AnswerOrder = answer.AnswerOrder
            });
        }
    }
}