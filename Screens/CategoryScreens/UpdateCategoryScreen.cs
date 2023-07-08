using Quiz.Models;
using Quiz.Repositories;

namespace Quiz.Screens.CategoryScreens
{
  public static class UpdateCategoryScreen
  {
    public static void Load()
    {
      System.Console.WriteLine("-----ATUALIZAR CATEGORIA-----");
      System.Console.WriteLine("(1) - Atualizar categoria");
      System.Console.WriteLine("(0) - Voltar");
      var option = int.Parse(Console.ReadLine());
      if (option == 0)
        MenuCategoryScreen.Load();
      Console.Clear();
      Console.WriteLine("Atualizar categoria");
      Console.WriteLine("-------------");
      System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
      ListCategoryScreen.List();
      System.Console.WriteLine();
      Console.Write("ID: ");
      var id = Console.ReadLine();

      Console.Write("Nome: ");
      var matter = Console.ReadLine();


      Update(new Category
      {
        Id = int.Parse(id),
        Matter = matter
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Update(Category category)
    {
      try
      {
        var repository = new Repository<Category>();
        repository.Update(category);
        Console.WriteLine("Categoria atualizada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar a categoria");
        Console.WriteLine(ex.Message);
      }
    }
  }
}