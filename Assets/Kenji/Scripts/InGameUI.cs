using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Text elapsedTimeText;

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            float time = GameManager.Instance.ElapsedTime;
            elapsedTimeText.text = $"経過時間: {time:F2}";
        }
    }
}
