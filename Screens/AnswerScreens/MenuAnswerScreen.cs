using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Screens.AnswerScreens
{
    public class MenuAnswerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de respostas");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Atualizar resposta");
            Console.WriteLine("2 - Excluir resposta");
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    UpdateAnswerScreen.Load();
                    break;
                case 2:
                    DeleteAnswerScreen.Load();
                    break;
                case 3:
                    ListAnswerScreen.List();
                    break;
                default:
                    System.Console.WriteLine("Opção digitada inválida, pressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                    Load();
                    break;
            }
        }
    }
}
/*
 * Atualizar e excluir - Avisar qual é a resposta correta para que a pessoa não delete ou
 atualize ela de forma incorreta.
 */