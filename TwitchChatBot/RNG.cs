using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// RNGs are great candidates for the Singleton pattern, IMO.  I wrote a lazy initializer, which means memory for 
    /// the RNG seed isn't allocated until the first number generation.  You never want to reinitialize the RNG seed
    /// every invocation, unless you like every random number to be the same.  ALWAYS go through the Get() function.
    /// </summary>
    class RNG
    {
        private static Random Instance = null;
        private static Random Get()
        {
            if (Instance == null)
            {
                Instance = new Random();
            }
            return Instance;
        }

        /// <summary>
        /// Roll dice, using provided arguments for number and sides
        /// </summary>
        /// <param name="dice">number of dice</param>
        /// <param name="sides">number of sides</param>
        /// <returns></returns>
        public static int Roll(int dice, int sides)
        {
            if (dice < 1)
            {
                // TODO: WTF
            }

            int val = 0;
            for (int i = 0; i < dice; i++)
            { 
                val += Get().Next(1, sides + 1);
            }
            return val;
        }

        /// <summary>
        /// Get an integer from min to max
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns></returns>
        public static int GetInt(int min, int max)
        {
            return Get().Next(min, max + 1);
        }
    }
}
