using Quiz.Models;
using Quiz.Repositories;
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
                // Fazer a criação de respostas
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