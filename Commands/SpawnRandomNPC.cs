using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutpathConsole.Commands
{
    public class SpawnRandomNPC : OutpathCommand
    {
        public override string CommandName => "SpawnRandomNPC";
        public override string CommandDesc => "SpawnRandomNPC(): Spawns a random NPC at your position";
        public override string Command(string input)
        {
            Block _block = GameObject.FindObjectOfType<Block>();
            _block.GenerateCreature_AtPos(PlayerGarden.instance.transform.position);
            return "Spawned a random [NPC].";
        }
    }
}
