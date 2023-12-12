namespace Pokemon.Models
{
    public class Trainer
    {
        public string name { get; set; }
        public Belt belt { get; set; }
        public bool pokemonInUse { get; set; }
        public Pokemon? ReleasedPokemon { get; set; }

        public Trainer() {}

        public void nameTrainer(string name)
        {
            this.name = name;
        }

        public void addBelt()
        {
            this.belt = new Belt();
        }
    }
}
