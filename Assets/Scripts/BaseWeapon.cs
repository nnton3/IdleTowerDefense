using System;
using System.Collections;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private BaseTargetSelector _targetSelector;
    private float _timeout = 0.75f;
    private int _damage = 1;
    private ObjectsPull _bulletsPull;

    private void Start()
    {
        _bulletsPull = GetComponent<ObjectsPull>();
        StartCoroutine(AttackRoutine());
    }

    public void SetDamage(int damage) => _damage = damage;
    public void SetTimeout(float timeout) => _timeout = timeout;

    private IEnumerator AttackRoutine()
    {
        Transform target = null;
        int hitCount = 0;
        while (true)
        {
            if (target == null)
            {
                target = GetNextTarget(ref hitCount);
                yield return null;
            }
            else
            {
                var bullet = _bulletsPull.GetInstance();
                bullet.transform.position = transform.position;
                bullet.GetComponent<BulletInitializer>().Init(_damage);
                bullet.SetActive(true);
                bullet.GetComponent<Mover>().StartMove(target.position);
                hitCount--;
                if (hitCount == 0)
                    target = GetNextTarget(ref hitCount);
                
                yield return new WaitForSeconds(_timeout);
            }
        }
    }

    private Transform GetNextTarget(ref int hitCount)
    {
        Transform target = _targetSelector.Target;
        if (target != null)
        {
            var enemyHealth = target?.GetComponent<EnemyHealth>();
            hitCount = (int)Math.Round((float)enemyHealth.Health / _damage);
        }
        
        return target;
    }
}
