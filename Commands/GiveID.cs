using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class GiveID : OutpathCommand
    {
        public override string CommandName => "GiveID";
        public override string CommandDesc => "GiveID(<Item ID>,<Amount>): Gives you the specified amount of the item with the specified item id.";
        public override string Command(string input)
        {
            string[] paramaterers = input.Split(new char[] { ',' });
            int itemID = int.Parse(paramaterers[0]);
            int quantity = int.Parse(paramaterers[1]);

            string returnString = "No item with that Name";

            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                if (item.itemID == itemID)
                {
                    InventoryManager.instance.AddItemToInv(item, quantity, true);

                    returnString = "Gave " + quantity + " [" + item.itemName + "]";
                }
            }
            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
