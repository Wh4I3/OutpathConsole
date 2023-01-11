using MelonLoader;
using OverfortGames.FirstPersonController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class SetJumpForce : OutpathCommand
    {
        public override string CommandName => "SetJumpForce";
        public override string CommandDesc => "SetJumpForce(): Sets how high you jump.";
        public override string Command(string input)
        {
            string returnString;

            float newJumpforce = float.Parse(input);
            FirstPersonController.instance.jumpSettings.jumpForce = newJumpforce;

            returnString = "Set [Jump Force] to: " + newJumpforce;
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
    }
}
