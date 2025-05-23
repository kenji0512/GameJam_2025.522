using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("タイマー設定")]
    public float _timeLimit = 60f;
    public float _RemainingTime;

    [Header("ゲーム状態フラグ")]
    private bool _isGameOver = false;

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
        // タイトルシーンに移動
        SceneManager.LoadScene("GameOver");
    }

    public void StageClear()
    {
        _isGameOver = true;
        ClearTime = _timeLimit - _RemainingTime;
        Debug.Log($"Stage Clear! クリアタイム: {ClearTime:F2} 秒");
        SceneManager.LoadScene("GameCrear");
        // 次のステージへ or リザルト表示など
    }
}
