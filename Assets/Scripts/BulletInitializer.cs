using UnityEngine;

public class BulletInitializer : MonoBehaviour
{
    [SerializeField] private HitChecker _hitChecker;

    public void Init(int damage)
    {
        _hitChecker.Init(damage);
    }
}
