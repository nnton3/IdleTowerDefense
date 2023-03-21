﻿using UnityEngine;

public class HitChecker : MonoBehaviour
{
    [SerializeField] private GameObject _mainObj;
    private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().ApplyDamage(_damage);
            _mainObj.SetActive(false);
        }
    }
}
