using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using static MelonLoader.MelonLaunchOptions;

namespace OutpathConsole
{
    public class Commands
    {

        public WeaponInfo Weapon;
        public string Help(string input)
        {
            string returnString;
            if (input != "")
            {
                input = input.Remove(input.Length - 1);
                if (input == "Help") return "Help(<Command>): Sends a list of commands if <Command> is empty. Otherwise it tells what a certain command does.";
                else if (input == "HelloWorld") return "HelloWorld(): Writes \"Hello World!\" to the Console.";
                else if (input == "Echo") return "Echo(<Message>): Writes the <Message> to the Console";
                else if (input == "GiveCredits") return "GiveCredits(<Quantity>): Gives you <Quantity> Credits";
                else if (input == "GiveItem") return "GiveItem(<Item Name>, <Quantity>): Gives you <Quantity> of <Item Name>.";
                else if (input == "GiveAllItems") return "GiveAllItems(<Quantity>): Gives you <Quantity> of all items.";
                else if (input == "GetItem") return "GetItem(<ItemID>): Tells you the name of the item with <ItemID> as the ItemID.";
                else if (input == "GetAllItems") return "GetAllItems(): Tells you the ItemID and name of every item.";
                else if (input == "Respawn") return "Respawn(): Respawns you.";
                else if (input == "AddCredits") return "AddCredits(<Amount>): Gives you the games currency.";
                else if (input == "CreateWeapon") return "CreateWeapon(): Creates a weapon. Right click to shoot";
                else if (input == "KillAll") return "KillAll(): Kills all animals";
                else return "No such command";
            }
            else
            {
                returnString = "\nList of commands):\n";
                returnString += "\nHelp";
                returnString += "\nHelloWorld";
                returnString += "\nEcho";
                returnString += "\nGiveCredits";
                returnString += "\nGiveItem";
                returnString += "\nGiveAllItems";
                returnString += "\nGetItem";
                returnString += "\nGetAllItems";
                returnString += "\nRespawn";
                returnString += "\nAddCredits";
                returnString += "\nCreateWeapon";
                returnString += "\nKillAll";
                returnString += "\n\n(You can see what each command does with /Help(<Command>).";
            }

            return returnString;
        }
        public string HelloWorld(string input)
        {
            Melon<Mod>.Logger.Msg("Hello World!");
            return "Hello World!";
        }
        public string Echo(string input)
        {
            Melon<Mod>.Logger.Msg(input);
            return input;
        }
        public string GiveCredits(string input)
        {
            int quantity = int.Parse(input);
            PlayerGarden.instance.AddCredits(quantity);
            Melon<Mod>.Logger.Msg("Gave " + quantity + " [Credits]");
            return "Gave " + quantity + " [Credits]";
        }
        public string GiveItem(string input)
        {
            string[] parts = input.Split(new char[] { ',' }, 2);
            int quantity = int.Parse(parts[1]);

            for (int i = 0; i <= ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                if (item.name == parts[0])
                {
                    InventoryManager.instance.AddItemToInv(item, quantity, true);

                    Melon<Mod>.Logger.Msg("Gave " + quantity + " [" + item.name + "]");
                    return "Gave " + quantity + " [" + item.name + "]";
                }
            }
            Melon<Mod>.Logger.Msg("No item with that Name");
            return "No item with that Name";
        }
        public string GiveAllItems(string input)
        {
            int quantity = int.Parse(input);
            string returnString = "";

            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                InventoryManager.instance.AddItemToInv(item, quantity, true);

                Melon<Mod>.Logger.Msg("Gave " + quantity + " [" + item.name + "]");
                returnString += "\n" + "Gave " + quantity + " [" + item.name + "]";
            }
            return returnString;
        }
        public string GetItem(string input)
        {
            int itemID = int.Parse(input);

            if (itemID <= ItemList.instance.itemList.Length)
            {
                ItemInfo item = ItemList.instance.itemList[itemID];

                Melon<Mod>.Logger.Msg("Item of [ItemID] " + itemID + " is called [" + item.name + "]");
                return "Item of [ItemID] " + itemID + " is called [" + item.name + "]";
            }
            Melon<Mod>.Logger.Msg("No item with that Name");
            return "No item with that Name";
        }
        public string GetAllItems(string input)
        {
            string returnString = "";
            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                Melon<Mod>.Logger.Msg("Item of [ItemID] " + i + " is called [" + ItemList.instance.itemList[i].name + "]");
                returnString += "\n" + "Item of [ItemID] " + i + " is called [" + ItemList.instance.itemList[i].name + "]";
            }
            return returnString;
        }
        public string Respawn(string input)
        {
            string returnString = "";

            PlayerGarden.instance.GetDrown();
            returnString = "Respawned!";

            return returnString;
        }
        public string AddCredits(string input)
        {
            string returnString = "";

            PlayerGarden.instance.AddCredits(int.Parse(input));
            returnString = "Gave " + input + " Credits.";

            return returnString;
        }

        public string CreateWeapon(string input)
        {
            string returnString = "Created a weapon??";

            int WeaponIndex = int.Parse(input);
            WeaponInfo[] _Weapon = Resources.FindObjectsOfTypeAll<WeaponInfo>();
            foreach (var A in _Weapon)
            {
                if (WeaponIndex == 1)
                {
                    Weapon = _Weapon[0];
                }
                if (WeaponIndex == 2)
                {
                    Weapon = _Weapon[1];
                }
            }
            PlayerWeaponManager.instance.SetupWeapon(Weapon);
            returnString = "Created Weapon: " + Weapon.name;

            return returnString;
        }
        public string KillAll(string input)
        {
            string returnString = "Killing all animals";

            EnemyHealth[] Enemys = Resources.FindObjectsOfTypeAll<EnemyHealth>();

            foreach(var Animal in Enemys)
            {
                Animal.health = 0;
                Animal.DamageEnemy();
            }

            returnString = "Killed all animals/creatures.";

            return returnString;
        }
    }
}

