using Pokemon.Models;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Belt beltTrainer1 = new();
        Belt beltTrainer2 = new();
        Console.WriteLine("Name Trainer 1: ");
        var nameTrainer1 = Console.ReadLine();
        Trainer trainer1 = new Trainer(nameTrainer1, beltTrainer1);
        beltTrainer1.trainerName = nameTrainer1;
        Console.Write("Give the pokemon a name? y/n");
        var answer = Console.ReadLine();
        if (answer == "y")
        {
            for (var i = 0; i < 6; i++)
            {
                trainer1.belt.add(trainer1.belt.makePokeball(new Charmander()));
            }
        }
        else
        {
            for (var i = 0; i < 6; i++)
            {
                trainer1.belt.add(trainer1.belt.makePokeball(new Charmander(false)));
            }
        }
        Console.WriteLine("Name Trainer 2: ");
        var nameTrainer2 = Console.ReadLine();
        Trainer trainer2 = new Trainer(nameTrainer2, beltTrainer1);
        beltTrainer2.trainerName = nameTrainer2;
        Console.Write("Give the pokemon a name? y/n");
        answer = Console.ReadLine();
        if (answer == "y")
        {
            for (var i = 0; i < 6; i++)
            {
                trainer2.belt.add(trainer2.belt.makePokeball(new Charmander()));
            }
        }
        else
        {
            for (var i = 0; i < 6; i++)
            {
                trainer2.belt.add(trainer2.belt.makePokeball(new Charmander()));
            }
        }
        Battle.HandleBattle(trainer1, trainer2);
    }
}