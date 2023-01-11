using MelonLoader;
using OverfortGames.FirstPersonController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class ResetJumpForce : OutpathCommand
    {
        public override string CommandName => "ResetJumpForce";
        public override string CommandDesc => "ResetJumpForce(): Resets how high you jump.";
        public override string Command(string input)
        {
            string returnString;

            FirstPersonController.instance.jumpSettings.jumpForce = 6.0f;

            returnString = "Reset [Jump Force]";
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
    }
}
