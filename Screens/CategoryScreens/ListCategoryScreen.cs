using Quiz.Models;
using Quiz.Repositories;
using Dapper;

namespace Quiz.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Categorias");
            Console.WriteLine("--------------");
            List();
            Console.WriteLine();
            System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
        internal static void List()
        {
            var repository = new Repository<Category>();
            var categories = repository.Get();
            foreach (var item in categories)
                Console.WriteLine($"{item.Id} - {item.Matter}");
        }
    }

}