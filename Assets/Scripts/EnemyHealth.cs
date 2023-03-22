using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health => _currentHealth;

    [SerializeField] private GameObject _mainObj;
    private const int _maxHealth = 3;
    private int _currentHealth = _maxHealth;
    
    public void ApplyDamage(int damage)
    {
        if (_currentHealth <= damage)
            _mainObj.SetActive(false);
        else
            _currentHealth -= damage;
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }
}
