using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string petName = "";
            string petOwner = "";
            //string userEntry = "";

            int petHunger = 100;
            int petHappiness = 100;
            int petCleanliness = 100;
            //int petStatus = 0;

            bool petExists = false;

            //Random random = new Random();

            Console.WriteLine("Olá, seja bem vindo ao 'Meu bichinho virtual'");
            if (petExists)
            {
                StartGame(petName, petOwner, ref petHunger, ref petHappiness, ref petCleanliness);
                Console.WriteLine("Muito obrigado por cuidar do seu bichinho!!!");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Qual o nome do seu bichinho?: ");
                petName = Console.ReadLine();
                Console.Write($"Qual o nome do dono do {petName}?: ");
                petOwner = Console.ReadLine();

                petExists = CreateNewGame(petName, petOwner, petHunger, petHappiness, petCleanliness);
                
                StartGame(petName, petOwner, ref petHunger, ref petHappiness, ref petCleanliness);
                Console.WriteLine("Muito obrigado por cuidar do seu bichinho!!!");
                Console.WriteLine();
            }

        }

        static void StartGame
        (string petName, string petOwner, ref int petHunger, ref int petHappiness, ref int petCleanliness)
        {
            string userEntry = "";
            int petStatus = 0;
            Random random = new Random();

            Console.WriteLine($"Olá {petOwner}, senti sua falta!!!");
            while (userEntry != "4")
            {
                petStatus = random.Next(3);
                switch (petStatus)
                {
                    case 0: petHunger -= random.Next(20);
                        break;
                    case 1: petHappiness -= random.Next(20);
                        break;
                    case 2: petCleanliness -= random.Next(20);
                        break;
                }

                Console.Clear();
                Console.WriteLine
                    ($"Fome: {petHunger} | Alegria: {petHappiness} | Limpo: {petCleanliness}");

                Console.WriteLine("O que vamos fazer hoje?");
                Console.WriteLine("1.Brincar");
                Console.WriteLine("2.Comer");
                Console.WriteLine("3.Tomar banho");
                Console.WriteLine("4.Nada");
                Console.Write("Digite o número da opção desejada: ");
                userEntry = Console.ReadLine();

                switch (userEntry)
                {
                    case "1": petHappiness += random.Next(30);
                        break;
                    case "2": petHunger += random.Next(30);
                        break;
                    case "3": petCleanliness += random.Next(30);
                        break;
                }

                if(petHunger > 100) { petHunger = 100; }
                if(petHappiness > 100) { petHappiness = 100; }
                if(petCleanliness > 100) { petCleanliness = 100; }
            }

            

        }

        static bool CreateNewGame
        (string petName, string petOwner, int petHunger, int petHappiness, int petCleanliness) 
        {
            bool petExists = true;
            return petExists;

        }

        
    }
}
