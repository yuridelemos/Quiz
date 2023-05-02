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
            Console.Clear();
            Console.WriteLine("Atualizar questão");
            Console.WriteLine("-------------");
            ListQuestionScreen.List();
            System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
            System.Console.WriteLine();

            Console.Write("ID: ");
            var id = Console.ReadLine();
            Console.Write("Questão: ");
            var body = Console.ReadLine();

            var categoryId = ListQuestionScreen.List2();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a questão");
                Console.WriteLine(ex.Message);
            }
        }
    }
}