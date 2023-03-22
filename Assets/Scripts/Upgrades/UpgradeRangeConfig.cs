using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeRangeConfig", menuName = "Upgrades/Range")]
    public class UpgradeRangeConfig : ScriptableObject
    {
        public float[] Values;
    }
}