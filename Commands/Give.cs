using JetBrains.Annotations;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutpathConsole.Commands
{
    public  class Give : OutpathCommand
    {
        public override string CommandName => "Give";
        public override string CommandDesc => "Give(<Item Name>, <Amount>): Gives you the specified amount of the specified item.";
        public override string Command(string input)
        {
            string[] paramaterers = input.Split(new char[] { ',' });
            string itemName = paramaterers[0];
            int quantity = int.Parse(paramaterers[1]);

            string returnString = "No item with that Name";

            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                if (item.itemName == itemName)
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
