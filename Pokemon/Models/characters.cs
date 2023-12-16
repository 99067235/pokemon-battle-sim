namespace Pokemon.Models
{
    public abstract class Pokemon
    {
        private string? givenName;
        private PokemonTypes type;
        private static readonly List<string> pokemonNames = new List<string>
        {
            "Sparky", "Blaze", "Aqua", "Leafy", "Rocky",
            "Fluffy", "Zappy", "Misty", "Sunny", "Breezy"
        };
        public Pokemon()
        {
            this.giveName();
        }
        public void giveName()
        {
            Random random = new Random();
            this.givenName = pokemonNames[random.Next(pokemonNames.Count)];

        }

        public string getName()
        {
            return this.givenName;
        }

        public PokemonTypes getType()
        {
            return this.type;
        }

        public void setType(PokemonTypes type)
        {
            this.type = type;
        }

        public bool? Versus(PokemonTypes enemyType, PokemonTypes type)
        {
            if (enemyType != null && this.type != null)
            {
                var result = BattleHandler.Versus(type, enemyType);
                return result;
            }
            Console.WriteLine("An error has occurred.");
            return null;
        }

        public abstract void BattleCry();
    }

    public class Charmander : Pokemon
    {
        public override void BattleCry()
        {
            Console.WriteLine("\n*Charmander sounds*");
        }
        public Charmander(string ? defaultName = "Charmander"): base()
        {
            this.setType(PokemonTypes.Fire);
        }
    }

    public class Squirtle : Pokemon
    {
        public override void BattleCry()
        {
            Console.WriteLine("\n*Squirtle sounds*");
        }
        public Squirtle(string ? defaultName = "Squirtle"): base()
        {
            this.setType(PokemonTypes.Water);
        }
    }

    public class Bulbasaur : Pokemon
    {
        public override void BattleCry()
        {
            Console.WriteLine("\n*Bulbasaur sounds*");
        }
        public Bulbasaur(string defaultName = "Bulbasaur"): base()
        {
            this.setType(PokemonTypes.Grass);
        }
    }
}
