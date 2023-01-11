using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class GetAll : OutpathCommand
    {
        public override string CommandName => "GetAll";
        public override string CommandDesc => "GetAll(): Tells you the ItemID and itemName of every item.";
        public override string Command(string input)
        {
            string returnString = "";
            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                Melon<Mod>.Logger.Msg("Item of [ItemID] " + i + " is called [" + ItemList.instance.itemList[i].itemName + "]");
                returnString += "\n" + "Item of [ItemID] " + i + " is called [" + ItemList.instance.itemList[i].itemName + "]";
            }
            return returnString;
        }
    }
}
