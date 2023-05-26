using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.AnswerScreens;

namespace Quiz.Screens.QuestionScreens
{
  public class DeleteQuestionScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Deletar questão");
      Console.WriteLine("-------------");
      System.Console.WriteLine("OBS: Ao deletar uma questão, irá deletar todas as respostas presentes nela.");
      System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
      System.Console.WriteLine();

      ListQuestionScreen.ListWithoutReturn();

      System.Console.WriteLine();
      Console.Write("ID: ");
      var id = Console.ReadLine();


      DeleteOneQuestion(new Question
      {
        Id = int.Parse(id)
      });
      Console.ReadKey();
      MenuQuestionScreen.Load();
    }

    public static void DeleteOneQuestion(Question question)
    {
      try
      {
        System.Console.WriteLine($"Você tem certeza que deseja deletar essa questão: {question.Body}?");
        System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
        var option = Console.ReadLine();
        if (option.ToUpper() == "S")
        {
          DeleteAnswerScreen.DeleteAll(new Answer
          {
            QuestionId = question.Id
          });
          var repository = new Repository<Question>();
          repository.Delete(question);
          Console.WriteLine("Questão deletada com sucesso!");
          Thread.Sleep(2000);
        }
        Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar questão");
        Console.WriteLine(ex.Message);
      }
    }
    public static void DeleteAllQuestions(Question question)
    {
      try
      {
        List<Question> listQuestions = ListQuestionScreen.ListForDelete(question);
        //Erro se encontra aqui, não há código de categoria. Tenho que pensar outro modo de deletar
        foreach (var item in listQuestions)
        {
          DeleteAnswerScreen.DeleteAll(new Answer
          {
            QuestionId = item.Id
          });
          var repository = new Repository<Question>();
          repository.Delete(item);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar as respostas");
        Console.WriteLine(ex.Message);
      }
    }
  }
}