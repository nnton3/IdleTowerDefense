using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private BaseTargetSelector _targetSelector;
    [SerializeField] private float _timeout;
    private ObjectsPull _bulletsPull;
    private List<GameObject> _bullets = new List<GameObject>();

    private void Start()
    {
        _bulletsPull = GetComponent<ObjectsPull>();
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        Transform target = null;
        EnemyHealth enemyHealth = null;
        while (true)
        {
            if (target == null || enemyHealth.IsDead)
            {
                target = _targetSelector.Target;
                if (target != null)
                Debug.Log($"Select target {target.parent.name}");
                enemyHealth = target?.GetComponent<EnemyHealth>();
                _bullets.ForEach(b =>  b.gameObject.SetActive(false));
                _bullets.Clear();
                yield return null;
            }
            else
            {
                var bullet = _bulletsPull.GetInstance();
                _bullets.Add(bullet);
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
                bullet.GetComponent<Mover>().StartMove(target.position);
                yield return new WaitForSeconds(_timeout);
            }
        }
    }
}
