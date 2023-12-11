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
        public string trainerName;
        public pokeball GetItemFromPokeball(int id)
        {
            return belt[id];
        }

        public void add(pokeball pokeball)
        {
            belt.Add(pokeball);
        }

        public pokeball getItemFromBelt(int index)
        {
            return belt[index];
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
    }
}
