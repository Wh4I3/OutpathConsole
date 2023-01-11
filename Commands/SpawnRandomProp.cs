using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutpathConsole.Commands
{
    public class SpawnRandomProp : OutpathCommand
    {
        public override string CommandName => "SpawnRandomProp";
        public override string CommandDesc => "SpawnRandomProp(): Spawns a random Prop at your current position";
        public override string Command(string input)
        {
            Block _block = GameObject.FindObjectOfType<Block>();

            Block.Prop propInfo = (Block.Prop)typeof(Block).GetMethod("GetPropInfo", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(_block, null);

            PropConfig component = propInfo.itemPrefab.GetComponent<PropConfig>();
            component.isleGeneratorParent = _block.IsleGeneratorParent;
            Vector3 propPos = PlayerGarden.instance.transform.position;
            if (UnityEngine.Random.value <= propInfo.probToSpawn)
            {
                UnityEngine.Object.Instantiate<GameObject>(propInfo.itemPrefab, propPos, _block.transform.rotation).transform.SetParent(_block.objectsParent);
            }

            return "Spawned a random [Prop]";
        }
    }
}
