using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health => _currentHealth;
    public bool IsDead => isDead;

    [SerializeField] private GameObject _mainObj;
    private const int _maxHealth = 3;
    private int _currentHealth = _maxHealth;
    private bool isDead;
    
    public void ApplyDamage(int damage)
    {
        if (_currentHealth <= damage)
        {
            isDead = true;
            _mainObj.SetActive(false);
        }
        else
        {
            _currentHealth -= damage;
        }
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
        isDead = false;
    }
}
