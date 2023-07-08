using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.QuestionScreens;

namespace Quiz.Screens.CategoryScreens
{
  public class DeleteCategoryScreen
  {
    // Informar que deletar uma categoria irá
    // deletar todas as perguntas presentes nela
    // perguntar se ele tem certeza
    public static void Load()
    {
      System.Console.WriteLine("-----DELETAR CATEGORIA-----");
      System.Console.WriteLine("(1) - Deletar categoria");
      System.Console.WriteLine("(0) - Voltar");
      System.Console.WriteLine("OBS: Ao deletar uma categoria, todas as perguntas presentes nela serão deletadas.");
      var option = int.Parse(Console.ReadLine());
      if (option == 0)
        MenuCategoryScreen.Load();
      Console.Clear();
      Console.WriteLine("Deletar categoria");
      Console.WriteLine("-------------");
      ListCategoryScreen.List();
      System.Console.WriteLine();
      System.Console.WriteLine("Escreva o ID e Nome para prosseguir.");
      Console.Write("ID: ");
      var id = Console.ReadLine();

      Console.Write("Nome: ");
      var matter = Console.ReadLine();


      Delete(new Category
      {
        Id = int.Parse(id),
        Matter = matter
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Delete(Category category)
    {
      try
      {
        System.Console.WriteLine($"Você tem certeza que deseja deletar essa categoria: {category.Matter}?");
        System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
        var option = Console.ReadLine();
        if (option.ToUpper() == "S")
        {
          //Colocar o delete das perguntas aqui
          DeleteQuestionScreen.DeleteAllQuestions(new Question
          {
            CategoryId = category.Id
          });
          var repository = new Repository<Category>();
          repository.Delete(category);
          Console.WriteLine("Categoria deletada com sucesso!");
        }
        Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar categoria");
        Console.WriteLine(ex.Message);
      }
    }
  }
}