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
            clearTimeText.text = $"�N���A�^�C��: {clearTime:F2} �b";
        }
    }
}
