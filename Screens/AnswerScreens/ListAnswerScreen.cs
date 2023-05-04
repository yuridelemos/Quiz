using Quiz.Models;
using Dapper.Contrib.Extensions;
using Quiz.Repositories;
using Quiz.Screens.QuestionScreens;

namespace Quiz.Screens.AnswerScreens
{
    public class ListAnswerScreen
    {
        public static int List()
        {
            ListQuestionScreen.List();
            System.Console.Write("Selecione a questão: ");
            var questionId = int.Parse(Console.ReadLine());

            var answers = Database.Connection.GetAll<Answer>(null, commandTimeout: 120)
                .Where(x => (x.Id >> 16) == questionId)
                .OrderBy(x => x.AnswerOrder);

            foreach (var item in answers)
            {
                Console.WriteLine($"{item.AnswerOrder} - {item.Body}");
            }
            return questionId;
        }
    }
}