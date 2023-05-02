using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Screens
{
    public class RulesScreen
    {
        public void ShowRules()
        {
            Console.WriteLine("--------------- REGRAS DO JOGO ---------------");
            Console.WriteLine("O jogo é composto por uma série de perguntas.");
            Console.WriteLine("Você deverá responder corretamente o maior número de perguntas possível.");
            Console.WriteLine("Para cada pergunta respondida corretamente, você ganha pontos.");
            Console.WriteLine("Você pode escolher quantas perguntas deseja responder, mas caso não escolha, a quantidade será de dez perguntas.");
            Console.WriteLine("O jogo termina quando você responde todas as perguntas ou quando desiste.");
            Console.WriteLine("A desistência ocorre quando é apertado 0.");
            Console.WriteLine("Boa sorte e divirta-se!\n");
        }
    }
}