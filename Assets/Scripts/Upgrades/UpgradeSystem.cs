using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Upgrades
{
    public class UpgradeSystem : MonoBehaviour
    {
        [SerializeField] protected Button _btn;
        [SerializeField] protected UpgradeView _view;
        protected int _currentLvl;
        protected int _maxLvl;

        protected virtual void Awake()
        {
            _btn.onClick.AddListener(() => UpHandler());
        }

        protected virtual void UpHandler()
        {
            _currentLvl++;
            _view.UpdateView(_currentLvl);
        }

        protected bool CanUpgrade() => _currentLvl < _maxLvl;
    }
}