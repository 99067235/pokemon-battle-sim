using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    public abstract class BattleHandler
    {
        public abstract bool? Versus(string enemy_type);
    }
    public class Fire : BattleHandler
    {
        public override bool? Versus(string enemy_type)
        {
            if (enemy_type is "Water")
            {
                return false;
            }
            else if (enemy_type is "Grass")
            {
                return true;
            }
            else if (enemy_type is "Fire")
            {
                return null;
            }
            else
            {
<<<<<<< HEAD
                Console.WriteLine("Attack failed: No valid type.");
=======
>>>>>>> 39105b7 (Removed console.writelines.)
                return false;
            }
        }
    }
    public class Grass : BattleHandler
    {
        public override bool? Versus(string enemy_type)
        {
            if (enemy_type is "Water")
            {
                return true;
            }
            else if (enemy_type is "Grass")
            {
                return null;
            }
            else if (enemy_type is "Fire")
            {
                return false;
            }
            else
            {
<<<<<<< HEAD
                Console.WriteLine("Attack failed: No valid type.");
=======
>>>>>>> 39105b7 (Removed console.writelines.)
                return false;
            }
        }
    }
    public class Water : BattleHandler
    {
        public override bool? Versus(string enemy_type)
        {
            if (enemy_type is "Water")
            {
                return null;
            }
            else if (enemy_type is "Grass")
            {
                return false;
            }
            else if (enemy_type is "Fire")
            {
                return true;
            }
            else
            {
<<<<<<< HEAD
                Console.WriteLine("Attack failed: No valid type.");
=======
>>>>>>> 39105b7 (Removed console.writelines.)
                return false;
            }
        }
    }
}
