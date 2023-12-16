namespace Pokemon.Models
{
    public abstract class Pokemon
    {
        public String? defaultName;
        public string? givenName;
        protected readonly String? strength;
        protected readonly String? weakness;
        public bool useable;
        public PokemonTypes type;
        public readonly BattleHandler batteHandler;
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

        public string getStrength()
        {
            if (this.strength != null)
            {
                return this.strength;
            } else
            {
                return null;
            }
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
            this.type = PokemonTypes.Fire;
            this.defaultName = defaultName;
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
            this.defaultName = defaultName;
            this.type = PokemonTypes.Water;
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
            this.defaultName = defaultName;
            this.type = PokemonTypes.Grass;
        }
    }
}
