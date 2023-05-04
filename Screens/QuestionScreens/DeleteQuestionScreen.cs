using Quiz.Models;
using Quiz.Repositories;

namespace Quiz.Screens.QuestionScreens
{
    public class DeleteQuestionScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar questão");
            Console.WriteLine("-------------");
            System.Console.WriteLine("OBS: Ao deletar uma questão, irá deletar todas as respostas presentes nela.");
            System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
            System.Console.WriteLine();

            ListQuestionScreen.List();

            System.Console.WriteLine();
            Console.Write("ID: ");
            var id = Console.ReadLine();


            Delete(new Question
            {
                Id = int.Parse(id)
            });
            Console.ReadKey();
            MenuQuestionScreen.Load();
        }

        public static void Delete(Question question)
        {
            try
            {
                System.Console.WriteLine($"Você tem certeza que deseja deletar essa questão: {question.Body}?");
                System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
                var option = Console.ReadLine();
                if (option.ToUpper() == "S")
                {
                    //Implantar Delete das respostas antes
                    var repository = new Repository<Question>();
                    repository.Delete(question);
                    Console.WriteLine("Questão deletada com sucesso!");
                }
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletada a questão");
                Console.WriteLine(ex.Message);
            }
        }
    }
}