﻿namespace Pokemon.Models
{
    public class Trainer
    {
        private string name;
        private Belt belt;

        public Trainer() {}

        public void nameTrainer(string name)
        {
            this.name = name;
        }

        public void addBelt()
        {
            this.belt = new Belt();
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
