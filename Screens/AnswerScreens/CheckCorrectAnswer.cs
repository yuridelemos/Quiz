using Dapper.Contrib.Extensions;
using Quiz.Models;

namespace Quiz.Screens.AnswerScreens
{
    public class CheckCorrectAnswer
    {
        public static int CheckAnswer(int questionId)
        {
            var answers = Database.Connection.GetAll<Answer>(null, commandTimeout: 120)
                .Where(x => (x.Id >> 16) == questionId)
                .OrderBy(x => x.AnswerOrder);

            foreach (var item in answers)
            {
                if (item.RightAnswer)
                    return item.AnswerOrder;
            }
            return 0;
        }
    }
}