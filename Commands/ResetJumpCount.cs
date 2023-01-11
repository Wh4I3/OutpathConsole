using MelonLoader;
using OverfortGames.FirstPersonController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class ResetJumpCount : OutpathCommand
    {
        public override string CommandName => "ResetJumpCount";
        public override string CommandDesc => "ResetJumpCount(): Resets the amount of times you can jump before hitting the ground.";
        public override string Command(string input)
        {
            string returnString;

            FirstPersonController.instance.jumpSettings.jumpsCount = 1;

            returnString = "Reset [Jump Count]";
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
    }
}