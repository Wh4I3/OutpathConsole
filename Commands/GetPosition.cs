using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutpathConsole.Commands
{
    public class GetPosition : OutpathCommand
    {
        public override string CommandName => "GetPosition";
        public override string CommandDesc => "GetPosition(): Gets your current position.";
        public override string Command(string input)
        {
            string returnString;
            Vector3 position = PlayerGarden.instance.transform.position;

            returnString = "Your position is: [x: " + position.x + "], [y: " + position.y + "], [z: " + position.z + "]";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
