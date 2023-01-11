using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class Respawn : OutpathCommand
    {
        public override string CommandName => "Respawn";
        public override string CommandDesc => "Respawn(): Makes you respawn.";
        public override string Command(string input)
        {
            string returnString;

            PlayerGarden.instance.GetDrown();
            returnString = "Respawned!";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
