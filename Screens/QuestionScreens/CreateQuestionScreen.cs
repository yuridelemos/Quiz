using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.AnswerScreens;
using Quiz.Screens.CategoryScreens;

namespace Quiz.Screens.QuestionScreens
{
  public class CreateQuestionScreen
  {
    public static void Load()
    {
      System.Console.WriteLine("-----CRIAR QUESTÃO-----");
      System.Console.WriteLine("(1) - Criar questão");
      System.Console.WriteLine("(0) - Voltar");
      var option = int.Parse(Console.ReadLine());
      if (option == 0)
        MenuQuestionScreen.Load();
      Console.Clear();
      Console.WriteLine("Nova questão");
      Console.WriteLine("-------------");
      System.Console.WriteLine("Ao criar uma nova questão, será obrigado logo em seguida a colocação das 5 alternativas de respostas.");
      ListCategoryScreen.List();
      Console.Write("Categoria da questão: ");
      var categoryId = short.Parse(Console.ReadLine());
      Console.WriteLine("Digite a questão");
      var body = Console.ReadLine();


      Create(new Question
      {
        CategoryId = categoryId,
        Body = body
      });
      Console.ReadKey();
      MenuQuestionScreen.Load();
    }

    public static void Create(Question question)
    {
      try
      {
        var repository = new Repository<Question>();
        repository.Insert(question);
        for (int i = 1; i < 6; i++)
        {
          CreateAnswerScreen.Load(question, i);
        }
        Console.WriteLine("Questão cadastrada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar a questão");
        Console.WriteLine(ex.Message);
      }
    }
  }
}