﻿using Pokemon.Models;

internal partial class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("Name Trainer 1: ");
            var nameTrainer1 = Console.ReadLine();
            Trainer trainer1 = new Trainer();
            trainer1.nameTrainer(nameTrainer1);
            trainer1.addBelt();
            trainer1.addNameToBelt(nameTrainer1);
            trainer1.createPokemonTeam();
            Console.WriteLine("Name Trainer 2: ");
            var nameTrainer2 = Console.ReadLine();
            Trainer trainer2 = new Trainer();
            trainer2.nameTrainer(nameTrainer2);
            trainer2.addBelt();
            trainer2.addNameToBelt(nameTrainer2);
            trainer2.createPokemonTeam();
            Arena.HandleBattle(trainer1, trainer2);
            Console.WriteLine("\n\nDo you want to play again? (y/n)");
            if (Console.ReadLine() != "y")
            {
                Arena.showScoreBoard();
                break;
            }
        }
    }
}