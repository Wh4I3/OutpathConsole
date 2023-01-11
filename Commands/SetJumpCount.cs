using MelonLoader;
using OverfortGames.FirstPersonController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class SetJumpCount : OutpathCommand
    {
        public override string CommandName => "SetJumpCount";
        public override string CommandDesc => "SetJumpCount(): Sets the amount of times you can jump before hitting the ground.";
        public override string Command(string input)
        {
            string returnString;

            int newJumpsCount = int.Parse(input);
            FirstPersonController.instance.jumpSettings.jumpsCount = newJumpsCount;

            returnString = "Set [Jump Count] to: " + newJumpsCount;
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
    }
}
