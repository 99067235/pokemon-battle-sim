using System.Runtime.CompilerServices;

namespace Pokemon.Models
{
    sealed class Battle
    {
        public static Trainer StartBattle(Trainer trainer1, Trainer trainer2, pokeball pokeballTrainer1, pokeball pokeballTrainer2)
        {
            if (trainer1 == null || trainer2 == null)
            {
                return null;
            }
            Pokemon? pokemonTrainer1 = pokeballTrainer1.Use(trainer1);
            Pokemon? pokemonTrainer2 = pokeballTrainer2.Use(trainer2);
            if (pokeballTrainer1 == null || pokemonTrainer2 == null)
            {
                return null;
            }
            else
            {
                bool? trainer1HasWon = pokemonTrainer1.Versus(pokemonTrainer2);
                if (trainer1HasWon == true)
                {
                    return trainer1;
                } else if (trainer1HasWon == false)
                {
                    return trainer2;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void HandleBattle(Trainer trainer1, Trainer trainer2)
        {
            // Start the battle
            // Define the variables which keep track of the amount of wins
            int winsTrainer1 = 0;
            int winsTrainer2 = 0;
            // Define a variable to keep track of how many ties there are played
            int ties = 0;
            while (true)
            {
                try
                {
                    var trainer1Pokemon = trainer1.belt.getItemFromBelt(winsTrainer1);
                    var trainer2Pokemon = trainer2.belt.getItemFromBelt(winsTrainer2);
                    Trainer winner = StartBattle(trainer1, trainer2, trainer1Pokemon, trainer2Pokemon);
                    if (winner != null)
                    {
                        if (winner == trainer1)
                        {
                            winsTrainer1++;
                        }
                        else
                        {
                            winsTrainer2++;
                        }
                    }
                    else
                    {
                        ties++;
                    }
                }
                catch
                {
                    break;
                }
            }
            Console.WriteLine("Results: ");
            if (winsTrainer1 > winsTrainer2)
            {
                Console.WriteLine($"{trainer1.name} has won from {trainer2.name} with a score of {winsTrainer1}");
            }
            else if (winsTrainer2 > winsTrainer1)
            {
                Console.WriteLine($"{trainer2.name} has won from {trainer1.name} with a score of {winsTrainer2}");
            }
            else
            {
                Console.WriteLine($"It's a tie, you both had {winsTrainer1} wins.");
            }
        }
    }
}
