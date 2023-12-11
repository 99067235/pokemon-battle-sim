using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    public enum PokemonTypes {
        Fire,
        Grass,
        Water
    }
    public abstract class BattleHandler
    {
        public static bool? Versus(PokemonTypes type, PokemonTypes EnemyType)
        {
            if (type == PokemonTypes.Fire)
            {
                if (EnemyType == PokemonTypes.Grass)
                {
                    return true;
                }
                if (EnemyType == PokemonTypes.Fire)
                {
                    return null;
                }
                if (EnemyType == PokemonTypes.Water)
                {
                    return false;
                }
            }

            if (type == PokemonTypes.Water)
            {
                if (EnemyType == PokemonTypes.Fire)
                {
                    return true;
                }
                if (EnemyType == PokemonTypes.Water)
                {
                    return null;
                }
                if (EnemyType == PokemonTypes.Grass)
                {
                    return false;
                }
            }

            if (type == PokemonTypes.Grass)
            {
                if (EnemyType == PokemonTypes.Water)
                {
                    return true;
                }
                if (EnemyType == PokemonTypes.Grass)
                {
                    return null;
                }
                if (EnemyType == PokemonTypes.Fire)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
