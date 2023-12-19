using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    internal class Arena
    {
        private static int winsTrainer1 = 0;
        private static int winsTrainer2 = 0;
        private static int ties = 0;
        private static int rounds = 0;
        public static void HandleBattle(Trainer trainer1, Trainer trainer2)
        {
            Trainer previousWinner = null;
            pokeball pokeballPreviousWinner = null;
            while (trainer1.getBeltLength() > 0 && trainer2.getBeltLength() > 0)
            {
                try
                {
                    Thread.Sleep(1000);
                    rounds = rounds + 1;
                    var pokeballTrainer1 = trainer1.getItemFromBelt(winsTrainer1);
                    var pokeballTrainer2 = trainer2.getItemFromBelt(winsTrainer2);

                    Trainer winner = Battle.StartBattle(trainer1, trainer2, pokeballTrainer1, pokeballTrainer2);

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

                        }
                        else
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

            showScoreBoard();
        }

        public static void showScoreBoard()
        {
            Console.WriteLine("Pokemon Battle Scoreboard");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Trainer 1 Wins: {winsTrainer1}");
            Console.WriteLine($"Trainer 2 Wins: {winsTrainer2}");
            Console.WriteLine($"Ties: {ties}");
            Console.WriteLine($"Total Rounds: {rounds}");
        }
    }
}
