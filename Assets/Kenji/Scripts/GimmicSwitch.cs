using UnityEngine;

public class GimmicSwitch : MonoBehaviour
{
    [Header("����Ώۂ̃v���C���[�^�O")]
    [SerializeField] private string[] _targetTags; // PlayerRed �ȂǕ����Ή���

    [Header("����Ώۂ̃M�~�b�N")]
    [SerializeField] GameObject _Gimmic_Ground;// �؂�ւ��Ώۂ̃M�~�b�N��
    [SerializeField] GameObject _Normal_Ground;// �؂�ւ��Ώۂ̃M�~�b�N��

    [Header("�ז��ȕǁi�X�C�b�`���ɏ����j")]
    [SerializeField] private GameObject _ObstacleWall;            // ��\���ɂ����

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
    // �^�O���L�����ǂ������`�F�b�N
    private bool IsValidPlayer(string tag)
    {
        foreach (string validTag in _targetTags)
        {
            if (tag == validTag) return true;
        }
        return false;
    }
    // �M�~�b�N�؂�ւ�
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
            _ObstacleWall.SetActive(false); // �ǂ��\��
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
            _ObstacleWall.SetActive(true); // �ǂ��ĕ\��
        }
    }
}
