using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private Text clearTimeText;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            float clearTime = GameManager.Instance.ClearTime;
            clearTimeText.text = $"クリアタイム: {clearTime:F2} 秒";
        }
    }
}
