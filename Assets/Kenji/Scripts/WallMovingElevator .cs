using UnityEngine;

public class WallMovingElevator : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _radius = 1f;
    [SerializeField] MoveDirection _direction;
    [SerializeField] string _allowedTag; // このタグを持つプレイヤーだけ乗れる

    private Vector2 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }

    void Update()
    {
        WallMoveOnUpdate();
    }

    void WallMoveOnUpdate()
    {
        float offset = _radius * Mathf.Sin(_speed * Time.time);
        Vector2 newPosition = _initialPosition;

        switch (_direction)
        {
            case MoveDirection.Horizontal:
                newPosition.x += offset;
                break;
            case MoveDirection.Vertical:
                newPosition.y += offset;
                break;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_allowedTag))
        {
            collision.transform.SetParent(this.transform); // プレイヤーを子にする
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_allowedTag))
        {
            collision.transform.SetParent(null); // 子から外す
        }
    }

    public enum MoveDirection
    {
        Horizontal,
        Vertical
    }
}
