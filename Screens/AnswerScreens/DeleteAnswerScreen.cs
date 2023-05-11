using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.QuestionScreens;

namespace Quiz.Screens.AnswerScreens
{
    public class DeleteAnswerScreen
    {
        public static void DeleteAll(Answer answer)
        {
            try
            {
                var repository = new AnswerRepository();
                repository.Delete(answer); // Está deletando todas as respostas
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletar as respostas");
                Console.WriteLine(ex.Message);
            }
        }
    }
}