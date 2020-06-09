using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    interface IBoss
    {
        //przyporządkowany item:
        Item item { get; set; }

        //żeby oldman i mistyk wiedzieli że został pokonany:
        bool IsDefeated { get; set; }

        //musi być jakaś nazwa jeszcze więc:
        string NameView { get; set; }

    }
}
