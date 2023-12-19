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
    }
}
