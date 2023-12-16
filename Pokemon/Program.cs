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
            trainer1.createPokemonTeam();
            Console.WriteLine("Name Trainer 2: ");
            var nameTrainer2 = Console.ReadLine();
            Trainer trainer2 = new Trainer();
            trainer2.nameTrainer(nameTrainer2);
            trainer2.addBelt();
            beltTrainer2.addTrainerName(nameTrainer2);
            trainer2.createPokemonTeam();
            Battle.HandleBattle(trainer1, trainer2);
            Console.Write("Do you want to play again?");
            if (Console.ReadLine() != "y")
            {
                break;
            }
        }
    }
}