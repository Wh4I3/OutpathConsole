using MelonLoader;
using OverfortGames.FirstPersonController;
using System;
using System.Collections.Generic;
using System.Reflection;
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
                else if (input == "Give") return "Give(<Item Name>, <Amount>): Gives you <Amount> of <Item Name>.";
                else if (input == "GiveAllItems") return "GiveAllItems(<Amount>): Gives you <Amount> of all items.";
                else if (input == "Remove") return "Remove(<Item Name>, <Amount>): Removes <Amount> of <Item Name>.";
                else if (input == "Clear") return "Clear(): Removes all your items.";
                else if (input == "GetItem") return "GetItem(<ItemID>): Tells you the name of the item with <ItemID> as the ItemID.";
                else if (input == "GetAllItems") return "GetAllItems(): Tells you the ItemID and name of every item.";
                else if (input == "Respawn") return "Respawn(): Respawns you.";
                else if (input == "AddCredits") return "AddCredits(<Amount>): Gives you the games currency.";
                else if (input == "RemoveCredits") return "RemoveCredits(<Amount>): Removes your game currency.";
                else if (input == "CreateWeapon") return "CreateWeapon(): Creates a weapon. Right click to shoot";
                else if (input == "Butcher") return "Butcher(): Kills all animals";
                else if (input == "Tp") return "Tp(<x>, <y>, <z>): Teleports you to the position specified.";
                else if (input == "GetPosition") return "GetPosition(): Gets your current position.";
                else if (input == "SetJumpCount") return "SetJumpCount(): Sets the amount of times you can jump before hitting the ground.";
                else if (input == "SetJumpForce") return "SetJumpForce(): Sets how high you jump.";
                else if (input == "SpawnRandomNPC") return "SpawnRandomNPC(): Spawns a random NPC.";
                else if (input == "SpawnRandomProp") return "SpawnRandomProp(): Spawns a random Prop,";
                else return "No such command";
            }
            else
            {
                returnString = "\nList of commands):\n";
                returnString += "\nHelp";
                returnString += "\nHelloWorld";
                returnString += "\nEcho";
                returnString += "\nGive";
                returnString += "\nGiveAllItems";
                returnString += "\nRemove";
                returnString += "\nClear";
                returnString += "\nGetItem";
                returnString += "\nGetAllItems";
                returnString += "\nRespawn";
                returnString += "\nAddCredits";
                returnString += "\nRemoveCredits";
                returnString += "\nCreateWeapon";
                returnString += "\nButcher";
                returnString += "\nTp";
                returnString += "\nGetPosition";
                returnString += "\nSetJumpCount";
                returnString += "\nSetJumpForce";
                returnString += "\nSpawnRandomNPC";
                returnString += "\nSpawnRandomProp";
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
        public string Give(string input)
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
        public string Remove(string input)
        {
            string[] parts = input.Split(new char[] { ',' }, 2);
            int quantity = int.Parse(parts[1]);

            for (int i = 0; i <= ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                if (item.name == parts[0])
                {
                    InventoryManager.instance.RemoveItemFromInv(item, quantity);

                    Melon<Mod>.Logger.Msg("Removed " + quantity + " [" + item.name + "]");
                    return "Removed " + quantity + " [" + item.name + "]";
                }
            }
            Melon<Mod>.Logger.Msg("No item with that Name");
            return "No item with that Name";
        }
        public string Clear(string input)
        {
            for (int i = 0; i < ItemList.instance.itemList.Length; i++)
            {
                ItemInfo item = ItemList.instance.itemList[i];
                int quantity = InventoryManager.instance.itemsInInv[i];
                InventoryManager.instance.RemoveItemFromInv(item, quantity);

                Melon<Mod>.Logger.Msg("Removed [" + item.name + "] from your inventory.");
            }
            return "Cleared Inventory";
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
            string returnString;

            PlayerGarden.instance.GetDrown();
            returnString = "Respawned!";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string AddCredits(string input)
        {
            string returnString;

            PlayerGarden.instance.AddCredits(int.Parse(input));
            returnString = "Gave " + input + " [Credits].";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string RemoveCredits(string input)
        {
            string returnString;

            PlayerGarden.instance.RemoveCredits(int.Parse(input));
            returnString = "Removed " + input + " [Credits].";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string CreateWeapon(string input)
        {
            string returnString;

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

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string Butcher(string input)
        {
            string returnString;
            EnemyHealth[] Enemies = Resources.FindObjectsOfTypeAll<EnemyHealth>();

            foreach(var Animal in Enemies)
            {
                Animal.DestroyEnemy();
            }

            returnString = "Killed all animals/creatures.";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string Tp(string input)
        {
            string returnString;
            string[] parts = input.Split(new char[] { ',' }, 3);

            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float z = float.Parse(parts[2]);

            PlayerGarden.instance.transform.position = new Vector3(x, y, z);

            returnString = "Teleported player to: [x: " + x + "], [y: " + y + "], [z: " + z + "]";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string GetPosition(string input)
        {
            string returnString;

            Vector3 position = PlayerGarden.instance.transform.position;

            returnString = "Your position is: [x: " + position.x + "], [y: " + position.y + "], [z: " + position.z + "]";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
        public string SetJumpCount(string input)
        {
            string returnString;

            int newJumpsCount = int.Parse(input);
            FirstPersonController.instance.jumpSettings.jumpsCount = newJumpsCount;

            returnString = "Set [Jump Count] to: " + newJumpsCount;
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
        public string SetJumpForce(string input)
        {
            string returnString;

            float newJumpforce = float.Parse(input);
            FirstPersonController.instance.jumpSettings.jumpForce = newJumpforce;

            returnString = "Set [Jump Force] to: " + newJumpforce;
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
        public string ResetJumpCount(string input)
        {
            string returnString;

            FirstPersonController.instance.jumpSettings.jumpsCount = 1;

            returnString = "Reset [Jump Count]";
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
        public string ResetJumpForce(string input)
        {
            string returnString;

            FirstPersonController.instance.jumpSettings.jumpForce = 6.0f;

            returnString = "Reset [Jump Force]";
            Melon<Mod>.Logger.Msg(returnString);

            return returnString;
        }
        public string SpawnRandomNPC(string input)
        {
            Block _block = GameObject.FindObjectOfType<Block>();
            _block.GenerateCreature_AtPos(PlayerGarden.instance.transform.position);
            return "";
        }
        public string SpawnRandomProp(string input)
        {
            Block _block = GameObject.FindObjectOfType<Block>();

            Block.Prop propInfo = (Block.Prop)typeof(Block).GetMethod("GetPropInfo", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(_block, null);
           
            PropConfig component = propInfo.itemPrefab.GetComponent<PropConfig>();
            component.isleGeneratorParent = _block.IsleGeneratorParent;
            Vector3 propPos = PlayerGarden.instance.transform.position;
            if (propPos == Vector3.zero)
            {
                return "";
            }
            if (UnityEngine.Random.value <= propInfo.probToSpawn)
            {
                UnityEngine.Object.Instantiate<GameObject>(propInfo.itemPrefab, propPos, _block.transform.rotation).transform.SetParent(_block.objectsParent);
            }

            return "";
        }
    }
}