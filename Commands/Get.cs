using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class Get : OutpathCommand
    {
        public override string CommandName => "Get";
        public override string CommandDesc => "Get(<ItemID>): Tells you the name of the item with the specified item id.";
        public override string Command(string input)
        {
            int itemID = int.Parse(input);
            string returnString = "No item with that ID.";

            if (itemID <= ItemList.instance.itemList.Length)
            {
                ItemInfo item = ItemList.instance.itemList[itemID];
                returnString = "Item of [ItemID] " + itemID + " is called [" + item.itemName + "]";
            }
            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
