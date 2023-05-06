using Quiz.Models;
using Quiz.Repositories;
using Quiz.Screens.QuestionScreens;

namespace Quiz.Screens.AnswerScreens
{
    public class DeleteAnswerScreen
    {
        public static void Load()
        {
            // Primeiro é necessário puxar a escolha de categoria
            // depois puxar todas as perguntas, selecionar as perguntas
            // e depois irá mostrar as respostas. Quando uma resposta
            // for selecionada para ser deletada, irá aparecer a opção se a pessoa tem certeza disso
            // e logo depois irá solicitar que ela já insira outra pergunta
            Console.Clear();
            Console.WriteLine("Deletar categoria");
            Console.WriteLine("-------------");
            System.Console.WriteLine(@"OBS: Ao deletar uma resposta, não será possível recuperação. Não é possível deletar
            a resposta correta, caso haja algum erro de escrita ou por outro motivo desejar a editar, use a opção de alteração.");
            System.Console.WriteLine(@"OBS: Ao deletar uma resposta, você será obrigado logo em seguida a cadastrar uma
            nova resposta. Essa obrigação se deve que todas as perguntas presentes devem conter CINCO opções de respostas.");
            System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
            ListQuestionScreen.List();
            System.Console.WriteLine();
            Console.Write("ID Pergunta: ");
            var questionId = Console.ReadLine();

            Console.Write("ID Resposta: ");
            var answerOrder = Console.ReadLine();


            Delete(new Answer
            {
                QuestionId = int.Parse(questionId),
                AnswerOrder = int.Parse(answerOrder)
            });
            Console.ReadKey();
            MenuAnswerScreen.Load();
        }

        public static void Delete(Answer answer)
        {
            try
            {
                if (answer.RightAnswer == true)
                    Load();
                System.Console.WriteLine($"Você tem certeza que deseja deletar essa resposta: {answer.Body}?");
                System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
                var option = Console.ReadLine();
                if (option.ToUpper() == "S")
                {
                    var repository = new Repository<Answer>();
                    repository.Delete(answer); // Está deletando todas as respostas
                    Console.WriteLine("Categoria deletada com sucesso!");
                }
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletada a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}