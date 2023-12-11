using Pokemon.Models;

internal partial class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Belt beltTrainer1 = new();
            Belt beltTrainer2 = new();
            Console.WriteLine("Name Trainer 1: ");
            var nameTrainer1 = Console.ReadLine();
            Trainer trainer1 = new Trainer(nameTrainer1, beltTrainer1);
            beltTrainer1.trainerName = nameTrainer1;
            Console.Write("Give the pokemon a name? y/n ");
            var answer = Console.ReadLine();
            for (var i = 0; i < 6; i++)
            {
                Random random = new Random();
                int randomPokemon = random.Next(1, 4);

                if (randomPokemon == 1)
                {
                    trainer1.belt.add(trainer1.belt.makePokeball(new Charmander(answer == "y")));
                }
                else if (randomPokemon == 2)
                {
                    trainer1.belt.add(trainer1.belt.makePokeball(new Squirtle(answer == "y")));
                }
                else
                {
                    trainer1.belt.add(trainer1.belt.makePokeball(new Bulbasaur(answer == "y")));
                }
            }
            Console.WriteLine("Name Trainer 2: ");
            var nameTrainer2 = Console.ReadLine();
            Trainer trainer2 = new Trainer(nameTrainer2, beltTrainer2);
            beltTrainer2.trainerName = nameTrainer2;
            Console.Write("Give the pokemon a name? y/n ");
            var answerTrainer2 = Console.ReadLine();
            for (var i = 0; i < 6; i++)
            {
                Random random = new Random();
                int randomPokemon = random.Next(1, 4);

                if (randomPokemon == 1)
                {
                    trainer2.belt.add(trainer2.belt.makePokeball(new Charmander(answerTrainer2 == "y")));
                }
                else if (randomPokemon == 2)
                {
                    trainer2.belt.add(trainer2.belt.makePokeball(new Squirtle(answerTrainer2 == "y")));
                }
                else
                {
                    trainer2.belt.add(trainer2.belt.makePokeball(new Bulbasaur(answerTrainer2 == "y")));
                }
            }
            Battle.HandleBattle(trainer1, trainer2);
            Console.Write("Do you want to play again?");
            if (Console.ReadLine() != "y")
            {
                break;
            }
        }
    }
}