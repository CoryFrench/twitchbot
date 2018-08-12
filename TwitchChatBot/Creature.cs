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
        public bool IsPlayer { get; set; }
        public bool IsAlive { get; set; }
        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set;}
        public int ToHitBonus { get; set; }
        public int DamageDice { get; set; }
        public int DamageSides { get; set; }
        public int DamageBonus { get; set; }
        public int Level { get; set; }
        public int MR { get; set; }
        public int DR { get; set; }
        public int Speed { get; set; }

        public Creature(string name, int ac, int level, int tohitbonus, int damagedice, int damagesides, int damagebonus, int speed, int mr, int dr)
        {
            Name = name;
            IsPlayer = false;
            IsAlive = true;
            AC = ac;
            Level = level;
            Speed = speed;
            MR = mr;
            DR = dr;
            for(int x =  0; x < level; x++)
            {
                MaxHP += RNG.Roll(1, 8);
            }
            CurrentHP = MaxHP;
            ToHitBonus = tohitbonus;
            DamageDice = damagedice;
            DamageSides = damagesides;
            DamageBonus = damagebonus;
        }

        public void Attack(ICreature creature)
        {
            if (RNG.Roll(1, 20) + ToHitBonus >= creature.AC)
            {
                int damage = (RNG.Roll(DamageDice, DamageSides) + DamageBonus) - creature.DR;
                creature.CurrentHP -= damage;
                Console.WriteLine(this.Name + " hits " + creature.Name + " for " + damage);
            }
        }

        public ICreature GetCreatureFromList(List<ICreature> creatures)
        {
            return creatures[RNG.GetInt(0, creatures.Count - 1)];
        }

        public bool IsFriendly(ICreature target)
        {
            return (target.IsPlayer == this.IsPlayer);
        }
    }
}
