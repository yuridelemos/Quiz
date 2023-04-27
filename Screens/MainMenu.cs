using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.Screens.AnswerScreens;

namespace Quiz.Screens
{
    public class MainMenu
    {
        public void Start()
        {
            System.Console.WriteLine("-------------Bem-vindo ao Quiz universiotário-------------");
            System.Console.WriteLine("----------------------Menu Principal----------------------\n");
            System.Console.WriteLine("(1) - Iniciar Jogo"); // Perguntar quantas questões deseja, caso digite 0 irá buscar 5 questões como base
            System.Console.WriteLine("(2) - Regras");
            System.Console.WriteLine("(3) - Categorias");
            System.Console.WriteLine("(4) - Perguntas");
            System.Console.WriteLine("(5) - Respostas");
            System.Console.Write("----------------: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }

        }

    }
}