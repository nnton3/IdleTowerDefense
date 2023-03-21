using System.Collections.Generic;
using UnityEngine;

public class BaseTargetSelector : MonoBehaviour
{
    public Transform Target
    {
        get
        {
            if (_targetQueue.Count > 0)
                return _targetQueue.Dequeue();
            else 
                return null;
        }
    }
    [SerializeField] private Queue<Transform> _targetQueue = new Queue<Transform>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log($"Add target {collision.transform.parent.name} to queue");
            _targetQueue.Enqueue(collision.transform);
        }
    }
}
