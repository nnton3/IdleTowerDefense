using System.Collections.Generic;
using UnityEngine;

public class ObjectsPull : MonoBehaviour
{
    [SerializeField] private int _startCount = 5;
    [SerializeField] private GameObject _pref;
    [SerializeField] private Transform _parent;
    private Stack<GameObject> _objsStack;

    private void Awake()
    {
        _objsStack = new Stack<GameObject>();
        for (int i = 0; i < _startCount; i++)
        {
            var instance = SpawnInstance();
            instance.SetActive(false);
        }
    }

    public GameObject GetInstance()
    {
        GameObject instance;
        if (_objsStack.Count == 0)
            instance = SpawnInstance();
        else
            instance = _objsStack.Pop();

        Debug.Log($"Get instance {instance.name}");
        return instance;
    }

    private int _instanceCounter;
    private GameObject SpawnInstance()
    {
        var instance = Instantiate(_pref, _parent);
        instance.name += _instanceCounter;
        _instanceCounter++;
        instance.GetComponent<PullInstance>().Init(() => _objsStack.Push(instance));
        Debug.Log($"Spawn instance {instance.name}");
        return instance;
    }
}
