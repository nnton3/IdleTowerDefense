using System;
using UnityEngine;

public class PullInstance : MonoBehaviour
{
    private Action _onReturnToPull;

    public void Init(Action onReturnToPull) => _onReturnToPull = onReturnToPull;
    private void OnDisable() => _onReturnToPull?.Invoke();
    private void OnDestroy() => _onReturnToPull = null;
}
