using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class GiveAll : OutpathCommand
    {
        public override string CommandName => "GiveAll";
        public override string CommandDesc => "GiveAll(<Amount>): Gives you the specified amount of every item.";
        public override string Command(string input)
        {
            int quantity = int.Parse(input);

            string returnString = "";
            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                InventoryManager.instance.AddItemToInv(item, quantity, true);

                Melon<Mod>.Logger.Msg("Gave " + quantity + " [" + item.itemName + "]");
                returnString += "\n" + "Gave " + quantity + " [" + item.itemName + "]";
            }
            return returnString;
        }
    }
}