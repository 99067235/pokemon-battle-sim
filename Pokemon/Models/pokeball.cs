namespace Pokemon.Models
{
    public class pokeball
    {
        private bool pokemonInPokeball;
        private bool PokemonReleased;
        private Pokemon pokemon;
        private Pokemon pokemonInside;
        public pokeball(Pokemon? pokemon = null)
        {
            this.pokemon = pokemon;
            this.pokemonInside = pokemon;
        }

        public Pokemon? Use(Trainer trainer)
        {
            if (!pokemonInPokeball)
            {
                this.PokemonReleased = true;
                Console.WriteLine($"\n{this.pokemonInside.getName()} I CHOOSE YOU!");
                this.pokemonInside.BattleCry();
            }
            else
            {
                this.pokemonInPokeball = false;
                Console.WriteLine($"\n{trainer.getName()} retreated {this.pokemonInside.getName()}");
            }
            return this.pokemonInside;
        }
    }
}
