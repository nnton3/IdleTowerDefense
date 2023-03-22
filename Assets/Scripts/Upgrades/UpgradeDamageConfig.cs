using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeDamageConfig", menuName = "Upgrades/Damage")]
    public class UpgradeDamageConfig : ScriptableObject
    {
        public int[] Values;
    }
}