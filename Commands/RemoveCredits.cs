using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class RemoveCredits : OutpathCommand
    {
        public override string CommandName => "RemoveCredits";
        public override string CommandDesc => "RemoveCredits(<Amount>): Removes the specified amount of the games currency.";
        public override string Command(string input)
        {
            string returnString;

            PlayerGarden.instance.RemoveCredits(int.Parse(input));
            returnString = "Removed " + input + " [Credits].";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
