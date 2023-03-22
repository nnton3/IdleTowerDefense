using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class UpgradeSpeedSystem : UpgradeSystem
    {
        [SerializeField] private UpgradeSpeedConfig _config;
        [SerializeField] private BaseWeapon _weapon;

        protected override void Awake()
        {
            base.Awake();
            _maxLvl = _config.Values.Length - 1;
        }

        protected override void UpHandler()
        {
            if (!CanUpgrade()) return;
            base.UpHandler();
            _weapon.SetTimeout(_config.Values[_currentLvl]);
        }
    }
}