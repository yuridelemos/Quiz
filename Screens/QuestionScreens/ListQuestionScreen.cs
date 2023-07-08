using System.Globalization;
using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.CategoryScreens;

namespace Quiz.Screens.QuestionScreens
{
  public class ListQuestionScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Gestão de questões");
      Console.WriteLine("--------------");
      ListWithoutReturn();
      Console.WriteLine();
      System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
      Console.ReadKey();
      MenuQuestionScreen.Load();
    }
    internal static void ListWithoutReturn()
    {
      System.Console.WriteLine("Selecione a categoria de questões que deseja ver.");
      ListCategoryScreen.List();
      System.Console.WriteLine("0 - Questões de todas as categorias.");
      System.Console.Write("----------------------------------: ");
      var option = int.Parse(Console.ReadLine());
      var repository = new Repository<Question>();
      var questions = repository.Get();
      foreach (var item in questions)
      {
        if (option == 0)
          Console.WriteLine($"{item.Id} - {item.Body}");
        else if (option != 0 && item.CategoryId == option)
          Console.WriteLine($"{item.Id} - {item.Body}");
      }
    }

    internal static int ListWithReturn()
    {
      var option = int.Parse(Console.ReadLine());
      var repository = new Repository<Question>();
      var questions = repository.Get();
      foreach (var item in questions)
      {
        if (option == 0)
          Console.WriteLine($"{item.Id} - {item.Body}");
        else if (option != 0 && item.CategoryId == option)
          Console.WriteLine($"{item.Id} - {item.Body}");
      }
      return option;
    }

    internal static int ListWithNumberQuestionReturn(Question question)
    {
      var repository = new Repository<Question>();
      var questions = repository.Get();

      var lastIndex = questions.Last();

      return lastIndex.Id;
    }


    internal static List<Question> ListForDelete(Question question)
    {
      var repository = new Repository<Question>();
      var allQuestions = repository.Get();
      List<Question> questions = new List<Question>();

      foreach (var item in allQuestions)
      {
        if (item.CategoryId == question.CategoryId)
        {
          questions.Add(item);
        }
      }
      return questions;
    }
  }
}