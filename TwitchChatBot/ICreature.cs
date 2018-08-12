using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    public interface ICreature
    {
        String Name { get; set; }
        bool IsPlayer { get; set; }
        bool IsAlive { get; set; }
        int CurrentHP { get; set; }
        int Level { get; set; }
        int Speed { get; set; }
        int MaxHP { get; set; }
        int AC { get; set; }
        int MR { get; set; }
        int DR{ get; set; }
        int ToHitBonus { get; set; } 
        int DamageDice { get; set; }
        int DamageSides { get; set; }
        int DamageBonus { get; set; }
        void Attack(ICreature creature);
        bool IsFriendly(ICreature target);
        ICreature GetCreatureFromList(List<ICreature> creatures);
    }
}
