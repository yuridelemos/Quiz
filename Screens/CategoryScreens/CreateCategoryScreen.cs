using Quiz.Models;
using Quiz.Repositories;

namespace Quiz.Screens.CategoryScreens
{
  public static class CreateCategoryScreen
  {
    public static void Load()
    {
      System.Console.WriteLine("-----CRIAÇÃO DE CATEGORIA-----");
      System.Console.WriteLine("(1) - Criar categoria");
      System.Console.WriteLine("(0) - Voltar");
      var option = int.Parse(Console.ReadLine());
      if (option == 0)
        MenuCategoryScreen.Load();
      Console.Clear();
      Console.WriteLine("Nova categoria");
      Console.WriteLine("-------------");
      Console.Write("Nome: ");
      var matter = Console.ReadLine();


      Create(new Category
      {
        Matter = matter
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Create(Category category)
    {
      try
      {
        var repository = new Repository<Category>();
        repository.Insert(category);
        Console.WriteLine("Categoria cadastrada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar a categoria");
        Console.WriteLine(ex.Message);
      }
    }
  }
}