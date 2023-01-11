using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutpathConsole.Commands
{
    public class Tp : OutpathCommand
    {
        public override string CommandName => "Tp";
        public override string CommandDesc => "Tp(<x>, <y>, <z>): Teleports you to the specified position.";
        public override string Command(string input)
        {
            string returnString;
            string[] parts = input.Split(new char[] { ',' }, 3);

            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float z = float.Parse(parts[2]);

            PlayerGarden.instance.transform.position = new Vector3(x, y, z);

            returnString = "Teleported player to: [x: " + x + "], [y: " + y + "], [z: " + z + "]";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
