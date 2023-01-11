using MelonLoader;
using UnityEngine;

namespace OutpathConsole.Commands
{
    public class Butcher : OutpathCommand
    {
        public override string CommandName => "Butcher";
        public override string CommandDesc => "Butcher(): Kills all animals.";
        public override string Command(string input)
        {
            string returnString;
            EnemyHealth[] Enemies = Resources.FindObjectsOfTypeAll<EnemyHealth>();

            foreach (var Animal in Enemies)
            {
                Animal.DestroyEnemy();
            }

            returnString = "Killed all animals/creatures.";

            Melon<Mod>.Logger.Msg(returnString);
            return returnString;
        }
    }
}
