using UnityEngine;

public class SceneTake : MonoBehaviour
{
    public static SceneTake Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��I�u�W�F�N�g��ێ�
        }
        else
        {
            Destroy(gameObject); // ���łɑ��݂���ꍇ�͍폜�i�d��������h���j
        }
    }
}
