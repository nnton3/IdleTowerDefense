using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Init(float speed) => _speed = speed;

    public void StartMove(Vector2 targetPos)
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", (Vector3)targetPos,
            "speed", _speed,
            "easetype", iTween.EaseType.linear));
    }

    private void StopMove()
    {
        iTween.Stop(gameObject, "MoveTo");
    }

    private void OnDisable()
    {
        StopMove();
    }
}
