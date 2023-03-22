using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Upgrades
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private Image[] _stars;
        [SerializeField] private Color _fillColor;

        public void UpdateView(int lvl)
        {
            _stars[lvl].color = _fillColor;
        }
    }
}