using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class ClearCredits : OutpathCommand
    {
        public override string CommandName => "ClearCredits";
        public override string CommandDesc => "ClearCredits(): Removes all your credits.";
        public override string Command(string input)
        {
            PlayerGarden.instance.RemoveCredits(PlayerGarden.instance.credits);
            return "Cleared Credits";
        }
    }
}
