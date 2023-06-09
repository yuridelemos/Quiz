using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.CategoryScreens;

namespace Quiz.Screens.AnswerScreens
{
  public class UpdateAnswerScreen
  {
    public static void Load()
    {
      System.Console.WriteLine("-----ATUALIZAR RESPOSTA-----");
      System.Console.WriteLine("(1) - Atualizar resposta");
      System.Console.WriteLine("(0) - Voltar");
      var option = int.Parse(Console.ReadLine());
      if (option == 0)
        MenuAnswerScreen.Load();
      Console.Clear();
      Console.WriteLine("Atualizar resposta");
      Console.WriteLine("-------------");

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
        if (CheckCorrectAnswer.CheckAnswer(answer.QuestionId) == answer.AnswerOrder)
        {
          System.Console.WriteLine("Aviso!: Você está alterando a resposta correta!");
          System.Console.WriteLine("Deseja continuar?");
          System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
          var option = Console.ReadLine();
          if (option.ToUpper() == "N")
            Load();
        }
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