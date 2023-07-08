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
    public new void Insert(Answer answer)
    {
      var sql = @"INSERT INTO [Answer](QuestionId, AnswerOrder, Body, RightAnswer) VALUES (@QuestionId, @AnswerOrder, @Body, @RightAnswer)";
      Database.Connection.Execute(sql, new
      {
        QuestionId = answer.QuestionId,
        AnswerOrder = answer.AnswerOrder,
        Body = answer.Body,
        RightAnswer = answer.RightAnswer
      });
    }
  }
}