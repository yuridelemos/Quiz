using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.CategoryScreens;

namespace Quiz.Screens.AnswerScreens
{
    public class UpdateAnswerScreen
    {
        public static void Load()
        {
            // Primeiro é necessário puxar a escolha de resposta
            // depois puxar todas as perguntas, selecionar as perguntas
            // e depois irá mostrar as respostas.
            Console.Clear();
            Console.WriteLine("Atualizar resposta");
            Console.WriteLine("-------------");
            System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");

            System.Console.WriteLine();
            var questionId = ListAnswerScreen.List();

            Console.Write("Selecione a resposta: ");
            var answerOrder = Console.ReadLine();

            System.Console.WriteLine("Escreva a nova resposta:");
            var newBody = Console.ReadLine();


            Update(new Answer
            {
                QuestionId = questionId,
                AnswerOrder = int.Parse(answerOrder),
                Body = newBody
            });
            Console.ReadKey();
            MenuAnswerScreen.Load();
        }

        public static void Update(Answer answer)
        {
            try
            {
                if (answer.RightAnswer == true)
                {
                    System.Console.WriteLine("Não é possível alterar a resposta correta.");
                    Thread.Sleep(2000);
                    Load();
                }
                System.Console.WriteLine("Teste");
                var repository = new AnswerRepository();
                repository.Update(answer);
                Console.WriteLine("Resposta atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a resposta");
                Console.WriteLine(ex.Message);
            }
        }
    }
}