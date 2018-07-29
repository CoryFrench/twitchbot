﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Player : IPlayer
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int ToHitBonus { get; set; }
        public int DamageDice { get; set; }
        public int DamageSides { get; set; }
        public int DamageBonus { get; set; }

        public Player(string name)
        {
            Name = name;
            Class = "Warrior";
            AC = 17;
            MaxHP = 16;
            CurrentHP = 16;
            ToHitBonus = 5;
            DamageDice = 1;
            DamageSides = 8;
            DamageBonus = 3;
        }

        public void Attack(ICreature creature)
        {
            if(RNG.Roll(1,20) + ToHitBonus >= creature.AC)
            {
                creature.CurrentHP -= RNG.Roll(DamageDice, DamageSides) + DamageBonus;
            }
        }
    }
}
