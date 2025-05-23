using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("�^�C�}�[�ݒ�")]
    public float _timeLimit = 60f;
    public float _RemainingTime;

    [Header("�Q�[����ԃt���O")]
    private bool _isGameOver = false;

    public float ClearTime { get; private set; }
    public float ElapsedTime { get; private set; }


    private void Awake()
    {
        // �V���O���g���p�^�[��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateTimer()
    {
        if (_isGameOver) return;

        _RemainingTime -= Time.deltaTime;
        ElapsedTime += Time.deltaTime;

        if (_RemainingTime <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        _RemainingTime = _timeLimit;
        _isGameOver = false;
        ClearTime = 0f;
        ElapsedTime = 0f;

    }

    public void GameOver()
    {
        _isGameOver = true;
        Debug.Log("Game Over!");
        // �^�C�g���V�[���Ɉړ�
        SceneManager.LoadScene("GameOver");
    }

    public void StageClear()
    {
        _isGameOver = true;
        ClearTime = _timeLimit - _RemainingTime;
        Debug.Log($"Stage Clear! �N���A�^�C��: {ClearTime:F2} �b");
        SceneManager.LoadScene("GameCrear");
        // ���̃X�e�[�W�� or ���U���g�\���Ȃ�
    }
}
