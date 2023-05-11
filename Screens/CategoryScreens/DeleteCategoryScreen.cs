using Quiz.Models;
using Quiz.Repositories;

namespace Quiz.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        // Informar que deletar uma categoria irá
        // deletar todas as perguntas presentes nela
        // perguntar se ele tem certeza
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar categoria");
            Console.WriteLine("-------------");
            System.Console.WriteLine("OBS: Ao deletar uma categoria, irá deletar todas as perguntas presentes nela.");
            System.Console.WriteLine("Caso não queira mais, basta apertar ENTER duas vezes.");
            ListCategoryScreen.List();
            System.Console.WriteLine();
            Console.Write("ID: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var matter = Console.ReadLine();


            Delete(new Category
            {
                Id = int.Parse(id),
                Matter = matter
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(Category category)
        {
            try
            {
                System.Console.WriteLine($"Você tem certeza que deseja deletar essa categoria: {category.Matter}?");
                System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
                var option = Console.ReadLine();
                if (option.ToUpper() == "S")
                {
                    var repository = new Repository<Category>();
                    repository.Delete(category);
                    Console.WriteLine("Categoria deletada com sucesso!");
                }
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível deletar categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}