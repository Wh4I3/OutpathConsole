using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole.Commands
{
    public class Clear : OutpathCommand
    {
        public override string CommandName => "Clear";
        public override string CommandDesc => "Clear(): Removes all your items.";
        public override string Command(string input)
        {
            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                int quantity = InventoryManager.instance.itemsInInv[i];
                InventoryManager.instance.RemoveItemFromInv(item, quantity);

                Melon<Mod>.Logger.Msg("Removed [" + item.itemName + "] from your inventory.");
            }
            return "Cleared Inventory";
        }
    }
}
