using UnityEngine;

public class GimmicSwitch : MonoBehaviour
{
    [Header("動作対象のプレイヤータグ")]
    [SerializeField] private string[] _targetTags; // PlayerRed など複数対応可

    [Header("操作対象のギミック")]
    [SerializeField] GameObject _Gimmic_Ground;// 切り替え対象のギミック床
    [SerializeField] GameObject _Normal_Ground;// 切り替え対象のギミック床

    [Header("邪魔な壁（スイッチ中に消す）")]
    [SerializeField] private GameObject _ObstacleWall;            // 非表示にする壁

    private GameObject _spawnedNormalGround;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (IsValidPlayer(col.gameObject.tag))
        {
            ActivateSwitch();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (IsValidPlayer(col.gameObject.tag))
        {
            DeactivateSwitch();
        }
    }
    // タグが有効かどうかをチェック
    private bool IsValidPlayer(string tag)
    {
        foreach (string validTag in _targetTags)
        {
            if (tag == validTag) return true;
        }
        return false;
    }
    // ギミック切り替え
    private void ActivateSwitch()
    {
        if (_Gimmic_Ground != null)
        {
            _Gimmic_Ground.SetActive(false);
        }

        if (_Normal_Ground != null && _spawnedNormalGround == null)
        {
            _spawnedNormalGround = Instantiate(
                _Normal_Ground,
                _Gimmic_Ground.transform.position,
                _Gimmic_Ground.transform.rotation
            );
        }

        if (_ObstacleWall != null)
        {
            _ObstacleWall.SetActive(false); // 壁を非表示
        }
    }
    private void DeactivateSwitch()
    {
        if (_Gimmic_Ground != null)
        {
            _Gimmic_Ground.SetActive(true);
        }

        if (_spawnedNormalGround != null)
        {
            Destroy(_spawnedNormalGround);
            _spawnedNormalGround = null;
        }

        if (_ObstacleWall != null)
        {
            _ObstacleWall.SetActive(true); // 壁を再表示
        }
    }
}
