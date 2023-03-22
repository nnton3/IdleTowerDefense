using System.Collections;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private float _timeout;
    [SerializeField] private Transform _basePos;
    private ObjectsPull _enemiesPull;
    private readonly float spawnRange = 2.5f;
    private float _rangeK;
    private Vector2 _basePosition;

    private void Start()
    {
        _enemiesPull = GetComponent<ObjectsPull>();

        _basePosition = _basePos.position;
        CalcSpawnRangeKoef();

        StartCoroutine(SpawnRoutine());
    }

    private void CalcSpawnRangeKoef()
    {
        var pos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        pos = pos.normalized;
        _rangeK = spawnRange / Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2));
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var instance = _enemiesPull.GetInstance();
            instance.transform.position = GetSpawnPosition();
            instance.SetActive(true);
            instance.GetComponent<Mover>().StartMove(_basePos.position);
            yield return new WaitForSeconds(_timeout);
        }
    }

    private Vector2 GetSpawnPosition()
    {
        var pos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        return _basePosition + pos.normalized * _rangeK;
    }
}
