using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class RemoveID : OutpathCommand
    {
        public override string CommandName => "RemoveID";
        public override string CommandDesc => "RemoveID(<Item ID>, <Amount>): Removes the specified amount of the item with the specified item id.";
        public override string Command(string input)
        {
            string[] parts = input.Split(new char[] { ',' }, 2);
            int itemID = int.Parse(parts[0]);
            int quantity = int.Parse(parts[1]);
            string returnString = "No item with that Name";

            for (int i = 0; i <= ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                if (item.itemID == itemID)
                {
                    InventoryManager.instance.RemoveItemFromInv(item, quantity);
                    returnString = "Removed " + quantity + " [" + item.itemName + "]";
                }
            }
            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
