namespace Pokemon.Models
{
    public class Trainer
    {
        public string name { get; set; }
        public Belt belt { get; set; }
        public bool pokemonInUse { get; set; }
        public Pokemon? ReleasedPokemon { get; set; }

        public Trainer(string name, Belt belt) {
            this.name = name;
            this.belt = belt;
        }
    }
}
