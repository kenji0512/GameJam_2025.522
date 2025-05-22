using UnityEngine;

public class ColorWall : MonoBehaviour
{
    // 通れるプレイヤータイプをInspectorで設定
    [SerializeField] private PlayerType _passablePlayerType;

    private Collider2D _wallCollider;

    private void Awake()
    {
        _wallCollider = GetComponent<Collider2D>();
        if (_wallCollider == null)
        {
            Debug.LogError("このオブジェクトにCollider2Dがありません！");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
        if (player == null) return;

        switch (player._playerType)
        {
            case PlayerType.Player1:
                if (_passablePlayerType == PlayerType.Player1)
                {
                    Debug.Log("Player1が通過できます");
                    Physics2D.IgnoreCollision(collision.collider, _wallCollider, true);
                }
                else
                {
                    Debug.Log("Player1はこの壁を通過できません");
                }
                break;

            case PlayerType.Player2:
                if (_passablePlayerType == PlayerType.Player2)
                {
                    Debug.Log("Player2が通過できます");
                    Physics2D.IgnoreCollision(collision.collider, _wallCollider, true);
                }
                else
                {
                    Debug.Log("Player2はこの壁を通過できません");
                }
                break;

            default:
                Debug.LogWarning("未対応のPlayerTypeです");
                break;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();

        if (player != null)
        {
            // 衝突解除時にコリジョン戻す（通れたプレイヤーのみ対象）
            if (player._playerType == PlayerType.Player1 && _passablePlayerType == PlayerType.Player1)
            {
                Physics2D.IgnoreCollision(collision.collider, _wallCollider, false);
            }
            else if (player._playerType == PlayerType.Player2 && _passablePlayerType == PlayerType.Player2)
            {
                Physics2D.IgnoreCollision(collision.collider, _wallCollider, false);
            }
        }
    }
}
