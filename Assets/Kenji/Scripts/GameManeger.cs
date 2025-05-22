using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("タイマー設定")]
    public float _timeLimit = 60f;
    private float _currentTime;
    //public Text _timerText; // UI テキスト表示用（UnityEngine.UI）

    [Header("ゲーム状態フラグ")]
    private bool isGameOver = false;

    private void Awake()
    {
        // シングルトンパターン
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

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (isGameOver) return;

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _currentTime -= Time.deltaTime;
        //_timerText.text = Mathf.CeilToInt(_currentTime).ToString();

        if (_currentTime <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        _currentTime = _timeLimit;
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        // タイトルシーンに移動
        SceneManager.LoadScene("Start");
    }

    public void StageClear()
    {
        isGameOver = true;
        Debug.Log("Stage Clear!");
        SceneManager.LoadScene("GameCrear");
        // 次のステージへ or リザルト表示など
    }
}
