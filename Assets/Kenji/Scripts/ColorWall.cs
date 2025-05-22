using UnityEngine;

public class ColorWall : MonoBehaviour
{
    // �ʂ��v���C���[�^�C�v��Inspector�Őݒ�
    [SerializeField] private PlayerType _passablePlayerType;

    private Collider2D _wallCollider;

    private void Awake()
    {
        _wallCollider = GetComponent<Collider2D>();
        if (_wallCollider == null)
        {
            Debug.LogError("���̃I�u�W�F�N�g��Collider2D������܂���I");
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
                    Debug.Log("Player1���ʉ߂ł��܂�");
                    Physics2D.IgnoreCollision(collision.collider, _wallCollider, true);
                }
                else
                {
                    Debug.Log("Player1�͂��̕ǂ�ʉ߂ł��܂���");
                }
                break;

            case PlayerType.Player2:
                if (_passablePlayerType == PlayerType.Player2)
                {
                    Debug.Log("Player2���ʉ߂ł��܂�");
                    Physics2D.IgnoreCollision(collision.collider, _wallCollider, true);
                }
                else
                {
                    Debug.Log("Player2�͂��̕ǂ�ʉ߂ł��܂���");
                }
                break;

            default:
                Debug.LogWarning("���Ή���PlayerType�ł�");
                break;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();

        if (player != null)
        {
            // �Փˉ������ɃR���W�����߂��i�ʂꂽ�v���C���[�̂ݑΏہj
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
