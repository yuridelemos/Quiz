using Quiz.Screens.CategoryScreens;
using Quiz.Screens.QuestionScreens;
using Quiz.Screens.AnswerScreens;

namespace Quiz.Screens
{
  public static class MainMenu
  {
    public static void Start()
    {
      Console.WriteLine("-------------Bem-vindo ao Quiz universiotário-------------");
      Console.WriteLine("----------------------Menu Principal----------------------\n");
      Console.WriteLine("(1) - Iniciar Jogo");
      Console.WriteLine("(2) - Regras");
      Console.WriteLine("(3) - Gestão de Categorias");
      Console.WriteLine("(4) - Gestão de Perguntas");
      Console.WriteLine("(5) - Gestão de Respostas");
      Console.Write("----------------: ");
      var option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          StartGame.Load();
          break;
        case 2:
          Console.Clear();
          RulesScreen.ShowRules();
          Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal...");
          Console.ReadKey();
          Start();
          break;
        case 3:
          MenuCategoryScreen.Load();
          break;
        case 4:
          MenuQuestionScreen.Load();
          break;
        case 5:
          MenuAnswerScreen.Load();
          break;
        default: Start(); break;

      }
    }

  }
}