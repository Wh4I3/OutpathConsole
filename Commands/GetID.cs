using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class GetID : OutpathCommand
    {
        public override string CommandName => "GetID";
        public override string CommandDesc => "GetID(<Item Name>): Tells you the item id of the item with the specified name.";
        public override string Command(string input)
        {
            string returnString = "No item with that Name.";

            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                if (ItemList.instance.itemList[i].name == input) {
                    ItemInfo item = ItemList.instance.itemList[i];
                    returnString = "The [ItemID] of the item called[itemName] is: " + item.itemID + ".";
                }
            }
            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
