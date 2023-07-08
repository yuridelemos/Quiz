using Quiz.Models;
using Quiz.Repositories;

namespace Quiz.Screens.QuestionScreens
{
  public class UpdateQuestionScreen
  {
    // Quando terminar o Update da pergunta, 
    // perguntar se deseja mudar as respostas
    // dar um update em outra pergunta ou voltar
    // para o menu
    public static void Load()
    {
      System.Console.WriteLine("-----ATUALIZAR QUESTÃO-----");
      System.Console.WriteLine("(1) - Atualizar questão");
      System.Console.WriteLine("(0) - Voltar");
      var option = int.Parse(Console.ReadLine());
      if (option == 0)
        MenuQuestionScreen.Load();
      Console.Clear();
      Console.WriteLine("Atualizar questão");
      Console.WriteLine("-------------");
      var categoryId = ListQuestionScreen.ListWithReturn();

      Console.Write("ID: ");
      var id = Console.ReadLine();
      Console.Write("Escreva a nova questão: ");
      var body = Console.ReadLine();


      Update(new Question
      {
        Id = int.Parse(id),
        CategoryId = categoryId,
        Body = body
      });
      Console.ReadKey();
      MenuQuestionScreen.Load();
    }

    public static void Update(Question question)
    {
      try
      {
        var repository = new Repository<Question>();
        repository.Update(question);
        Console.WriteLine("Questão atualizada com sucesso!");
        System.Console.WriteLine("Você deseja atualizar as respostas dessa pergunta?");
        // atualizar as respostas
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar a questão");
        Console.WriteLine(ex.Message);
      }
    }
  }
}