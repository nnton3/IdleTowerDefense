using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class UpgradeRangeSystem : UpgradeSystem
    {
        [SerializeField] private UpgradeRangeConfig _config;
        [SerializeField] private BaseTargetSelector _targetSelector;

        protected override void Awake()
        {
            base.Awake();
            _maxLvl = _config.Values.Length - 1;
        }

        protected override void UpHandler()
        {
            if (!CanUpgrade()) return;
            base.UpHandler();
            _targetSelector.SetRange(_config.Values[_currentLvl]);
        }
    }
}