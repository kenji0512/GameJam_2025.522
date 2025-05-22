using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // [SerializeField] private GameManager gameManager;
    GameManager _gameManager;
    Text _timerText;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        _timerText = GetComponent<Text>();
        if ( _timerText == null)
        {
            Debug.Log("Text‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }
    }
    private void Update()
    {
        if ( _timerText != null )
        {
            return;
        }
        _timerText.text = string.Format("{0:D2}:{1:D2}",
            (int)_gameManager.RemainingTime % 60,
            (int)(_gameManager.RemainingTime * 100) % 60
            );
    }
}
