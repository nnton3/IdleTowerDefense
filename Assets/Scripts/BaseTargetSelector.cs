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
            _targetQueue.Enqueue(collision.transform);
    }

    public void SetRange(float range)
    {
        iTween.Stop(gameObject, "ScaleTo");
        iTween.ScaleTo(gameObject, iTween.Hash(
            "scale", Vector3.one * range,
            "time", 0.5f,
            "easetype", iTween.EaseType.easeInOutSine));
    }
}
