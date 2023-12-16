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
            Trainer trainer1 = new Trainer();
            trainer1.nameTrainer(nameTrainer1);
            trainer1.addBelt();
            beltTrainer1.addTrainerName(nameTrainer1);
            for (var i = 0; i < 6; i++)
            {
                Random random = new Random();
                int randomPokemon = random.Next(1, 4);

                if (randomPokemon == 1)
                {
                    trainer1.belt.add(trainer1.belt.makePokeball(new Charmander()));
                }
                else if (randomPokemon == 2)
                {
                    trainer1.belt.add(trainer1.belt.makePokeball(new Squirtle()));
                }
                else
                {
                    trainer1.belt.add(trainer1.belt.makePokeball(new Bulbasaur()));
                }
            }
            Console.WriteLine("Name Trainer 2: ");
            var nameTrainer2 = Console.ReadLine();
            Trainer trainer2 = new Trainer();
            trainer2.nameTrainer(nameTrainer2);
            trainer2.addBelt();
            beltTrainer2.addTrainerName(nameTrainer2);
            for (var i = 0; i < 6; i++)
            {
                Random random = new Random();
                int randomPokemon = random.Next(1, 4);

                if (randomPokemon == 1)
                {
                    trainer2.belt.add(trainer2.belt.makePokeball(new Charmander()));
                }
                else if (randomPokemon == 2)
                {
                    trainer2.belt.add(trainer2.belt.makePokeball(new Squirtle()));
                }
                else
                {
                    trainer2.belt.add(trainer2.belt.makePokeball(new Bulbasaur()));
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