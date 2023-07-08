
using Dapper;
using Quiz.Models;

namespace Quiz.Screens
{
  public class StartGame
  {
    public static void Load()
    {
      Console.WriteLine("-------------Iniciando o jogo-------------");
      Console.WriteLine("Escolha a quantidade de questões para iniciar seu quiz");
      Console.WriteLine("Você pode escolher quantas perguntas deseja responder (máximo de 20), mas caso não escolha, a quantidade será de 10 perguntas.");
      Console.Write("----------------: ");
      var numberOfQuestions = short.Parse(Console.ReadLine());
      if (numberOfQuestions > 20)
        numberOfQuestions = 20;
      else if (numberOfQuestions < 0)
        numberOfQuestions = 10;
      Random rand = new Random();
      int rightQuestions = 0, questionNumber = 1;
      List<int> questionsAlreadyAsked = new List<int>();

      while (numberOfQuestions > 0)
      {
        var questions = Database.Connection.Query<Question>("SELECT TOP 1 * FROM [Question] ORDER BY NEWID()");
        var answers = Database.Connection.Query<Answer>("SELECT * FROM [Answer]");
        foreach (var question in questions)
        {
          if (!questionsAlreadyAsked.Any(x => x == question.Id))
          {
            List<bool> options = new List<bool>();
            int i = 0;
            System.Console.WriteLine($"({questionNumber}) - {question.Body}");
            foreach (var answer in answers.OrderBy(x => rand.Next()))
            {
              if (answer.QuestionId == question.Id)
              {
                System.Console.WriteLine($"{i + 1} - {answer.Body}");
                options.Add(answer.RightAnswer);
                i++;
              }
            }
            System.Console.WriteLine("Qual a resposta correta?");
            System.Console.Write("======================: ");
            var SelectAnswer = int.Parse(Console.ReadLine());
            if (options[SelectAnswer - 1] == true)
            {
              System.Console.WriteLine("Certa resposta!");
              rightQuestions++;
            }
            else
              System.Console.WriteLine("Resposta errada!");
            questionsAlreadyAsked.Add(question.Id);
          }
        }
        numberOfQuestions--;
        questionNumber++;
      }
      System.Console.WriteLine($"Seu resultado foi de {rightQuestions} acertos!");
    }
  }
}