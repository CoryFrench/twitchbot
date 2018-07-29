using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Creature : ICreature
    {
        public string Name { get; set; }
        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set;}
        public int ToHitBonus { get; set; }
        public int DamageDice { get; set; }
        public int DamageSides { get; set; }
        public int DamageBonus { get; set; }


        public Creature(string name, int ac, int maxhp, int tohitbonus, int damagedice, int damagesides, int damagebonus)
        {
            Name = name;
            AC = ac;
            MaxHP = maxhp;
            CurrentHP = maxhp;
            ToHitBonus = tohitbonus;
            DamageDice = damagedice;
            DamageSides = damagesides;
            DamageBonus = damagebonus;
        }

        public void Attack(ICreature creature)
        {
            if (RNG.Roll(1, 20) + ToHitBonus >= creature.AC)
            {
                creature.CurrentHP -= RNG.Roll(DamageDice, DamageSides) + DamageBonus;
            }
        }
    }
}
