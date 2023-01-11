using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class Help : OutpathCommand
    {
        public override string CommandName => "Help";
        public override string CommandDesc => "Help(<Command>): Sends a list of commands if <Command> is empty. Otherwise it tells what the specified command does.";
        public override string Command(string input)
        {
            string returnString = "";
            if (input == "")
            {
                returnString = "List of commands):\n";
                for (int i = 0; i < Mod.commandList.Count; i++)
                {
                    returnString += "\n" + Mod.commandList[i].CommandName;
                }
                returnString += "\n\n(You can see what each command does with /Help(<Command>).";
            }
            else
            {
                Melon<Mod>.Logger.Msg("True");
                bool foundCommand = false;
                for (int i = 0; i < Mod.commandList.Count; i++)
                {
                    Melon<Mod>.Logger.Msg(input);
                    if (input == Mod.commandList[i].CommandName)
                    {
                        Melon<Mod>.Logger.Msg(Mod.commandList[i].CommandName);
                        returnString = Mod.commandList[i].CommandDesc;

                        foundCommand = true;
                    }
                    else if (!foundCommand)
                    {
                        returnString = "No command with that name.";
                    }
                }
            }
            return returnString;
        }
    }
}