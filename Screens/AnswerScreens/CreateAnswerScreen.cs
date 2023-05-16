using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.QuestionScreens;

namespace Quiz.Screens.AnswerScreens
{
    public class CreateAnswerScreen
    {
        public static void Load(string question, int count)
        {
            Console.WriteLine("Nova resposta");
            Console.WriteLine("-------------");
            var questionId = ListQuestionScreen.ListWithNumberQuestionReturn(question);
            var answerOrder = count;
            Console.WriteLine("Digite a resposta");
            var body = Console.ReadLine();
            System.Console.WriteLine("Essa resposta é a correta? \"S\" Sim e \"N\" Não");
            var option = Console.ReadLine().ToUpper();
            var rightAnswer = false;
            if (option == "S" || option == "SIM")
                rightAnswer = true;
            Create(new Answer
            {
                QuestionId = questionId,
                AnswerOrder = answerOrder,
                Body = body,
                RightAnswer = rightAnswer
            });
        }

        public static void Create(Answer answer)
        {
            try
            {
                var repository = new AnswerRepository();
                repository.Insert(answer);
                System.Console.WriteLine("Resposta salva com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a resposta");
                Console.WriteLine(ex.Message);
            }
        }
    }
}