using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    [Header("このブロックを押せるプレイヤータイプ")]
    [SerializeField] private PlayerType pushableBy = PlayerType.Player1;

    [Header("押される速度")]
    [SerializeField] private float pushSpeed = 2f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // PlayerManager を持っているオブジェクトか？
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
        if (player == null) return;

        // 指定されたプレイヤーのみ処理を実行
        if (player._playerType != pushableBy) return;

        // 押している方向が左右かつ接触が強い場合に押す処理
        Vector2 contactNormal = collision.GetContact(0).normal;
        if (Mathf.Abs(contactNormal.x) > 0.5f)
        {
            float pushDirection = -Mathf.Sign(contactNormal.x);
            Vector2 pushVec = new Vector2(pushDirection * pushSpeed * Time.deltaTime, 0);
            _rigidbody.MovePosition(_rigidbody.position + pushVec);
        }
    }
}
