using System;
using System.Threading;
using System.IO;

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

            //Random random = new Random();

            Console.Write("Qual o nome do seu bichinho?: ");
            petName = Console.ReadLine();
            Console.Write($"Qual o nome do dono do {petName}?: ");
            petOwner = Console.ReadLine();

            string filePath = "C:\\" + petName + petOwner + ".txt"; 

            Console.WriteLine("Olá, seja bem vindo ao 'Meu bichinho virtual'");
            if (File.Exists(filePath))
            {
                string[] petData = File.ReadAllLines(filePath);
                petName = petData[0];
                petOwner = petData[1];
                petHunger = Convert.ToInt32(petData[2]);
                petHappiness = Convert.ToInt32(petData[3]);
                petCleanliness = Convert.ToInt32(petData[4]);

                if(petHunger <=0 || petHappiness <= 0 || petHappiness <= 0)
                {
                    Console.WriteLine("Assistente virtual");
                    Console.WriteLine("Nós analisamos o estado do seu bichinho, e" +
                        " percebemos que seu bichinho está muito mal tratado.");
                    Console.WriteLine("Nós iremos cuidar dele por você..");
                    petHunger = 100;
                    petHappiness = 100;
                    petCleanliness = 100;

                    Console.WriteLine("Pronto, seu bichinho está novinho em folha");

                }
                
                StartGame(petName, petOwner, ref petHunger, ref petHappiness, ref petCleanliness);
                
            }
            else
            {
              

                CreateNewGame(petName, petOwner, petHunger, petHappiness, petCleanliness);
                
                StartGame(petName, petOwner, ref petHunger, ref petHappiness, ref petCleanliness);
                
            }

        }

        static void StartGame
        (string petName, string petOwner, ref int petHunger, ref int petHappiness, ref int petCleanliness)
        {
            string userEntry = "";
            string[] petConversation = new string[3];
            petConversation[0] = "Hoje foi um dia muitooo legal, comi o sofá";
            petConversation[1] = "Estava com saudade de você, passei o dia te esperando";
            petConversation[2] = "HyaBadabaDuh";

            int petStatus = 0;
            Random random = new Random();

            Console.WriteLine("A tecla 'Enter' é a tecla utilizada para continuar no jogo, ou para enviar as respostas");
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine($"Olá {petOwner}, senti sua falta!!!");
            while (userEntry != "5")
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
                    ($"Fome: {petHunger} | Alegria: {petHappiness} | Limpo: {petCleanliness}\n");
                
                Console.WriteLine("O que vamos fazer hoje?");
                Console.WriteLine("1.Brincar");
                Console.WriteLine("2.Comer");
                Console.WriteLine("3.Tomar banho");
                Console.WriteLine("4.Nada");
                Console.WriteLine("5.Sair do jogo");
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

                Console.Clear();

                if(petHunger > 100) { petHunger = 100; }
                if(petHappiness > 100) { petHappiness = 100; }
                if(petCleanliness > 100) { petCleanliness = 100; }

                if (petHunger < 60 && petHunger > 20) 
                    Console.WriteLine("Que fome, nada melhor que um lanchinho");
                if (petHappiness < 60 && petHappiness > 20) 
                    Console.WriteLine("Estou tão desanimado, nada melhor do que brincar");
                if (petCleanliness < 60 && petCleanliness > 20) 
                    Console.WriteLine("Estou tão sujo, nada melhor que um banho");
                
                if (!(petHunger < 60 && petHunger > 20) && 
                    !(petHappiness < 60 && petHappiness > 20) && 
                    !(petCleanliness < 60 && petCleanliness > 20))
                {
                    Console.WriteLine(petConversation[random.Next(petConversation.Length)]);
                }

                Thread.Sleep(3000);

            }

            EndGame(petOwner, petHunger, petHappiness,petCleanliness);

            

        }

        public static void CreateNewGame
        (string petName, string petOwner, int petHunger, int petHappiness, int petCleanliness) 
        {
            StartGame(petName, petOwner, ref petHunger, ref petHappiness, ref petCleanliness);
        }
        public static void EndGame(string petOwner, int petHunger, int petHappiness, int petCleanliness)
        {
          if(petHunger <= 0 || petHappiness <= 0 || petCleanliness <= 0)
            {
                Console.WriteLine($"{petOwner}, que descuido, estou muito maltratado, fui embora, em busca de um dono melhor!!");
                Console.WriteLine("Cuide melhor do seu próximo bichinho");
            }
            else
            {
                Console.WriteLine("Obrigado por cuidar do seu bichinho");
                Console.WriteLine($"{petOwner}, volte logo!!!");
            }

        }

        
    }
}
