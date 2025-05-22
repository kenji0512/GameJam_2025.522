using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // [SerializeField] private GameManager gameManager;
    public Text m_textTimer;
    public GameTimer m_gameTimer;
    private void Update()
    {
        m_textTimer.text = string.Format("{0:D2}:{1:D2}",
            (int)m_gameTimer.CurrentTime % 60,
            (int)(m_gameTimer.CurrentTime * 100) % 60
            );
    }
}
