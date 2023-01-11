using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class AddCredits : OutpathCommand
    {
        public override string CommandName => "AddCredits";
        public override string CommandDesc => "AddCredits(<Amount>): Gives you the specified amount of the games currency.";
        public override string Command(string input)
        {
            string returnString;

            PlayerGarden.instance.credits += int.Parse(input);

            PlayerGarden.instance.UpdateTotalCredits();
            PlayerGarden.instance.UpdateCreditsText();
            PlayerGarden.instance.cellsAnim.Play("CellCounter_Pop", -1, 0f);
            PlayerGarden.instance.creditsParticles.Play();

            returnString = "Added " + input + " [Credits].";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
