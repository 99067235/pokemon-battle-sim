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
        private static int battles = 0;
        private static int winsTrainer1 = 0;
        private static int winsTrainer2 = 0;
        private static int ties = 0;
        private static int rounds = 0;
        private static int interval = 2000;
        private static List<Trainer> trainers = new();

        public static void HandleBattle(Trainer trainer1, Trainer trainer2)
        {
            trainers.Add(trainer1);
            trainers.Add(trainer2);
            trainer1 = trainers.Find(t => t.Equals(trainer1));
            trainer2 = trainers.Find(t => t.Equals(trainer2));

            battles++;

            trainer1.setBattlePlayed(battles);
            trainer2.setBattlePlayed(battles);

            Trainer previousWinner = null;
            pokeball pokeballPreviousWinner = null;
            while (trainer1.getBeltLength() > 0 && trainer2.getBeltLength() > 0)
            {
                try
                {
                    Thread.Sleep(interval);
                    rounds++;
                    var pokeballTrainer1 = trainer1.getItemFromBelt(trainer1.getScore());
                    var pokeballTrainer2 = trainer2.getItemFromBelt(trainer2.getScore());

                    Trainer winner = Battle.StartBattle(trainer1, trainer2, pokeballTrainer1, pokeballTrainer2);

                    if (winner != null)
                    {
                        Trainer loser = (winner == trainer1) ? trainer2 : trainer1;
                        Console.WriteLine($"\nTrainer {winner.getName()} has won!");
                        Console.WriteLine($"\nThe pokemon of {loser.getName()} returned to his pokeball!");
                        loser.RemovePokeball(pokeballTrainer2);

                        if (winner == trainer1)
                        {
                            trainer1.increaseScore();
                            previousWinner = trainer1;
                            pokeballPreviousWinner = pokeballTrainer1;
                        }
                        else
                        {
                            trainer2.increaseScore();
                            previousWinner = trainer2;
                            pokeballPreviousWinner = pokeballTrainer2;
                        }
                    }
                    else
                    {
                        if (rounds == 1)
                        {
                            Console.WriteLine("\nIts a tie in the first round! Both pokemon will be returned to their pokeballs.");
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
                            Console.WriteLine($"\nIts a tie! The pokemon of {previousWinner.getName()} will be returned to their pokeballs.");
                            previousWinner.RemovePokeball(pokeballPreviousWinner);
                        }
                        ties++;
                    }
                    Console.WriteLine("\n\n");
                    trainer1.increasePlayedRounds();
                    trainer2.increasePlayedRounds();
                }
                catch
                {
                    break;
                }
            }
        }

        public static void showScoreBoard()
        {
            Console.WriteLine("\n\nPokemon Battle Scoreboard");
            Console.WriteLine("-------------------------");
            for (var i = 0; i < trainers.Count(); i++)
            {
                var trainer = trainers[i];
                if ((i + 1) % 2 == 1)
                {
                    Console.WriteLine($"\nRound {trainer.getBattlePlayed()}:");
                    Console.WriteLine("Wins:");
                }
                Console.WriteLine($" {trainer.getName()}: {trainer.getScore()}");
            }
            Console.WriteLine($"\nTotal Ties: {ties}");
            Console.WriteLine($"Total Rounds: {rounds}");
            Console.WriteLine($"Total Battles: {battles}");
        }
    }
}
