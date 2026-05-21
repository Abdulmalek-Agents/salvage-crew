using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SalvageCrew.Data
{
    [CreateAssetMenu(menuName = "SalvageCrew/Wreck Data", fileName = "Wreck_")]
    public class WreckData : ScriptableObject
    {
        public string wreckId;
        public string displayName;
        [TextArea] public string flavor;
        public AssetReference sceneReference;
    }
}
