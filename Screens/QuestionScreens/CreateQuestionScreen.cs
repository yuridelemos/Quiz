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
                for (int i = 0; i < 5; i++)
                {
                    var count = 1;
                    CreateAnswerScreen.Load(question.Body, count);
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