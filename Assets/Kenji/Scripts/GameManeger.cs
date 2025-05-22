using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("�^�C�}�[�ݒ�")]
    public float _timeLimit = 60f;
    public float RemainingTime;
    //public Text _timerText; // UI �e�L�X�g�\���p�iUnityEngine.UI�j

    [Header("�Q�[����ԃt���O")]
    private bool isGameOver = false;

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
        RemainingTime -= Time.deltaTime;
        //_timerText.text = Mathf.CeilToInt(_currentTime).ToString();

        if (RemainingTime <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        RemainingTime = _timeLimit;
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        // �^�C�g���V�[���Ɉړ�
        SceneManager.LoadScene("Start");
    }

    public void StageClear()
    {
        isGameOver = true;
        Debug.Log("Stage Clear!");
        SceneManager.LoadScene("GameCrear");
        // ���̃X�e�[�W�� or ���U���g�\���Ȃ�
    }
}
