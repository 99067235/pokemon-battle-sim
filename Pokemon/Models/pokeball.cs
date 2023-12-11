namespace Pokemon.Models
{
    public class pokeball
    {
        private bool pokemonInPokeball { get; set; }
        private bool PokemonReleased { get; set; }
        private Pokemon pokemon;
        private Pokemon pokemonInside;
        public pokeball(Pokemon? pokemon = null)
        {
            this.pokemon = pokemon;
            this.pokemonInside = pokemon;
        }

        public Pokemon? Use(Trainer trainer)
        {
            if (trainer.pokemonInUse)
            {
                if (trainer.ReleasedPokemon != null && trainer.pokemonInUse)
                {
                    if (trainer.ReleasedPokemon != this.pokemonInside)
                    {
                        return null;
                    }
                }
            }

            if (!pokemonInPokeball)
            {
                this.PokemonReleased = true;
                trainer.ReleasedPokemon = this.pokemonInside;
                trainer.pokemonInUse = true;
                Console.WriteLine(trainer.name + " has called " + this.pokemonInside.givenName);
                this.pokemonInside.BattleCry();
            }
            else
            {
                this.pokemonInPokeball = false;
                trainer.ReleasedPokemon = null;
                trainer.pokemonInUse = false;
                Console.WriteLine(trainer.name + " has retreated " + this.pokemonInside.givenName);
            }
            return this.pokemonInside;
        }
    }
}
