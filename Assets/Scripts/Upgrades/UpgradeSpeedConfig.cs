using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeSpeedConfig", menuName = "Upgrades/Speed")]
    public class UpgradeSpeedConfig : ScriptableObject
    {
        public float[] Values;
    }
}