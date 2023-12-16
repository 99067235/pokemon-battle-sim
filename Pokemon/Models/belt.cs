using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    public sealed class Belt
    {
        private List<pokeball> belt = new();
        private string trainerName;

        public void addTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public pokeball GetItemFromPokeball(int id)
        {
            return belt[id];
        }

        public void add(pokeball pokeball)
        {
            if (belt.Count > 6)
            {
                throw new InvalidOperationException("Cannot add more than 6 pokeballs to the belt.");
            } else
            {
                belt.Add(pokeball);
            }
        }

        public pokeball getItemFromBelt(int index)
        {
            if (index < 0 || index >= belt.Count)
            {
                Random random = new Random();
                index = random.Next(0, belt.Count);
            }

            return belt[index];
        }

        public int getBeltLength()
        {
            return this.belt.Count;
        }

        public pokeball makePokeball(Pokemon? pokemon = null)
        {
            if (pokemon != null)
            {
                pokeball pokeball = new(pokemon);
                return pokeball;
            } else
            {
                pokeball pokeball = new();
                return pokeball;
            }
        }

        public void RemovePokeball(pokeball pokeball)
        {
            belt.Remove(pokeball);
        }
    }
}
