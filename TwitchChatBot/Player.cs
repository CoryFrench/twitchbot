using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Player : IPlayer
    {
        public string Name { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsAlive { get; set; }
        public string Class { get; set; }
        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int ToHitBonus { get; set; }
        public int DamageDice { get; set; }
        public int DamageSides { get; set; }
        public int DamageBonus { get; set; }
        public int Level { get; set; }
        public int MR { get; set; }
        public int DR { get; set; }
        public int Speed { get; set; }

        public Player(string name)
        {
            Name = name;
            IsPlayer = true;
            IsAlive = true;
            Class = "Warrior";
            AC = 17;
            DR = 0;
            MR = 0;
            Level = 2;
            for(int x = 0; x < Level; x++)
            {
                MaxHP += Level * RNG.Roll(1, 8);
            }
            CurrentHP = MaxHP;
            ToHitBonus = 5;
            DamageDice = 1;
            DamageSides = 8;
            DamageBonus = 3;
            Speed = 15;
            Level = 1;
        }

        public void Attack(ICreature creature)
        {
            if(RNG.Roll(1,20) + ToHitBonus >= creature.AC)
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
