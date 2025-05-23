using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("タイマー設定")]
    public float _timeLimit = 60f;
    public float RemainingTime;
    //public Text _timerText; // UI テキスト表示用（UnityEngine.UI）

    [Header("ゲーム状態フラグ")]
    private bool isGameOver = false;

    public float ClearTime { get; private set; }
    public float ElapsedTime { get; private set; }


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
    public void UpdateTimer()
    {
        if (isGameOver) return;

        RemainingTime -= Time.deltaTime;
        ElapsedTime += Time.deltaTime;

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
        ClearTime = 0f;
        ElapsedTime = 0f;

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
        ClearTime = _timeLimit - RemainingTime;
        Debug.Log($"Stage Clear! クリアタイム: {ClearTime:F2} 秒");
        SceneManager.LoadScene("GameCrear");
        // 次のステージへ or リザルト表示など
    }
}
