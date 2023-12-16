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
            bool? trainer1HasWon = pokemonTrainer1.Versus(pokemonTrainer1.getType(), pokemonTrainer2.getType());
            if (trainer1HasWon == true)
            {
                trainer1.RemovePokeball(pokeballTrainer1);
                return trainer1;
            } else if (trainer1HasWon == false)
            {
                trainer2.RemovePokeball(pokeballTrainer2);
                return trainer2;
            }
            else
            {
                trainer1.RemovePokeball(pokeballTrainer1);
                trainer2.RemovePokeball(pokeballTrainer2);
                return null;
            }
        }

        public static void HandleBattle(Trainer trainer1, Trainer trainer2)
        {
            int winsTrainer1 = 0;
            int winsTrainer2 = 0;
            int ties = 0;
            int rounds = 0;
            Trainer previousWinner = null;
            pokeball pokeballPreviousWinner = null;
            while (trainer1.getBeltLength() > 0 && trainer2.getBeltLength() > 0)
            {
                try
                {
                    rounds = rounds + 1;
                    var pokeballTrainer1 = trainer1.getItemFromBelt(winsTrainer1);
                    var pokeballTrainer2 = trainer2.getItemFromBelt(winsTrainer2);

                    Trainer winner = StartBattle(trainer1, trainer2, pokeballTrainer1, pokeballTrainer2);

                    if (winner != null)
                    {
                        Trainer loser = (winner == trainer1) ? trainer2 : trainer1;
                        Console.WriteLine("Trainer " + winner.getName() + " has won!");
                        Console.WriteLine("The pokemon of " + loser.getName() + " returned to his pokeball!");
                        loser.RemovePokeball(pokeballTrainer2);

                        if (winner == trainer1)
                        {
                            winsTrainer1++;
                            previousWinner = trainer1;
                            pokeballPreviousWinner = pokeballTrainer1;
                        }
                        else
                        {
                            winsTrainer2++;
                            previousWinner = trainer2;
                            pokeballPreviousWinner = pokeballTrainer2;
                        }
                    }
                    else
                    {
                        if (rounds == 1)
                        {
                            Console.WriteLine("Its a tie in the first round! Both pokemon will be returned to their pokeballs.");
                            trainer1.RemovePokeball(pokeballTrainer1);
                            trainer2.RemovePokeball(pokeballTrainer2);

                        } else
                        {
                            if (previousWinner == null)
                            {
                                Random random = new Random();
                                int randomNumber = random.Next(1, 2);
                                if (randomNumber == 1)
                                {
                                    previousWinner = trainer1;
                                }
                                else
                                {
                                    previousWinner = trainer2;
                                }
                            }
                            Console.WriteLine("Its a tie! The pokemon of " + previousWinner.getName() + " will be returned to their pokeballs.");
                            previousWinner.RemovePokeball(pokeballPreviousWinner);
                        }
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
                Console.WriteLine($"{trainer1.getName()} has won from {trainer2.getName()} with a score of {winsTrainer1}");
            }
            else if (winsTrainer2 > winsTrainer1)
            {
                Console.WriteLine($"{trainer2.getName()} has won from {trainer1.getName()} with a score of {winsTrainer2}");
            }
            else
            {
                Console.WriteLine($"It's a tie, you both had {winsTrainer1} wins.");
            }
        }
    }
}
