using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float _moveSpeed = 5f;

    [Header("プレイヤー設定")]
    [SerializeField] private PlayerType _playerType;

    private Rigidbody2D _rigidbody;
    public Transform interactPoint;
    public float interactRange = 1f;
    public LayerMask interactLayer;

    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode actionKey;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        switch (_playerType)
        {
            case PlayerType.Player1:
                leftKey = KeyCode.A;
                rightKey = KeyCode.D;
                actionKey = KeyCode.LeftShift;
                break;

            case PlayerType.Player2:
                leftKey = KeyCode.LeftArrow;
                rightKey = KeyCode.RightArrow;
                actionKey = KeyCode.RightShift;
                break;

            default:
                Debug.LogWarning("このゲームでは Player1 と Player2 のみ対応しています。");
                break;
        }
    }

    private void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(leftKey))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(rightKey))
        {
            moveInput = 1f;
        }

        _rigidbody.velocity = new Vector2(moveInput * _moveSpeed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(actionKey))
        {
            Debug.Log(_playerType + "アクション");
            TryInteract();
        }
    }

    private void TryInteract()
    {
        //Collider2D[] hits = Physics2D.OverlapCircleAll(interactPoint.position, interactRange, interactLayer);
        //foreach (var hit in hits)
        //{
        //    ISwitchable switchable = hit.GetComponent<ISwitchable>();
        //    if (switchable != null)
        //    {
        //        switchable.OnInteract();
        //        break;
        //    }
        //}
    }

    private void OnDrawGizmosSelected()
    {
        if (interactPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(interactPoint.position, interactRange);
        }
    }
}
