using System.Threading.Tasks.Sources;

namespace Pokemon.Models
{
    public class Trainer
    {
        private string name;
        private Belt belt;
        private int score;
        private int rounds;
        private int battlePlayed;
        private string[] trainerNames = {
            "Gill Bates",
            "Jeve Stobs",
            "Zark Muckerberg",
            "Melon Usk",
            "Cim Took",
            "Eff Bjezos",
            "Rark Mutte",
            "Arack Bobama",
            "Boe Jiden",
            "Tronald Dump"
        };

        public Trainer() {}

        public void nameTrainer(string name)
        {
            if (name == "" || name == null)
            {
                Random random = new Random();
                int randomIndex = random.Next(trainerNames.Length);
                name = trainerNames[randomIndex];
            }
            this.name = name;
        }

        public void increaseScore()
        {
            score++;
        }

        public int getScore()
        {
            return score;
        }

        public void increasePlayedRounds()
        {
            rounds++;
        }

        public int getPlayedRounds()
        {
            return rounds;
        }

        public void setBattlePlayed(int battlePlayed)
        {
            this.battlePlayed = battlePlayed;
        }

        public int getBattlePlayed()
        {
            return battlePlayed;
        }

        public void addBelt()
        {
            this.belt = new Belt();
        }

        public void addNameToBelt(string name)
        {
            this.belt.addTrainerName(name);
        }

        public string getName()
        {
            return this.name;
        }

        public void RemovePokeball(pokeball pokeball)
        {
            this.belt.RemovePokeball(pokeball);
        }

        public int getBeltLength()
        {
            return this.belt.getBeltLength();
        }

        public pokeball getItemFromBelt(int index)
        {
            return this.belt.getItemFromBelt(index);
        }

        public void createPokemonTeam()
        {
            for (var i = 0; i < 6; i++)
            {
                Random random = new Random();
                int randomPokemon = random.Next(1, 4);

                if (randomPokemon == 1)
                {
                    this.belt.add(this.belt.makePokeball(new Charmander()));
                }
                else if (randomPokemon == 2)
                {
                    this.belt.add(this.belt.makePokeball(new Squirtle()));
                }
                else
                {
                    this.belt.add(this.belt.makePokeball(new Bulbasaur()));
                }
            }
        }
    }
}
