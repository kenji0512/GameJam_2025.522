using UnityEngine;

public class GoalArea : MonoBehaviour
{
    private int _playersInGoal = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerRed") || other.CompareTag("PlayerBlue"))
        {
            _playersInGoal++;

            if (_playersInGoal >= 2)
            {
                GameManager.Instance.StageClear();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerRed") || other.CompareTag("PlayerBlue"))
        {
            _playersInGoal--;
        }
    }
}
